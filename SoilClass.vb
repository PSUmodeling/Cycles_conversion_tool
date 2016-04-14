Option Explicit On
Imports System.Math

Friend Class SoilClass
    'Private Sand() As Double

    Public totalLayers As Integer
    Public Curve_Number As Integer
    Public Percent_Slope As Double

    Public annualTemperaturePhase As Integer
    Public dampingDepth As Double

    Public cumulativeDepth() As Double                  'depth, in meters, to the bottom of that layer
    Public nodeDepth() As Double
    Public layerThickness() As Double                   'Measured in Meters
    Public Clay() As Double                             'Clay fraction, reads clay % from spreadsheet
    Public Sand() As Double
    Public IOM() As Double                              'Initial Organic Matter
    Public NO3() As Double                              'Nitrate(kg/ha)
    Public NH4() As Double                              'Ammonium(kg/ha)
    Public BD() As Double                               'Bulk Density (Mg/m3)
    Public FC() As Double                               'Field Capacity water content
    Public PWP() As Double                              'Permanent Wilting Point
    Public Porosity() As Double                         'Saturation water content (m3/m3)
    Public PAW() As Double                              'Maximum plant available water
    Public FC_WaterPotential() As Double                'Estimate water potential at field capacity
    Public airEntryPotential() As Double                'Calculate Air Entry Potential
    Public B_Value() As Double                          'Calculated "B" value
    Public M_Value() As Double                          'Calculated "M" value

    Public n2o() As Double 'temporary output of n2o per layer

    Public SOC_Conc() As Double                         'g C / kg soil
    Public SOC_Mass() As Double                         'Soil Organic Carbon, Mg/ha, factor 0.58 converts SOM to SOC
    Public SON_Mass() As Double                         'Soil Organic Nitrogen, Mg/ha
    Public MBC_Mass() As Double                         'Microbial Biomass Carbon, Mg/ha
    Public MBN_Mass() As Double                         'Microbial Biomass Nitrogen, Mg/ha
    Public SOCProfile As Double
    Public SONProfile As Double

    Public C_Humified As Double                         'Carbon humified from residues, roots, rizho, and manure
    Public C_ResidueRespired As Double                  'Carbon respired from residues, roots, rizho, and manure
    Public C_SoilRespired As Double                     'Carbon respired from soil organic carbon only

    Public soilTemperature() As Double                  'Celsius
    Public waterContent() As Double                     'Volumetric water content, m3/m3
    Public waterUptake() As Double                      'layer water uptake 
    Public pH() As Double

    Public evaporationVol As Double                     'mm of water
    Public residueEvaporationVol As Double              'mm of water
    Public infiltrationVol As Double                    'mm of water
    Public runoffVol As Double                          'mm of water
    Public irrigationVol As Double                      'mm of water
    Public drainageVol As Double                        'mm of water
    Public NO3Leaching As Double                        'Mg N/ha
    Public NH4Leaching As Double                        'Mg N/ha

    Public NO3Profile As Double
    Public NH4Profile As Double
    Public N_Immobilization As Double
    Public N_Mineralization As Double
    Public N_NetMineralization As Double
    Public NH4_Nitrification As Double
    Public N2O_Nitrification As Double
    Public NO3_Denitrification As Double
    Public N2O_Denitrification As Double
    Public NH4_Volatilization As Double

    Public Sub New(ByVal layers As Integer)
        totalLayers = layers
        layers += 1

        ReDim cumulativeDepth(Me.totalLayers)
        ReDim nodeDepth(layers)
        ReDim layerThickness(layers)
        ReDim Sand(layers)
        ReDim Clay(layers)
        ReDim Sand(layers)
        ReDim IOM(layers)
        ReDim NO3(layers)
        ReDim NH4(layers)
        ReDim BD(layers)
        ReDim FC(layers)
        ReDim PWP(layers)

        ReDim waterContent(layers)
        ReDim soilTemperature(layers)
        ReDim Porosity(layers)
        ReDim PAW(layers)
        ReDim FC_WaterPotential(layers)
        ReDim airEntryPotential(layers)
        ReDim B_Value(layers)
        ReDim M_Value(layers)
        ReDim SOC_Conc(layers)
        ReDim SOC_Mass(layers)
        ReDim SON_Mass(layers)
        ReDim MBC_Mass(layers)
        ReDim MBN_Mass(layers)
        ReDim waterUptake(layers)
        ReDim pH(layers)

        ReDim n2o(layers) 'layers

    End Sub

    Public Function StoreInputData(ByVal manualBD As Boolean, ByVal manualFC As Boolean, ByVal manualPWP As Boolean, _
                                   ByVal LT() As Double, ByVal clayContent() As Double, ByVal sandContent() As Double, _
                                   ByVal organicMatter() As Double, ByVal Nitrate() As Double, ByVal Ammonium() As Double, _
                                   ByVal Bulk_Density() As Double, ByVal fieldCapacity() As Double, ByVal PermWiltingPoint() As Double, _
                                   ByVal percentSlope As Double, ByVal curveNumber As Double) As Boolean

        'Precondition:  inputs arrays must be zero based
        'Postcondition: stored arrays are 1 based

        'Dim WC33 As Double       'volumetric water content at 33 J/kg
        'Dim WC1500 As Double     'volumetric water content at 1500 J/kg
        Dim Location As String

        Curve_Number = curveNumber
        Percent_Slope = percentSlope

        'Cannot remove error handling for PWP from soilclass without significant code duplication as PWP is compared after calculation

        cumulativeDepth(0) = 0

        nodeDepth(0) = SideSubs.Formatting(-0.5 * layerThickness(1))

        For i As Integer = 1 To totalLayers
            layerThickness(i) = LT(i - 1)
            Clay(i) = clayContent(i - 1) / 100
            Sand(i) = sandContent(i - 1) / 100
            IOM(i) = organicMatter(i - 1)
            NO3(i) = Nitrate(i - 1) / 1000
            NH4(i) = Ammonium(i - 1) / 1000
            BD(i) = Bulk_Density(i - 1)
            FC(i) = fieldCapacity(i - 1)
            PWP(i) = PermWiltingPoint(i - 1)
            nodeDepth(i) = SideSubs.Formatting(cumulativeDepth(i - 1) + layerThickness(i) / 2)
            cumulativeDepth(i) = SideSubs.Formatting(cumulativeDepth(i - 1) + layerThickness(i))
        Next i

        nodeDepth(totalLayers + 1) = SideSubs.Formatting(cumulativeDepth(totalLayers) + layerThickness(totalLayers) / 2)

        Location = "Error: Soil Sheet"

        'computes hydraulic properties based on user inputs and Saxton's estimates
        For i As Integer = 1 To totalLayers
            'estimate b, air entry, bulk density and gravimetric FC and PWP using Saxton and Rawls
            Dim sb As Double        'Saxton's b coefficient 
            Dim sAP As Double       'Saxton's air entry potential
            Dim sBD As Double       'Saxton's bulk density
            Dim s33 As Double       'Saxton's volumetric WC at 33 J/kg
            Dim s1500 As Double     'Saxton's volumetric WC at 1500 J/kg

            sBD = BulkDensity(Clay(i), Sand(i), IOM(i))
            s33 = VolumetricWCAt33Jkg(Clay(i), Sand(i), IOM(i))
            s1500 = VolumetricWCAt1500Jkg(Clay(i), Sand(i), IOM(i))
            sb = (Log(1500) - Log(33)) / (Log(s33) - Log(s1500))
            sAP = -33 * (s33 / (1 - sBD / 2.65)) ^ sb              'this is sAP=-33*(WCv/WCs)^b

            If manualBD Then 'bulk density switch
                airEntryPotential(i) = sAP * (BD(i) / sBD) ^ (0.67 * sb)    'recalculate air entry potential - Eq. 5.12 in Cambell's Soil Physics with Basics (sort of) (I use a reference BD instead of 1.3 as Gaylon did)
            Else
                BD(i) = sBD
                airEntryPotential(i) = sAP
            End If

            Porosity(i) = 1 - BD(i) / 2.65
            B_Value(i) = sb
            M_Value(i) = 2 * sb + 3

            If Not manualFC Then 'FC switch
                FC_WaterPotential(i) = -0.35088 * Clay(i) * 100 - 28.947
                FC(i) = SoilWaterContent(Porosity(i), airEntryPotential(i), B_Value(i), FC_WaterPotential(i))
            End If

            If Not manualPWP Then 'PWP switch
                PWP(i) = SoilWaterContent(Porosity(i), airEntryPotential(i), B_Value(i), -1500)
            End If


            If PWP(i) >= FC(i) Then
                MsgBox("Permanent Wilting Point must be less than Field Capacity." & vbCr & "Layer " & i, vbOKOnly, Location)
                Return False
            End If

            If Porosity(i) < FC(i) Then
                Dim rr As Double
                'in case the air entry potential adjustment fails to deliver FC < Porosity
                'this function estimates the ratio of volume (sat - fc) / (fc - pwp) 
                'used to recalculate FC if bulk density is too high (source: guess based on Saxton and Rawls data)
                rr = 0.63 + 0.59 * Math.Exp(0.6 * Sand(i) * 100 - 2.84)
                FC(i) = (rr * PWP(i) + Porosity(i)) / (1 + rr)
            End If
        Next i

        'For i As Integer = 1 To totalLayers                                    'Uses user input to switch between user or calculated data

        '    If Not manualBD Then BD(i) = BulkDensity(Clay(i), Sand(i), IOM(i)) 'Bulk Density switch

        '    Porosity(i) = 1 - BD(i) / 2.65
        '    WC33 = VolumetricWCAt33Jkg(Clay(i), Sand(i), IOM(i))
        '    WC1500 = VolumetricWCAt1500Jkg(Clay(i), Sand(i), IOM(i))
        '    B_Value(i) = (Log(1500) - Log(33)) / (Log(WC33) - Log(WC1500))
        '    airEntryPotential(i) = -33 * (WC33 / Porosity(i)) ^ B_Value(i)
        '    M_Value(i) = 2 * B_Value(i) + 3

        '    If manualFC Then                                                'Field Capacity switch
        '        FC_WaterPotential(i) = SoilWaterPotential(Porosity(i), airEntryPotential(i), B_Value(i), FC(i))
        '    Else
        '        FC_WaterPotential(i) = -0.35088 * Clay(i) * 100 - 28.947
        '        FC(i) = SoilWaterContent(Porosity(i), airEntryPotential(i), B_Value(i), FC_WaterPotential(i))
        '    End If

        '    If Not manualPWP Then                                           'Permanent Wilting Point switch
        '        PWP(i) = SoilWaterContent(Porosity(i), airEntryPotential(i), B_Value(i), -1500)
        '    End If

        '    If PWP(i) >= FC(i) Then
        '        MsgBox("Permanent Wilting Point must be less than Field Capacity." & vbCr & "Layer " & i, vbOKOnly, Location)
        '        Return False
        '    End If

        'Next i

        For i As Integer = 1 To totalLayers                                 'Initializes variables dependent on previous loop
            SOC_Conc(i) = IOM(i) * 10 * 0.58
            SOC_Mass(i) = IOM(i) / 100 * 0.58 * layerThickness(i) * BD(i) * 10000
            SON_Mass(i) = SOC_Mass(i) / 10                                  'Initializes with CN ratio = 10
            MBC_Mass(i) = 0.03 * SOC_Mass(i)                                'Initializes as 3% of SOC_Mass, but "added" C
            MBN_Mass(i) = MBC_Mass(i) / 10                                  'Initializes with CN ratio = 10
            PAW(i) = FC(i) - PWP(i)
            waterContent(i) = (FC(i) + PWP(i)) / 2
        Next i

        Return True
    End Function

    Public Function SoilWaterPotential(ByVal SaturationWC As Double, ByVal AirEntryPot As Double, ByVal Campbell_b As Double, ByVal WC As Double) As Double
        Return AirEntryPot * (WC / SaturationWC) ^ (-Campbell_b)
    End Function

    'Public Function XConc(ByVal NewX As Double, ByVal OldX As Double, ByVal NewMass As Double, ByVal OldMass As Double) As Double
    '    XConc = (NewX + OldX) / (NewMass + OldMass)
    'End Function

    Private Function VolumetricWCAt33Jkg(ByVal Clay As Double, ByVal Sand As Double, ByVal OM As Double) As Double
        ' Saxton and Rawls 2006 SSSAJ 70:1569-1578 Eq 2 (r2 = 0.63)
        ' clay and sand fractional, OM as % (original paper says % for everything, results make no sense)
        Dim x1 As Double

        x1 = 0.299 - 0.251 * Sand + 0.195 * Clay + 0.011 * OM + 0.006 * Sand * OM - 0.027 * Clay * OM + 0.452 * Sand * Clay
        Return -0.015 + 0.636 * x1 + 1.283 * x1 ^ 2
    End Function

    Private Function VolumetricWCAt1500Jkg(ByVal Clay As Double, ByVal Sand As Double, ByVal OM As Double) As Double
        ' Saxton and Rawls 2006 SSSAJ 70:1569-1578 Eq 1 (r2 = 0.86)
        ' clay and sand fractional, OM as % (original paper says % for everything, results make no sense)
        Dim x1 As Double

        x1 = 0.031 - 0.024 * Sand + 0.487 * Clay + 0.006 * OM + 0.005 * Sand * OM - 0.013 * Clay * OM + 0.068 * Sand * Clay
        Return -0.02 + 1.14 * x1
    End Function

    Private Function SoilWaterContent(ByVal SaturationWC As Double, ByVal AirEntryPot As Double, ByVal Campbell_b As Double, _
            ByVal Water_Potential As Double) As Double
        Return SaturationWC * (Water_Potential / AirEntryPot) ^ (-1 / Campbell_b)
    End Function

    Private Function BulkDensity(ByVal Clay As Double, ByVal Sand As Double, ByVal OM As Double) As Double
        ' Saxton and Rawls 2006 SSSAJ 70:1569-1578 Eq 6,5 (r2 = 0.29) really poor fit
        ' clay and sand fractional, OM as % (original paper says % for everything, results make no sense)
        ' note:  X2 is Eq 3, supposedly representing moisture from FC to Saturation; however, porosity is further adjusted by sand, an inconsistency
        Dim x1 As Double, x2 As Double, FC As Double, Porosity As Double

        x1 = 0.078 + 0.278 * Sand + 0.034 * Clay + 0.022 * OM - 0.018 * Sand * OM - 0.027 * Clay * OM - 0.584 * Sand * Clay
        x2 = -0.107 + 1.636 * x1
        FC = VolumetricWCAt33Jkg(Clay, Sand, OM)
        Porosity = 0.043 + FC + x2 - 0.097 * Sand
        Return (1 - Porosity) * 2.65
    End Function

End Class
