Option Explicit On
Imports System.Math

Friend Module TillageOps
    Public Const maxTools As Integer = 85
    Private Tillage_Factor() As Double
    Private tillageOperationsTable(maxTools, 3) As Object

    Public Class TillageClass
        Inherits FieldOperationsBaseClass

        Public Sub New(ByVal totalLayers As Integer)
            MyBase.New()
            ReDim Tillage_Factor(totalLayers)
        End Sub

        Public Sub AddTillageOperation(ByVal year As Integer, ByVal day As Integer, ByVal toolName As String, ByVal toolDepth As Double, ByVal toolSDR As Integer, ByVal toolME As Double)
            'Precondition:  none
            'Postcondition: adds to sorted operations in operations list

            If year <> Nothing And day <> Nothing And day <= 365 And toolName.Trim <> Nothing Then 'And toolDepth <> Nothing And toolSDR <> Nothing And toolME <> Nothing Then
                If year > 0 And day > 0 And day <= 365 And toolName.Trim <> Nothing And toolDepth >= 0 And toolSDR >= 0 And toolME >= 0 Then
                    Call Me.AddOperation(year, day, toolName, toolDepth, toolSDR, toolME)
                End If
            End If
        End Sub

        'active field operations parameters
        Public ReadOnly Property opToolName() As String
            Get
                Return Me.opList.Data(2)
            End Get
        End Property
        Public ReadOnly Property opDepth() As Double
            Get
                Return Me.opList.Data(3)
            End Get
        End Property
        Public ReadOnly Property opSDR() As Double
            Get
                Return Me.opList.Data(4)
            End Get
        End Property
        Public ReadOnly Property opMixingEfficiency() As Double
            Get
                Return Me.opList.Data(5)
            End Get
        End Property

        Public Sub ExecuteTillage(ByVal y As Integer, ByRef abgdBiomassInput(,) As Double, ByVal Tillage As TillageClass, ByRef Soil As SoilClass, ByRef Residue As ResidueClass)
            'Precondition:  tillage operation exists
            '               passed arrays are not empty
            '               passed classes have been initialized
            '               0 < y <= totalYears
            'Postcondition: Tillage performed on the soil profile as described by the tillage parameters

            Const mixVariables As Integer = 17
            Dim lastLayer As Integer = Soil.totalLayers
            Dim conc(Soil.totalLayers, mixVariables) As Double
            Dim mixed(mixVariables) As Double

            Dim toolDepth, _
                soilMass(Soil.totalLayers), _
                soilMassNotMixed(Soil.totalLayers), _
                soilMassMixed(Soil.totalLayers), _
                totalSoilMassMixed, _
                partialSoilMassMixed As Double                      ' Mg/m3

            Dim SOCConc(Soil.totalLayers), _
                SONConc(Soil.totalLayers), _
                NO3Conc(Soil.totalLayers), _
                NH4Conc(Soil.totalLayers) As Double

            Dim incorporatedResidueBiomass, _
                incorporatedResidueN, _
                incorporatedManureC, _
                incorporatedManureN As Double

            Dim mixedFraction As Double                             ' fraction of soil layer mixed
            Dim flattenedFraction As Double                         ' fraction of the standing residues that are flattened

            'flatten standing residues
            flattenedFraction = Tillage.opMixingEfficiency ^ 0.5
            Residue.flatResidueMass += flattenedFraction * Residue.stanResidueMass
            Residue.stanResidueMass *= (1 - flattenedFraction)
            Residue.flatResidueN += flattenedFraction * Residue.stanResidueN
            Residue.stanResidueN *= (1 - flattenedFraction)
            Residue.flatResidueWater += flattenedFraction * Residue.stanResidueWater
            Residue.stanResidueWater *= (1 - flattenedFraction)

            'set tillage depth
            If Tillage.opMixingEfficiency = 0 Or Tillage.opDepth = 0 Then
                Return
            ElseIf Soil.cumulativeDepth(Soil.totalLayers) >= Tillage.opDepth Then
                toolDepth = Tillage.opDepth
            Else
                toolDepth = Soil.cumulativeDepth(Soil.totalLayers)
            End If

            'add water mixing, microbial biomass

            'start soil mixing
            For i As Integer = 1 To Soil.totalLayers
                If Soil.cumulativeDepth(i - 1) >= toolDepth Then Exit For

                soilMass(i) = Soil.BD(i) * Soil.layerThickness(i) * 10000          'mass in Mg C ha-1

                conc(i, 1) = Soil.Clay(i)
                conc(i, 2) = Soil.SOC_Conc(i)
                conc(i, 3) = Soil.SON_Mass(i) / soilMass(i)
                conc(i, 4) = Residue.residueAbgd(i) / soilMass(i)
                conc(i, 5) = Residue.residueRt(i) / soilMass(i)
                conc(i, 6) = Residue.residueRz(i) / soilMass(i)
                conc(i, 7) = Residue.residueAbgdN(i) / soilMass(i)
                conc(i, 8) = Residue.residueRtN(i) / soilMass(i)
                conc(i, 9) = Residue.residueRzN(i) / soilMass(i)
                conc(i, 10) = Residue.manureC(i) / soilMass(i)
                conc(i, 11) = Residue.manureN(i) / soilMass(i)
                conc(i, 12) = Soil.NO3(i) / soilMass(i)
                conc(i, 13) = Soil.NH4(i) / soilMass(i)
                conc(i, 14) = Soil.MBC_Mass(i) / soilMass(i)
                conc(i, 15) = Soil.MBN_Mass(i) / soilMass(i)
                conc(i, 16) = Soil.waterContent(i) * Soil.layerThickness(i) / soilMass(i)
                conc(i, 17) = Soil.Sand(i)

                lastLayer = i
            Next

            For i As Integer = 1 To lastLayer
                If toolDepth >= Soil.cumulativeDepth(i) Then
                    soilMassMixed(i) = Tillage.opMixingEfficiency * soilMass(i)
                Else
                    soilMassMixed(i) = Tillage.opMixingEfficiency * soilMass(i) * (toolDepth - Soil.cumulativeDepth(i - 1)) / Soil.layerThickness(i)
                End If

                soilMassNotMixed(i) = soilMass(i) - soilMassMixed(i)
                partialSoilMassMixed = totalSoilMassMixed + soilMassMixed(i)

                For j As Integer = 1 To mixVariables '(a * b + c * d) / e
                    mixed(j) = Fraction(totalSoilMassMixed, mixed(j), soilMassMixed(i), conc(i, j), partialSoilMassMixed)
                Next

                totalSoilMassMixed = partialSoilMassMixed
            Next

            'Redistribute mixed material re-computing state variables while preserving the layer bulk density 
            For i As Integer = 1 To lastLayer
                Soil.Clay(i) = Fraction(conc(i, 1), soilMassNotMixed(i), mixed(1), soilMassMixed(i), soilMass(i))
                Soil.SOC_Conc(i) = Fraction(conc(i, 2), soilMassNotMixed(i), mixed(2), soilMassMixed(i), soilMass(i))
                Soil.SON_Mass(i) = soilMass(i) * Fraction(conc(i, 3), soilMassNotMixed(i), mixed(3), soilMassMixed(i), soilMass(i))
                Residue.residueAbgd(i) = soilMass(i) * Fraction(conc(i, 4), soilMassNotMixed(i), mixed(4), soilMassMixed(i), soilMass(i))
                Residue.residueRt(i) = soilMass(i) * Fraction(conc(i, 5), soilMassNotMixed(i), mixed(5), soilMassMixed(i), soilMass(i))
                Residue.residueRz(i) = soilMass(i) * Fraction(conc(i, 6), soilMassNotMixed(i), mixed(6), soilMassMixed(i), soilMass(i))
                Residue.residueAbgdN(i) = soilMass(i) * Fraction(conc(i, 7), soilMassNotMixed(i), mixed(7), soilMassMixed(i), soilMass(i))
                Residue.residueRtN(i) = soilMass(i) * Fraction(conc(i, 8), soilMassNotMixed(i), mixed(8), soilMassMixed(i), soilMass(i))
                Residue.residueRzN(i) = soilMass(i) * Fraction(conc(i, 9), soilMassNotMixed(i), mixed(9), soilMassMixed(i), soilMass(i))
                Residue.manureC(i) = soilMass(i) * Fraction(conc(i, 10), soilMassNotMixed(i), mixed(10), soilMassMixed(i), soilMass(i))
                Residue.manureN(i) = soilMass(i) * Fraction(conc(i, 11), soilMassNotMixed(i), mixed(11), soilMassMixed(i), soilMass(i))
                Soil.NO3(i) = soilMass(i) * Fraction(conc(i, 12), soilMassNotMixed(i), mixed(12), soilMassMixed(i), soilMass(i))
                Soil.NH4(i) = soilMass(i) * Fraction(conc(i, 13), soilMassNotMixed(i), mixed(13), soilMassMixed(i), soilMass(i))
                Soil.MBC_Mass(i) = soilMass(i) * Fraction(conc(i, 14), soilMassNotMixed(i), mixed(14), soilMassMixed(i), soilMass(i))
                Soil.MBN_Mass(i) = soilMass(i) * Fraction(conc(i, 15), soilMassNotMixed(i), mixed(15), soilMassMixed(i), soilMass(i))
                Soil.waterContent(i) = soilMass(i) / Soil.layerThickness(i) * Fraction(conc(i, 16), soilMassNotMixed(i), mixed(16), soilMassMixed(i), soilMass(i))
                Soil.Sand(i) = Fraction(conc(i, 17), soilMassNotMixed(i), mixed(17), soilMassMixed(i), soilMass(i))

                Soil.SOC_Mass(i) = Soil.SOC_Conc(i) / 1000 * soilMass(i)   'mass in Mg/ha
            Next

            'Remove residue from the surface and incorporate within each layer
            incorporatedResidueBiomass = (Residue.stanResidueMass + Residue.flatResidueMass) * Tillage.opMixingEfficiency
            incorporatedResidueN = (Residue.stanResidueN + Residue.flatResidueN) * Tillage.opMixingEfficiency
            incorporatedManureC = Residue.manureSurfaceC * Tillage.opMixingEfficiency
            incorporatedManureN = Residue.manureSurfaceN * Tillage.opMixingEfficiency

            'Distribute among soil layers
            For i As Integer = 1 To lastLayer
                If toolDepth >= Soil.cumulativeDepth(i) Then
                    mixedFraction = Soil.layerThickness(i) / toolDepth
                Else
                    mixedFraction = (toolDepth - Soil.cumulativeDepth(i - 1)) / toolDepth
                End If

                Residue.residueAbgd(i) += incorporatedResidueBiomass * mixedFraction
                Residue.residueAbgdN(i) += incorporatedResidueN * mixedFraction
                Residue.manureC(i) += incorporatedManureC * mixedFraction
                Residue.manureN(i) += incorporatedManureN * mixedFraction
                abgdBiomassInput(y, i) += incorporatedResidueBiomass * mixedFraction
            Next

            'Update surface pools
            Residue.flatResidueMass *= (1 - Tillage.opMixingEfficiency)
            Residue.stanResidueMass *= (1 - Tillage.opMixingEfficiency)
            Residue.flatResidueN *= (1 - Tillage.opMixingEfficiency)
            Residue.stanResidueN *= (1 - Tillage.opMixingEfficiency)
            Residue.manureSurfaceC *= (1 - Tillage.opMixingEfficiency)
            Residue.manureSurfaceN *= (1 - Tillage.opMixingEfficiency)
            Residue.flatResidueWater *= (1 - Tillage.opMixingEfficiency)
            Residue.stanResidueWater *= (1 - Tillage.opMixingEfficiency)

            Call ComputeTillageFactor(Soil, Soil.cumulativeDepth, toolDepth, Tillage.opSDR)
        End Sub

        Public Sub TillageFactorSettling(ByVal totalLayers As Integer, ByVal waterContent() As Double, ByVal Porosity() As Double)
            For i As Integer = 1 To totalLayers
                Tillage_Factor(i) *= (1.0# - 0.02 * waterContent(i) / Porosity(i))
            Next
        End Sub

        Private Function Fraction(ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal d As Double, ByVal f As Double) As Double
            Return (a * b + c * d) / f
        End Function

        Private Sub ComputeTillageFactor(ByRef Soil As SoilClass, ByRef soilLayerBottom() As Double, ByRef toolDepth As Double, ByVal TSDR As Double)
            'Precondition:  clay is expressed fractionally
            '               0 < toolDepth <= soilDepth
            '               0 < TSDR
            '               Passed arrays are not empty
            '               Passed classes have been initialized
            'Postcondition: Multiplier for soil decomposition rate based on tillage intensity and soil type is returned
            '               SDR is the sum for the year of NRCS' Soil Disturbance Rating

            Const k1 As Double = 5.5                                ' empirical constant
            Const k2 As Double = 0.05 '0.075                        ' empirical constant

            Dim SDR, _
                 SDR1, _
                 SDR2, _
                 FX, _
                 DFX, _
                 textureFactor, _
                 TF1, _
                 XX As Double

            For i As Integer = 1 To Soil.totalLayers
                textureFactor = ComputeTextureFactor(Soil.Clay(i))
                TF1 = Tillage_Factor(i) / textureFactor

                If TF1 > 0.01 Then
                    SDR1 = 35                                       ' iteration starting value
                    SDR2 = 0

                    Do While Abs((SDR1 - SDR2) / SDR1) > 0.05
                        SDR2 = SDR1
                        XX = Exp(k1 - k2 * SDR1)
                        FX = SDR1 / (SDR1 + XX) - TF1
                        DFX = (1 + k2 * SDR1) * XX / ((SDR1 + XX) ^ 2)
                        SDR1 = SDR1 - FX / DFX
                    Loop

                    SDR = SDR1
                Else
                    SDR = 1
                End If

                If soilLayerBottom(i) < toolDepth Or soilLayerBottom(i) = toolDepth Then
                    SDR += TSDR
                ElseIf soilLayerBottom(i) > toolDepth And soilLayerBottom(i - 1) < toolDepth Then
                    SDR += TSDR * (toolDepth - soilLayerBottom(i - 1)) / Soil.layerThickness(i)
                End If

                Tillage_Factor(i) = textureFactor * SDR / (SDR + Exp(k1 - k2 * SDR))
            Next
        End Sub

        Private Function ComputeTextureFactor(ByVal Clay As Double) As Double
            ' clay is expressed fractionally
            Const aClay As Integer = 1  ' the maximum (lots of tillage) multiplier in a 100% clay soil is (A_clay + 1)
            Const aSand As Integer = 5  ' the maximum multiplier in 100% sand soil is (A_sand + 1)
            Const kClay As Double = 5.5 ' a curvature factor

            Return aClay + (aSand - aClay) * Exp(-kClay * Clay) ' clay dependent term
        End Function

        Public ReadOnly Property tillageFactor(ByVal layer As Integer) As Double
            Get
                Return Tillage_Factor(layer)
            End Get
        End Property

        'DEBUG ONLY
        Public Sub msgboxOpList()
            Dim line As String = Nothing

            If Not Me.opList.IsEmpty Then
                Call Me.SelectFirstOperation()

                Do Until Me.opYear <= 0
                    line = line & "Year: " & Format(Me.opList.Data(0), "###0") & "   " & _
                                  "Day: " & Format(Me.opList.Data(1), "###0") & "   " & _
                                  "Depth: " & Format(Me.opList.Data(3), "#0.00") & "   " & _
                                  "SDR: " & Format(Me.opList.Data(4), "#0.000") & "   " & _
                                  "ME: " & Format(Me.opList.Data(5), "#0.000") & "   " & _
                                  "Name: " & Me.opList.Data(2) & vbCr
                    SelectNextOperation()
                Loop

                MsgBox(line, MsgBoxStyle.OkOnly, "DEBUG: Tillage")
            End If
        End Sub

    End Class


    'hard coded information
    Public Sub PopulateOperationsTable()
        Dim i As Integer = -1

        i += 1
        tillageOperationsTable(i, 0) = "Bale straw Or Residue"       'Operation Name   
        tillageOperationsTable(i, 1) = 3                             'Soil Disturbance Rating
        tillageOperationsTable(i, 2) = 0                             'Mixing Efficiency 
        tillageOperationsTable(i, 3) = 0.01                          'Depth (Default Value)
        i += 1
        tillageOperationsTable(i, 0) = "Bed shaper"
        tillageOperationsTable(i, 1) = 7
        tillageOperationsTable(i, 2) = 0.071554
        tillageOperationsTable(i, 3) = 0.05
        i += 1
        tillageOperationsTable(i, 0) = "Bedder, hipper, disk hiller"
        tillageOperationsTable(i, 1) = 29
        tillageOperationsTable(i, 2) = 0.8
        tillageOperationsTable(i, 3) = 0.15
        i += 1
        tillageOperationsTable(i, 0) = "Bulldozer, clearing"
        tillageOperationsTable(i, 1) = 30
        tillageOperationsTable(i, 2) = 0.8
        tillageOperationsTable(i, 3) = 0.3
        i += 1
        tillageOperationsTable(i, 0) = "Burn residue, high intensity"
        tillageOperationsTable(i, 1) = 0
        tillageOperationsTable(i, 2) = 0.01
        tillageOperationsTable(i, 3) = 0.01
        i += 1
        tillageOperationsTable(i, 0) = "Burn residue, low intensity"
        tillageOperationsTable(i, 1) = 0
        tillageOperationsTable(i, 2) = 0.01
        tillageOperationsTable(i, 3) = 0.01
        i += 1
        tillageOperationsTable(i, 0) = "Chisel, st. pt."
        tillageOperationsTable(i, 1) = 19
        tillageOperationsTable(i, 2) = 0.265919
        tillageOperationsTable(i, 3) = 0.25
        i += 1
        tillageOperationsTable(i, 0) = "Chisel, sweep shovel"
        tillageOperationsTable(i, 1) = 21
        tillageOperationsTable(i, 2) = 0.265919
        tillageOperationsTable(i, 3) = 0.2
        i += 1
        tillageOperationsTable(i, 0) = "Chisel, twisted shovel"
        tillageOperationsTable(i, 1) = 24
        tillageOperationsTable(i, 2) = 0.447042
        tillageOperationsTable(i, 3) = 0.2
        i += 1
        tillageOperationsTable(i, 0) = "Cultipacker , Roller"
        tillageOperationsTable(i, 1) = 19
        tillageOperationsTable(i, 2) = 0.265919
        tillageOperationsTable(i, 3) = 0.05
        i += 1
        tillageOperationsTable(i, 0) = "Cultivator, field 6-12 in sweeps"
        tillageOperationsTable(i, 1) = 20
        tillageOperationsTable(i, 2) = 0.202386
        tillageOperationsTable(i, 3) = 0.12
        i += 1
        tillageOperationsTable(i, 0) = "Cultivator, field w/ spike points"
        tillageOperationsTable(i, 1) = 18
        tillageOperationsTable(i, 2) = 0.371806
        tillageOperationsTable(i, 3) = 0.12
        i += 1
        tillageOperationsTable(i, 0) = "Cultivator, hipper, disk hiller on beds"
        tillageOperationsTable(i, 1) = 23
        tillageOperationsTable(i, 2) = 0.572433
        tillageOperationsTable(i, 3) = 0.12
        i += 1
        tillageOperationsTable(i, 0) = "Cultivator, off bar w/disk hillers on beds"
        tillageOperationsTable(i, 1) = 13
        tillageOperationsTable(i, 2) = 0.308274
        tillageOperationsTable(i, 3) = 0.12
        i += 1
        tillageOperationsTable(i, 0) = "Disk, offset, heavy"
        tillageOperationsTable(i, 1) = 27
        tillageOperationsTable(i, 2) = 0.657771
        tillageOperationsTable(i, 3) = 0.15
        i += 1
        tillageOperationsTable(i, 0) = "Disk, offset, heavy >12 in depth"
        tillageOperationsTable(i, 1) = 28
        tillageOperationsTable(i, 2) = 0.8
        tillageOperationsTable(i, 3) = 0.3
        i += 1
        tillageOperationsTable(i, 0) = "Disk, tandem heavy primary op."
        tillageOperationsTable(i, 1) = 26
        tillageOperationsTable(i, 2) = 0.657771
        tillageOperationsTable(i, 3) = 0.2
        i += 1
        tillageOperationsTable(i, 0) = "Disk, tandem secondary op."
        tillageOperationsTable(i, 1) = 18
        tillageOperationsTable(i, 2) = 0.265919
        tillageOperationsTable(i, 3) = 0.1
        i += 1
        tillageOperationsTable(i, 0) = "Drill or air seeder double disk openers 7-10 in spac."
        tillageOperationsTable(i, 1) = 6
        tillageOperationsTable(i, 2) = 0.071554
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Drill or air seeder, hoe opener in hvy residue"
        tillageOperationsTable(i, 1) = 16
        tillageOperationsTable(i, 2) = 0.497198
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Drill or air seeder, hoe/chisel openers 6-12 in spac."
        tillageOperationsTable(i, 1) = 17
        tillageOperationsTable(i, 2) = 0.639427
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Drill or airseeder, double disk"
        tillageOperationsTable(i, 1) = 17
        tillageOperationsTable(i, 2) = 0.497198
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Drill or airseeder, double disk opener, w/ fert openers"
        tillageOperationsTable(i, 1) = 23
        tillageOperationsTable(i, 2) = 0.639427
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Drill or airseeder, double disk, w/ fluted coulters"
        tillageOperationsTable(i, 1) = 18
        tillageOperationsTable(i, 2) = 0.639427
        tillageOperationsTable(i, 3) = 0.09
        i += 1
        tillageOperationsTable(i, 0) = "Drill or airseeder, offset double disk openers"
        tillageOperationsTable(i, 1) = 8
        tillageOperationsTable(i, 2) = 0.259212
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Drill, air seeder, sweep or band opener"
        tillageOperationsTable(i, 1) = 22
        tillageOperationsTable(i, 2) = 0.497198
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Drill, deep / semi-deep furrow  12 to 18 in spacing"
        tillageOperationsTable(i, 1) = 17
        tillageOperationsTable(i, 2) = 0.497198
        tillageOperationsTable(i, 3) = 0.12
        i += 1
        tillageOperationsTable(i, 0) = "Drill, heavy, direct seed, dbl disk opnr"
        tillageOperationsTable(i, 1) = 23
        tillageOperationsTable(i, 2) = 0.639427
        tillageOperationsTable(i, 3) = 0.1
        i += 1
        tillageOperationsTable(i, 0) = "Fert applic. anhyd knife 12 in"
        tillageOperationsTable(i, 1) = 13
        tillageOperationsTable(i, 2) = 0.265919
        tillageOperationsTable(i, 3) = 0.12
        i += 1
        tillageOperationsTable(i, 0) = "Fert applic. deep plcmt hvy shnk"
        tillageOperationsTable(i, 1) = 16
        tillageOperationsTable(i, 2) = 0.371806
        tillageOperationsTable(i, 3) = 0.15
        i += 1
        tillageOperationsTable(i, 0) = "Fert applic. surface broadcast"
        tillageOperationsTable(i, 1) = 5
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.005
        i += 1
        tillageOperationsTable(i, 0) = "Fert. applic. anhyd knife 30 in"
        tillageOperationsTable(i, 1) = 8
        tillageOperationsTable(i, 2) = 0.120616
        tillageOperationsTable(i, 3) = 0.12
        i += 1
        tillageOperationsTable(i, 0) = "Fert. applic., strip-till 30 in"
        tillageOperationsTable(i, 1) = 13
        tillageOperationsTable(i, 2) = 0.265919
        tillageOperationsTable(i, 3) = 0.12
        i += 1
        tillageOperationsTable(i, 1) = i
        tillageOperationsTable(i, 0) = "Furrow diker"
        tillageOperationsTable(i, 1) = 15
        tillageOperationsTable(i, 2) = 0.265919
        tillageOperationsTable(i, 3) = 0.15
        i += 1
        tillageOperationsTable(i, 0) = "Furrow shaper, torpedo"
        tillageOperationsTable(i, 1) = 7
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.1
        i += 1
        tillageOperationsTable(i, 0) = "Graze, continuous"
        tillageOperationsTable(i, 1) = 4
        tillageOperationsTable(i, 2) = 0.026833
        tillageOperationsTable(i, 3) = 0.02
        i += 1
        tillageOperationsTable(i, 0) = "Graze, rotational"
        tillageOperationsTable(i, 1) = 4
        tillageOperationsTable(i, 2) = 0.026833
        tillageOperationsTable(i, 3) = 0.02
        i += 1
        tillageOperationsTable(i, 0) = "Graze, stubble Or Residue"
        tillageOperationsTable(i, 1) = 4
        tillageOperationsTable(i, 2) = 0.026833
        tillageOperationsTable(i, 3) = 0.03
        i += 1
        tillageOperationsTable(i, 0) = "Harrow, coiled tine"
        tillageOperationsTable(i, 1) = 11
        tillageOperationsTable(i, 2) = 0.120616
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Harrow, heavy or rotary"
        tillageOperationsTable(i, 1) = 15
        tillageOperationsTable(i, 2) = 0.265919
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Harrow, spike tooth"
        tillageOperationsTable(i, 1) = 10
        tillageOperationsTable(i, 2) = 0.075895
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Harrow, tine, on beds"
        tillageOperationsTable(i, 1) = 11
        tillageOperationsTable(i, 2) = 0.120616
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Harvest, corn silage or forage sorghum"
        tillageOperationsTable(i, 1) = 5
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.02
        i += 1
        tillageOperationsTable(i, 0) = "Harvest, cotton"
        tillageOperationsTable(i, 1) = 5
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.02
        i += 1
        tillageOperationsTable(i, 0) = "Harvest, grain"
        tillageOperationsTable(i, 1) = 5
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.01
        i += 1
        tillageOperationsTable(i, 0) = "Harvest, grass or legume seed"
        tillageOperationsTable(i, 1) = 3
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.01
        i += 1
        tillageOperationsTable(i, 0) = "Harvest, hay"
        tillageOperationsTable(i, 1) = 3
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.01
        i += 1
        tillageOperationsTable(i, 0) = "Harvest, peanut digger"
        tillageOperationsTable(i, 1) = 25
        tillageOperationsTable(i, 2) = 0.8
        tillageOperationsTable(i, 3) = 0.1
        i += 1
        tillageOperationsTable(i, 0) = "Harvest, root crops, digger"
        tillageOperationsTable(i, 1) = 25
        tillageOperationsTable(i, 2) = 0.8
        tillageOperationsTable(i, 3) = 0.2
        i += 1
        tillageOperationsTable(i, 0) = "Harvest, rootcrops, manually"
        tillageOperationsTable(i, 1) = 11
        tillageOperationsTable(i, 2) = 0.202386
        tillageOperationsTable(i, 3) = 0.15
        i += 1
        tillageOperationsTable(i, 0) = "Harvest, sugarcane"
        tillageOperationsTable(i, 1) = 5
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.02
        i += 1
        tillageOperationsTable(i, 0) = "Harvest, tobacco"
        tillageOperationsTable(i, 1) = 1
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.18
        i += 1
        tillageOperationsTable(i, 0) = "Kill Crop"
        tillageOperationsTable(i, 1) = 0
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0
        i += 1
        tillageOperationsTable(i, 0) = "Manure injector"
        tillageOperationsTable(i, 1) = 21
        tillageOperationsTable(i, 2) = 0.447042
        tillageOperationsTable(i, 3) = 0.1
        i += 1
        tillageOperationsTable(i, 0) = "Manure spreader"
        tillageOperationsTable(i, 1) = 5
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.01
        i += 1
        tillageOperationsTable(i, 0) = "Mower, swather, windrower"
        tillageOperationsTable(i, 1) = 3
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.01
        i += 1
        tillageOperationsTable(i, 0) = "Mulch treader"
        tillageOperationsTable(i, 1) = 14
        tillageOperationsTable(i, 2) = 0.371806
        tillageOperationsTable(i, 3) = 0.04
        i += 1
        tillageOperationsTable(i, 0) = "Permeable weed barrier applicator"
        tillageOperationsTable(i, 1) = 9
        tillageOperationsTable(i, 2) = 0.202386
        tillageOperationsTable(i, 3) = 0.04
        i += 1
        tillageOperationsTable(i, 0) = "Planter, double disk opnr"
        tillageOperationsTable(i, 1) = 5
        tillageOperationsTable(i, 2) = 0.071554
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Planter, double disk opnr w/fluted coulter"
        tillageOperationsTable(i, 1) = 5
        tillageOperationsTable(i, 2) = 0.071554
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Planter, double disk opnr, 18 in rows"
        tillageOperationsTable(i, 1) = 7
        tillageOperationsTable(i, 2) = 0.120616
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Planter, in-row subsoiler"
        tillageOperationsTable(i, 1) = 11
        tillageOperationsTable(i, 2) = 0.120616
        tillageOperationsTable(i, 3) = 0.1
        i += 1
        tillageOperationsTable(i, 0) = "Planter, ridge till"
        tillageOperationsTable(i, 1) = 17
        tillageOperationsTable(i, 2) = 0.447042
        tillageOperationsTable(i, 3) = 0.15
        i += 1
        tillageOperationsTable(i, 0) = "Planter, small veg seed"
        tillageOperationsTable(i, 1) = 4
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.02
        i += 1
        tillageOperationsTable(i, 0) = "Planter, strip till"
        tillageOperationsTable(i, 1) = 8
        tillageOperationsTable(i, 2) = 0.120616
        tillageOperationsTable(i, 3) = 0.08
        i += 1
        tillageOperationsTable(i, 0) = "Planter, sugarcane"
        tillageOperationsTable(i, 1) = 6
        tillageOperationsTable(i, 2) = 0.026833
        tillageOperationsTable(i, 3) = 0.05
        i += 1
        tillageOperationsTable(i, 0) = "Planter, transplanter, vegetable"
        tillageOperationsTable(i, 1) = 6
        tillageOperationsTable(i, 2) = 0.026833
        tillageOperationsTable(i, 3) = 0.1
        i += 1
        tillageOperationsTable(i, 0) = "Planting, broadcast seeder"
        tillageOperationsTable(i, 1) = 3
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.01
        i += 1
        tillageOperationsTable(i, 0) = "Plastic mulch, apply"
        tillageOperationsTable(i, 1) = 9
        tillageOperationsTable(i, 2) = 0.202386
        tillageOperationsTable(i, 3) = 0.05
        i += 1
        tillageOperationsTable(i, 0) = "Plastic mulch, remove"
        tillageOperationsTable(i, 1) = 9
        tillageOperationsTable(i, 2) = 0.202386
        tillageOperationsTable(i, 3) = 0.05
        i += 1
        tillageOperationsTable(i, 0) = "Plow, disk"
        tillageOperationsTable(i, 1) = 26
        tillageOperationsTable(i, 2) = 0.657771
        tillageOperationsTable(i, 3) = 0.18
        i += 1
        tillageOperationsTable(i, 0) = "Plow, moldboard"
        tillageOperationsTable(i, 1) = 29
        tillageOperationsTable(i, 2) = 0.8
        tillageOperationsTable(i, 3) = 0.18
        i += 1
        tillageOperationsTable(i, 0) = "Plow, moldboard, conservation"
        tillageOperationsTable(i, 1) = 27
        tillageOperationsTable(i, 2) = 0.657771
        tillageOperationsTable(i, 3) = 0.18
        i += 1
        tillageOperationsTable(i, 0) = "Residue, row cleaner"
        tillageOperationsTable(i, 1) = 12
        tillageOperationsTable(i, 2) = 0.265919
        tillageOperationsTable(i, 3) = 0.02
        i += 1
        tillageOperationsTable(i, 0) = "Rodweeder"
        tillageOperationsTable(i, 1) = 12
        tillageOperationsTable(i, 2) = 0.265919
        tillageOperationsTable(i, 3) = 0.05
        i += 1
        tillageOperationsTable(i, 0) = "Roller, corrugated packer"
        tillageOperationsTable(i, 1) = 1
        tillageOperationsTable(i, 2) = 0.153324
        tillageOperationsTable(i, 3) = 0.02
        i += 1
        tillageOperationsTable(i, 0) = "Roller, Smooth"
        tillageOperationsTable(i, 1) = 4
        tillageOperationsTable(i, 2) = 0.026833
        tillageOperationsTable(i, 3) = 0.02
        i += 1
        tillageOperationsTable(i, 0) = "Rotary hoe"
        tillageOperationsTable(i, 1) = 11
        tillageOperationsTable(i, 2) = 0.071554
        tillageOperationsTable(i, 3) = 0.05
        i += 1
        tillageOperationsTable(i, 0) = "Rototiller"
        tillageOperationsTable(i, 1) = 29
        tillageOperationsTable(i, 2) = 0.8
        tillageOperationsTable(i, 3) = 0.05
        i += 1
        tillageOperationsTable(i, 0) = "Sprayer"
        tillageOperationsTable(i, 1) = 3
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.005
        i += 1
        tillageOperationsTable(i, 0) = "Stalk puller"
        tillageOperationsTable(i, 1) = 6
        tillageOperationsTable(i, 2) = 0.153324
        tillageOperationsTable(i, 3) = 0.18
        i += 1
        tillageOperationsTable(i, 0) = "Striptiller w/middlebuster on beds"
        tillageOperationsTable(i, 1) = 23
        tillageOperationsTable(i, 2) = 0.572433
        tillageOperationsTable(i, 3) = 0.15
        i += 1
        tillageOperationsTable(i, 0) = "Subsoiler"
        tillageOperationsTable(i, 1) = 15
        tillageOperationsTable(i, 2) = 0.120616
        tillageOperationsTable(i, 3) = 0.25
        i += 1
        tillageOperationsTable(i, 0) = "Subsoiler bedder(ripper / hipper)"
        tillageOperationsTable(i, 1) = 29
        tillageOperationsTable(i, 2) = 0.12
        tillageOperationsTable(i, 3) = 0.25
        i += 1
        tillageOperationsTable(i, 0) = "Subsoiler ripper, 24 to 40 in. deep"
        tillageOperationsTable(i, 1) = 16
        tillageOperationsTable(i, 2) = 0.120616
        tillageOperationsTable(i, 3) = 0.25
        i += 1
        tillageOperationsTable(i, 0) = "Sweep plow"
        tillageOperationsTable(i, 1) = 17
        tillageOperationsTable(i, 2) = 0
        tillageOperationsTable(i, 3) = 0.15
    End Sub

    Public ReadOnly Property listToolName(ByVal toolNumber As Integer) As String
        Get
            Return tillageOperationsTable(toolNumber, 0)
        End Get
    End Property
    Public ReadOnly Property listSoilDisturbanceRating(ByVal toolNumber As Integer) As Integer
        Get
            Return tillageOperationsTable(toolNumber, 1)
        End Get
    End Property
    Public ReadOnly Property listMixingEfficiency(ByVal toolNumber As Integer) As Double
        Get
            Return tillageOperationsTable(toolNumber, 2)
        End Get
    End Property
    Public ReadOnly Property listDefaultDepth(ByVal toolNumber As Integer) As Double
        Get
            Return tillageOperationsTable(toolNumber, 3)
        End Get
    End Property

End Module