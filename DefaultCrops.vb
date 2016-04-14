Option Explicit On

Friend Class DefaultCrops
    Public MAX_CROPS As Integer = 30                    'current number of crops stored

    Private Const ANNUAL As String = "Annual"
    Private Const PERENNIAL As String = "Perennial"

    Private cropInfo(MAX_CROPS, 21) As Object           ' Master crop List 
    Private cropNum As Integer                          ' Index for master crop list 

    Public Sub New()
        Dim i As Integer = -1

        ' 0=Name                             1=Min Temp for Transp       2=Threshold Temp for Transp         3=Min Temp for Cold Damage
        ' 4=Threshold temp for cold damage   5=Tb                        6=Topt                              7=Tmax
        ' 8=EmergenceTT                      9=Initial Shoot Partition  10=Final Shoot Partition            11=RUE
        '12=TUE                             13=HIx                      14=HIo                              15=HIk
        '16=N Max Concentration             17=N Dilution Slope         18=Kc (crop ET factor)              19=Annual or Perennial             
        '20=Legume or Not Legume            21=C3 or C4

        '********************************************* ANNUALS - LEGUMES **************************************************************
        i = i + 1
        Me.cropInfo(i, 0) = "Chickpeas" : Me.cropInfo(i, 1) = 0 : Me.cropInfo(i, 2) = 9 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = 0 : Me.cropInfo(i, 5) = 3 : Me.cropInfo(i, 6) = 25 : Me.cropInfo(i, 7) = 45
        Me.cropInfo(i, 8) = 90 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.32
        Me.cropInfo(i, 12) = 4.5 : Me.cropInfo(i, 13) = 0.38 : Me.cropInfo(i, 14) = 0.1 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.4 : Me.cropInfo(i, 18) = 1.05 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = True : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Lentils" : Me.cropInfo(i, 1) = 0 : Me.cropInfo(i, 2) = 8 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = 0 : Me.cropInfo(i, 5) = 2 : Me.cropInfo(i, 6) = 25 : Me.cropInfo(i, 7) = 45
        Me.cropInfo(i, 8) = 90 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.32
        Me.cropInfo(i, 12) = 4.5 : Me.cropInfo(i, 13) = 0.38 : Me.cropInfo(i, 14) = 0.1 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.4 : Me.cropInfo(i, 18) = 1.05 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = True : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Soybean" : Me.cropInfo(i, 1) = 3 : Me.cropInfo(i, 2) = 15 : Me.cropInfo(i, 3) = -5
        Me.cropInfo(i, 4) = 3 : Me.cropInfo(i, 5) = 5 : Me.cropInfo(i, 6) = 28 : Me.cropInfo(i, 7) = 43
        Me.cropInfo(i, 8) = 70 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.32
        Me.cropInfo(i, 12) = 4.5 : Me.cropInfo(i, 13) = 0.4 : Me.cropInfo(i, 14) = 0.15 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.4 : Me.cropInfo(i, 18) = 1.05 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = True : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Spring Peas" : Me.cropInfo(i, 1) = 0 : Me.cropInfo(i, 2) = 9 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = 0 : Me.cropInfo(i, 5) = 3 : Me.cropInfo(i, 6) = 25 : Me.cropInfo(i, 7) = 45
        Me.cropInfo(i, 8) = 90 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.32
        Me.cropInfo(i, 12) = 4.54 : Me.cropInfo(i, 13) = 0.38 : Me.cropInfo(i, 14) = 0.1 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.4 : Me.cropInfo(i, 18) = 1.05 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = True : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Vicia" : Me.cropInfo(i, 1) = -1 : Me.cropInfo(i, 2) = 8 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = 0 : Me.cropInfo(i, 5) = 2 : Me.cropInfo(i, 6) = 26 : Me.cropInfo(i, 7) = 40
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.65
        Me.cropInfo(i, 12) = 6.0 : Me.cropInfo(i, 13) = 0.52 : Me.cropInfo(i, 14) = 0.31 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.4 : Me.cropInfo(i, 18) = 1.05 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = True : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Winter Lentils" : Me.cropInfo(i, 1) = -1 : Me.cropInfo(i, 2) = 8 : Me.cropInfo(i, 3) = -18
        Me.cropInfo(i, 4) = -3 : Me.cropInfo(i, 5) = 1 : Me.cropInfo(i, 6) = 25 : Me.cropInfo(i, 7) = 45
        Me.cropInfo(i, 8) = 90 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.32
        Me.cropInfo(i, 12) = 4.5 : Me.cropInfo(i, 13) = 0.38 : Me.cropInfo(i, 14) = 0.1 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.4 : Me.cropInfo(i, 18) = 1.05 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = True : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Winter Peas" : Me.cropInfo(i, 1) = -1 : Me.cropInfo(i, 2) = 8 : Me.cropInfo(i, 3) = -12
        Me.cropInfo(i, 4) = -3 : Me.cropInfo(i, 5) = 1 : Me.cropInfo(i, 6) = 25 : Me.cropInfo(i, 7) = 45
        Me.cropInfo(i, 8) = 90 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.32
        Me.cropInfo(i, 12) = 4.5 : Me.cropInfo(i, 13) = 0.38 : Me.cropInfo(i, 14) = 0.1 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.4 : Me.cropInfo(i, 18) = 1.05 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = True : Me.cropInfo(i, 21) = "C3"

        '********************************************* ANNUALS - NON-LEGUMES *****************************************************
        i = i + 1
        Me.cropInfo(i, 0) = "Cotton" : Me.cropInfo(i, 1) = 3 : Me.cropInfo(i, 2) = 15 : Me.cropInfo(i, 3) = -5
        Me.cropInfo(i, 4) = 2 : Me.cropInfo(i, 5) = 5 : Me.cropInfo(i, 6) = 28 : Me.cropInfo(i, 7) = 45
        Me.cropInfo(i, 8) = 90 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.54
        Me.cropInfo(i, 12) = 5.06 : Me.cropInfo(i, 13) = 0.38 : Me.cropInfo(i, 14) = 0.1 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.47 : Me.cropInfo(i, 18) = 1.1 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Oats" : Me.cropInfo(i, 1) = -1 : Me.cropInfo(i, 2) = 8 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = 0 : Me.cropInfo(i, 5) = 2 : Me.cropInfo(i, 6) = 26 : Me.cropInfo(i, 7) = 40
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.65
        Me.cropInfo(i, 12) = 6.0 : Me.cropInfo(i, 13) = 0.52 : Me.cropInfo(i, 14) = 0.31 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.47 : Me.cropInfo(i, 18) = 1.1 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Ryegrass - Annual" : Me.cropInfo(i, 1) = -1 : Me.cropInfo(i, 2) = 8 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = -1 : Me.cropInfo(i, 5) = 2 : Me.cropInfo(i, 6) = 26 : Me.cropInfo(i, 7) = 40
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.65
        Me.cropInfo(i, 12) = 6.0 : Me.cropInfo(i, 13) = 0.52 : Me.cropInfo(i, 14) = 0.31 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.47 : Me.cropInfo(i, 18) = 1.1 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Spring Barley" : Me.cropInfo(i, 1) = -1 : Me.cropInfo(i, 2) = 8 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = 0 : Me.cropInfo(i, 5) = 2 : Me.cropInfo(i, 6) = 26 : Me.cropInfo(i, 7) = 40
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.65
        Me.cropInfo(i, 12) = 6.0 : Me.cropInfo(i, 13) = 0.52 : Me.cropInfo(i, 14) = 0.31 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.47 : Me.cropInfo(i, 18) = 1.1 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Spring Canola" : Me.cropInfo(i, 1) = -1 : Me.cropInfo(i, 2) = 9 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = 0 : Me.cropInfo(i, 5) = 1 : Me.cropInfo(i, 6) = 24 : Me.cropInfo(i, 7) = 40
        Me.cropInfo(i, 8) = 90 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.32
        Me.cropInfo(i, 12) = 4.6 : Me.cropInfo(i, 13) = 0.38 : Me.cropInfo(i, 14) = 0.1 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.3 : Me.cropInfo(i, 18) = 1.05 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Spring Wheat" : Me.cropInfo(i, 1) = -1 : Me.cropInfo(i, 2) = 8 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = -1 : Me.cropInfo(i, 5) = 2 : Me.cropInfo(i, 6) = 26 : Me.cropInfo(i, 7) = 40
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.65
        Me.cropInfo(i, 12) = 6.0 : Me.cropInfo(i, 13) = 0.52 : Me.cropInfo(i, 14) = 0.31 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.47 : Me.cropInfo(i, 18) = 1.1 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Sunflower" : Me.cropInfo(i, 1) = 3 : Me.cropInfo(i, 2) = 12 : Me.cropInfo(i, 3) = -5
        Me.cropInfo(i, 4) = 2 : Me.cropInfo(i, 5) = 5 : Me.cropInfo(i, 6) = 28 : Me.cropInfo(i, 7) = 43
        Me.cropInfo(i, 8) = 90 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.75
        Me.cropInfo(i, 12) = 5.0 : Me.cropInfo(i, 13) = 0.44 : Me.cropInfo(i, 14) = 0.2 : Me.cropInfo(i, 15) = 3
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.45 : Me.cropInfo(i, 18) = 1.2 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Triticale" : Me.cropInfo(i, 1) = -1 : Me.cropInfo(i, 2) = 8 : Me.cropInfo(i, 3) = -15
        Me.cropInfo(i, 4) = -2 : Me.cropInfo(i, 5) = 2 : Me.cropInfo(i, 6) = 26 : Me.cropInfo(i, 7) = 40
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.65
        Me.cropInfo(i, 12) = 6.0 : Me.cropInfo(i, 13) = 0.52 : Me.cropInfo(i, 14) = 0.31 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.47 : Me.cropInfo(i, 18) = 1.1 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Winter Canola" : Me.cropInfo(i, 1) = 3 : Me.cropInfo(i, 2) = 9 : Me.cropInfo(i, 3) = -18
        Me.cropInfo(i, 4) = -2 : Me.cropInfo(i, 5) = 1 : Me.cropInfo(i, 6) = 24 : Me.cropInfo(i, 7) = 40
        Me.cropInfo(i, 8) = 90 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.32
        Me.cropInfo(i, 12) = 4.5 : Me.cropInfo(i, 13) = 0.38 : Me.cropInfo(i, 14) = 0.1 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.35 : Me.cropInfo(i, 18) = 1.05 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Winter Wheat" : Me.cropInfo(i, 1) = -1 : Me.cropInfo(i, 2) = 8 : Me.cropInfo(i, 3) = -25
        Me.cropInfo(i, 4) = -4 : Me.cropInfo(i, 5) = 0 : Me.cropInfo(i, 6) = 24 : Me.cropInfo(i, 7) = 40
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 1.65
        Me.cropInfo(i, 12) = 6.0 : Me.cropInfo(i, 13) = 0.52 : Me.cropInfo(i, 14) = 0.31 : Me.cropInfo(i, 15) = 2
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.47 : Me.cropInfo(i, 18) = 1.05 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Maize" : Me.cropInfo(i, 1) = 3 : Me.cropInfo(i, 2) = 15 : Me.cropInfo(i, 3) = -5
        Me.cropInfo(i, 4) = 3 : Me.cropInfo(i, 5) = 5 : Me.cropInfo(i, 6) = 28 : Me.cropInfo(i, 7) = 46
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 2.2
        Me.cropInfo(i, 12) = 7.9 : Me.cropInfo(i, 13) = 0.8 : Me.cropInfo(i, 14) = 0.15 : Me.cropInfo(i, 15) = 1.3
        Me.cropInfo(i, 16) = 0.055 : Me.cropInfo(i, 17) = 0.4 : Me.cropInfo(i, 18) = 1.2 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C4"

        i = i + 1
        Me.cropInfo(i, 0) = "Sorghum" : Me.cropInfo(i, 1) = 3 : Me.cropInfo(i, 2) = 15 : Me.cropInfo(i, 3) = -5
        Me.cropInfo(i, 4) = 5 : Me.cropInfo(i, 5) = 5 : Me.cropInfo(i, 6) = 28 : Me.cropInfo(i, 7) = 46
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 2.0
        Me.cropInfo(i, 12) = 7.9 : Me.cropInfo(i, 13) = 0.8 : Me.cropInfo(i, 14) = 0.2 : Me.cropInfo(i, 15) = 1.13
        Me.cropInfo(i, 16) = 0.055 : Me.cropInfo(i, 17) = 0.4 : Me.cropInfo(i, 18) = 1.1 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C4"

        i = i + 1
        Me.cropInfo(i, 0) = "Biomass Sorghum" : Me.cropInfo(i, 1) = 3 : Me.cropInfo(i, 2) = 15 : Me.cropInfo(i, 3) = -5
        Me.cropInfo(i, 4) = 5 : Me.cropInfo(i, 5) = 5 : Me.cropInfo(i, 6) = 28 : Me.cropInfo(i, 7) = 46
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.45 : Me.cropInfo(i, 10) = 0.95 : Me.cropInfo(i, 11) = 2.2
        Me.cropInfo(i, 12) = 7.9 : Me.cropInfo(i, 13) = 0.8 : Me.cropInfo(i, 14) = 0.2 : Me.cropInfo(i, 15) = 1.13
        Me.cropInfo(i, 16) = 0.055 : Me.cropInfo(i, 17) = 0.5 : Me.cropInfo(i, 18) = 1.25 : Me.cropInfo(i, 19) = ANNUAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C4"

        ' 0=Name                             1=Min Temp for Transp       2=Threshold Temp for Transp         3=Min Temp for Cold Damage
        ' 4=Threshold temp for cold damage   5=Tb                        6=Topt                              7=Tmax
        ' 8=EmergenceTT                      9=Initial Shoot Partition  10=Final Shoot Partition            11=RUE
        '12=TUE                             13=HIx                      14=HIo                              15=HIk
        '16=N Max Concentration             17=N Dilution Slope         18=Kc (crop ET factor)              19=Annual or Perennial             
        '20=Legume or Not Legume            21=C3 or C4

        '********************************************* PERENNIALS - LEGUMES **************************************************************
        i = i + 1
        Me.cropInfo(i, 0) = "Alfalfa" : Me.cropInfo(i, 1) = 4 : Me.cropInfo(i, 2) = 12 : Me.cropInfo(i, 3) = -20
        Me.cropInfo(i, 4) = 3 : Me.cropInfo(i, 5) = 6 : Me.cropInfo(i, 6) = 25 : Me.cropInfo(i, 7) = 42
        Me.cropInfo(i, 8) = 90 : Me.cropInfo(i, 9) = 0.35 : Me.cropInfo(i, 10) = 0.75 : Me.cropInfo(i, 11) = 1.65
        Me.cropInfo(i, 12) = 5.6 : Me.cropInfo(i, 13) = 0.12 : Me.cropInfo(i, 14) = 0.01 : Me.cropInfo(i, 15) = 1.5
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.35 : Me.cropInfo(i, 18) = 1.2 : Me.cropInfo(i, 19) = PERENNIAL
        Me.cropInfo(i, 20) = True : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Red Clover" : Me.cropInfo(i, 1) = 4 : Me.cropInfo(i, 2) = 10 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = 0 : Me.cropInfo(i, 5) = 6 : Me.cropInfo(i, 6) = 25 : Me.cropInfo(i, 7) = 40
        Me.cropInfo(i, 8) = 90 : Me.cropInfo(i, 9) = 0.35 : Me.cropInfo(i, 10) = 0.75 : Me.cropInfo(i, 11) = 1.43
        Me.cropInfo(i, 12) = 4.62 : Me.cropInfo(i, 13) = 0.04 : Me.cropInfo(i, 14) = 0.005 : Me.cropInfo(i, 15) = 1
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.35 : Me.cropInfo(i, 18) = 1.1 : Me.cropInfo(i, 19) = PERENNIAL
        Me.cropInfo(i, 20) = True : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "White Clover" : Me.cropInfo(i, 1) = 2 : Me.cropInfo(i, 2) = 9 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = 0 : Me.cropInfo(i, 5) = 4 : Me.cropInfo(i, 6) = 22 : Me.cropInfo(i, 7) = 35
        Me.cropInfo(i, 8) = 90 : Me.cropInfo(i, 9) = 0.35 : Me.cropInfo(i, 10) = 0.75 : Me.cropInfo(i, 11) = 1.43
        Me.cropInfo(i, 12) = 4.62 : Me.cropInfo(i, 13) = 0.04 : Me.cropInfo(i, 14) = 0.005 : Me.cropInfo(i, 15) = 1
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.35 : Me.cropInfo(i, 18) = 1.05 : Me.cropInfo(i, 19) = PERENNIAL
        Me.cropInfo(i, 20) = True : Me.cropInfo(i, 21) = "C3"

        '********************************************* PERENNIALS - NON-LEGUMES ****************************************************
        i = i + 1
        Me.cropInfo(i, 0) = "Orchardgrass" : Me.cropInfo(i, 1) = 0 : Me.cropInfo(i, 2) = 9 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = -2 : Me.cropInfo(i, 5) = 2 : Me.cropInfo(i, 6) = 24 : Me.cropInfo(i, 7) = 38
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.35 : Me.cropInfo(i, 10) = 0.75 : Me.cropInfo(i, 11) = 1.43
        Me.cropInfo(i, 12) = 5.5 : Me.cropInfo(i, 13) = 0.08 : Me.cropInfo(i, 14) = 0.01 : Me.cropInfo(i, 15) = 1.5
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.4 : Me.cropInfo(i, 18) = 1.1 : Me.cropInfo(i, 19) = PERENNIAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Reed Canary Grass" : Me.cropInfo(i, 1) = 0 : Me.cropInfo(i, 2) = 9 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = -2 : Me.cropInfo(i, 5) = 2 : Me.cropInfo(i, 6) = 24 : Me.cropInfo(i, 7) = 38
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.35 : Me.cropInfo(i, 10) = 0.75 : Me.cropInfo(i, 11) = 1.44
        Me.cropInfo(i, 12) = 5.5 : Me.cropInfo(i, 13) = 0.08 : Me.cropInfo(i, 14) = 0.01 : Me.cropInfo(i, 15) = 1.5
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.4 : Me.cropInfo(i, 18) = 1.1 : Me.cropInfo(i, 19) = PERENNIAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Ryegrass - Perennial" : Me.cropInfo(i, 1) = -1 : Me.cropInfo(i, 2) = 9 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = -2 : Me.cropInfo(i, 5) = 2 : Me.cropInfo(i, 6) = 24 : Me.cropInfo(i, 7) = 38
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.35 : Me.cropInfo(i, 10) = 0.75 : Me.cropInfo(i, 11) = 1.43
        Me.cropInfo(i, 12) = 5.4 : Me.cropInfo(i, 13) = 0.08 : Me.cropInfo(i, 14) = 0.01 : Me.cropInfo(i, 15) = 1.5
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.4 : Me.cropInfo(i, 18) = 1.05 : Me.cropInfo(i, 19) = PERENNIAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Tall Fescue" : Me.cropInfo(i, 1) = 0 : Me.cropInfo(i, 2) = 9 : Me.cropInfo(i, 3) = -10
        Me.cropInfo(i, 4) = -2 : Me.cropInfo(i, 5) = 2 : Me.cropInfo(i, 6) = 24 : Me.cropInfo(i, 7) = 38
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.35 : Me.cropInfo(i, 10) = 0.75 : Me.cropInfo(i, 11) = 1.43
        Me.cropInfo(i, 12) = 5.6 : Me.cropInfo(i, 13) = 0.08 : Me.cropInfo(i, 14) = 0.01 : Me.cropInfo(i, 15) = 1.5
        Me.cropInfo(i, 16) = 0.07 : Me.cropInfo(i, 17) = 0.4 : Me.cropInfo(i, 18) = 1.1 : Me.cropInfo(i, 19) = PERENNIAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C3"

        i = i + 1
        Me.cropInfo(i, 0) = "Bermudagrass" : Me.cropInfo(i, 1) = 5 : Me.cropInfo(i, 2) = 15 : Me.cropInfo(i, 3) = -9
        Me.cropInfo(i, 4) = 3 : Me.cropInfo(i, 5) = 7 : Me.cropInfo(i, 6) = 28 : Me.cropInfo(i, 7) = 46
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.35 : Me.cropInfo(i, 10) = 0.75 : Me.cropInfo(i, 11) = 2.1
        Me.cropInfo(i, 12) = 7.8 : Me.cropInfo(i, 13) = 0.05 : Me.cropInfo(i, 14) = 0.005 : Me.cropInfo(i, 15) = 1.5
        Me.cropInfo(i, 16) = 0.055 : Me.cropInfo(i, 17) = 0.35 : Me.cropInfo(i, 18) = 1.1 : Me.cropInfo(i, 19) = PERENNIAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C4"

        i = i + 1
        Me.cropInfo(i, 0) = "Dallisgrass" : Me.cropInfo(i, 1) = 5 : Me.cropInfo(i, 2) = 15 : Me.cropInfo(i, 3) = -9
        Me.cropInfo(i, 4) = 3 : Me.cropInfo(i, 5) = 7 : Me.cropInfo(i, 6) = 28 : Me.cropInfo(i, 7) = 46
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.35 : Me.cropInfo(i, 10) = 0.75 : Me.cropInfo(i, 11) = 2.2
        Me.cropInfo(i, 12) = 7.7 : Me.cropInfo(i, 13) = 0.05 : Me.cropInfo(i, 14) = 0.005 : Me.cropInfo(i, 15) = 1.5
        Me.cropInfo(i, 16) = 0.055 : Me.cropInfo(i, 17) = 0.35 : Me.cropInfo(i, 18) = 1.1 : Me.cropInfo(i, 19) = PERENNIAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C4"

        i = i + 1
        Me.cropInfo(i, 0) = "Miscanthus" : Me.cropInfo(i, 1) = 2 : Me.cropInfo(i, 2) = 10 : Me.cropInfo(i, 3) = -20
        Me.cropInfo(i, 4) = 3 : Me.cropInfo(i, 5) = 0 : Me.cropInfo(i, 6) = 24 : Me.cropInfo(i, 7) = 40
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.35 : Me.cropInfo(i, 10) = 0.75 : Me.cropInfo(i, 11) = 2.3
        Me.cropInfo(i, 12) = 8.1 : Me.cropInfo(i, 13) = 0.001 : Me.cropInfo(i, 14) = 0.0001 : Me.cropInfo(i, 15) = 0.5
        Me.cropInfo(i, 16) = 0.055 : Me.cropInfo(i, 17) = 0.45 : Me.cropInfo(i, 18) = 1.2 : Me.cropInfo(i, 19) = PERENNIAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C4"

        i = i + 1
        Me.cropInfo(i, 0) = "Switchgrass" : Me.cropInfo(i, 1) = 7 : Me.cropInfo(i, 2) = 18 : Me.cropInfo(i, 3) = -5
        Me.cropInfo(i, 4) = 4 : Me.cropInfo(i, 5) = 7 : Me.cropInfo(i, 6) = 28 : Me.cropInfo(i, 7) = 46
        Me.cropInfo(i, 8) = 100 : Me.cropInfo(i, 9) = 0.35 : Me.cropInfo(i, 10) = 0.75 : Me.cropInfo(i, 11) = 2.3
        Me.cropInfo(i, 12) = 8.2 : Me.cropInfo(i, 13) = 0.001 : Me.cropInfo(i, 14) = 0.0001 : Me.cropInfo(i, 15) = 0.5
        Me.cropInfo(i, 16) = 0.055 : Me.cropInfo(i, 17) = 0.45 : Me.cropInfo(i, 18) = 1.2 : Me.cropInfo(i, 19) = PERENNIAL
        Me.cropInfo(i, 20) = False : Me.cropInfo(i, 21) = "C4"

        ' 0=Name                             1=Min Temp for Transp       2=Threshold Temp for Transp         3=Min Temp for Cold Damage
        ' 4=Threshold temp for cold damage   5=Tb                        6=Topt                              7=Tmax
        ' 8=EmergenceTT                      9=Initial Shoot Partition  10=Final Shoot Partition            11=RUE
        '12=TUE                             13=HIx                      14=HIo                              15=HIk
        '16=N Max Concentration             17=N Dilution Slope         18=Kc (crop ET factor)              19=Annual or Perennial             
        '20=Legume or Not Legume            21=C3 or C4
    End Sub

    'source data, internal index
    Public ReadOnly Property srcCropName() As String
        Get
            Return CStr(Me.cropInfo(Me.cropNum, 0))
        End Get
    End Property
    Public ReadOnly Property srcTranspirationMinTemperature() As Integer
        Get
            Return CInt(Me.cropInfo(Me.cropNum, 1))
        End Get
    End Property
    Public ReadOnly Property srcTranspirationThresholdTemperature() As Integer
        Get
            Return CInt(Me.cropInfo(Me.cropNum, 2))
        End Get
    End Property
    Public ReadOnly Property srcColdDamageMinTemperature() As Integer
        Get
            Return CInt(Me.cropInfo(Me.cropNum, 3))
        End Get
    End Property
    Public ReadOnly Property srcColdDamageThresholdTemperature() As Integer
        Get
            Return CInt(Me.cropInfo(Me.cropNum, 4))
        End Get
    End Property
    Public ReadOnly Property srcTemperatureBase() As Double
        Get
            Return CDbl(Me.cropInfo(Me.cropNum, 5))
        End Get
    End Property
    Public ReadOnly Property srcTemperatureOptimum() As Double
        Get
            Return CDbl(Me.cropInfo(Me.cropNum, 6))
        End Get
    End Property
    Public ReadOnly Property srcTemperatureMax() As Double
        Get
            Return CDbl(Me.cropInfo(Me.cropNum, 7))
        End Get
    End Property
    Public ReadOnly Property srcEmergenceTT() As Double
        Get
            Return CDbl(Me.cropInfo(Me.cropNum, 8))
        End Get
    End Property
    Public ReadOnly Property srcInitialShootPartition() As Double
        Get
            Return CDbl(Me.cropInfo(Me.cropNum, 9))
        End Get
    End Property
    Public ReadOnly Property srcFinalShootPartition() As Double
        Get
            Return CDbl(Me.cropInfo(Me.cropNum, 10))
        End Get
    End Property
    Public ReadOnly Property srcRadiationUseEfficiency() As Double
        Get
            Return CDbl(Me.cropInfo(Me.cropNum, 11))
        End Get
    End Property
    Public ReadOnly Property srcTranspirationUseEfficiency() As Double
        Get
            Return CDbl(Me.cropInfo(Me.cropNum, 12))
        End Get
    End Property
    Public ReadOnly Property srcHIx() As Double
        Get
            Return CDbl(Me.cropInfo(Me.cropNum, 13))
        End Get
    End Property
    Public ReadOnly Property srcHIo() As Double
        Get
            Return CDbl(Me.cropInfo(Me.cropNum, 14))
        End Get
    End Property
    Public ReadOnly Property srcHIk() As Double
        Get
            Return CDbl(Me.cropInfo(Me.cropNum, 15))
        End Get
    End Property
    Public ReadOnly Property srcNMaxConcentration() As Double
        Get
            Return CDbl(Me.cropInfo(Me.cropNum, 16))
        End Get
    End Property
    Public ReadOnly Property srcNDilutionSlope() As Double
        Get
            Return CDbl(Me.cropInfo(Me.cropNum, 17))
        End Get
    End Property
    Public ReadOnly Property srcKc() As Double
        Get
            Return CDbl(Me.cropInfo(Me.cropNum, 18))
        End Get
    End Property
    Public ReadOnly Property srcAnnualOrPerennial() As String
        Get
            Return CStr(Me.cropInfo(Me.cropNum, 19))
        End Get
    End Property
    Public ReadOnly Property srcLegume() As Boolean
        Get
            Return CBool(Me.cropInfo(Me.cropNum, 20))
        End Get
    End Property
    Public ReadOnly Property srcC3orC4() As String
        Get
            Return CStr(Me.cropInfo(Me.cropNum, 21))
        End Get
    End Property

    'source data, passed index
    Public ReadOnly Property srcCropName(ByVal index As Integer) As String
        Get
            Return CStr(Me.cropInfo(index, 0))
        End Get
    End Property
    Public ReadOnly Property srcTranspirationMinTemperature(ByVal index As Integer) As Integer
        Get
            Return CInt(Me.cropInfo(index, 1))
        End Get
    End Property
    Public ReadOnly Property srcTranspirationThresholdTemperature(ByVal index As Integer) As Integer
        Get
            Return CInt(Me.cropInfo(index, 2))
        End Get
    End Property
    Public ReadOnly Property srcColdDamageMinTemperature(ByVal index As Integer) As Integer
        Get
            Return CInt(Me.cropInfo(index, 3))
        End Get
    End Property
    Public ReadOnly Property srcColdDamageThresholdTemperature(ByVal index As Integer) As Integer
        Get
            Return CInt(Me.cropInfo(index, 4))
        End Get
    End Property
    Public ReadOnly Property srcTemperatureBase(ByVal index As Integer) As Double
        Get
            Return CDbl(Me.cropInfo(index, 5))
        End Get
    End Property
    Public ReadOnly Property srcTemperatureOptimum(ByVal index As Integer) As Double
        Get
            Return CDbl(Me.cropInfo(index, 6))
        End Get
    End Property
    Public ReadOnly Property srcTemperatureMaximum(ByVal index As Integer) As Double
        Get
            Return CDbl(Me.cropInfo(index, 7))
        End Get
    End Property
    Public ReadOnly Property srcEmergenceTT(ByVal index As Integer) As Double
        Get
            Return CDbl(Me.cropInfo(index, 8))
        End Get
    End Property
    Public ReadOnly Property srcShootPartitionInitial(ByVal index As Integer) As Double
        Get
            Return CDbl(Me.cropInfo(index, 9))
        End Get
    End Property
    Public ReadOnly Property srcShootPartitionFinal(ByVal index As Integer) As Double
        Get
            Return CDbl(Me.cropInfo(index, 10))
        End Get
    End Property
    Public ReadOnly Property srcRadiationUseEfficiency(ByVal index As Integer) As Double
        Get
            Return CDbl(Me.cropInfo(index, 11))
        End Get
    End Property
    Public ReadOnly Property srcTranspirationUseEfficiency(ByVal index As Integer) As Double
        Get
            Return CDbl(Me.cropInfo(index, 12))
        End Get
    End Property
    Public ReadOnly Property srcHIx(ByVal index As Integer) As Double
        Get
            Return CDbl(Me.cropInfo(index, 13))
        End Get
    End Property
    Public ReadOnly Property srcHIo(ByVal index As Integer) As Double
        Get
            Return CDbl(Me.cropInfo(index, 14))
        End Get
    End Property
    Public ReadOnly Property srcHIk(ByVal index As Integer) As Double
        Get
            Return CDbl(Me.cropInfo(index, 15))
        End Get
    End Property
    Public ReadOnly Property srcNMaxConcentration(ByVal index As Integer) As Double
        Get
            Return CDbl(Me.cropInfo(index, 16))
        End Get
    End Property
    Public ReadOnly Property srcNDilutionSlope(ByVal index As Integer) As Double
        Get
            Return CDbl(Me.cropInfo(index, 17))
        End Get
    End Property
    Public ReadOnly Property srcKc(ByVal index As Integer) As Double
        Get
            Return CDbl(Me.cropInfo(index, 18))
        End Get
    End Property
    Public ReadOnly Property srcAnnualOrPerennial(ByVal index As Integer) As String
        Get
            Return CStr(Me.cropInfo(index, 19))
        End Get
    End Property
    Public ReadOnly Property srcLegume(ByVal index As Integer) As Boolean
        Get
            Return CBool(Me.cropInfo(index, 20))
        End Get
    End Property
    Public ReadOnly Property srcC3orC4(ByVal index As Integer) As String
        Get
            Return CStr(Me.cropInfo(index, 21))
        End Get
    End Property

End Class
