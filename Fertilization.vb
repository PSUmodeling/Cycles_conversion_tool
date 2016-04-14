Option Explicit On

Friend Module Fertilization
    Public maxFertilizers As Integer = 28
    Private fertList(maxFertilizers, 11) As Object

    Public Class FixedFertilizationClass
        Inherits FieldOperationsBaseClass

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub AddFertilizerOperation(ByVal year As Integer, ByVal day As Integer, ByVal source As String, ByVal mass As Double, _
                                          ByVal form As String, ByVal method As String, ByVal layer As String, ByVal cOrganic As Double, _
                                          ByVal cCharcoal As Double, ByVal nOrganic As Double, ByVal nCharcoal As Double, ByVal NH4 As Double, _
                                          ByVal NO3 As Double, ByVal pOrganic As Double, ByVal pCharcoal As Double, ByVal pInorganic As Double, _
                                          ByVal K As Double, ByVal S As Double)

            'Precondition:  none
            'Postcondition: adds operations to OperationParameters ordered by year/day

            Dim sum As Double

            If year > 0 And day > 0 And day <= 366 And mass > 0 And source.Trim <> Nothing And form.Trim <> Nothing And method.Trim <> Nothing And _
                    cOrganic >= 0 And cCharcoal >= 0 And nOrganic >= 0 And nCharcoal >= 0 And NH4 >= 0 And NO3 >= 0 And pOrganic >= 0 And _
                    pCharcoal >= 0 And pInorganic >= 0 And K >= 0 And S >= 0 Then
                sum = cOrganic + cCharcoal + nOrganic + nCharcoal + NH4 + NO3 + pOrganic + pCharcoal + pInorganic + K + S

                If sum <= 1 Then
                    Call Me.AddOperation(year, day, source, mass / 1000, form, method, layer, cOrganic, cCharcoal, nOrganic, nCharcoal, NH4, NO3, pOrganic, pCharcoal, pInorganic, K, S)
                Else
                    MsgBox("Added fractions must be <= 1:  " & sum, MsgBoxStyle.Exclamation, MainForm.ProductName)
                End If
            Else
                MsgBox("Invalid entries found for the operation occurring in year " & year & " on day " & day & ".", _
                       MsgBoxStyle.Exclamation, MainForm.ProductName & ": Fixed Fertilization")
            End If
        End Sub

        Public ReadOnly Property opSource() As String
            Get
                Return Me.opList.Data(2)
            End Get
        End Property
        Public ReadOnly Property opMass() As Double
            Get
                Return Me.opList.Data(3)
            End Get
        End Property
        Public ReadOnly Property opForm() As String
            Get
                Return Me.opList.Data(4)
            End Get
        End Property
        Public ReadOnly Property opMethod() As String
            Get
                Return Me.opList.Data(5)
            End Get
        End Property
        Public ReadOnly Property opLayer() As Integer
            Get
                Return Me.opList.Data(6)
            End Get
        End Property
        Public ReadOnly Property opC_Organic() As Double
            Get
                Return Me.opList.Data(7)
            End Get
        End Property
        Public ReadOnly Property opC_Charcoal() As Double
            Get
                Return Me.opList.Data(8)
            End Get
        End Property
        Public ReadOnly Property opN_Organic() As Double
            Get
                Return Me.opList.Data(9)
            End Get
        End Property
        Public ReadOnly Property opN_Charcoal() As Double
            Get
                Return Me.opList.Data(10)
            End Get
        End Property
        Public ReadOnly Property opN_NH4() As Double
            Get
                Return Me.opList.Data(11)
            End Get
        End Property
        Public ReadOnly Property opN_NO3() As Double
            Get
                Return Me.opList.Data(12)
            End Get
        End Property
        Public ReadOnly Property opP_Organic() As Double
            Get
                Return Me.opList.Data(13)
            End Get
        End Property
        Public ReadOnly Property opP_Charcoal() As Double
            Get
                Return Me.opList.Data(14)
            End Get
        End Property
        Public ReadOnly Property opP_Inorganic() As Double
            Get
                Return Me.opList.Data(15)
            End Get
        End Property
        Public ReadOnly Property opK() As Double
            Get
                Return Me.opList.Data(16)
            End Get
        End Property
        Public ReadOnly Property opS() As Double
            Get
                Return Me.opList.Data(17)
            End Get
        End Property

        'DEBUG ONLY
        Public Sub msgboxOpList()
            Dim line As String = Nothing

            If Not Me.opList.IsEmpty Then
                Call Me.SelectFirstOperation()

                Do Until Me.opYear <= 0
                    line = line & "Year: " & Format(CDbl(Me.opList.Data(0)), "###0") & "  " & _
                                  "Day: " & Format(CDbl(Me.opList.Data(1)), "###0") & "  " & _
                                  "Source: " & CStr(Me.opList.Data(2)) & "  " & _
                                  "Mass: " & Format(CDbl(Me.opList.Data(3)), "0.00") & "  " & _
                                  "Form: " & CStr(Me.opList.Data(4)) & "  " & _
                                  "Method: " & CStr(Me.opList.Data(5)) & _
                                  "Depth: " & CStr(Me.opList.Data(6)) & _
                                  "C Org: " & Format(CDbl(Me.opList.Data(7)), "0.000") & "  " & _
                                  "C Char: " & Format(CDbl(Me.opList.Data(8)), "0.000") & "  " & _
                                  "N Org: " & Format(CDbl(Me.opList.Data(9)), "0.000") & "  " & _
                                  "N char: " & Format(CDbl(Me.opList.Data(10)), "0.000") & "  " & _
                                  "N NH4: " & Format(CDbl(Me.opList.Data(11)), "0.000") & "  " & _
                                  "N NO3: " & Format(CDbl(Me.opList.Data(12)), "0.000") & "  " & _
                                  "P Org: " & Format(CDbl(Me.opList.Data(13)), "0.000") & "  " & _
                                  "P Char: " & Format(CDbl(Me.opList.Data(14)), "0.000") & "  " & _
                                  "P Inorg: " & Format(CDbl(Me.opList.Data(15)), "0.000") & "  " & _
                                  "K: " & Format(CDbl(Me.opList.Data(16)), "0.000") & "  " & _
                                  "S: " & Format(CDbl(Me.opList.Data(17)), "0.000") & "  " & vbCr
                    SelectNextOperation()
                Loop

                MsgBox(line, MsgBoxStyle.OkOnly, "DEBUG: Fertilization")
            End If
        End Sub

    End Class

    Public Class AutoFertilizationClass

        'Public Sub AddNutrientToTissue(ByVal AbgdDemandCritical As Double, ByVal RootDemandCritical As Double, _
        '                               ByRef AbgdNutrient As Double, ByRef RootNutrient As Double, ByRef NutrientAdded As Double)

        '    AbgdNutrient += AbgdDemandCritical
        '    RootNutrient += RootDemandCritical
        '    NutrientAdded += AbgdDemandCritical + RootDemandCritical
        'End Sub

        'Public Function FindFertilizationAmount(ByVal doy As Integer, ByVal cropNum As Integer, ByRef Crop As CropClass, ByRef Soil As SoilClass) As Double
        '    'Precondition: 
        '    'Postcondition: 

        '    Dim depletionZoneWater, _
        '        tempVal As Double

        '    If cropNum >= 0 And cropNum <= UBound(operationParameters, Rank:=1) Then
        '        If doy >= Me.opStartDay(cropNum) And doy <= Me.opStopDay(cropNum) Then
        '            depletionZoneWater = 0

        '            For i As Integer = 1 To Me.opLastSoilLayer(cropNum)
        '                If Soil.waterContent(i) >= Soil.PWP(i) Then
        '                    depletionZoneWater += (Soil.waterContent(i) - Soil.PWP(i)) * Soil.layerThickness(i)
        '                End If
        '            Next

        '            If (depletionZoneWater + Soil.irrigationVol) < (Me.depletionZonePAW(Me.opLastSoilLayer(cropNum)) * (1 - Me.opWaterDepletion(cropNum))) Then
        '                tempVal = ((Me.depletionZonePAW(Me.opLastSoilLayer(cropNum)) - depletionZoneWater) * 1000) - Soil.irrigationVol  'Convert m to mm
        '            End If
        '        End If
        '    End If

        '    Return tempVal
        'End Function

    End Class

    'Public Sub ReadFertilizerList(ByVal lcldir As String)
    '    If FileOps.FileExists(lcldir & "fert.dat") Then
    '        Try

    '        Catch ex As Exception
    '            MsgBox(ex, MsgBoxStyle.Exclamation, MainForm.ProductName)
    '            Exit Sub
    '        End Try


    '    End If
    'End Sub

    Public Sub ApplyFertilizer(ByVal fixedFertilization As FixedFertilizationClass, ByRef Soil As SoilClass, ByRef Residue As ResidueClass)
        Dim layer As Integer

        'incorporates fertilizer
        'with option to put manure C and manure N in the surface, but mineral components are added to layer 1

        If fixedFertilization.opLayer > 0 Then
            layer = fixedFertilization.opLayer
            Residue.manureC(layer) += fixedFertilization.opMass * fixedFertilization.opC_Organic
            'Soil.charcoalC(layer) += fixedFertilization.opMass * fixedFertilization.opC_Charcoal
            Residue.manureN(layer) += fixedFertilization.opMass * fixedFertilization.opN_Organic
            'Soil.charcoalN(layer) += fixedFertilization.opMass * fixedFertilization.opN_Charcoal
            Soil.NO3(layer) += fixedFertilization.opMass * fixedFertilization.opN_NO3
            Soil.NH4(layer) += fixedFertilization.opMass * fixedFertilization.opN_NH4
            'Soil.manureP(layer) += fixedFertilization.opMass * fixedFertilization.opP_Organic
            'Soil.charcoalP(layer) += fixedFertilization.opMass * fixedFertilization.opP_Charcoal
            'Soil.inorgP(layer) += fixedFertilization.opMass * fixedFertilization.opP_Inorganic
            'Soil.potassium(layer) += fixedFertilization.opMass * fixedFertilization.opK
            'Soil.inorgS(layer) += fixedFertilization.opMass * fixedFertilization.opS
        Else
            Residue.manureSurfaceC += fixedFertilization.opMass * fixedFertilization.opC_Organic
            Residue.manureSurfaceN += fixedFertilization.opMass * fixedFertilization.opN_Organic
            'Soil.charcoalN(layer) += fixedFertilization.opMass * fixedFertilization.opN_Charcoal

            layer = 1
            Soil.NO3(layer) += fixedFertilization.opMass * fixedFertilization.opN_NO3
            Soil.NH4(layer) += fixedFertilization.opMass * fixedFertilization.opN_NH4
            'Soil.manureP(layer) += fixedFertilization.opMass * fixedFertilization.opP_Organic
            'Soil.charcoalP(layer) += fixedFertilization.opMass * fixedFertilization.opP_Charcoal
            'Soil.inorgP(layer) += fixedFertilization.opMass * fixedFertilization.opP_Inorganic
            'Soil.potassium(layer) += fixedFertilization.opMass * fixedFertilization.opK
            'Soil.inorgS(layer) += fixedFertilization.opMass * fixedFertilization.opS

        End If

    End Sub

    Public Sub PopulateOperationsTable()
        Dim i As Integer = -1

        i += 1
        fertList(i, 0) = "Nitrate"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0 : fertList(i, 6) = 1 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0 : fertList(i, 10) = 0 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "Ammonium"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 1 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0 : fertList(i, 10) = 0 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "Phosphorus"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 1 : fertList(i, 10) = 0 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "Potassium"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0 : fertList(i, 10) = 1 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "Sulphur"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0 : fertList(i, 10) = 0 : fertList(i, 11) = 1

        i += 1
        fertList(i, 0) = "Urea"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0.46 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0 : fertList(i, 10) = 0 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "82-00-00 Anhydrous Ammonia"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0.82 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0 : fertList(i, 10) = 0 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "32-00-00 Urea Ammonium Nitrate Solution"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0.24 : fertList(i, 6) = 0.08 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0 : fertList(i, 10) = 0 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "21-00-00 Ammonium Sulfate"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0.2 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0 : fertList(i, 10) = 0 : fertList(i, 11) = 0.24

        i += 1
        fertList(i, 0) = "18-46-00 Di-Ammonium Phoshate"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0.18 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0.202 : fertList(i, 10) = 0 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "13-00-44 Potassium Nitrate"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0.13 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0 : fertList(i, 10) = 0.44 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "30-15-00"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0.3 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0.066 : fertList(i, 10) = 0 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "33-00-00 Ammonium Nitrate"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0.175 : fertList(i, 6) = 0.175 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0 : fertList(i, 10) = 0 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "25-05-00"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0 : fertList(i, 6) = 0.25 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0.022 : fertList(i, 10) = 0 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "24-06-00"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0 : fertList(i, 6) = 0.24 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0.026 : fertList(i, 10) = 0 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "20-20-20"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0 : fertList(i, 6) = 0.2 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0.088 : fertList(i, 10) = 0 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "16-20-20 Potassium Ammonium Phosphate"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0.16 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0.088 : fertList(i, 10) = 0.2 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "15-15-00"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0.15 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0.066 : fertList(i, 10) = 0 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "15-15-15"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0.15 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0.066 : fertList(i, 10) = 0.15 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "13-13-13"
        fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        fertList(i, 5) = 0.13 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        fertList(i, 9) = 0.057 : fertList(i, 10) = 0.13 : fertList(i, 11) = 0

        i += 1
        fertList(i, 0) = "Dairy Manure"
        fertList(i, 1) = 0.43 : fertList(i, 2) = 0 : fertList(i, 3) = 0.031 : fertList(i, 4) = 0
        fertList(i, 5) = 0.007 : fertList(i, 6) = 0 : fertList(i, 7) = 0.003 : fertList(i, 8) = 0
        fertList(i, 9) = 0.005 : fertList(i, 10) = 0 : fertList(i, 11) = 0.005

        i += 1
        fertList(i, 0) = "Beef Manure"
        fertList(i, 1) = 0.42 : fertList(i, 2) = 0 : fertList(i, 3) = 0.03 : fertList(i, 4) = 0
        fertList(i, 5) = 0.01 : fertList(i, 6) = 0 : fertList(i, 7) = 0.007 : fertList(i, 8) = 0
        fertList(i, 9) = 0.004 : fertList(i, 10) = 0 : fertList(i, 11) = 0.004

        i += 1
        fertList(i, 0) = "Veal Manure"
        fertList(i, 1) = 0.41 : fertList(i, 2) = 0 : fertList(i, 3) = 0.029 : fertList(i, 4) = 0
        fertList(i, 5) = 0.023 : fertList(i, 6) = 0 : fertList(i, 7) = 0.007 : fertList(i, 8) = 0
        fertList(i, 9) = 0.006 : fertList(i, 10) = 0 : fertList(i, 11) = 0.006

        i += 1
        fertList(i, 0) = "Swine Manure"
        fertList(i, 1) = 0.25 : fertList(i, 2) = 0 : fertList(i, 3) = 0.021 : fertList(i, 4) = 0
        fertList(i, 5) = 0.026 : fertList(i, 6) = 0 : fertList(i, 7) = 0.005 : fertList(i, 8) = 0
        fertList(i, 9) = 0.011 : fertList(i, 10) = 0 : fertList(i, 11) = 0.0011

        i += 1
        fertList(i, 0) = "Sheep Manure"
        fertList(i, 1) = 0.29 : fertList(i, 2) = 0 : fertList(i, 3) = 0.024 : fertList(i, 4) = 0
        fertList(i, 5) = 0.014 : fertList(i, 6) = 0 : fertList(i, 7) = 0.005 : fertList(i, 8) = 0
        fertList(i, 9) = 0.003 : fertList(i, 10) = 0 : fertList(i, 11) = 0.003

        i += 1
        fertList(i, 0) = "Goat Manure"
        fertList(i, 1) = 0.26 : fertList(i, 2) = 0 : fertList(i, 3) = 0.022 : fertList(i, 4) = 0
        fertList(i, 5) = 0.013 : fertList(i, 6) = 0 : fertList(i, 7) = 0.005 : fertList(i, 8) = 0
        fertList(i, 9) = 0.003 : fertList(i, 10) = 0 : fertList(i, 11) = 0.003

        i += 1
        fertList(i, 0) = "Horse Manure"
        fertList(i, 1) = 0.28 : fertList(i, 2) = 0 : fertList(i, 3) = 0.014 : fertList(i, 4) = 0
        fertList(i, 5) = 0.006 : fertList(i, 6) = 0 : fertList(i, 7) = 0.003 : fertList(i, 8) = 0
        fertList(i, 9) = 0.001 : fertList(i, 10) = 0 : fertList(i, 11) = 0.001

        i += 1
        fertList(i, 0) = "Chicken Manure"
        fertList(i, 1) = 0.44 : fertList(i, 2) = 0 : fertList(i, 3) = 0.04 : fertList(i, 4) = 0
        fertList(i, 5) = 0.01 : fertList(i, 6) = 0 : fertList(i, 7) = 0.01 : fertList(i, 8) = 0
        fertList(i, 9) = 0.004 : fertList(i, 10) = 0 : fertList(i, 11) = 0.004

        i += 1
        fertList(i, 0) = "Turkey Manure"
        fertList(i, 1) = 0.44 : fertList(i, 2) = 0 : fertList(i, 3) = 0.045 : fertList(i, 4) = 0
        fertList(i, 5) = 0.007 : fertList(i, 6) = 0 : fertList(i, 7) = 0.016 : fertList(i, 8) = 0
        fertList(i, 9) = 0.003 : fertList(i, 10) = 0 : fertList(i, 11) = 0.003

        'i += 1
        'fertList(i, 0) = ""
        'fertList(i, 1) = 0 : fertList(i, 2) = 0 : fertList(i, 3) = 0 : fertList(i, 4) = 0
        'fertList(i, 5) = 0 : fertList(i, 6) = 0 : fertList(i, 7) = 0 : fertList(i, 8) = 0
        'fertList(i, 9) = 0 : fertList(i, 10) = 0 : fertList(i, 11) = 0

    End Sub

    Public ReadOnly Property Source(ByVal index As Integer) As String
        Get
            Return fertList(index, 0)
        End Get
    End Property
    Public ReadOnly Property C_Organic(ByVal index As Integer) As Double
        Get
            Return fertList(index, 1)
        End Get
    End Property
    Public ReadOnly Property C_Charcoal(ByVal index As Integer) As Double
        Get
            Return fertList(index, 2)
        End Get
    End Property
    Public ReadOnly Property N_Organic(ByVal index As Integer) As Double
        Get
            Return fertList(index, 3)
        End Get
    End Property
    Public ReadOnly Property N_Charcoal(ByVal index As Integer) As Double
        Get
            Return fertList(index, 4)
        End Get
    End Property
    Public ReadOnly Property N_NH4(ByVal index As Integer) As Double
        Get
            Return fertList(index, 5)
        End Get
    End Property
    Public ReadOnly Property N_NO3(ByVal index As Integer) As Double
        Get
            Return fertList(index, 6)
        End Get
    End Property
    Public ReadOnly Property P_Organic(ByVal index As Integer) As Double
        Get
            Return fertList(index, 7)
        End Get
    End Property
    Public ReadOnly Property P_Charcoal(ByVal index As Integer) As Double
        Get
            Return fertList(index, 8)
        End Get
    End Property
    Public ReadOnly Property P(ByVal index As Integer) As Double
        Get
            Return fertList(index, 9)
        End Get
    End Property
    Public ReadOnly Property K(ByVal index As Integer) As Double
        Get
            Return fertList(index, 10)
        End Get
    End Property
    Public ReadOnly Property S(ByVal index As Integer) As Double
        Get
            Return fertList(index, 11)
        End Get
    End Property
End Module
