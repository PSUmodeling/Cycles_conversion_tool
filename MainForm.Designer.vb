Imports System.Collections
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ToolTip1 As System.Windows.Forms.ToolTip
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.fixedFertSetup_Mass = New System.Windows.Forms.TextBox
        Me.tillSetup_Depth = New System.Windows.Forms.TextBox
        Me.CropDescrip24 = New System.Windows.Forms.TextBox
        Me.CropDescrip15 = New System.Windows.Forms.TextBox
        Me.soil_curve = New System.Windows.Forms.TextBox
        Me.soil_slope = New System.Windows.Forms.TextBox
        Me.weatherFile_Path = New System.Windows.Forms.Label
        Me.duration_StopYear = New System.Windows.Forms.ComboBox
        Me.duration_StartYear = New System.Windows.Forms.ComboBox
        Me.autoIrrSetup_LastSoilLayer = New System.Windows.Forms.ComboBox
        Me.autoIrrSetup_WaterDepletion = New System.Windows.Forms.ComboBox
        Me.autoFertSetup_Mass = New System.Windows.Forms.TextBox
        Me.resultsFile_Path = New System.Windows.Forms.Label
        Me.CropDescrip27 = New System.Windows.Forms.TextBox
        Me.CropDescrip28 = New System.Windows.Forms.TextBox
        Me.CropDescrip14 = New System.Windows.Forms.TextBox
        Me.CropDescrip16 = New System.Windows.Forms.TextBox
        Me.CropDescrip17 = New System.Windows.Forms.TextBox
        Me.CropDescrip18 = New System.Windows.Forms.TextBox
        Me.CropDescrip19 = New System.Windows.Forms.TextBox
        Me.CropDescrip20 = New System.Windows.Forms.TextBox
        Me.CropDescrip21 = New System.Windows.Forms.TextBox
        Me.CropDescrip22 = New System.Windows.Forms.TextBox
        Me.CropDescrip26 = New System.Windows.Forms.TextBox
        Me.CropDescrip23 = New System.Windows.Forms.TextBox
        Me.CropDescrip25 = New System.Windows.Forms.TextBox
        Me.CropDescrip29 = New System.Windows.Forms.TextBox
        Me.CropDescrip30 = New System.Windows.Forms.TextBox
        Me.CropDescrip31 = New System.Windows.Forms.TextBox
        Me.fixedFertSetup_Day = New System.Windows.Forms.TextBox
        Me.autoFertSetup_EndDay = New System.Windows.Forms.TextBox
        Me.autoFertSetup_StartDay = New System.Windows.Forms.TextBox
        Me.fixedFertSetup_Year = New System.Windows.Forms.ComboBox
        Me.fixedIrrSetup_Year = New System.Windows.Forms.ComboBox
        Me.tillSetup_Year = New System.Windows.Forms.ComboBox
        Me.tillSetup_Day = New System.Windows.Forms.TextBox
        Me.plantingSetup_Year = New System.Windows.Forms.ComboBox
        Me.duration_RotationSize = New System.Windows.Forms.ComboBox
        Me.plantingSetup_Day = New System.Windows.Forms.TextBox
        Me.fixedIrrSetup_Day = New System.Windows.Forms.TextBox
        Me.autoIrrSetup_StopDay = New System.Windows.Forms.TextBox
        Me.autoIrrSetup_StartDay = New System.Windows.Forms.TextBox
        Me.CropDescrip4 = New System.Windows.Forms.TextBox
        Me.CropDescrip3 = New System.Windows.Forms.TextBox
        Me.CropDescrip2 = New System.Windows.Forms.TextBox
        Me.resultsFile_Overwrite = New System.Windows.Forms.CheckBox
        Me.fixedFertSetup_Layer = New System.Windows.Forms.ComboBox
        Me.tillSetup_SDR = New System.Windows.Forms.TextBox
        Me.tillSetup_ME = New System.Windows.Forms.TextBox
        Me.fixedFertSetup_C_Organic = New System.Windows.Forms.TextBox
        Me.fixedFertSetup_C_Charcoal = New System.Windows.Forms.TextBox
        Me.fixedFertSetup_N_Organic = New System.Windows.Forms.TextBox
        Me.fixedFertSetup_N_NH4 = New System.Windows.Forms.TextBox
        Me.fixedFertSetup_N_NO3 = New System.Windows.Forms.TextBox
        Me.fixedFertSetup_P_Organic = New System.Windows.Forms.TextBox
        Me.fixedFertSetup_P_Charcoal = New System.Windows.Forms.TextBox
        Me.fixedFertSetup_P_Inorganic = New System.Windows.Forms.TextBox
        Me.fixedFertSetup_K = New System.Windows.Forms.TextBox
        Me.fixedFertSetup_N_Charcoal = New System.Windows.Forms.TextBox
        Me.fixedFertSetup_S = New System.Windows.Forms.TextBox
        Me.autoFertSetup_S = New System.Windows.Forms.TextBox
        Me.autoFertSetup_N_Charcoal = New System.Windows.Forms.TextBox
        Me.autoFertSetup_K = New System.Windows.Forms.TextBox
        Me.autoFertSetup_P_Inorganic = New System.Windows.Forms.TextBox
        Me.autoFertSetup_P_Charcoal = New System.Windows.Forms.TextBox
        Me.autoFertSetup_P_Organic = New System.Windows.Forms.TextBox
        Me.autoFertSetup_N_NO3 = New System.Windows.Forms.TextBox
        Me.autoFertSetup_N_NH4 = New System.Windows.Forms.TextBox
        Me.autoFertSetup_N_Organic = New System.Windows.Forms.TextBox
        Me.autoFertSetup_C_Charcoal = New System.Windows.Forms.TextBox
        Me.autoFertSetup_C_Organic = New System.Windows.Forms.TextBox
        Me.autoFertSetup_Depth = New System.Windows.Forms.TextBox
        Me.btn_AddFixedFertOp = New System.Windows.Forms.Button
        Me.btn_AddFixedIrrOp = New System.Windows.Forms.Button
        Me.btn_AddTillageOp = New System.Windows.Forms.Button
        Me.btn_AddDescribedCrop = New System.Windows.Forms.Button
        Me.calcOptions_adjustedYields = New System.Windows.Forms.CheckBox
        Me.btn_AddAutoIrrOp = New System.Windows.Forms.Button
        Me.btn_AddPlantingEvent = New System.Windows.Forms.Button
        Me.plantingSetup_cropName = New System.Windows.Forms.ComboBox
        Me.btn_AddAutoFertOp = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AltRun = New System.Windows.Forms.ToolStripMenuItem
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ResetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SimulationControlsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SoilDescriptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CropDescriptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PlantingOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TillageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FixedIrrigationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AutomaticIrrigationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FixedFertilizationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AutomaticFertilizationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContactInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.Tab_Log = New System.Windows.Forms.TabPage
        Me.lv_logViewer = New System.Windows.Forms.ListView
        Me.Tab_FieldOperations = New System.Windows.Forms.TabPage
        Me.FieldOperationsTabControl = New System.Windows.Forms.TabControl
        Me.Tab_ActiveOperations = New System.Windows.Forms.TabPage
        Me.lv_ActiveFieldOperations = New System.Windows.Forms.ListView
        Me.Tab_Crops = New System.Windows.Forms.TabPage
        Me.btn_ChangePlantingEvent = New System.Windows.Forms.Button
        Me.grp_PlantedCrops = New System.Windows.Forms.GroupBox
        Me.lv_PlantedCrops = New System.Windows.Forms.ListView
        Me.grp_PlantingSetup = New System.Windows.Forms.GroupBox
        Me.plantingSetup_DefaultDay = New System.Windows.Forms.Label
        Me.plantingSetup_AutoFert = New System.Windows.Forms.CheckBox
        Me.plantingSetup_labelDefaultDay = New System.Windows.Forms.Label
        Me.plantingSetup_labelDay = New System.Windows.Forms.Label
        Me.plantingSetup_AutoIrr = New System.Windows.Forms.CheckBox
        Me.plantingSetup_labelYear = New System.Windows.Forms.Label
        Me.plantingSetup_labelName = New System.Windows.Forms.Label
        Me.Tab_Tillage = New System.Windows.Forms.TabPage
        Me.grp_TillSetup = New System.Windows.Forms.GroupBox
        Me.tillSetup_defaultME = New System.Windows.Forms.Label
        Me.tillSetup_defaultSDR = New System.Windows.Forms.Label
        Me.tillSetup_labelME = New System.Windows.Forms.Label
        Me.tillSetup_labelSDR = New System.Windows.Forms.Label
        Me.tillSetup_defaultDepth = New System.Windows.Forms.Label
        Me.tillSetup_Tool = New System.Windows.Forms.ComboBox
        Me.tillSetup_labelTool = New System.Windows.Forms.Label
        Me.tillSetup_labelDefaultDepth = New System.Windows.Forms.Label
        Me.tillSetup_labelYear = New System.Windows.Forms.Label
        Me.tillSetup_labelDay = New System.Windows.Forms.Label
        Me.tillSetup_labelDepth = New System.Windows.Forms.Label
        Me.grp_Tillage = New System.Windows.Forms.GroupBox
        Me.lv_Tillage = New System.Windows.Forms.ListView
        Me.btn_ChangeTillageOp = New System.Windows.Forms.Button
        Me.tillSetup_PerformOperations = New System.Windows.Forms.CheckBox
        Me.Tab_FixedIrrigation = New System.Windows.Forms.TabPage
        Me.grp_FixedIrrigation = New System.Windows.Forms.GroupBox
        Me.lv_FixedIrrigation = New System.Windows.Forms.ListView
        Me.fixedIrrSetup_PerformOperations = New System.Windows.Forms.CheckBox
        Me.grp_fixedIrrSetup = New System.Windows.Forms.GroupBox
        Me.fixedIrrSetup_Volume = New System.Windows.Forms.TextBox
        Me.fixedIrrSetup_labelYear = New System.Windows.Forms.Label
        Me.fixedIrrSetup_labelVolume = New System.Windows.Forms.Label
        Me.fixedIrrSetup_labelDay = New System.Windows.Forms.Label
        Me.btn_ChangeFixedIrrOp = New System.Windows.Forms.Button
        Me.Tab_FixedFertilization = New System.Windows.Forms.TabPage
        Me.grp_FixedFertSetup = New System.Windows.Forms.GroupBox
        Me.grp_FixedFertOps = New System.Windows.Forms.GroupBox
        Me.fixedFertSetup_Method = New System.Windows.Forms.ComboBox
        Me.fixedFertSetup_labelMethod = New System.Windows.Forms.Label
        Me.fixedFertSetup_labelS = New System.Windows.Forms.Label
        Me.fixedFertSetup_labelN_Charcoal = New System.Windows.Forms.Label
        Me.fixedFertSetup_labelK = New System.Windows.Forms.Label
        Me.fixedFertSetup_labelP_Inorganic = New System.Windows.Forms.Label
        Me.fixedFertSetup_labelP_Charcoal = New System.Windows.Forms.Label
        Me.fixedFertSetup_labelP_Organic = New System.Windows.Forms.Label
        Me.fixedFertSetup_labelN_NO3 = New System.Windows.Forms.Label
        Me.fixedFertSetup_labelN_NH4 = New System.Windows.Forms.Label
        Me.fixedFertSetup_LabelN_Organic = New System.Windows.Forms.Label
        Me.fixedFertSetup_labelC_Charcoal = New System.Windows.Forms.Label
        Me.fixedFertSetup_labelC_Organic = New System.Windows.Forms.Label
        Me.fixedFertSetup_Form = New System.Windows.Forms.ComboBox
        Me.fixedFertSetup_labelLayer = New System.Windows.Forms.Label
        Me.fixedFertSetup_labelForm = New System.Windows.Forms.Label
        Me.fixedFertSetup_labelMass = New System.Windows.Forms.Label
        Me.fixedFertSetup_labelYear = New System.Windows.Forms.Label
        Me.fixedFertSetup_labelDay = New System.Windows.Forms.Label
        Me.fixedFertSetup_Source = New System.Windows.Forms.ComboBox
        Me.fixedFertSetup_labelSource = New System.Windows.Forms.Label
        Me.grp_FixedFertilization = New System.Windows.Forms.GroupBox
        Me.lv_FixedFertilization = New System.Windows.Forms.ListView
        Me.btn_ChangeFixedFertOp = New System.Windows.Forms.Button
        Me.fixedFertSetup_PerformOperations = New System.Windows.Forms.CheckBox
        Me.Tab_AutoIrrigation = New System.Windows.Forms.TabPage
        Me.grp_AutomaticIrrigation = New System.Windows.Forms.GroupBox
        Me.lv_AutomaticIrrigation = New System.Windows.Forms.ListView
        Me.btn_ChangeAutoIrrOp = New System.Windows.Forms.Button
        Me.grp_AutoIrrSetup = New System.Windows.Forms.GroupBox
        Me.autoIrrSetup_DefaultEndDay = New System.Windows.Forms.Label
        Me.autoIrrSetup_labelDefaultEndDay = New System.Windows.Forms.Label
        Me.autoIrrSetup_DefaultStartDay = New System.Windows.Forms.Label
        Me.autoIrrSetup_labelDefaultStartDay = New System.Windows.Forms.Label
        Me.autoIrrSetup_labelName = New System.Windows.Forms.Label
        Me.autoIrrSetup_Name = New System.Windows.Forms.ComboBox
        Me.autoIrrSetup_labelWaterDepletion = New System.Windows.Forms.Label
        Me.autoIrrSetup_labelStartDay = New System.Windows.Forms.Label
        Me.autoIrrSetup_labelLastSoilLayer = New System.Windows.Forms.Label
        Me.autoIrrSetup_labelStopDay = New System.Windows.Forms.Label
        Me.autoIrrSetup_PerformOperations = New System.Windows.Forms.CheckBox
        Me.Tab_AutoFertilization = New System.Windows.Forms.TabPage
        Me.grp_AutoFertSetup = New System.Windows.Forms.GroupBox
        Me.autoFertSetup_DefaultEndDay = New System.Windows.Forms.Label
        Me.autoFertSetup_labelDefaultEndDay = New System.Windows.Forms.Label
        Me.autoFertSetup_DefaultStartDay = New System.Windows.Forms.Label
        Me.grp_AutoFertOps = New System.Windows.Forms.GroupBox
        Me.autoFertSetup_LabelSource = New System.Windows.Forms.Label
        Me.autoFertSetup_labelS = New System.Windows.Forms.Label
        Me.autoFertSetup_Source = New System.Windows.Forms.ComboBox
        Me.autoFertSetup_LabelMethod = New System.Windows.Forms.Label
        Me.autoFertSetup_labelN_Charcoal = New System.Windows.Forms.Label
        Me.autoFertSetup_LabelMass = New System.Windows.Forms.Label
        Me.autoFertSetup_labelK = New System.Windows.Forms.Label
        Me.autoFertSetup_LabelForm = New System.Windows.Forms.Label
        Me.autoFertSetup_labelP_Inorganic = New System.Windows.Forms.Label
        Me.autoFertSetup_labelP_Charcoal = New System.Windows.Forms.Label
        Me.autoFertSetup_labelP_Organic = New System.Windows.Forms.Label
        Me.autoFertSetup_Method = New System.Windows.Forms.ComboBox
        Me.autoFertSetup_labelN_NO3 = New System.Windows.Forms.Label
        Me.autoFertSetup_labelN_NH4 = New System.Windows.Forms.Label
        Me.autoFertSetup_Form = New System.Windows.Forms.ComboBox
        Me.autoFertSetup_labelN_Organic = New System.Windows.Forms.Label
        Me.autoFertSetup_labelC_Charcoal = New System.Windows.Forms.Label
        Me.autoFertSetup_labelC_Organic = New System.Windows.Forms.Label
        Me.autoFertSetup_labelDepth = New System.Windows.Forms.Label
        Me.autoFertSetup_labelDefaultStartDay = New System.Windows.Forms.Label
        Me.autoFertSetup_LabelStartDay = New System.Windows.Forms.Label
        Me.autoFertSetup_LabelEndDay = New System.Windows.Forms.Label
        Me.autoFertSetup_LabelName = New System.Windows.Forms.Label
        Me.autoFertSetup_Name = New System.Windows.Forms.ComboBox
        Me.grp_AutoFertilization = New System.Windows.Forms.GroupBox
        Me.lv_AutoFertilization = New System.Windows.Forms.ListView
        Me.btn_ChangeAutoFertOp = New System.Windows.Forms.Button
        Me.autoFertSetup_PerformOperations = New System.Windows.Forms.CheckBox
        Me.Tab_Crop = New System.Windows.Forms.TabPage
        Me.grp_CropAdvancedDescrip = New System.Windows.Forms.GroupBox
        Me.pnl_CropAdvancedDescrip = New System.Windows.Forms.Panel
        Me.CropLabel31 = New System.Windows.Forms.Label
        Me.CropDescrip34 = New System.Windows.Forms.ComboBox
        Me.CropLabel34 = New System.Windows.Forms.Label
        Me.CropLabel30 = New System.Windows.Forms.Label
        Me.CropLabel29 = New System.Windows.Forms.Label
        Me.CropDescrip33 = New System.Windows.Forms.ComboBox
        Me.CropLabel33 = New System.Windows.Forms.Label
        Me.CropLabel27 = New System.Windows.Forms.Label
        Me.CropLabel28 = New System.Windows.Forms.Label
        Me.CropDescrip32 = New System.Windows.Forms.ComboBox
        Me.CropLabel32 = New System.Windows.Forms.Label
        Me.CropLabel26 = New System.Windows.Forms.Label
        Me.CropLabel25 = New System.Windows.Forms.Label
        Me.CropLabel24 = New System.Windows.Forms.Label
        Me.CropLabel20 = New System.Windows.Forms.Label
        Me.CropLabel21 = New System.Windows.Forms.Label
        Me.CropLabel14 = New System.Windows.Forms.Label
        Me.CropLabel22 = New System.Windows.Forms.Label
        Me.CropLabel23 = New System.Windows.Forms.Label
        Me.CropLabel15 = New System.Windows.Forms.Label
        Me.CropLabel16 = New System.Windows.Forms.Label
        Me.CropLabel17 = New System.Windows.Forms.Label
        Me.CropLabel18 = New System.Windows.Forms.Label
        Me.CropLabel19 = New System.Windows.Forms.Label
        Me.grp_DescribedCrops = New System.Windows.Forms.GroupBox
        Me.lv_DescribedCrops = New System.Windows.Forms.ListView
        Me.grp_CropDescrip = New System.Windows.Forms.GroupBox
        Me.CropDescrip13 = New System.Windows.Forms.TextBox
        Me.CropDescrip12 = New System.Windows.Forms.TextBox
        Me.CropDescrip11 = New System.Windows.Forms.TextBox
        Me.CropDescrip10 = New System.Windows.Forms.TextBox
        Me.CropDescrip5 = New System.Windows.Forms.TextBox
        Me.Chkbx_UseAdvancedDescrip = New System.Windows.Forms.CheckBox
        Me.CropDescrip9 = New System.Windows.Forms.TextBox
        Me.CropDescrip8 = New System.Windows.Forms.TextBox
        Me.CropDescrip7 = New System.Windows.Forms.TextBox
        Me.CropDescrip6 = New System.Windows.Forms.TextBox
        Me.CropDescrip1 = New System.Windows.Forms.ComboBox
        Me.CropLabel13 = New System.Windows.Forms.Label
        Me.CropLabel12 = New System.Windows.Forms.Label
        Me.CropLabel11 = New System.Windows.Forms.Label
        Me.CropLabel7 = New System.Windows.Forms.Label
        Me.CropLabel8 = New System.Windows.Forms.Label
        Me.CropLabel9 = New System.Windows.Forms.Label
        Me.CropLabel10 = New System.Windows.Forms.Label
        Me.CropLabel1 = New System.Windows.Forms.Label
        Me.CropLabel2 = New System.Windows.Forms.Label
        Me.CropLabel3 = New System.Windows.Forms.Label
        Me.CropLabel4 = New System.Windows.Forms.Label
        Me.CropLabel5 = New System.Windows.Forms.Label
        Me.CropLabel6 = New System.Windows.Forms.Label
        Me.btn_ChangeDescribedCrop = New System.Windows.Forms.Button
        Me.Tab_Soil = New System.Windows.Forms.TabPage
        Me.soil_labelMaxLayer = New System.Windows.Forms.Label
        Me.soil_maxLayer = New System.Windows.Forms.ComboBox
        Me.grp_SoilProfile = New System.Windows.Forms.Panel
        Me.grp_LayerButtons = New System.Windows.Forms.Panel
        Me.soil_labelSlope = New System.Windows.Forms.Label
        Me.soil_labelCurve = New System.Windows.Forms.Label
        Me.Manual_PWP_ckbx = New System.Windows.Forms.CheckBox
        Me.Manual_BD_ckbx = New System.Windows.Forms.CheckBox
        Me.Manual_FC_ckbx = New System.Windows.Forms.CheckBox
        Me.soil_labelPWP1 = New System.Windows.Forms.Label
        Me.soil_labelSand1 = New System.Windows.Forms.Label
        Me.soil_labelSand2 = New System.Windows.Forms.Label
        Me.soil_labelIOM2 = New System.Windows.Forms.Label
        Me.soil_labelIOM3 = New System.Windows.Forms.Label
        Me.soil_labelFC1 = New System.Windows.Forms.Label
        Me.soil_labelFC2 = New System.Windows.Forms.Label
        Me.soil_labelFC3 = New System.Windows.Forms.Label
        Me.soil_labelPWP2 = New System.Windows.Forms.Label
        Me.soil_labelPWP3 = New System.Windows.Forms.Label
        Me.soil_labelNitrogen2 = New System.Windows.Forms.Label
        Me.soil_labelNitrogen3 = New System.Windows.Forms.Label
        Me.soil_labelAmmonium2 = New System.Windows.Forms.Label
        Me.soil_labelAmmonium3 = New System.Windows.Forms.Label
        Me.soil_labelNitrogen1 = New System.Windows.Forms.Label
        Me.soil_labelAmmonium1 = New System.Windows.Forms.Label
        Me.soil_labelLayerThickness1 = New System.Windows.Forms.Label
        Me.soil_labelLayerThickness2 = New System.Windows.Forms.Label
        Me.soil_labelLayerThickness3 = New System.Windows.Forms.Label
        Me.soil_labelCumDepth1 = New System.Windows.Forms.Label
        Me.soil_labelCumDepth2 = New System.Windows.Forms.Label
        Me.soil_labelClay1 = New System.Windows.Forms.Label
        Me.soil_labelIOM1 = New System.Windows.Forms.Label
        Me.soil_labelBD2 = New System.Windows.Forms.Label
        Me.soil_labelBD1 = New System.Windows.Forms.Label
        Me.soil_labelCumDepth3 = New System.Windows.Forms.Label
        Me.soil_labelClay2 = New System.Windows.Forms.Label
        Me.soil_labelBD3 = New System.Windows.Forms.Label
        Me.soil_labelLayer = New System.Windows.Forms.Label
        Me.Tier1TabControl = New System.Windows.Forms.TabControl
        Me.Tab_Field_Inputs = New System.Windows.Forms.TabPage
        Me.grp_OptionalReporting = New System.Windows.Forms.GroupBox
        Me.DailySoilCarbonReporting = New System.Windows.Forms.CheckBox
        Me.DailyResidueReporting = New System.Windows.Forms.CheckBox
        Me.SeasonReporting = New System.Windows.Forms.CheckBox
        Me.AnnualSoilProfileReporting = New System.Windows.Forms.CheckBox
        Me.AnnualSoilReporting = New System.Windows.Forms.CheckBox
        Me.DailyWeatherReporting = New System.Windows.Forms.CheckBox
        Me.DailyWaterReporting = New System.Windows.Forms.CheckBox
        Me.DailyNitrogenReporting = New System.Windows.Forms.CheckBox
        Me.DailySoilReporting = New System.Windows.Forms.CheckBox
        Me.DailyCropReporting = New System.Windows.Forms.CheckBox
        Me.grp_resultsFile = New System.Windows.Forms.GroupBox
        Me.resultsFile_selectFileBtn = New System.Windows.Forms.Button
        Me.resultsFile_labelPath = New System.Windows.Forms.Label
        Me.grp_CalculationOptions = New System.Windows.Forms.GroupBox
        Me.calcOptions_autoSulfur = New System.Windows.Forms.CheckBox
        Me.calcOptions_autoPhosphorus = New System.Windows.Forms.CheckBox
        Me.calcOptions_autoNitrogen = New System.Windows.Forms.CheckBox
        Me.calcOptions_waterInfiltration = New System.Windows.Forms.CheckBox
        Me.grp_Weatherfile = New System.Windows.Forms.GroupBox
        Me.weatherFile_selectFileBtn = New System.Windows.Forms.Button
        Me.weatherFile_labelPath = New System.Windows.Forms.Label
        Me.grp_Duration = New System.Windows.Forms.GroupBox
        Me.duration_TotalRotations = New System.Windows.Forms.Label
        Me.duration_TotalYears = New System.Windows.Forms.Label
        Me.duration_labelTotalRotations = New System.Windows.Forms.Label
        Me.duration_labelTotalYears = New System.Windows.Forms.Label
        Me.duration_labelTotalYearsError = New System.Windows.Forms.Label
        Me.duration_labelRotationSize = New System.Windows.Forms.Label
        Me.duration_labelStopYear = New System.Windows.Forms.Label
        Me.duration_labelStartYear = New System.Windows.Forms.Label
        Me.lbl_Weatherfile = New System.Windows.Forms.Label
        Me.inputErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Tab_Log.SuspendLayout()
        Me.Tab_FieldOperations.SuspendLayout()
        Me.FieldOperationsTabControl.SuspendLayout()
        Me.Tab_ActiveOperations.SuspendLayout()
        Me.Tab_Crops.SuspendLayout()
        Me.grp_PlantedCrops.SuspendLayout()
        Me.grp_PlantingSetup.SuspendLayout()
        Me.Tab_Tillage.SuspendLayout()
        Me.grp_TillSetup.SuspendLayout()
        Me.grp_Tillage.SuspendLayout()
        Me.Tab_FixedIrrigation.SuspendLayout()
        Me.grp_FixedIrrigation.SuspendLayout()
        Me.grp_fixedIrrSetup.SuspendLayout()
        Me.Tab_FixedFertilization.SuspendLayout()
        Me.grp_FixedFertSetup.SuspendLayout()
        Me.grp_FixedFertOps.SuspendLayout()
        Me.grp_FixedFertilization.SuspendLayout()
        Me.Tab_AutoIrrigation.SuspendLayout()
        Me.grp_AutomaticIrrigation.SuspendLayout()
        Me.grp_AutoIrrSetup.SuspendLayout()
        Me.Tab_AutoFertilization.SuspendLayout()
        Me.grp_AutoFertSetup.SuspendLayout()
        Me.grp_AutoFertOps.SuspendLayout()
        Me.grp_AutoFertilization.SuspendLayout()
        Me.Tab_Crop.SuspendLayout()
        Me.grp_CropAdvancedDescrip.SuspendLayout()
        Me.pnl_CropAdvancedDescrip.SuspendLayout()
        Me.grp_DescribedCrops.SuspendLayout()
        Me.grp_CropDescrip.SuspendLayout()
        Me.Tab_Soil.SuspendLayout()
        Me.grp_SoilProfile.SuspendLayout()
        Me.Tier1TabControl.SuspendLayout()
        Me.Tab_Field_Inputs.SuspendLayout()
        Me.grp_OptionalReporting.SuspendLayout()
        Me.grp_resultsFile.SuspendLayout()
        Me.grp_CalculationOptions.SuspendLayout()
        Me.grp_Weatherfile.SuspendLayout()
        Me.grp_Duration.SuspendLayout()
        CType(Me.inputErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        ToolTip1.AutoPopDelay = 10000
        ToolTip1.InitialDelay = 500
        ToolTip1.ReshowDelay = 50
        ToolTip1.ShowAlways = True
        '
        'fixedFertSetup_Mass
        '
        Me.fixedFertSetup_Mass.Location = New System.Drawing.Point(73, 31)
        Me.fixedFertSetup_Mass.Name = "fixedFertSetup_Mass"
        Me.fixedFertSetup_Mass.Size = New System.Drawing.Size(70, 20)
        Me.fixedFertSetup_Mass.TabIndex = 0
        Me.fixedFertSetup_Mass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.fixedFertSetup_Mass, "kg/ha")
        '
        'tillSetup_Depth
        '
        Me.tillSetup_Depth.Location = New System.Drawing.Point(133, 88)
        Me.tillSetup_Depth.Name = "tillSetup_Depth"
        Me.tillSetup_Depth.Size = New System.Drawing.Size(49, 20)
        Me.tillSetup_Depth.TabIndex = 3
        Me.tillSetup_Depth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.tillSetup_Depth, "Optional. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If not assigned the default value will be used.")
        '
        'CropDescrip24
        '
        Me.CropDescrip24.Enabled = False
        Me.CropDescrip24.Location = New System.Drawing.Point(220, 193)
        Me.CropDescrip24.Name = "CropDescrip24"
        Me.CropDescrip24.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip24.TabIndex = 10
        Me.CropDescrip24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip24, "g biomass/Kg water @ VPD = 1 kPa")
        '
        'CropDescrip15
        '
        Me.CropDescrip15.Enabled = False
        Me.CropDescrip15.Location = New System.Drawing.Point(220, 22)
        Me.CropDescrip15.Name = "CropDescrip15"
        Me.CropDescrip15.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip15.TabIndex = 1
        Me.CropDescrip15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip15, "°C")
        '
        'soil_curve
        '
        Me.soil_curve.Location = New System.Drawing.Point(133, 9)
        Me.soil_curve.Name = "soil_curve"
        Me.soil_curve.Size = New System.Drawing.Size(55, 20)
        Me.soil_curve.TabIndex = 0
        Me.soil_curve.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.soil_curve, "0 to 100")
        '
        'soil_slope
        '
        Me.soil_slope.AllowDrop = True
        Me.soil_slope.Location = New System.Drawing.Point(133, 28)
        Me.soil_slope.Name = "soil_slope"
        Me.soil_slope.Size = New System.Drawing.Size(55, 20)
        Me.soil_slope.TabIndex = 1
        Me.soil_slope.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.soil_slope, "0.0 to 0.9")
        '
        'weatherFile_Path
        '
        Me.weatherFile_Path.AllowDrop = True
        Me.weatherFile_Path.AutoEllipsis = True
        Me.weatherFile_Path.Location = New System.Drawing.Point(59, 18)
        Me.weatherFile_Path.Name = "weatherFile_Path"
        Me.weatherFile_Path.Size = New System.Drawing.Size(569, 13)
        Me.weatherFile_Path.TabIndex = 0
        ToolTip1.SetToolTip(Me.weatherFile_Path, "To select a weather file:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Double click field or use button to the right")
        '
        'duration_StopYear
        '
        Me.duration_StopYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.duration_StopYear.FormattingEnabled = True
        Me.duration_StopYear.Location = New System.Drawing.Point(191, 40)
        Me.duration_StopYear.MaxDropDownItems = 10
        Me.duration_StopYear.Name = "duration_StopYear"
        Me.duration_StopYear.Size = New System.Drawing.Size(58, 21)
        Me.duration_StopYear.TabIndex = 1
        Me.duration_StopYear.Tag = ""
        ToolTip1.SetToolTip(Me.duration_StopYear, "Based on weather file data")
        '
        'duration_StartYear
        '
        Me.duration_StartYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.duration_StartYear.FormattingEnabled = True
        Me.duration_StartYear.Location = New System.Drawing.Point(191, 20)
        Me.duration_StartYear.MaxDropDownItems = 10
        Me.duration_StartYear.Name = "duration_StartYear"
        Me.duration_StartYear.Size = New System.Drawing.Size(58, 21)
        Me.duration_StartYear.TabIndex = 0
        Me.duration_StartYear.Tag = ""
        ToolTip1.SetToolTip(Me.duration_StartYear, "Based on weather file data")
        '
        'autoIrrSetup_LastSoilLayer
        '
        Me.autoIrrSetup_LastSoilLayer.DisplayMember = "Integer"
        Me.autoIrrSetup_LastSoilLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.autoIrrSetup_LastSoilLayer.FormattingEnabled = True
        Me.autoIrrSetup_LastSoilLayer.Location = New System.Drawing.Point(223, 109)
        Me.autoIrrSetup_LastSoilLayer.MaxDropDownItems = 10
        Me.autoIrrSetup_LastSoilLayer.Name = "autoIrrSetup_LastSoilLayer"
        Me.autoIrrSetup_LastSoilLayer.Size = New System.Drawing.Size(59, 21)
        Me.autoIrrSetup_LastSoilLayer.TabIndex = 4
        ToolTip1.SetToolTip(Me.autoIrrSetup_LastSoilLayer, "Layers available set by Soil Description")
        Me.autoIrrSetup_LastSoilLayer.ValueMember = "Integer"
        '
        'autoIrrSetup_WaterDepletion
        '
        Me.autoIrrSetup_WaterDepletion.FormattingEnabled = True
        Me.autoIrrSetup_WaterDepletion.Location = New System.Drawing.Point(223, 89)
        Me.autoIrrSetup_WaterDepletion.MaxDropDownItems = 10
        Me.autoIrrSetup_WaterDepletion.Name = "autoIrrSetup_WaterDepletion"
        Me.autoIrrSetup_WaterDepletion.Size = New System.Drawing.Size(59, 21)
        Me.autoIrrSetup_WaterDepletion.TabIndex = 3
        ToolTip1.SetToolTip(Me.autoIrrSetup_WaterDepletion, "0 to 1")
        '
        'autoFertSetup_Mass
        '
        Me.autoFertSetup_Mass.Location = New System.Drawing.Point(72, 54)
        Me.autoFertSetup_Mass.Name = "autoFertSetup_Mass"
        Me.autoFertSetup_Mass.Size = New System.Drawing.Size(70, 20)
        Me.autoFertSetup_Mass.TabIndex = 1
        Me.autoFertSetup_Mass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_Mass, "kg/ha")
        '
        'resultsFile_Path
        '
        Me.resultsFile_Path.AutoEllipsis = True
        Me.resultsFile_Path.Location = New System.Drawing.Point(59, 18)
        Me.resultsFile_Path.Name = "resultsFile_Path"
        Me.resultsFile_Path.Size = New System.Drawing.Size(492, 13)
        Me.resultsFile_Path.TabIndex = 0
        ToolTip1.SetToolTip(Me.resultsFile_Path, "To select a results file:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Double click field")
        '
        'CropDescrip27
        '
        Me.CropDescrip27.Enabled = False
        Me.CropDescrip27.Location = New System.Drawing.Point(220, 250)
        Me.CropDescrip27.Name = "CropDescrip27"
        Me.CropDescrip27.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip27.TabIndex = 13
        Me.CropDescrip27.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip27, "use default")
        '
        'CropDescrip28
        '
        Me.CropDescrip28.Enabled = False
        Me.CropDescrip28.Location = New System.Drawing.Point(220, 269)
        Me.CropDescrip28.Name = "CropDescrip28"
        Me.CropDescrip28.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip28.TabIndex = 14
        Me.CropDescrip28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip28, "°C Day")
        '
        'CropDescrip14
        '
        Me.CropDescrip14.Enabled = False
        Me.CropDescrip14.Location = New System.Drawing.Point(220, 3)
        Me.CropDescrip14.Name = "CropDescrip14"
        Me.CropDescrip14.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip14.TabIndex = 0
        Me.CropDescrip14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip14, "°C")
        '
        'CropDescrip16
        '
        Me.CropDescrip16.Enabled = False
        Me.CropDescrip16.Location = New System.Drawing.Point(220, 41)
        Me.CropDescrip16.Name = "CropDescrip16"
        Me.CropDescrip16.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip16.TabIndex = 2
        Me.CropDescrip16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip16, "°C")
        '
        'CropDescrip17
        '
        Me.CropDescrip17.Enabled = False
        Me.CropDescrip17.Location = New System.Drawing.Point(220, 60)
        Me.CropDescrip17.Name = "CropDescrip17"
        Me.CropDescrip17.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip17.TabIndex = 3
        Me.CropDescrip17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip17, "°C")
        '
        'CropDescrip18
        '
        Me.CropDescrip18.Enabled = False
        Me.CropDescrip18.Location = New System.Drawing.Point(220, 79)
        Me.CropDescrip18.Name = "CropDescrip18"
        Me.CropDescrip18.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip18.TabIndex = 4
        Me.CropDescrip18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip18, "°C")
        '
        'CropDescrip19
        '
        Me.CropDescrip19.Enabled = False
        Me.CropDescrip19.Location = New System.Drawing.Point(220, 98)
        Me.CropDescrip19.Name = "CropDescrip19"
        Me.CropDescrip19.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip19.TabIndex = 5
        Me.CropDescrip19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip19, "°C")
        '
        'CropDescrip20
        '
        Me.CropDescrip20.Enabled = False
        Me.CropDescrip20.Location = New System.Drawing.Point(220, 117)
        Me.CropDescrip20.Name = "CropDescrip20"
        Me.CropDescrip20.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip20.TabIndex = 6
        Me.CropDescrip20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip20, "°C")
        '
        'CropDescrip21
        '
        Me.CropDescrip21.Enabled = False
        Me.CropDescrip21.Location = New System.Drawing.Point(220, 136)
        Me.CropDescrip21.Name = "CropDescrip21"
        Me.CropDescrip21.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip21.TabIndex = 7
        Me.CropDescrip21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip21, "g/g")
        '
        'CropDescrip22
        '
        Me.CropDescrip22.Enabled = False
        Me.CropDescrip22.Location = New System.Drawing.Point(220, 155)
        Me.CropDescrip22.Name = "CropDescrip22"
        Me.CropDescrip22.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip22.TabIndex = 8
        Me.CropDescrip22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip22, "g/g")
        '
        'CropDescrip26
        '
        Me.CropDescrip26.Enabled = False
        Me.CropDescrip26.Location = New System.Drawing.Point(220, 231)
        Me.CropDescrip26.Name = "CropDescrip26"
        Me.CropDescrip26.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip26.TabIndex = 12
        Me.CropDescrip26.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip26, "g grain/g above ground biomass")
        '
        'CropDescrip23
        '
        Me.CropDescrip23.Enabled = False
        Me.CropDescrip23.Location = New System.Drawing.Point(220, 174)
        Me.CropDescrip23.Name = "CropDescrip23"
        Me.CropDescrip23.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip23.TabIndex = 9
        Me.CropDescrip23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip23, "g biomass/MJ solar radiation")
        '
        'CropDescrip25
        '
        Me.CropDescrip25.Enabled = False
        Me.CropDescrip25.Location = New System.Drawing.Point(220, 212)
        Me.CropDescrip25.Name = "CropDescrip25"
        Me.CropDescrip25.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip25.TabIndex = 11
        Me.CropDescrip25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip25, "g grain/g above ground biomass")
        '
        'CropDescrip29
        '
        Me.CropDescrip29.Enabled = False
        Me.CropDescrip29.Location = New System.Drawing.Point(220, 288)
        Me.CropDescrip29.Name = "CropDescrip29"
        Me.CropDescrip29.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip29.TabIndex = 15
        Me.CropDescrip29.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip29, "g grain/g above ground biomass")
        '
        'CropDescrip30
        '
        Me.CropDescrip30.Enabled = False
        Me.CropDescrip30.Location = New System.Drawing.Point(220, 307)
        Me.CropDescrip30.Name = "CropDescrip30"
        Me.CropDescrip30.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip30.TabIndex = 16
        Me.CropDescrip30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip30, "g grain/g above ground biomass")
        '
        'CropDescrip31
        '
        Me.CropDescrip31.Enabled = False
        Me.CropDescrip31.Location = New System.Drawing.Point(220, 326)
        Me.CropDescrip31.Name = "CropDescrip31"
        Me.CropDescrip31.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip31.TabIndex = 17
        Me.CropDescrip31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip31, "g grain/g above ground biomass")
        '
        'fixedFertSetup_Day
        '
        Me.fixedFertSetup_Day.Location = New System.Drawing.Point(185, 45)
        Me.fixedFertSetup_Day.Name = "fixedFertSetup_Day"
        Me.fixedFertSetup_Day.Size = New System.Drawing.Size(53, 20)
        Me.fixedFertSetup_Day.TabIndex = 2
        Me.fixedFertSetup_Day.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.fixedFertSetup_Day, "1 to 366" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Double-click to select Year and Day via calender")
        '
        'autoFertSetup_EndDay
        '
        Me.autoFertSetup_EndDay.Location = New System.Drawing.Point(211, 46)
        Me.autoFertSetup_EndDay.Name = "autoFertSetup_EndDay"
        Me.autoFertSetup_EndDay.Size = New System.Drawing.Size(42, 20)
        Me.autoFertSetup_EndDay.TabIndex = 2
        Me.autoFertSetup_EndDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_EndDay, "1 to 366" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Optional. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If not assigned the default value will be used." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Double-c" & _
                "lick to select date via calender")
        '
        'autoFertSetup_StartDay
        '
        Me.autoFertSetup_StartDay.Location = New System.Drawing.Point(96, 46)
        Me.autoFertSetup_StartDay.Name = "autoFertSetup_StartDay"
        Me.autoFertSetup_StartDay.Size = New System.Drawing.Size(42, 20)
        Me.autoFertSetup_StartDay.TabIndex = 1
        Me.autoFertSetup_StartDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_StartDay, "1 to 366" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Optional. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If not assigned the default value will be used." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Double-c" & _
                "lick to select date via calender")
        '
        'fixedFertSetup_Year
        '
        Me.fixedFertSetup_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fixedFertSetup_Year.FormattingEnabled = True
        Me.fixedFertSetup_Year.Location = New System.Drawing.Point(90, 45)
        Me.fixedFertSetup_Year.MaxDropDownItems = 10
        Me.fixedFertSetup_Year.Name = "fixedFertSetup_Year"
        Me.fixedFertSetup_Year.Size = New System.Drawing.Size(53, 21)
        Me.fixedFertSetup_Year.TabIndex = 1
        ToolTip1.SetToolTip(Me.fixedFertSetup_Year, "Available list determined from Years in the Rotation on Simulation Controls." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dou" & _
                "ble-click to select Year and Day via calender")
        '
        'fixedIrrSetup_Year
        '
        Me.fixedIrrSetup_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fixedIrrSetup_Year.FormattingEnabled = True
        Me.fixedIrrSetup_Year.Location = New System.Drawing.Point(137, 31)
        Me.fixedIrrSetup_Year.MaxDropDownItems = 10
        Me.fixedIrrSetup_Year.Name = "fixedIrrSetup_Year"
        Me.fixedIrrSetup_Year.Size = New System.Drawing.Size(62, 21)
        Me.fixedIrrSetup_Year.TabIndex = 0
        ToolTip1.SetToolTip(Me.fixedIrrSetup_Year, "Available list determined from Years in the Rotation on Simulation Controls." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dou" & _
                "ble-click to select Year and Day via calender")
        '
        'tillSetup_Year
        '
        Me.tillSetup_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tillSetup_Year.FormattingEnabled = True
        Me.tillSetup_Year.Location = New System.Drawing.Point(13, 88)
        Me.tillSetup_Year.MaxDropDownItems = 10
        Me.tillSetup_Year.Name = "tillSetup_Year"
        Me.tillSetup_Year.Size = New System.Drawing.Size(62, 21)
        Me.tillSetup_Year.TabIndex = 1
        ToolTip1.SetToolTip(Me.tillSetup_Year, "Available list determined from Years in the Rotation on Simulation Controls." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dou" & _
                "ble-click to select Year and Day via calender")
        '
        'tillSetup_Day
        '
        Me.tillSetup_Day.Location = New System.Drawing.Point(81, 88)
        Me.tillSetup_Day.Name = "tillSetup_Day"
        Me.tillSetup_Day.Size = New System.Drawing.Size(46, 20)
        Me.tillSetup_Day.TabIndex = 2
        Me.tillSetup_Day.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.tillSetup_Day, "1 to 366" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Double-click to select Year and Day via calender")
        '
        'plantingSetup_Year
        '
        Me.plantingSetup_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.plantingSetup_Year.FormattingEnabled = True
        Me.plantingSetup_Year.Location = New System.Drawing.Point(130, 45)
        Me.plantingSetup_Year.MaxDropDownItems = 10
        Me.plantingSetup_Year.Name = "plantingSetup_Year"
        Me.plantingSetup_Year.Size = New System.Drawing.Size(58, 21)
        Me.plantingSetup_Year.TabIndex = 11
        ToolTip1.SetToolTip(Me.plantingSetup_Year, "Available list determined from Years in the Rotation on Simulation Controls." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dou" & _
                "ble-click to select Year and Day via calender")
        '
        'duration_RotationSize
        '
        Me.duration_RotationSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.duration_RotationSize.FormattingEnabled = True
        Me.duration_RotationSize.Location = New System.Drawing.Point(191, 60)
        Me.duration_RotationSize.MaxDropDownItems = 10
        Me.duration_RotationSize.Name = "duration_RotationSize"
        Me.duration_RotationSize.Size = New System.Drawing.Size(58, 21)
        Me.duration_RotationSize.TabIndex = 2
        ToolTip1.SetToolTip(Me.duration_RotationSize, resources.GetString("duration_RotationSize.ToolTip"))
        '
        'plantingSetup_Day
        '
        Me.plantingSetup_Day.Location = New System.Drawing.Point(130, 65)
        Me.plantingSetup_Day.Name = "plantingSetup_Day"
        Me.plantingSetup_Day.Size = New System.Drawing.Size(58, 20)
        Me.plantingSetup_Day.TabIndex = 10
        Me.plantingSetup_Day.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.plantingSetup_Day, "1 to 366" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Optional. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If not assigned the default value will be used." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Double-c" & _
                "lick to select Year and Day via calender")
        '
        'fixedIrrSetup_Day
        '
        Me.fixedIrrSetup_Day.Location = New System.Drawing.Point(137, 58)
        Me.fixedIrrSetup_Day.Name = "fixedIrrSetup_Day"
        Me.fixedIrrSetup_Day.Size = New System.Drawing.Size(62, 20)
        Me.fixedIrrSetup_Day.TabIndex = 6
        Me.fixedIrrSetup_Day.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.fixedIrrSetup_Day, "1 to 366" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Double-click to select Year and Day via calender")
        '
        'autoIrrSetup_StopDay
        '
        Me.autoIrrSetup_StopDay.Location = New System.Drawing.Point(135, 62)
        Me.autoIrrSetup_StopDay.Name = "autoIrrSetup_StopDay"
        Me.autoIrrSetup_StopDay.Size = New System.Drawing.Size(59, 20)
        Me.autoIrrSetup_StopDay.TabIndex = 11
        Me.autoIrrSetup_StopDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoIrrSetup_StopDay, "1 to 366" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Optional. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If not assigned the default value will be used." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Double-c" & _
                "lick to select date via calender")
        '
        'autoIrrSetup_StartDay
        '
        Me.autoIrrSetup_StartDay.Location = New System.Drawing.Point(135, 43)
        Me.autoIrrSetup_StartDay.Name = "autoIrrSetup_StartDay"
        Me.autoIrrSetup_StartDay.Size = New System.Drawing.Size(59, 20)
        Me.autoIrrSetup_StartDay.TabIndex = 10
        Me.autoIrrSetup_StartDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoIrrSetup_StartDay, "1 to 366" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Optional. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If not assigned the default value will be used." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Double-c" & _
                "lick to select date via calender")
        '
        'CropDescrip4
        '
        Me.CropDescrip4.Enabled = False
        Me.CropDescrip4.Location = New System.Drawing.Point(203, 109)
        Me.CropDescrip4.Name = "CropDescrip4"
        Me.CropDescrip4.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip4.TabIndex = 4
        Me.CropDescrip4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip4, "1 to 366" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Double-click to select date via calender")
        '
        'CropDescrip3
        '
        Me.CropDescrip3.Enabled = False
        Me.CropDescrip3.Location = New System.Drawing.Point(203, 90)
        Me.CropDescrip3.Name = "CropDescrip3"
        Me.CropDescrip3.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip3.TabIndex = 3
        Me.CropDescrip3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip3, "1 to 366" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Double-click to select date via calender")
        '
        'CropDescrip2
        '
        Me.CropDescrip2.Enabled = False
        Me.CropDescrip2.Location = New System.Drawing.Point(203, 71)
        Me.CropDescrip2.Name = "CropDescrip2"
        Me.CropDescrip2.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip2.TabIndex = 2
        Me.CropDescrip2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.CropDescrip2, "1 to 366" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Double-click to select date via calender")
        '
        'resultsFile_Overwrite
        '
        Me.resultsFile_Overwrite.AutoSize = True
        Me.resultsFile_Overwrite.Location = New System.Drawing.Point(592, 17)
        Me.resultsFile_Overwrite.Name = "resultsFile_Overwrite"
        Me.resultsFile_Overwrite.Size = New System.Drawing.Size(71, 17)
        Me.resultsFile_Overwrite.TabIndex = 1
        Me.resultsFile_Overwrite.Text = "Overwrite"
        ToolTip1.SetToolTip(Me.resultsFile_Overwrite, "Any pre-existing file will be deleted")
        Me.resultsFile_Overwrite.UseVisualStyleBackColor = True
        '
        'fixedFertSetup_Layer
        '
        Me.fixedFertSetup_Layer.Location = New System.Drawing.Point(73, 90)
        Me.fixedFertSetup_Layer.Name = "fixedFertSetup_Layer"
        Me.fixedFertSetup_Layer.Size = New System.Drawing.Size(70, 21)
        Me.fixedFertSetup_Layer.TabIndex = 3
        ToolTip1.SetToolTip(Me.fixedFertSetup_Layer, "Layer Zero = Surface")
        '
        'tillSetup_SDR
        '
        Me.tillSetup_SDR.Location = New System.Drawing.Point(188, 88)
        Me.tillSetup_SDR.Name = "tillSetup_SDR"
        Me.tillSetup_SDR.Size = New System.Drawing.Size(49, 20)
        Me.tillSetup_SDR.TabIndex = 4
        Me.tillSetup_SDR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.tillSetup_SDR, "Optional. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If not assigned the default value will be used.")
        '
        'tillSetup_ME
        '
        Me.tillSetup_ME.Location = New System.Drawing.Point(243, 88)
        Me.tillSetup_ME.Name = "tillSetup_ME"
        Me.tillSetup_ME.Size = New System.Drawing.Size(49, 20)
        Me.tillSetup_ME.TabIndex = 5
        Me.tillSetup_ME.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.tillSetup_ME, "Optional. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If not assigned the default value will be used.")
        '
        'fixedFertSetup_C_Organic
        '
        Me.fixedFertSetup_C_Organic.Location = New System.Drawing.Point(73, 110)
        Me.fixedFertSetup_C_Organic.Name = "fixedFertSetup_C_Organic"
        Me.fixedFertSetup_C_Organic.Size = New System.Drawing.Size(70, 20)
        Me.fixedFertSetup_C_Organic.TabIndex = 4
        Me.fixedFertSetup_C_Organic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.fixedFertSetup_C_Organic, "kg/ha")
        '
        'fixedFertSetup_C_Charcoal
        '
        Me.fixedFertSetup_C_Charcoal.Location = New System.Drawing.Point(73, 129)
        Me.fixedFertSetup_C_Charcoal.Name = "fixedFertSetup_C_Charcoal"
        Me.fixedFertSetup_C_Charcoal.Size = New System.Drawing.Size(70, 20)
        Me.fixedFertSetup_C_Charcoal.TabIndex = 5
        Me.fixedFertSetup_C_Charcoal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.fixedFertSetup_C_Charcoal, "kg/ha")
        '
        'fixedFertSetup_N_Organic
        '
        Me.fixedFertSetup_N_Organic.Location = New System.Drawing.Point(73, 148)
        Me.fixedFertSetup_N_Organic.Name = "fixedFertSetup_N_Organic"
        Me.fixedFertSetup_N_Organic.Size = New System.Drawing.Size(70, 20)
        Me.fixedFertSetup_N_Organic.TabIndex = 6
        Me.fixedFertSetup_N_Organic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.fixedFertSetup_N_Organic, "kg/ha")
        '
        'fixedFertSetup_N_NH4
        '
        Me.fixedFertSetup_N_NH4.Location = New System.Drawing.Point(215, 42)
        Me.fixedFertSetup_N_NH4.Name = "fixedFertSetup_N_NH4"
        Me.fixedFertSetup_N_NH4.Size = New System.Drawing.Size(70, 20)
        Me.fixedFertSetup_N_NH4.TabIndex = 8
        Me.fixedFertSetup_N_NH4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.fixedFertSetup_N_NH4, "kg/ha")
        '
        'fixedFertSetup_N_NO3
        '
        Me.fixedFertSetup_N_NO3.Location = New System.Drawing.Point(215, 61)
        Me.fixedFertSetup_N_NO3.Name = "fixedFertSetup_N_NO3"
        Me.fixedFertSetup_N_NO3.Size = New System.Drawing.Size(70, 20)
        Me.fixedFertSetup_N_NO3.TabIndex = 9
        Me.fixedFertSetup_N_NO3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.fixedFertSetup_N_NO3, "kg/ha")
        '
        'fixedFertSetup_P_Organic
        '
        Me.fixedFertSetup_P_Organic.Location = New System.Drawing.Point(215, 80)
        Me.fixedFertSetup_P_Organic.Name = "fixedFertSetup_P_Organic"
        Me.fixedFertSetup_P_Organic.Size = New System.Drawing.Size(70, 20)
        Me.fixedFertSetup_P_Organic.TabIndex = 10
        Me.fixedFertSetup_P_Organic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.fixedFertSetup_P_Organic, "kg/ha")
        '
        'fixedFertSetup_P_Charcoal
        '
        Me.fixedFertSetup_P_Charcoal.Location = New System.Drawing.Point(215, 99)
        Me.fixedFertSetup_P_Charcoal.Name = "fixedFertSetup_P_Charcoal"
        Me.fixedFertSetup_P_Charcoal.Size = New System.Drawing.Size(70, 20)
        Me.fixedFertSetup_P_Charcoal.TabIndex = 11
        Me.fixedFertSetup_P_Charcoal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.fixedFertSetup_P_Charcoal, "kg/ha")
        '
        'fixedFertSetup_P_Inorganic
        '
        Me.fixedFertSetup_P_Inorganic.Location = New System.Drawing.Point(215, 118)
        Me.fixedFertSetup_P_Inorganic.Name = "fixedFertSetup_P_Inorganic"
        Me.fixedFertSetup_P_Inorganic.Size = New System.Drawing.Size(70, 20)
        Me.fixedFertSetup_P_Inorganic.TabIndex = 12
        Me.fixedFertSetup_P_Inorganic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.fixedFertSetup_P_Inorganic, "kg/ha")
        '
        'fixedFertSetup_K
        '
        Me.fixedFertSetup_K.Location = New System.Drawing.Point(215, 137)
        Me.fixedFertSetup_K.Name = "fixedFertSetup_K"
        Me.fixedFertSetup_K.Size = New System.Drawing.Size(70, 20)
        Me.fixedFertSetup_K.TabIndex = 13
        Me.fixedFertSetup_K.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.fixedFertSetup_K, "kg/ha")
        '
        'fixedFertSetup_N_Charcoal
        '
        Me.fixedFertSetup_N_Charcoal.Location = New System.Drawing.Point(215, 23)
        Me.fixedFertSetup_N_Charcoal.Name = "fixedFertSetup_N_Charcoal"
        Me.fixedFertSetup_N_Charcoal.Size = New System.Drawing.Size(70, 20)
        Me.fixedFertSetup_N_Charcoal.TabIndex = 7
        Me.fixedFertSetup_N_Charcoal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.fixedFertSetup_N_Charcoal, "kg/ha")
        '
        'fixedFertSetup_S
        '
        Me.fixedFertSetup_S.Location = New System.Drawing.Point(215, 156)
        Me.fixedFertSetup_S.Name = "fixedFertSetup_S"
        Me.fixedFertSetup_S.Size = New System.Drawing.Size(70, 20)
        Me.fixedFertSetup_S.TabIndex = 14
        Me.fixedFertSetup_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.fixedFertSetup_S, "kg/ha")
        '
        'autoFertSetup_S
        '
        Me.autoFertSetup_S.Location = New System.Drawing.Point(214, 179)
        Me.autoFertSetup_S.Name = "autoFertSetup_S"
        Me.autoFertSetup_S.Size = New System.Drawing.Size(70, 20)
        Me.autoFertSetup_S.TabIndex = 15
        Me.autoFertSetup_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_S, "kg/ha")
        '
        'autoFertSetup_N_Charcoal
        '
        Me.autoFertSetup_N_Charcoal.Location = New System.Drawing.Point(214, 46)
        Me.autoFertSetup_N_Charcoal.Name = "autoFertSetup_N_Charcoal"
        Me.autoFertSetup_N_Charcoal.Size = New System.Drawing.Size(70, 20)
        Me.autoFertSetup_N_Charcoal.TabIndex = 8
        Me.autoFertSetup_N_Charcoal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_N_Charcoal, "kg/ha")
        '
        'autoFertSetup_K
        '
        Me.autoFertSetup_K.Location = New System.Drawing.Point(214, 160)
        Me.autoFertSetup_K.Name = "autoFertSetup_K"
        Me.autoFertSetup_K.Size = New System.Drawing.Size(70, 20)
        Me.autoFertSetup_K.TabIndex = 14
        Me.autoFertSetup_K.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_K, "kg/ha")
        '
        'autoFertSetup_P_Inorganic
        '
        Me.autoFertSetup_P_Inorganic.Location = New System.Drawing.Point(214, 141)
        Me.autoFertSetup_P_Inorganic.Name = "autoFertSetup_P_Inorganic"
        Me.autoFertSetup_P_Inorganic.Size = New System.Drawing.Size(70, 20)
        Me.autoFertSetup_P_Inorganic.TabIndex = 13
        Me.autoFertSetup_P_Inorganic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_P_Inorganic, "kg/ha")
        '
        'autoFertSetup_P_Charcoal
        '
        Me.autoFertSetup_P_Charcoal.Location = New System.Drawing.Point(214, 122)
        Me.autoFertSetup_P_Charcoal.Name = "autoFertSetup_P_Charcoal"
        Me.autoFertSetup_P_Charcoal.Size = New System.Drawing.Size(70, 20)
        Me.autoFertSetup_P_Charcoal.TabIndex = 12
        Me.autoFertSetup_P_Charcoal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_P_Charcoal, "kg/ha")
        '
        'autoFertSetup_P_Organic
        '
        Me.autoFertSetup_P_Organic.Location = New System.Drawing.Point(214, 103)
        Me.autoFertSetup_P_Organic.Name = "autoFertSetup_P_Organic"
        Me.autoFertSetup_P_Organic.Size = New System.Drawing.Size(70, 20)
        Me.autoFertSetup_P_Organic.TabIndex = 11
        Me.autoFertSetup_P_Organic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_P_Organic, "kg/ha")
        '
        'autoFertSetup_N_NO3
        '
        Me.autoFertSetup_N_NO3.Location = New System.Drawing.Point(214, 84)
        Me.autoFertSetup_N_NO3.Name = "autoFertSetup_N_NO3"
        Me.autoFertSetup_N_NO3.Size = New System.Drawing.Size(70, 20)
        Me.autoFertSetup_N_NO3.TabIndex = 10
        Me.autoFertSetup_N_NO3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_N_NO3, "kg/ha")
        '
        'autoFertSetup_N_NH4
        '
        Me.autoFertSetup_N_NH4.Location = New System.Drawing.Point(214, 65)
        Me.autoFertSetup_N_NH4.Name = "autoFertSetup_N_NH4"
        Me.autoFertSetup_N_NH4.Size = New System.Drawing.Size(70, 20)
        Me.autoFertSetup_N_NH4.TabIndex = 9
        Me.autoFertSetup_N_NH4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_N_NH4, "kg/ha")
        '
        'autoFertSetup_N_Organic
        '
        Me.autoFertSetup_N_Organic.Location = New System.Drawing.Point(72, 170)
        Me.autoFertSetup_N_Organic.Name = "autoFertSetup_N_Organic"
        Me.autoFertSetup_N_Organic.Size = New System.Drawing.Size(70, 20)
        Me.autoFertSetup_N_Organic.TabIndex = 7
        Me.autoFertSetup_N_Organic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_N_Organic, "kg/ha")
        '
        'autoFertSetup_C_Charcoal
        '
        Me.autoFertSetup_C_Charcoal.Location = New System.Drawing.Point(72, 151)
        Me.autoFertSetup_C_Charcoal.Name = "autoFertSetup_C_Charcoal"
        Me.autoFertSetup_C_Charcoal.Size = New System.Drawing.Size(70, 20)
        Me.autoFertSetup_C_Charcoal.TabIndex = 6
        Me.autoFertSetup_C_Charcoal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_C_Charcoal, "kg/ha")
        '
        'autoFertSetup_C_Organic
        '
        Me.autoFertSetup_C_Organic.Location = New System.Drawing.Point(72, 132)
        Me.autoFertSetup_C_Organic.Name = "autoFertSetup_C_Organic"
        Me.autoFertSetup_C_Organic.Size = New System.Drawing.Size(70, 20)
        Me.autoFertSetup_C_Organic.TabIndex = 5
        Me.autoFertSetup_C_Organic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_C_Organic, "kg/ha")
        '
        'autoFertSetup_Depth
        '
        Me.autoFertSetup_Depth.Location = New System.Drawing.Point(72, 113)
        Me.autoFertSetup_Depth.Name = "autoFertSetup_Depth"
        Me.autoFertSetup_Depth.Size = New System.Drawing.Size(70, 20)
        Me.autoFertSetup_Depth.TabIndex = 4
        Me.autoFertSetup_Depth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ToolTip1.SetToolTip(Me.autoFertSetup_Depth, "kg/ha")
        '
        'btn_AddFixedFertOp
        '
        Me.btn_AddFixedFertOp.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_AddFixedFertOp.Location = New System.Drawing.Point(312, 242)
        Me.btn_AddFixedFertOp.Name = "btn_AddFixedFertOp"
        Me.btn_AddFixedFertOp.Size = New System.Drawing.Size(54, 23)
        Me.btn_AddFixedFertOp.TabIndex = 2
        Me.btn_AddFixedFertOp.Text = "g"
        Me.btn_AddFixedFertOp.UseVisualStyleBackColor = True
        '
        'btn_AddFixedIrrOp
        '
        Me.btn_AddFixedIrrOp.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_AddFixedIrrOp.Location = New System.Drawing.Point(312, 242)
        Me.btn_AddFixedIrrOp.Name = "btn_AddFixedIrrOp"
        Me.btn_AddFixedIrrOp.Size = New System.Drawing.Size(54, 23)
        Me.btn_AddFixedIrrOp.TabIndex = 2
        Me.btn_AddFixedIrrOp.Text = "g"
        Me.btn_AddFixedIrrOp.UseVisualStyleBackColor = True
        '
        'btn_AddTillageOp
        '
        Me.btn_AddTillageOp.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_AddTillageOp.Location = New System.Drawing.Point(312, 242)
        Me.btn_AddTillageOp.Name = "btn_AddTillageOp"
        Me.btn_AddTillageOp.Size = New System.Drawing.Size(54, 23)
        Me.btn_AddTillageOp.TabIndex = 2
        Me.btn_AddTillageOp.Text = "g"
        Me.btn_AddTillageOp.UseVisualStyleBackColor = True
        '
        'btn_AddDescribedCrop
        '
        Me.btn_AddDescribedCrop.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_AddDescribedCrop.Location = New System.Drawing.Point(282, 332)
        Me.btn_AddDescribedCrop.Name = "btn_AddDescribedCrop"
        Me.btn_AddDescribedCrop.Size = New System.Drawing.Size(54, 23)
        Me.btn_AddDescribedCrop.TabIndex = 2
        Me.btn_AddDescribedCrop.Text = "i"
        Me.btn_AddDescribedCrop.UseVisualStyleBackColor = True
        '
        'calcOptions_adjustedYields
        '
        Me.calcOptions_adjustedYields.AutoSize = True
        Me.calcOptions_adjustedYields.Enabled = False
        Me.calcOptions_adjustedYields.Location = New System.Drawing.Point(97, 20)
        Me.calcOptions_adjustedYields.Name = "calcOptions_adjustedYields"
        Me.calcOptions_adjustedYields.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.calcOptions_adjustedYields.Size = New System.Drawing.Size(140, 17)
        Me.calcOptions_adjustedYields.TabIndex = 0
        Me.calcOptions_adjustedYields.Text = "Compute adjusted yields"
        Me.calcOptions_adjustedYields.UseVisualStyleBackColor = True
        '
        'btn_AddAutoIrrOp
        '
        Me.btn_AddAutoIrrOp.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_AddAutoIrrOp.Location = New System.Drawing.Point(312, 242)
        Me.btn_AddAutoIrrOp.Name = "btn_AddAutoIrrOp"
        Me.btn_AddAutoIrrOp.Size = New System.Drawing.Size(54, 23)
        Me.btn_AddAutoIrrOp.TabIndex = 2
        Me.btn_AddAutoIrrOp.Text = "g"
        Me.btn_AddAutoIrrOp.UseVisualStyleBackColor = True
        '
        'btn_AddPlantingEvent
        '
        Me.btn_AddPlantingEvent.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_AddPlantingEvent.Location = New System.Drawing.Point(312, 242)
        Me.btn_AddPlantingEvent.Name = "btn_AddPlantingEvent"
        Me.btn_AddPlantingEvent.Size = New System.Drawing.Size(54, 23)
        Me.btn_AddPlantingEvent.TabIndex = 1
        Me.btn_AddPlantingEvent.Text = "g"
        Me.btn_AddPlantingEvent.UseVisualStyleBackColor = True
        '
        'plantingSetup_cropName
        '
        Me.plantingSetup_cropName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.plantingSetup_cropName.FormattingEnabled = True
        Me.plantingSetup_cropName.Location = New System.Drawing.Point(130, 18)
        Me.plantingSetup_cropName.MaxDropDownItems = 10
        Me.plantingSetup_cropName.Name = "plantingSetup_cropName"
        Me.plantingSetup_cropName.Size = New System.Drawing.Size(102, 21)
        Me.plantingSetup_cropName.TabIndex = 0
        Me.plantingSetup_cropName.Tag = ""
        '
        'btn_AddAutoFertOp
        '
        Me.btn_AddAutoFertOp.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_AddAutoFertOp.Location = New System.Drawing.Point(312, 242)
        Me.btn_AddAutoFertOp.Name = "btn_AddAutoFertOp"
        Me.btn_AddAutoFertOp.Size = New System.Drawing.Size(54, 23)
        Me.btn_AddAutoFertOp.TabIndex = 1
        Me.btn_AddAutoFertOp.Text = "g"
        Me.btn_AddAutoFertOp.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Highlight
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(683, 22)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunToolStripMenuItem, Me.ExitToolStripMenuItem, Me.AltRun})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 18)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'RunToolStripMenuItem
        '
        Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
        Me.RunToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.RunToolStripMenuItem.Text = "Run"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AltRun
        '
        Me.AltRun.Name = "AltRun"
        Me.AltRun.Size = New System.Drawing.Size(184, 22)
        Me.AltRun.Text = "Run with Direct Read"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportToolStripMenuItem, Me.ExportToolStripMenuItem, Me.ResetToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(58, 18)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'ResetToolStripMenuItem
        '
        Me.ResetToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SimulationControlsToolStripMenuItem, Me.SoilDescriptionToolStripMenuItem, Me.CropDescriptionsToolStripMenuItem, Me.PlantingOrderToolStripMenuItem, Me.TillageToolStripMenuItem, Me.FixedIrrigationToolStripMenuItem, Me.AutomaticIrrigationToolStripMenuItem, Me.FixedFertilizationToolStripMenuItem, Me.AutomaticFertilizationToolStripMenuItem, Me.AllToolStripMenuItem})
        Me.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem"
        Me.ResetToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ResetToolStripMenuItem.Text = "Reset"
        '
        'SimulationControlsToolStripMenuItem
        '
        Me.SimulationControlsToolStripMenuItem.Name = "SimulationControlsToolStripMenuItem"
        Me.SimulationControlsToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.SimulationControlsToolStripMenuItem.Text = "Simulation Controls"
        '
        'SoilDescriptionToolStripMenuItem
        '
        Me.SoilDescriptionToolStripMenuItem.Name = "SoilDescriptionToolStripMenuItem"
        Me.SoilDescriptionToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.SoilDescriptionToolStripMenuItem.Text = "Soil Description"
        '
        'CropDescriptionsToolStripMenuItem
        '
        Me.CropDescriptionsToolStripMenuItem.Name = "CropDescriptionsToolStripMenuItem"
        Me.CropDescriptionsToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.CropDescriptionsToolStripMenuItem.Text = "Crop Descriptions"
        '
        'PlantingOrderToolStripMenuItem
        '
        Me.PlantingOrderToolStripMenuItem.Name = "PlantingOrderToolStripMenuItem"
        Me.PlantingOrderToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.PlantingOrderToolStripMenuItem.Text = "Planting Order"
        '
        'TillageToolStripMenuItem
        '
        Me.TillageToolStripMenuItem.Name = "TillageToolStripMenuItem"
        Me.TillageToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.TillageToolStripMenuItem.Text = "Tillage"
        '
        'FixedIrrigationToolStripMenuItem
        '
        Me.FixedIrrigationToolStripMenuItem.Name = "FixedIrrigationToolStripMenuItem"
        Me.FixedIrrigationToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.FixedIrrigationToolStripMenuItem.Text = "Fixed Irrigation"
        '
        'AutomaticIrrigationToolStripMenuItem
        '
        Me.AutomaticIrrigationToolStripMenuItem.Name = "AutomaticIrrigationToolStripMenuItem"
        Me.AutomaticIrrigationToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.AutomaticIrrigationToolStripMenuItem.Text = "Automatic Irrigation"
        '
        'FixedFertilizationToolStripMenuItem
        '
        Me.FixedFertilizationToolStripMenuItem.Name = "FixedFertilizationToolStripMenuItem"
        Me.FixedFertilizationToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.FixedFertilizationToolStripMenuItem.Text = "Fixed Fertilization"
        '
        'AutomaticFertilizationToolStripMenuItem
        '
        Me.AutomaticFertilizationToolStripMenuItem.Name = "AutomaticFertilizationToolStripMenuItem"
        Me.AutomaticFertilizationToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.AutomaticFertilizationToolStripMenuItem.Text = "Automatic Fertilization"
        '
        'AllToolStripMenuItem
        '
        Me.AllToolStripMenuItem.Name = "AllToolStripMenuItem"
        Me.AllToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.AllToolStripMenuItem.Text = "All"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContactInformationToolStripMenuItem, Me.AboutToolStripMenuItem, Me.HelpToolStripMenuItem1})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 18)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ContactInformationToolStripMenuItem
        '
        Me.ContactInformationToolStripMenuItem.Name = "ContactInformationToolStripMenuItem"
        Me.ContactInformationToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.ContactInformationToolStripMenuItem.Text = "Contact Information"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(175, 22)
        Me.HelpToolStripMenuItem1.Text = "Help"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel, Me.ProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 591)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(683, 22)
        Me.StatusStrip1.TabIndex = 0
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(38, 17)
        Me.StatusLabel.Text = "Status"
        '
        'ProgressBar
        '
        Me.ProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ProgressBar.Size = New System.Drawing.Size(475, 16)
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.Visible = False
        '
        'Tab_Log
        '
        Me.Tab_Log.Controls.Add(Me.lv_logViewer)
        Me.Tab_Log.Location = New System.Drawing.Point(4, 22)
        Me.Tab_Log.Name = "Tab_Log"
        Me.Tab_Log.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Log.Size = New System.Drawing.Size(680, 547)
        Me.Tab_Log.TabIndex = 4
        Me.Tab_Log.Text = "Log"
        Me.Tab_Log.UseVisualStyleBackColor = True
        '
        'lv_logViewer
        '
        Me.lv_logViewer.FullRowSelect = True
        Me.lv_logViewer.Location = New System.Drawing.Point(3, 3)
        Me.lv_logViewer.Name = "lv_logViewer"
        Me.lv_logViewer.Size = New System.Drawing.Size(671, 540)
        Me.lv_logViewer.TabIndex = 0
        Me.lv_logViewer.TabStop = False
        Me.lv_logViewer.UseCompatibleStateImageBehavior = False
        '
        'Tab_FieldOperations
        '
        Me.Tab_FieldOperations.Controls.Add(Me.FieldOperationsTabControl)
        Me.Tab_FieldOperations.Location = New System.Drawing.Point(4, 22)
        Me.Tab_FieldOperations.Name = "Tab_FieldOperations"
        Me.Tab_FieldOperations.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_FieldOperations.Size = New System.Drawing.Size(680, 547)
        Me.Tab_FieldOperations.TabIndex = 2
        Me.Tab_FieldOperations.Text = "Field Operations"
        Me.Tab_FieldOperations.UseVisualStyleBackColor = True
        '
        'FieldOperationsTabControl
        '
        Me.FieldOperationsTabControl.Controls.Add(Me.Tab_ActiveOperations)
        Me.FieldOperationsTabControl.Controls.Add(Me.Tab_Crops)
        Me.FieldOperationsTabControl.Controls.Add(Me.Tab_Tillage)
        Me.FieldOperationsTabControl.Controls.Add(Me.Tab_FixedIrrigation)
        Me.FieldOperationsTabControl.Controls.Add(Me.Tab_FixedFertilization)
        Me.FieldOperationsTabControl.Controls.Add(Me.Tab_AutoIrrigation)
        Me.FieldOperationsTabControl.Controls.Add(Me.Tab_AutoFertilization)
        Me.FieldOperationsTabControl.Location = New System.Drawing.Point(-4, -1)
        Me.FieldOperationsTabControl.Name = "FieldOperationsTabControl"
        Me.FieldOperationsTabControl.SelectedIndex = 0
        Me.FieldOperationsTabControl.Size = New System.Drawing.Size(688, 552)
        Me.FieldOperationsTabControl.TabIndex = 0
        '
        'Tab_ActiveOperations
        '
        Me.Tab_ActiveOperations.Controls.Add(Me.lv_ActiveFieldOperations)
        Me.Tab_ActiveOperations.Location = New System.Drawing.Point(4, 22)
        Me.Tab_ActiveOperations.Name = "Tab_ActiveOperations"
        Me.Tab_ActiveOperations.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_ActiveOperations.Size = New System.Drawing.Size(680, 526)
        Me.Tab_ActiveOperations.TabIndex = 4
        Me.Tab_ActiveOperations.Text = "Active Operations"
        Me.Tab_ActiveOperations.UseVisualStyleBackColor = True
        '
        'lv_ActiveFieldOperations
        '
        Me.lv_ActiveFieldOperations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_ActiveFieldOperations.FullRowSelect = True
        Me.lv_ActiveFieldOperations.Location = New System.Drawing.Point(3, 3)
        Me.lv_ActiveFieldOperations.Name = "lv_ActiveFieldOperations"
        Me.lv_ActiveFieldOperations.Size = New System.Drawing.Size(674, 520)
        Me.lv_ActiveFieldOperations.TabIndex = 0
        Me.lv_ActiveFieldOperations.TabStop = False
        Me.lv_ActiveFieldOperations.UseCompatibleStateImageBehavior = False
        '
        'Tab_Crops
        '
        Me.Tab_Crops.Controls.Add(Me.btn_AddPlantingEvent)
        Me.Tab_Crops.Controls.Add(Me.btn_ChangePlantingEvent)
        Me.Tab_Crops.Controls.Add(Me.grp_PlantedCrops)
        Me.Tab_Crops.Controls.Add(Me.grp_PlantingSetup)
        Me.Tab_Crops.Location = New System.Drawing.Point(4, 22)
        Me.Tab_Crops.Name = "Tab_Crops"
        Me.Tab_Crops.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Crops.Size = New System.Drawing.Size(680, 526)
        Me.Tab_Crops.TabIndex = 5
        Me.Tab_Crops.Text = "Planting Order"
        Me.Tab_Crops.UseVisualStyleBackColor = True
        '
        'btn_ChangePlantingEvent
        '
        Me.btn_ChangePlantingEvent.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_ChangePlantingEvent.Location = New System.Drawing.Point(312, 271)
        Me.btn_ChangePlantingEvent.Name = "btn_ChangePlantingEvent"
        Me.btn_ChangePlantingEvent.Size = New System.Drawing.Size(54, 23)
        Me.btn_ChangePlantingEvent.TabIndex = 2
        Me.btn_ChangePlantingEvent.Text = "f"
        Me.btn_ChangePlantingEvent.UseVisualStyleBackColor = True
        '
        'grp_PlantedCrops
        '
        Me.grp_PlantedCrops.Controls.Add(Me.lv_PlantedCrops)
        Me.grp_PlantedCrops.Location = New System.Drawing.Point(372, 6)
        Me.grp_PlantedCrops.Name = "grp_PlantedCrops"
        Me.grp_PlantedCrops.Size = New System.Drawing.Size(302, 514)
        Me.grp_PlantedCrops.TabIndex = 3
        Me.grp_PlantedCrops.TabStop = False
        Me.grp_PlantedCrops.Text = "Active Operations: 0"
        '
        'lv_PlantedCrops
        '
        Me.lv_PlantedCrops.BackColor = System.Drawing.SystemColors.Window
        Me.lv_PlantedCrops.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_PlantedCrops.FullRowSelect = True
        Me.lv_PlantedCrops.Location = New System.Drawing.Point(3, 16)
        Me.lv_PlantedCrops.MultiSelect = False
        Me.lv_PlantedCrops.Name = "lv_PlantedCrops"
        Me.lv_PlantedCrops.Size = New System.Drawing.Size(296, 495)
        Me.lv_PlantedCrops.TabIndex = 0
        Me.lv_PlantedCrops.UseCompatibleStateImageBehavior = False
        '
        'grp_PlantingSetup
        '
        Me.grp_PlantingSetup.Controls.Add(Me.plantingSetup_DefaultDay)
        Me.grp_PlantingSetup.Controls.Add(Me.plantingSetup_Year)
        Me.grp_PlantingSetup.Controls.Add(Me.plantingSetup_Day)
        Me.grp_PlantingSetup.Controls.Add(Me.plantingSetup_AutoFert)
        Me.grp_PlantingSetup.Controls.Add(Me.plantingSetup_labelDefaultDay)
        Me.grp_PlantingSetup.Controls.Add(Me.plantingSetup_labelDay)
        Me.grp_PlantingSetup.Controls.Add(Me.plantingSetup_AutoIrr)
        Me.grp_PlantingSetup.Controls.Add(Me.plantingSetup_labelYear)
        Me.grp_PlantingSetup.Controls.Add(Me.plantingSetup_labelName)
        Me.grp_PlantingSetup.Controls.Add(Me.plantingSetup_cropName)
        Me.grp_PlantingSetup.Location = New System.Drawing.Point(3, 199)
        Me.grp_PlantingSetup.Name = "grp_PlantingSetup"
        Me.grp_PlantingSetup.Size = New System.Drawing.Size(303, 136)
        Me.grp_PlantingSetup.TabIndex = 0
        Me.grp_PlantingSetup.TabStop = False
        Me.grp_PlantingSetup.Text = "Operation Setup"
        '
        'plantingSetup_DefaultDay
        '
        Me.plantingSetup_DefaultDay.AutoSize = True
        Me.plantingSetup_DefaultDay.Location = New System.Drawing.Point(235, 68)
        Me.plantingSetup_DefaultDay.Name = "plantingSetup_DefaultDay"
        Me.plantingSetup_DefaultDay.Size = New System.Drawing.Size(0, 13)
        Me.plantingSetup_DefaultDay.TabIndex = 12
        '
        'plantingSetup_AutoFert
        '
        Me.plantingSetup_AutoFert.AutoSize = True
        Me.plantingSetup_AutoFert.Location = New System.Drawing.Point(130, 110)
        Me.plantingSetup_AutoFert.Name = "plantingSetup_AutoFert"
        Me.plantingSetup_AutoFert.Size = New System.Drawing.Size(103, 17)
        Me.plantingSetup_AutoFert.TabIndex = 9
        Me.plantingSetup_AutoFert.Text = "Auto Fertilization"
        Me.plantingSetup_AutoFert.UseVisualStyleBackColor = True
        '
        'plantingSetup_labelDefaultDay
        '
        Me.plantingSetup_labelDefaultDay.AutoSize = True
        Me.plantingSetup_labelDefaultDay.Location = New System.Drawing.Point(194, 68)
        Me.plantingSetup_labelDefaultDay.Name = "plantingSetup_labelDefaultDay"
        Me.plantingSetup_labelDefaultDay.Size = New System.Drawing.Size(44, 13)
        Me.plantingSetup_labelDefaultDay.TabIndex = 7
        Me.plantingSetup_labelDefaultDay.Text = "Default:"
        Me.plantingSetup_labelDefaultDay.Visible = False
        '
        'plantingSetup_labelDay
        '
        Me.plantingSetup_labelDay.AutoSize = True
        Me.plantingSetup_labelDay.Location = New System.Drawing.Point(98, 68)
        Me.plantingSetup_labelDay.Name = "plantingSetup_labelDay"
        Me.plantingSetup_labelDay.Size = New System.Drawing.Size(26, 13)
        Me.plantingSetup_labelDay.TabIndex = 6
        Me.plantingSetup_labelDay.Text = "Day"
        '
        'plantingSetup_AutoIrr
        '
        Me.plantingSetup_AutoIrr.AutoSize = True
        Me.plantingSetup_AutoIrr.Location = New System.Drawing.Point(130, 91)
        Me.plantingSetup_AutoIrr.Name = "plantingSetup_AutoIrr"
        Me.plantingSetup_AutoIrr.Size = New System.Drawing.Size(91, 17)
        Me.plantingSetup_AutoIrr.TabIndex = 8
        Me.plantingSetup_AutoIrr.Text = "Auto Irrigation"
        Me.plantingSetup_AutoIrr.UseVisualStyleBackColor = True
        '
        'plantingSetup_labelYear
        '
        Me.plantingSetup_labelYear.AutoSize = True
        Me.plantingSetup_labelYear.Location = New System.Drawing.Point(95, 49)
        Me.plantingSetup_labelYear.Name = "plantingSetup_labelYear"
        Me.plantingSetup_labelYear.Size = New System.Drawing.Size(29, 13)
        Me.plantingSetup_labelYear.TabIndex = 5
        Me.plantingSetup_labelYear.Text = "Year"
        '
        'plantingSetup_labelName
        '
        Me.plantingSetup_labelName.AutoSize = True
        Me.plantingSetup_labelName.Location = New System.Drawing.Point(64, 21)
        Me.plantingSetup_labelName.Name = "plantingSetup_labelName"
        Me.plantingSetup_labelName.Size = New System.Drawing.Size(60, 13)
        Me.plantingSetup_labelName.TabIndex = 4
        Me.plantingSetup_labelName.Text = "Crop Name"
        '
        'Tab_Tillage
        '
        Me.Tab_Tillage.Controls.Add(Me.grp_TillSetup)
        Me.Tab_Tillage.Controls.Add(Me.grp_Tillage)
        Me.Tab_Tillage.Controls.Add(Me.btn_AddTillageOp)
        Me.Tab_Tillage.Controls.Add(Me.btn_ChangeTillageOp)
        Me.Tab_Tillage.Controls.Add(Me.tillSetup_PerformOperations)
        Me.Tab_Tillage.Location = New System.Drawing.Point(4, 22)
        Me.Tab_Tillage.Name = "Tab_Tillage"
        Me.Tab_Tillage.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Tillage.Size = New System.Drawing.Size(680, 526)
        Me.Tab_Tillage.TabIndex = 3
        Me.Tab_Tillage.Text = "Tillage"
        Me.Tab_Tillage.UseVisualStyleBackColor = True
        '
        'grp_TillSetup
        '
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_ME)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_SDR)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_defaultME)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_defaultSDR)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_labelME)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_labelSDR)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_defaultDepth)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_Tool)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_labelTool)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_Day)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_Year)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_Depth)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_labelDefaultDepth)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_labelYear)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_labelDay)
        Me.grp_TillSetup.Controls.Add(Me.tillSetup_labelDepth)
        Me.grp_TillSetup.Location = New System.Drawing.Point(3, 199)
        Me.grp_TillSetup.Name = "grp_TillSetup"
        Me.grp_TillSetup.Size = New System.Drawing.Size(303, 136)
        Me.grp_TillSetup.TabIndex = 1
        Me.grp_TillSetup.TabStop = False
        Me.grp_TillSetup.Text = "Operation Setup"
        '
        'tillSetup_defaultME
        '
        Me.tillSetup_defaultME.AutoSize = True
        Me.tillSetup_defaultME.Location = New System.Drawing.Point(242, 111)
        Me.tillSetup_defaultME.Name = "tillSetup_defaultME"
        Me.tillSetup_defaultME.Size = New System.Drawing.Size(0, 13)
        Me.tillSetup_defaultME.TabIndex = 15
        '
        'tillSetup_defaultSDR
        '
        Me.tillSetup_defaultSDR.AutoSize = True
        Me.tillSetup_defaultSDR.Location = New System.Drawing.Point(187, 111)
        Me.tillSetup_defaultSDR.Name = "tillSetup_defaultSDR"
        Me.tillSetup_defaultSDR.Size = New System.Drawing.Size(0, 13)
        Me.tillSetup_defaultSDR.TabIndex = 14
        '
        'tillSetup_labelME
        '
        Me.tillSetup_labelME.AutoSize = True
        Me.tillSetup_labelME.Location = New System.Drawing.Point(257, 72)
        Me.tillSetup_labelME.Name = "tillSetup_labelME"
        Me.tillSetup_labelME.Size = New System.Drawing.Size(23, 13)
        Me.tillSetup_labelME.TabIndex = 11
        Me.tillSetup_labelME.Text = "ME"
        '
        'tillSetup_labelSDR
        '
        Me.tillSetup_labelSDR.AutoSize = True
        Me.tillSetup_labelSDR.Location = New System.Drawing.Point(198, 72)
        Me.tillSetup_labelSDR.Name = "tillSetup_labelSDR"
        Me.tillSetup_labelSDR.Size = New System.Drawing.Size(30, 13)
        Me.tillSetup_labelSDR.TabIndex = 10
        Me.tillSetup_labelSDR.Text = "SDR"
        '
        'tillSetup_defaultDepth
        '
        Me.tillSetup_defaultDepth.AutoSize = True
        Me.tillSetup_defaultDepth.Location = New System.Drawing.Point(131, 111)
        Me.tillSetup_defaultDepth.Name = "tillSetup_defaultDepth"
        Me.tillSetup_defaultDepth.Size = New System.Drawing.Size(0, 13)
        Me.tillSetup_defaultDepth.TabIndex = 13
        '
        'tillSetup_Tool
        '
        Me.tillSetup_Tool.FormattingEnabled = True
        Me.tillSetup_Tool.Location = New System.Drawing.Point(13, 43)
        Me.tillSetup_Tool.MaxDropDownItems = 10
        Me.tillSetup_Tool.Name = "tillSetup_Tool"
        Me.tillSetup_Tool.Size = New System.Drawing.Size(279, 21)
        Me.tillSetup_Tool.TabIndex = 0
        '
        'tillSetup_labelTool
        '
        Me.tillSetup_labelTool.AutoSize = True
        Me.tillSetup_labelTool.Location = New System.Drawing.Point(136, 27)
        Me.tillSetup_labelTool.Name = "tillSetup_labelTool"
        Me.tillSetup_labelTool.Size = New System.Drawing.Size(28, 13)
        Me.tillSetup_labelTool.TabIndex = 6
        Me.tillSetup_labelTool.Text = "Tool"
        '
        'tillSetup_labelDefaultDepth
        '
        Me.tillSetup_labelDefaultDepth.AutoSize = True
        Me.tillSetup_labelDefaultDepth.Location = New System.Drawing.Point(83, 111)
        Me.tillSetup_labelDefaultDepth.Name = "tillSetup_labelDefaultDepth"
        Me.tillSetup_labelDefaultDepth.Size = New System.Drawing.Size(44, 13)
        Me.tillSetup_labelDefaultDepth.TabIndex = 12
        Me.tillSetup_labelDefaultDepth.Text = "Default:"
        Me.tillSetup_labelDefaultDepth.Visible = False
        '
        'tillSetup_labelYear
        '
        Me.tillSetup_labelYear.AutoSize = True
        Me.tillSetup_labelYear.Location = New System.Drawing.Point(27, 72)
        Me.tillSetup_labelYear.Name = "tillSetup_labelYear"
        Me.tillSetup_labelYear.Size = New System.Drawing.Size(29, 13)
        Me.tillSetup_labelYear.TabIndex = 7
        Me.tillSetup_labelYear.Text = "Year"
        '
        'tillSetup_labelDay
        '
        Me.tillSetup_labelDay.AutoSize = True
        Me.tillSetup_labelDay.Location = New System.Drawing.Point(92, 72)
        Me.tillSetup_labelDay.Name = "tillSetup_labelDay"
        Me.tillSetup_labelDay.Size = New System.Drawing.Size(26, 13)
        Me.tillSetup_labelDay.TabIndex = 8
        Me.tillSetup_labelDay.Text = "Day"
        '
        'tillSetup_labelDepth
        '
        Me.tillSetup_labelDepth.AutoSize = True
        Me.tillSetup_labelDepth.Location = New System.Drawing.Point(133, 72)
        Me.tillSetup_labelDepth.Name = "tillSetup_labelDepth"
        Me.tillSetup_labelDepth.Size = New System.Drawing.Size(53, 13)
        Me.tillSetup_labelDepth.TabIndex = 9
        Me.tillSetup_labelDepth.Text = "Depth (m)"
        '
        'grp_Tillage
        '
        Me.grp_Tillage.Controls.Add(Me.lv_Tillage)
        Me.grp_Tillage.Location = New System.Drawing.Point(372, 6)
        Me.grp_Tillage.Name = "grp_Tillage"
        Me.grp_Tillage.Size = New System.Drawing.Size(302, 514)
        Me.grp_Tillage.TabIndex = 4
        Me.grp_Tillage.TabStop = False
        Me.grp_Tillage.Text = "Active Operations: 0"
        '
        'lv_Tillage
        '
        Me.lv_Tillage.BackColor = System.Drawing.SystemColors.Window
        Me.lv_Tillage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_Tillage.FullRowSelect = True
        Me.lv_Tillage.GridLines = True
        Me.lv_Tillage.Location = New System.Drawing.Point(3, 16)
        Me.lv_Tillage.MultiSelect = False
        Me.lv_Tillage.Name = "lv_Tillage"
        Me.lv_Tillage.Size = New System.Drawing.Size(296, 495)
        Me.lv_Tillage.TabIndex = 0
        Me.lv_Tillage.UseCompatibleStateImageBehavior = False
        '
        'btn_ChangeTillageOp
        '
        Me.btn_ChangeTillageOp.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_ChangeTillageOp.Location = New System.Drawing.Point(312, 271)
        Me.btn_ChangeTillageOp.Name = "btn_ChangeTillageOp"
        Me.btn_ChangeTillageOp.Size = New System.Drawing.Size(54, 23)
        Me.btn_ChangeTillageOp.TabIndex = 3
        Me.btn_ChangeTillageOp.Text = "f"
        Me.btn_ChangeTillageOp.UseVisualStyleBackColor = True
        '
        'tillSetup_PerformOperations
        '
        Me.tillSetup_PerformOperations.AutoSize = True
        Me.tillSetup_PerformOperations.Checked = True
        Me.tillSetup_PerformOperations.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tillSetup_PerformOperations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tillSetup_PerformOperations.Location = New System.Drawing.Point(100, 88)
        Me.tillSetup_PerformOperations.Name = "tillSetup_PerformOperations"
        Me.tillSetup_PerformOperations.Size = New System.Drawing.Size(134, 17)
        Me.tillSetup_PerformOperations.TabIndex = 0
        Me.tillSetup_PerformOperations.Text = "Perform Operations"
        Me.tillSetup_PerformOperations.UseVisualStyleBackColor = True
        '
        'Tab_FixedIrrigation
        '
        Me.Tab_FixedIrrigation.Controls.Add(Me.grp_FixedIrrigation)
        Me.Tab_FixedIrrigation.Controls.Add(Me.fixedIrrSetup_PerformOperations)
        Me.Tab_FixedIrrigation.Controls.Add(Me.grp_fixedIrrSetup)
        Me.Tab_FixedIrrigation.Controls.Add(Me.btn_AddFixedIrrOp)
        Me.Tab_FixedIrrigation.Controls.Add(Me.btn_ChangeFixedIrrOp)
        Me.Tab_FixedIrrigation.Location = New System.Drawing.Point(4, 22)
        Me.Tab_FixedIrrigation.Name = "Tab_FixedIrrigation"
        Me.Tab_FixedIrrigation.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_FixedIrrigation.Size = New System.Drawing.Size(680, 526)
        Me.Tab_FixedIrrigation.TabIndex = 0
        Me.Tab_FixedIrrigation.Text = "Fixed Irrigation"
        Me.Tab_FixedIrrigation.UseVisualStyleBackColor = True
        '
        'grp_FixedIrrigation
        '
        Me.grp_FixedIrrigation.Controls.Add(Me.lv_FixedIrrigation)
        Me.grp_FixedIrrigation.Location = New System.Drawing.Point(372, 6)
        Me.grp_FixedIrrigation.Name = "grp_FixedIrrigation"
        Me.grp_FixedIrrigation.Size = New System.Drawing.Size(302, 514)
        Me.grp_FixedIrrigation.TabIndex = 4
        Me.grp_FixedIrrigation.TabStop = False
        Me.grp_FixedIrrigation.Text = "Active Operations: 0"
        '
        'lv_FixedIrrigation
        '
        Me.lv_FixedIrrigation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_FixedIrrigation.FullRowSelect = True
        Me.lv_FixedIrrigation.Location = New System.Drawing.Point(3, 16)
        Me.lv_FixedIrrigation.MultiSelect = False
        Me.lv_FixedIrrigation.Name = "lv_FixedIrrigation"
        Me.lv_FixedIrrigation.Size = New System.Drawing.Size(296, 495)
        Me.lv_FixedIrrigation.TabIndex = 0
        Me.lv_FixedIrrigation.UseCompatibleStateImageBehavior = False
        '
        'fixedIrrSetup_PerformOperations
        '
        Me.fixedIrrSetup_PerformOperations.AutoSize = True
        Me.fixedIrrSetup_PerformOperations.Checked = True
        Me.fixedIrrSetup_PerformOperations.CheckState = System.Windows.Forms.CheckState.Checked
        Me.fixedIrrSetup_PerformOperations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fixedIrrSetup_PerformOperations.Location = New System.Drawing.Point(100, 88)
        Me.fixedIrrSetup_PerformOperations.Name = "fixedIrrSetup_PerformOperations"
        Me.fixedIrrSetup_PerformOperations.Size = New System.Drawing.Size(134, 17)
        Me.fixedIrrSetup_PerformOperations.TabIndex = 0
        Me.fixedIrrSetup_PerformOperations.Text = "Perform Operations"
        Me.fixedIrrSetup_PerformOperations.UseVisualStyleBackColor = True
        '
        'grp_fixedIrrSetup
        '
        Me.grp_fixedIrrSetup.Controls.Add(Me.fixedIrrSetup_Day)
        Me.grp_fixedIrrSetup.Controls.Add(Me.fixedIrrSetup_Volume)
        Me.grp_fixedIrrSetup.Controls.Add(Me.fixedIrrSetup_labelYear)
        Me.grp_fixedIrrSetup.Controls.Add(Me.fixedIrrSetup_Year)
        Me.grp_fixedIrrSetup.Controls.Add(Me.fixedIrrSetup_labelVolume)
        Me.grp_fixedIrrSetup.Controls.Add(Me.fixedIrrSetup_labelDay)
        Me.grp_fixedIrrSetup.Location = New System.Drawing.Point(3, 199)
        Me.grp_fixedIrrSetup.Name = "grp_fixedIrrSetup"
        Me.grp_fixedIrrSetup.Size = New System.Drawing.Size(303, 136)
        Me.grp_fixedIrrSetup.TabIndex = 1
        Me.grp_fixedIrrSetup.TabStop = False
        Me.grp_fixedIrrSetup.Text = "Operation Setup"
        '
        'fixedIrrSetup_Volume
        '
        Me.fixedIrrSetup_Volume.Location = New System.Drawing.Point(137, 84)
        Me.fixedIrrSetup_Volume.Name = "fixedIrrSetup_Volume"
        Me.fixedIrrSetup_Volume.Size = New System.Drawing.Size(62, 20)
        Me.fixedIrrSetup_Volume.TabIndex = 2
        Me.fixedIrrSetup_Volume.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'fixedIrrSetup_labelYear
        '
        Me.fixedIrrSetup_labelYear.AutoSize = True
        Me.fixedIrrSetup_labelYear.Location = New System.Drawing.Point(102, 34)
        Me.fixedIrrSetup_labelYear.Name = "fixedIrrSetup_labelYear"
        Me.fixedIrrSetup_labelYear.Size = New System.Drawing.Size(29, 13)
        Me.fixedIrrSetup_labelYear.TabIndex = 3
        Me.fixedIrrSetup_labelYear.Text = "Year"
        '
        'fixedIrrSetup_labelVolume
        '
        Me.fixedIrrSetup_labelVolume.AutoSize = True
        Me.fixedIrrSetup_labelVolume.Location = New System.Drawing.Point(63, 87)
        Me.fixedIrrSetup_labelVolume.Name = "fixedIrrSetup_labelVolume"
        Me.fixedIrrSetup_labelVolume.Size = New System.Drawing.Size(68, 13)
        Me.fixedIrrSetup_labelVolume.TabIndex = 5
        Me.fixedIrrSetup_labelVolume.Text = "Amount (mm)"
        '
        'fixedIrrSetup_labelDay
        '
        Me.fixedIrrSetup_labelDay.AutoSize = True
        Me.fixedIrrSetup_labelDay.Location = New System.Drawing.Point(105, 61)
        Me.fixedIrrSetup_labelDay.Name = "fixedIrrSetup_labelDay"
        Me.fixedIrrSetup_labelDay.Size = New System.Drawing.Size(26, 13)
        Me.fixedIrrSetup_labelDay.TabIndex = 4
        Me.fixedIrrSetup_labelDay.Text = "Day"
        '
        'btn_ChangeFixedIrrOp
        '
        Me.btn_ChangeFixedIrrOp.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_ChangeFixedIrrOp.Location = New System.Drawing.Point(312, 271)
        Me.btn_ChangeFixedIrrOp.Name = "btn_ChangeFixedIrrOp"
        Me.btn_ChangeFixedIrrOp.Size = New System.Drawing.Size(54, 23)
        Me.btn_ChangeFixedIrrOp.TabIndex = 3
        Me.btn_ChangeFixedIrrOp.Text = "f"
        Me.btn_ChangeFixedIrrOp.UseVisualStyleBackColor = True
        '
        'Tab_FixedFertilization
        '
        Me.Tab_FixedFertilization.Controls.Add(Me.grp_FixedFertSetup)
        Me.Tab_FixedFertilization.Controls.Add(Me.grp_FixedFertilization)
        Me.Tab_FixedFertilization.Controls.Add(Me.btn_AddFixedFertOp)
        Me.Tab_FixedFertilization.Controls.Add(Me.btn_ChangeFixedFertOp)
        Me.Tab_FixedFertilization.Controls.Add(Me.fixedFertSetup_PerformOperations)
        Me.Tab_FixedFertilization.Location = New System.Drawing.Point(4, 22)
        Me.Tab_FixedFertilization.Name = "Tab_FixedFertilization"
        Me.Tab_FixedFertilization.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_FixedFertilization.Size = New System.Drawing.Size(680, 526)
        Me.Tab_FixedFertilization.TabIndex = 2
        Me.Tab_FixedFertilization.Text = "Fixed Fertilization"
        Me.Tab_FixedFertilization.UseVisualStyleBackColor = True
        '
        'grp_FixedFertSetup
        '
        Me.grp_FixedFertSetup.Controls.Add(Me.fixedFertSetup_Day)
        Me.grp_FixedFertSetup.Controls.Add(Me.grp_FixedFertOps)
        Me.grp_FixedFertSetup.Controls.Add(Me.fixedFertSetup_Year)
        Me.grp_FixedFertSetup.Controls.Add(Me.fixedFertSetup_labelYear)
        Me.grp_FixedFertSetup.Controls.Add(Me.fixedFertSetup_labelDay)
        Me.grp_FixedFertSetup.Controls.Add(Me.fixedFertSetup_Source)
        Me.grp_FixedFertSetup.Controls.Add(Me.fixedFertSetup_labelSource)
        Me.grp_FixedFertSetup.Location = New System.Drawing.Point(3, 134)
        Me.grp_FixedFertSetup.Name = "grp_FixedFertSetup"
        Me.grp_FixedFertSetup.Size = New System.Drawing.Size(303, 266)
        Me.grp_FixedFertSetup.TabIndex = 1
        Me.grp_FixedFertSetup.TabStop = False
        Me.grp_FixedFertSetup.Text = "Operation Setup"
        '
        'grp_FixedFertOps
        '
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_Method)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_labelMethod)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_labelS)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_S)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_labelN_Charcoal)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_N_Charcoal)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_labelK)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_K)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_labelP_Inorganic)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_labelP_Charcoal)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_labelP_Organic)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_labelN_NO3)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_labelN_NH4)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_LabelN_Organic)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_labelC_Charcoal)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_labelC_Organic)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_P_Inorganic)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_P_Charcoal)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_P_Organic)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_N_NO3)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_N_NH4)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_N_Organic)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_C_Charcoal)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_C_Organic)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_Layer)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_Mass)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_Form)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_labelLayer)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_labelForm)
        Me.grp_FixedFertOps.Controls.Add(Me.fixedFertSetup_labelMass)
        Me.grp_FixedFertOps.Location = New System.Drawing.Point(6, 70)
        Me.grp_FixedFertOps.Name = "grp_FixedFertOps"
        Me.grp_FixedFertOps.Size = New System.Drawing.Size(291, 190)
        Me.grp_FixedFertOps.TabIndex = 3
        Me.grp_FixedFertOps.TabStop = False
        Me.grp_FixedFertOps.Text = "Fertilizer Application"
        '
        'fixedFertSetup_Method
        '
        Me.fixedFertSetup_Method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fixedFertSetup_Method.FormattingEnabled = True
        Me.fixedFertSetup_Method.Location = New System.Drawing.Point(73, 70)
        Me.fixedFertSetup_Method.MaxDropDownItems = 10
        Me.fixedFertSetup_Method.Name = "fixedFertSetup_Method"
        Me.fixedFertSetup_Method.Size = New System.Drawing.Size(70, 21)
        Me.fixedFertSetup_Method.TabIndex = 2
        '
        'fixedFertSetup_labelMethod
        '
        Me.fixedFertSetup_labelMethod.AutoSize = True
        Me.fixedFertSetup_labelMethod.Location = New System.Drawing.Point(24, 73)
        Me.fixedFertSetup_labelMethod.Name = "fixedFertSetup_labelMethod"
        Me.fixedFertSetup_labelMethod.Size = New System.Drawing.Size(43, 13)
        Me.fixedFertSetup_labelMethod.TabIndex = 29
        Me.fixedFertSetup_labelMethod.Text = "Method"
        '
        'fixedFertSetup_labelS
        '
        Me.fixedFertSetup_labelS.AutoSize = True
        Me.fixedFertSetup_labelS.Location = New System.Drawing.Point(195, 159)
        Me.fixedFertSetup_labelS.Name = "fixedFertSetup_labelS"
        Me.fixedFertSetup_labelS.Size = New System.Drawing.Size(14, 13)
        Me.fixedFertSetup_labelS.TabIndex = 27
        Me.fixedFertSetup_labelS.Text = "S"
        '
        'fixedFertSetup_labelN_Charcoal
        '
        Me.fixedFertSetup_labelN_Charcoal.AutoSize = True
        Me.fixedFertSetup_labelN_Charcoal.Location = New System.Drawing.Point(149, 26)
        Me.fixedFertSetup_labelN_Charcoal.Name = "fixedFertSetup_labelN_Charcoal"
        Me.fixedFertSetup_labelN_Charcoal.Size = New System.Drawing.Size(60, 13)
        Me.fixedFertSetup_labelN_Charcoal.TabIndex = 20
        Me.fixedFertSetup_labelN_Charcoal.Text = "N Charcoal"
        '
        'fixedFertSetup_labelK
        '
        Me.fixedFertSetup_labelK.AutoSize = True
        Me.fixedFertSetup_labelK.Location = New System.Drawing.Point(195, 140)
        Me.fixedFertSetup_labelK.Name = "fixedFertSetup_labelK"
        Me.fixedFertSetup_labelK.Size = New System.Drawing.Size(14, 13)
        Me.fixedFertSetup_labelK.TabIndex = 26
        Me.fixedFertSetup_labelK.Text = "K"
        '
        'fixedFertSetup_labelP_Inorganic
        '
        Me.fixedFertSetup_labelP_Inorganic.AutoSize = True
        Me.fixedFertSetup_labelP_Inorganic.Location = New System.Drawing.Point(148, 121)
        Me.fixedFertSetup_labelP_Inorganic.Name = "fixedFertSetup_labelP_Inorganic"
        Me.fixedFertSetup_labelP_Inorganic.Size = New System.Drawing.Size(61, 13)
        Me.fixedFertSetup_labelP_Inorganic.TabIndex = 25
        Me.fixedFertSetup_labelP_Inorganic.Text = "P Inorganic"
        '
        'fixedFertSetup_labelP_Charcoal
        '
        Me.fixedFertSetup_labelP_Charcoal.AutoSize = True
        Me.fixedFertSetup_labelP_Charcoal.Location = New System.Drawing.Point(150, 102)
        Me.fixedFertSetup_labelP_Charcoal.Name = "fixedFertSetup_labelP_Charcoal"
        Me.fixedFertSetup_labelP_Charcoal.Size = New System.Drawing.Size(59, 13)
        Me.fixedFertSetup_labelP_Charcoal.TabIndex = 24
        Me.fixedFertSetup_labelP_Charcoal.Text = "P Charcoal"
        '
        'fixedFertSetup_labelP_Organic
        '
        Me.fixedFertSetup_labelP_Organic.AutoSize = True
        Me.fixedFertSetup_labelP_Organic.Location = New System.Drawing.Point(155, 83)
        Me.fixedFertSetup_labelP_Organic.Name = "fixedFertSetup_labelP_Organic"
        Me.fixedFertSetup_labelP_Organic.Size = New System.Drawing.Size(54, 13)
        Me.fixedFertSetup_labelP_Organic.TabIndex = 23
        Me.fixedFertSetup_labelP_Organic.Text = "P Organic"
        '
        'fixedFertSetup_labelN_NO3
        '
        Me.fixedFertSetup_labelN_NO3.AutoSize = True
        Me.fixedFertSetup_labelN_NO3.Location = New System.Drawing.Point(169, 64)
        Me.fixedFertSetup_labelN_NO3.Name = "fixedFertSetup_labelN_NO3"
        Me.fixedFertSetup_labelN_NO3.Size = New System.Drawing.Size(40, 13)
        Me.fixedFertSetup_labelN_NO3.TabIndex = 22
        Me.fixedFertSetup_labelN_NO3.Text = "N NO3"
        '
        'fixedFertSetup_labelN_NH4
        '
        Me.fixedFertSetup_labelN_NH4.AutoSize = True
        Me.fixedFertSetup_labelN_NH4.Location = New System.Drawing.Point(169, 45)
        Me.fixedFertSetup_labelN_NH4.Name = "fixedFertSetup_labelN_NH4"
        Me.fixedFertSetup_labelN_NH4.Size = New System.Drawing.Size(40, 13)
        Me.fixedFertSetup_labelN_NH4.TabIndex = 21
        Me.fixedFertSetup_labelN_NH4.Text = "N NH4"
        '
        'fixedFertSetup_LabelN_Organic
        '
        Me.fixedFertSetup_LabelN_Organic.AutoSize = True
        Me.fixedFertSetup_LabelN_Organic.Location = New System.Drawing.Point(12, 151)
        Me.fixedFertSetup_LabelN_Organic.Name = "fixedFertSetup_LabelN_Organic"
        Me.fixedFertSetup_LabelN_Organic.Size = New System.Drawing.Size(55, 13)
        Me.fixedFertSetup_LabelN_Organic.TabIndex = 19
        Me.fixedFertSetup_LabelN_Organic.Text = "N Organic"
        '
        'fixedFertSetup_labelC_Charcoal
        '
        Me.fixedFertSetup_labelC_Charcoal.AutoSize = True
        Me.fixedFertSetup_labelC_Charcoal.Location = New System.Drawing.Point(8, 131)
        Me.fixedFertSetup_labelC_Charcoal.Name = "fixedFertSetup_labelC_Charcoal"
        Me.fixedFertSetup_labelC_Charcoal.Size = New System.Drawing.Size(59, 13)
        Me.fixedFertSetup_labelC_Charcoal.TabIndex = 18
        Me.fixedFertSetup_labelC_Charcoal.Text = "C Charcoal"
        '
        'fixedFertSetup_labelC_Organic
        '
        Me.fixedFertSetup_labelC_Organic.AutoSize = True
        Me.fixedFertSetup_labelC_Organic.Location = New System.Drawing.Point(13, 113)
        Me.fixedFertSetup_labelC_Organic.Name = "fixedFertSetup_labelC_Organic"
        Me.fixedFertSetup_labelC_Organic.Size = New System.Drawing.Size(54, 13)
        Me.fixedFertSetup_labelC_Organic.TabIndex = 17
        Me.fixedFertSetup_labelC_Organic.Text = "C Organic"
        '
        'fixedFertSetup_Form
        '
        Me.fixedFertSetup_Form.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fixedFertSetup_Form.FormattingEnabled = True
        Me.fixedFertSetup_Form.Location = New System.Drawing.Point(73, 50)
        Me.fixedFertSetup_Form.MaxDropDownItems = 10
        Me.fixedFertSetup_Form.Name = "fixedFertSetup_Form"
        Me.fixedFertSetup_Form.Size = New System.Drawing.Size(70, 21)
        Me.fixedFertSetup_Form.TabIndex = 1
        '
        'fixedFertSetup_labelLayer
        '
        Me.fixedFertSetup_labelLayer.AutoSize = True
        Me.fixedFertSetup_labelLayer.Location = New System.Drawing.Point(34, 93)
        Me.fixedFertSetup_labelLayer.Name = "fixedFertSetup_labelLayer"
        Me.fixedFertSetup_labelLayer.Size = New System.Drawing.Size(33, 13)
        Me.fixedFertSetup_labelLayer.TabIndex = 16
        Me.fixedFertSetup_labelLayer.Text = "Layer"
        '
        'fixedFertSetup_labelForm
        '
        Me.fixedFertSetup_labelForm.AutoSize = True
        Me.fixedFertSetup_labelForm.Location = New System.Drawing.Point(37, 53)
        Me.fixedFertSetup_labelForm.Name = "fixedFertSetup_labelForm"
        Me.fixedFertSetup_labelForm.Size = New System.Drawing.Size(30, 13)
        Me.fixedFertSetup_labelForm.TabIndex = 15
        Me.fixedFertSetup_labelForm.Text = "Form"
        '
        'fixedFertSetup_labelMass
        '
        Me.fixedFertSetup_labelMass.AutoSize = True
        Me.fixedFertSetup_labelMass.Location = New System.Drawing.Point(35, 34)
        Me.fixedFertSetup_labelMass.Name = "fixedFertSetup_labelMass"
        Me.fixedFertSetup_labelMass.Size = New System.Drawing.Size(32, 13)
        Me.fixedFertSetup_labelMass.TabIndex = 14
        Me.fixedFertSetup_labelMass.Text = "Mass"
        '
        'fixedFertSetup_labelYear
        '
        Me.fixedFertSetup_labelYear.AutoSize = True
        Me.fixedFertSetup_labelYear.Location = New System.Drawing.Point(55, 48)
        Me.fixedFertSetup_labelYear.Name = "fixedFertSetup_labelYear"
        Me.fixedFertSetup_labelYear.Size = New System.Drawing.Size(29, 13)
        Me.fixedFertSetup_labelYear.TabIndex = 4
        Me.fixedFertSetup_labelYear.Text = "Year"
        '
        'fixedFertSetup_labelDay
        '
        Me.fixedFertSetup_labelDay.AutoSize = True
        Me.fixedFertSetup_labelDay.Location = New System.Drawing.Point(153, 48)
        Me.fixedFertSetup_labelDay.Name = "fixedFertSetup_labelDay"
        Me.fixedFertSetup_labelDay.Size = New System.Drawing.Size(26, 13)
        Me.fixedFertSetup_labelDay.TabIndex = 5
        Me.fixedFertSetup_labelDay.Text = "Day"
        '
        'fixedFertSetup_Source
        '
        Me.fixedFertSetup_Source.FormattingEnabled = True
        Me.fixedFertSetup_Source.Location = New System.Drawing.Point(90, 19)
        Me.fixedFertSetup_Source.MaxDropDownItems = 10
        Me.fixedFertSetup_Source.Name = "fixedFertSetup_Source"
        Me.fixedFertSetup_Source.Size = New System.Drawing.Size(148, 21)
        Me.fixedFertSetup_Source.TabIndex = 0
        '
        'fixedFertSetup_labelSource
        '
        Me.fixedFertSetup_labelSource.AutoSize = True
        Me.fixedFertSetup_labelSource.Location = New System.Drawing.Point(43, 22)
        Me.fixedFertSetup_labelSource.Name = "fixedFertSetup_labelSource"
        Me.fixedFertSetup_labelSource.Size = New System.Drawing.Size(41, 13)
        Me.fixedFertSetup_labelSource.TabIndex = 3
        Me.fixedFertSetup_labelSource.Text = "Source"
        '
        'grp_FixedFertilization
        '
        Me.grp_FixedFertilization.Controls.Add(Me.lv_FixedFertilization)
        Me.grp_FixedFertilization.Location = New System.Drawing.Point(372, 6)
        Me.grp_FixedFertilization.Name = "grp_FixedFertilization"
        Me.grp_FixedFertilization.Size = New System.Drawing.Size(302, 514)
        Me.grp_FixedFertilization.TabIndex = 4
        Me.grp_FixedFertilization.TabStop = False
        Me.grp_FixedFertilization.Text = "Active Operations: 0"
        '
        'lv_FixedFertilization
        '
        Me.lv_FixedFertilization.BackColor = System.Drawing.SystemColors.Window
        Me.lv_FixedFertilization.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_FixedFertilization.FullRowSelect = True
        Me.lv_FixedFertilization.Location = New System.Drawing.Point(3, 16)
        Me.lv_FixedFertilization.MultiSelect = False
        Me.lv_FixedFertilization.Name = "lv_FixedFertilization"
        Me.lv_FixedFertilization.Size = New System.Drawing.Size(296, 495)
        Me.lv_FixedFertilization.TabIndex = 0
        Me.lv_FixedFertilization.UseCompatibleStateImageBehavior = False
        '
        'btn_ChangeFixedFertOp
        '
        Me.btn_ChangeFixedFertOp.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_ChangeFixedFertOp.Location = New System.Drawing.Point(312, 271)
        Me.btn_ChangeFixedFertOp.Name = "btn_ChangeFixedFertOp"
        Me.btn_ChangeFixedFertOp.Size = New System.Drawing.Size(54, 23)
        Me.btn_ChangeFixedFertOp.TabIndex = 3
        Me.btn_ChangeFixedFertOp.Text = "f"
        Me.btn_ChangeFixedFertOp.UseVisualStyleBackColor = True
        '
        'fixedFertSetup_PerformOperations
        '
        Me.fixedFertSetup_PerformOperations.AutoSize = True
        Me.fixedFertSetup_PerformOperations.Checked = True
        Me.fixedFertSetup_PerformOperations.CheckState = System.Windows.Forms.CheckState.Checked
        Me.fixedFertSetup_PerformOperations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fixedFertSetup_PerformOperations.Location = New System.Drawing.Point(100, 88)
        Me.fixedFertSetup_PerformOperations.Name = "fixedFertSetup_PerformOperations"
        Me.fixedFertSetup_PerformOperations.Size = New System.Drawing.Size(134, 17)
        Me.fixedFertSetup_PerformOperations.TabIndex = 0
        Me.fixedFertSetup_PerformOperations.Text = "Perform Operations"
        Me.fixedFertSetup_PerformOperations.UseVisualStyleBackColor = True
        '
        'Tab_AutoIrrigation
        '
        Me.Tab_AutoIrrigation.Controls.Add(Me.grp_AutomaticIrrigation)
        Me.Tab_AutoIrrigation.Controls.Add(Me.btn_AddAutoIrrOp)
        Me.Tab_AutoIrrigation.Controls.Add(Me.btn_ChangeAutoIrrOp)
        Me.Tab_AutoIrrigation.Controls.Add(Me.grp_AutoIrrSetup)
        Me.Tab_AutoIrrigation.Controls.Add(Me.autoIrrSetup_PerformOperations)
        Me.Tab_AutoIrrigation.Location = New System.Drawing.Point(4, 22)
        Me.Tab_AutoIrrigation.Name = "Tab_AutoIrrigation"
        Me.Tab_AutoIrrigation.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_AutoIrrigation.Size = New System.Drawing.Size(680, 526)
        Me.Tab_AutoIrrigation.TabIndex = 1
        Me.Tab_AutoIrrigation.Text = "Automatic Irrigation"
        Me.Tab_AutoIrrigation.UseVisualStyleBackColor = True
        '
        'grp_AutomaticIrrigation
        '
        Me.grp_AutomaticIrrigation.Controls.Add(Me.lv_AutomaticIrrigation)
        Me.grp_AutomaticIrrigation.Location = New System.Drawing.Point(372, 6)
        Me.grp_AutomaticIrrigation.Name = "grp_AutomaticIrrigation"
        Me.grp_AutomaticIrrigation.Size = New System.Drawing.Size(302, 514)
        Me.grp_AutomaticIrrigation.TabIndex = 4
        Me.grp_AutomaticIrrigation.TabStop = False
        Me.grp_AutomaticIrrigation.Text = "Active Operations: 0"
        '
        'lv_AutomaticIrrigation
        '
        Me.lv_AutomaticIrrigation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_AutomaticIrrigation.FullRowSelect = True
        Me.lv_AutomaticIrrigation.Location = New System.Drawing.Point(3, 16)
        Me.lv_AutomaticIrrigation.MultiSelect = False
        Me.lv_AutomaticIrrigation.Name = "lv_AutomaticIrrigation"
        Me.lv_AutomaticIrrigation.Size = New System.Drawing.Size(296, 495)
        Me.lv_AutomaticIrrigation.TabIndex = 0
        Me.lv_AutomaticIrrigation.UseCompatibleStateImageBehavior = False
        '
        'btn_ChangeAutoIrrOp
        '
        Me.btn_ChangeAutoIrrOp.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_ChangeAutoIrrOp.Location = New System.Drawing.Point(312, 271)
        Me.btn_ChangeAutoIrrOp.Name = "btn_ChangeAutoIrrOp"
        Me.btn_ChangeAutoIrrOp.Size = New System.Drawing.Size(54, 23)
        Me.btn_ChangeAutoIrrOp.TabIndex = 3
        Me.btn_ChangeAutoIrrOp.Text = "f"
        Me.btn_ChangeAutoIrrOp.UseVisualStyleBackColor = True
        '
        'grp_AutoIrrSetup
        '
        Me.grp_AutoIrrSetup.Controls.Add(Me.autoIrrSetup_DefaultEndDay)
        Me.grp_AutoIrrSetup.Controls.Add(Me.autoIrrSetup_labelDefaultEndDay)
        Me.grp_AutoIrrSetup.Controls.Add(Me.autoIrrSetup_DefaultStartDay)
        Me.grp_AutoIrrSetup.Controls.Add(Me.autoIrrSetup_StopDay)
        Me.grp_AutoIrrSetup.Controls.Add(Me.autoIrrSetup_StartDay)
        Me.grp_AutoIrrSetup.Controls.Add(Me.autoIrrSetup_labelDefaultStartDay)
        Me.grp_AutoIrrSetup.Controls.Add(Me.autoIrrSetup_labelName)
        Me.grp_AutoIrrSetup.Controls.Add(Me.autoIrrSetup_Name)
        Me.grp_AutoIrrSetup.Controls.Add(Me.autoIrrSetup_WaterDepletion)
        Me.grp_AutoIrrSetup.Controls.Add(Me.autoIrrSetup_LastSoilLayer)
        Me.grp_AutoIrrSetup.Controls.Add(Me.autoIrrSetup_labelWaterDepletion)
        Me.grp_AutoIrrSetup.Controls.Add(Me.autoIrrSetup_labelStartDay)
        Me.grp_AutoIrrSetup.Controls.Add(Me.autoIrrSetup_labelLastSoilLayer)
        Me.grp_AutoIrrSetup.Controls.Add(Me.autoIrrSetup_labelStopDay)
        Me.grp_AutoIrrSetup.Enabled = False
        Me.grp_AutoIrrSetup.Location = New System.Drawing.Point(3, 199)
        Me.grp_AutoIrrSetup.Name = "grp_AutoIrrSetup"
        Me.grp_AutoIrrSetup.Size = New System.Drawing.Size(303, 136)
        Me.grp_AutoIrrSetup.TabIndex = 1
        Me.grp_AutoIrrSetup.TabStop = False
        Me.grp_AutoIrrSetup.Text = "Operation Setup"
        '
        'autoIrrSetup_DefaultEndDay
        '
        Me.autoIrrSetup_DefaultEndDay.AutoSize = True
        Me.autoIrrSetup_DefaultEndDay.Location = New System.Drawing.Point(241, 65)
        Me.autoIrrSetup_DefaultEndDay.Name = "autoIrrSetup_DefaultEndDay"
        Me.autoIrrSetup_DefaultEndDay.Size = New System.Drawing.Size(0, 13)
        Me.autoIrrSetup_DefaultEndDay.TabIndex = 16
        '
        'autoIrrSetup_labelDefaultEndDay
        '
        Me.autoIrrSetup_labelDefaultEndDay.AutoSize = True
        Me.autoIrrSetup_labelDefaultEndDay.Location = New System.Drawing.Point(200, 65)
        Me.autoIrrSetup_labelDefaultEndDay.Name = "autoIrrSetup_labelDefaultEndDay"
        Me.autoIrrSetup_labelDefaultEndDay.Size = New System.Drawing.Size(44, 13)
        Me.autoIrrSetup_labelDefaultEndDay.TabIndex = 15
        Me.autoIrrSetup_labelDefaultEndDay.Text = "Default:"
        Me.autoIrrSetup_labelDefaultEndDay.Visible = False
        '
        'autoIrrSetup_DefaultStartDay
        '
        Me.autoIrrSetup_DefaultStartDay.AutoSize = True
        Me.autoIrrSetup_DefaultStartDay.Location = New System.Drawing.Point(241, 46)
        Me.autoIrrSetup_DefaultStartDay.Name = "autoIrrSetup_DefaultStartDay"
        Me.autoIrrSetup_DefaultStartDay.Size = New System.Drawing.Size(0, 13)
        Me.autoIrrSetup_DefaultStartDay.TabIndex = 14
        '
        'autoIrrSetup_labelDefaultStartDay
        '
        Me.autoIrrSetup_labelDefaultStartDay.AutoSize = True
        Me.autoIrrSetup_labelDefaultStartDay.Location = New System.Drawing.Point(200, 46)
        Me.autoIrrSetup_labelDefaultStartDay.Name = "autoIrrSetup_labelDefaultStartDay"
        Me.autoIrrSetup_labelDefaultStartDay.Size = New System.Drawing.Size(44, 13)
        Me.autoIrrSetup_labelDefaultStartDay.TabIndex = 13
        Me.autoIrrSetup_labelDefaultStartDay.Text = "Default:"
        Me.autoIrrSetup_labelDefaultStartDay.Visible = False
        '
        'autoIrrSetup_labelName
        '
        Me.autoIrrSetup_labelName.AutoSize = True
        Me.autoIrrSetup_labelName.Location = New System.Drawing.Point(69, 20)
        Me.autoIrrSetup_labelName.Name = "autoIrrSetup_labelName"
        Me.autoIrrSetup_labelName.Size = New System.Drawing.Size(60, 13)
        Me.autoIrrSetup_labelName.TabIndex = 5
        Me.autoIrrSetup_labelName.Text = "Crop Name"
        '
        'autoIrrSetup_Name
        '
        Me.autoIrrSetup_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.autoIrrSetup_Name.FormattingEnabled = True
        Me.autoIrrSetup_Name.Location = New System.Drawing.Point(135, 17)
        Me.autoIrrSetup_Name.MaxDropDownItems = 6
        Me.autoIrrSetup_Name.Name = "autoIrrSetup_Name"
        Me.autoIrrSetup_Name.Size = New System.Drawing.Size(102, 21)
        Me.autoIrrSetup_Name.TabIndex = 0
        '
        'autoIrrSetup_labelWaterDepletion
        '
        Me.autoIrrSetup_labelWaterDepletion.AutoSize = True
        Me.autoIrrSetup_labelWaterDepletion.Location = New System.Drawing.Point(12, 92)
        Me.autoIrrSetup_labelWaterDepletion.Name = "autoIrrSetup_labelWaterDepletion"
        Me.autoIrrSetup_labelWaterDepletion.Size = New System.Drawing.Size(205, 13)
        Me.autoIrrSetup_labelWaterDepletion.TabIndex = 8
        Me.autoIrrSetup_labelWaterDepletion.Text = "Allowable Plant Available Water Depletion"
        '
        'autoIrrSetup_labelStartDay
        '
        Me.autoIrrSetup_labelStartDay.AutoSize = True
        Me.autoIrrSetup_labelStartDay.Location = New System.Drawing.Point(78, 46)
        Me.autoIrrSetup_labelStartDay.Name = "autoIrrSetup_labelStartDay"
        Me.autoIrrSetup_labelStartDay.Size = New System.Drawing.Size(51, 13)
        Me.autoIrrSetup_labelStartDay.TabIndex = 6
        Me.autoIrrSetup_labelStartDay.Text = "Start Day"
        '
        'autoIrrSetup_labelLastSoilLayer
        '
        Me.autoIrrSetup_labelLastSoilLayer.AutoSize = True
        Me.autoIrrSetup_labelLastSoilLayer.Location = New System.Drawing.Point(28, 112)
        Me.autoIrrSetup_labelLastSoilLayer.Name = "autoIrrSetup_labelLastSoilLayer"
        Me.autoIrrSetup_labelLastSoilLayer.Size = New System.Drawing.Size(189, 13)
        Me.autoIrrSetup_labelLastSoilLayer.TabIndex = 9
        Me.autoIrrSetup_labelLastSoilLayer.Text = "Last Soil Layer to Monitor for Depletion"
        '
        'autoIrrSetup_labelStopDay
        '
        Me.autoIrrSetup_labelStopDay.AutoSize = True
        Me.autoIrrSetup_labelStopDay.Location = New System.Drawing.Point(81, 65)
        Me.autoIrrSetup_labelStopDay.Name = "autoIrrSetup_labelStopDay"
        Me.autoIrrSetup_labelStopDay.Size = New System.Drawing.Size(48, 13)
        Me.autoIrrSetup_labelStopDay.TabIndex = 7
        Me.autoIrrSetup_labelStopDay.Text = "End Day"
        '
        'autoIrrSetup_PerformOperations
        '
        Me.autoIrrSetup_PerformOperations.AutoSize = True
        Me.autoIrrSetup_PerformOperations.Checked = True
        Me.autoIrrSetup_PerformOperations.CheckState = System.Windows.Forms.CheckState.Checked
        Me.autoIrrSetup_PerformOperations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autoIrrSetup_PerformOperations.Location = New System.Drawing.Point(100, 88)
        Me.autoIrrSetup_PerformOperations.Name = "autoIrrSetup_PerformOperations"
        Me.autoIrrSetup_PerformOperations.Size = New System.Drawing.Size(134, 17)
        Me.autoIrrSetup_PerformOperations.TabIndex = 0
        Me.autoIrrSetup_PerformOperations.Text = "Perform Operations"
        Me.autoIrrSetup_PerformOperations.UseVisualStyleBackColor = True
        '
        'Tab_AutoFertilization
        '
        Me.Tab_AutoFertilization.Controls.Add(Me.grp_AutoFertSetup)
        Me.Tab_AutoFertilization.Controls.Add(Me.grp_AutoFertilization)
        Me.Tab_AutoFertilization.Controls.Add(Me.btn_AddAutoFertOp)
        Me.Tab_AutoFertilization.Controls.Add(Me.btn_ChangeAutoFertOp)
        Me.Tab_AutoFertilization.Controls.Add(Me.autoFertSetup_PerformOperations)
        Me.Tab_AutoFertilization.Location = New System.Drawing.Point(4, 22)
        Me.Tab_AutoFertilization.Name = "Tab_AutoFertilization"
        Me.Tab_AutoFertilization.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_AutoFertilization.Size = New System.Drawing.Size(680, 526)
        Me.Tab_AutoFertilization.TabIndex = 6
        Me.Tab_AutoFertilization.Text = "Automatic Fertilization"
        Me.Tab_AutoFertilization.UseVisualStyleBackColor = True
        '
        'grp_AutoFertSetup
        '
        Me.grp_AutoFertSetup.Controls.Add(Me.autoFertSetup_DefaultEndDay)
        Me.grp_AutoFertSetup.Controls.Add(Me.autoFertSetup_EndDay)
        Me.grp_AutoFertSetup.Controls.Add(Me.autoFertSetup_labelDefaultEndDay)
        Me.grp_AutoFertSetup.Controls.Add(Me.autoFertSetup_StartDay)
        Me.grp_AutoFertSetup.Controls.Add(Me.autoFertSetup_DefaultStartDay)
        Me.grp_AutoFertSetup.Controls.Add(Me.grp_AutoFertOps)
        Me.grp_AutoFertSetup.Controls.Add(Me.autoFertSetup_labelDefaultStartDay)
        Me.grp_AutoFertSetup.Controls.Add(Me.autoFertSetup_LabelStartDay)
        Me.grp_AutoFertSetup.Controls.Add(Me.autoFertSetup_LabelEndDay)
        Me.grp_AutoFertSetup.Controls.Add(Me.autoFertSetup_LabelName)
        Me.grp_AutoFertSetup.Controls.Add(Me.autoFertSetup_Name)
        Me.grp_AutoFertSetup.Location = New System.Drawing.Point(3, 117)
        Me.grp_AutoFertSetup.Name = "grp_AutoFertSetup"
        Me.grp_AutoFertSetup.Size = New System.Drawing.Size(303, 300)
        Me.grp_AutoFertSetup.TabIndex = 0
        Me.grp_AutoFertSetup.TabStop = False
        Me.grp_AutoFertSetup.Text = "Operation Setup"
        '
        'autoFertSetup_DefaultEndDay
        '
        Me.autoFertSetup_DefaultEndDay.AutoSize = True
        Me.autoFertSetup_DefaultEndDay.Location = New System.Drawing.Point(217, 69)
        Me.autoFertSetup_DefaultEndDay.Name = "autoFertSetup_DefaultEndDay"
        Me.autoFertSetup_DefaultEndDay.Size = New System.Drawing.Size(0, 13)
        Me.autoFertSetup_DefaultEndDay.TabIndex = 20
        '
        'autoFertSetup_labelDefaultEndDay
        '
        Me.autoFertSetup_labelDefaultEndDay.AutoSize = True
        Me.autoFertSetup_labelDefaultEndDay.Location = New System.Drawing.Point(167, 69)
        Me.autoFertSetup_labelDefaultEndDay.Name = "autoFertSetup_labelDefaultEndDay"
        Me.autoFertSetup_labelDefaultEndDay.Size = New System.Drawing.Size(44, 13)
        Me.autoFertSetup_labelDefaultEndDay.TabIndex = 8
        Me.autoFertSetup_labelDefaultEndDay.Text = "Default:"
        Me.autoFertSetup_labelDefaultEndDay.Visible = False
        '
        'autoFertSetup_DefaultStartDay
        '
        Me.autoFertSetup_DefaultStartDay.AutoSize = True
        Me.autoFertSetup_DefaultStartDay.Location = New System.Drawing.Point(102, 69)
        Me.autoFertSetup_DefaultStartDay.Name = "autoFertSetup_DefaultStartDay"
        Me.autoFertSetup_DefaultStartDay.Size = New System.Drawing.Size(0, 13)
        Me.autoFertSetup_DefaultStartDay.TabIndex = 18
        '
        'grp_AutoFertOps
        '
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_LabelSource)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_labelS)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_Source)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_LabelMethod)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_S)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_labelN_Charcoal)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_N_Charcoal)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_LabelMass)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_labelK)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_K)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_LabelForm)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_labelP_Inorganic)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_labelP_Charcoal)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_Mass)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_labelP_Organic)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_Method)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_labelN_NO3)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_labelN_NH4)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_Form)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_labelN_Organic)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_labelC_Charcoal)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_labelC_Organic)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_P_Inorganic)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_P_Charcoal)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_P_Organic)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_N_NO3)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_N_NH4)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_N_Organic)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_C_Charcoal)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_C_Organic)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_Depth)
        Me.grp_AutoFertOps.Controls.Add(Me.autoFertSetup_labelDepth)
        Me.grp_AutoFertOps.Location = New System.Drawing.Point(6, 85)
        Me.grp_AutoFertOps.Name = "grp_AutoFertOps"
        Me.grp_AutoFertOps.Size = New System.Drawing.Size(291, 209)
        Me.grp_AutoFertOps.TabIndex = 3
        Me.grp_AutoFertOps.TabStop = False
        Me.grp_AutoFertOps.Text = "Fertilizer Application"
        '
        'autoFertSetup_LabelSource
        '
        Me.autoFertSetup_LabelSource.AutoSize = True
        Me.autoFertSetup_LabelSource.Location = New System.Drawing.Point(43, 22)
        Me.autoFertSetup_LabelSource.Name = "autoFertSetup_LabelSource"
        Me.autoFertSetup_LabelSource.Size = New System.Drawing.Size(41, 13)
        Me.autoFertSetup_LabelSource.TabIndex = 16
        Me.autoFertSetup_LabelSource.Text = "Source"
        '
        'autoFertSetup_labelS
        '
        Me.autoFertSetup_labelS.AutoSize = True
        Me.autoFertSetup_labelS.Location = New System.Drawing.Point(194, 182)
        Me.autoFertSetup_labelS.Name = "autoFertSetup_labelS"
        Me.autoFertSetup_labelS.Size = New System.Drawing.Size(14, 13)
        Me.autoFertSetup_labelS.TabIndex = 31
        Me.autoFertSetup_labelS.Text = "S"
        '
        'autoFertSetup_Source
        '
        Me.autoFertSetup_Source.FormattingEnabled = True
        Me.autoFertSetup_Source.Location = New System.Drawing.Point(90, 19)
        Me.autoFertSetup_Source.MaxDropDownItems = 10
        Me.autoFertSetup_Source.Name = "autoFertSetup_Source"
        Me.autoFertSetup_Source.Size = New System.Drawing.Size(148, 21)
        Me.autoFertSetup_Source.TabIndex = 0
        '
        'autoFertSetup_LabelMethod
        '
        Me.autoFertSetup_LabelMethod.AutoSize = True
        Me.autoFertSetup_LabelMethod.Location = New System.Drawing.Point(23, 96)
        Me.autoFertSetup_LabelMethod.Name = "autoFertSetup_LabelMethod"
        Me.autoFertSetup_LabelMethod.Size = New System.Drawing.Size(43, 13)
        Me.autoFertSetup_LabelMethod.TabIndex = 19
        Me.autoFertSetup_LabelMethod.Text = "Method"
        '
        'autoFertSetup_labelN_Charcoal
        '
        Me.autoFertSetup_labelN_Charcoal.AutoSize = True
        Me.autoFertSetup_labelN_Charcoal.Location = New System.Drawing.Point(148, 49)
        Me.autoFertSetup_labelN_Charcoal.Name = "autoFertSetup_labelN_Charcoal"
        Me.autoFertSetup_labelN_Charcoal.Size = New System.Drawing.Size(60, 13)
        Me.autoFertSetup_labelN_Charcoal.TabIndex = 24
        Me.autoFertSetup_labelN_Charcoal.Text = "N Charcoal"
        '
        'autoFertSetup_LabelMass
        '
        Me.autoFertSetup_LabelMass.AutoSize = True
        Me.autoFertSetup_LabelMass.Location = New System.Drawing.Point(34, 57)
        Me.autoFertSetup_LabelMass.Name = "autoFertSetup_LabelMass"
        Me.autoFertSetup_LabelMass.Size = New System.Drawing.Size(32, 13)
        Me.autoFertSetup_LabelMass.TabIndex = 17
        Me.autoFertSetup_LabelMass.Text = "Mass"
        '
        'autoFertSetup_labelK
        '
        Me.autoFertSetup_labelK.AutoSize = True
        Me.autoFertSetup_labelK.Location = New System.Drawing.Point(194, 163)
        Me.autoFertSetup_labelK.Name = "autoFertSetup_labelK"
        Me.autoFertSetup_labelK.Size = New System.Drawing.Size(14, 13)
        Me.autoFertSetup_labelK.TabIndex = 30
        Me.autoFertSetup_labelK.Text = "K"
        '
        'autoFertSetup_LabelForm
        '
        Me.autoFertSetup_LabelForm.AutoSize = True
        Me.autoFertSetup_LabelForm.Location = New System.Drawing.Point(36, 76)
        Me.autoFertSetup_LabelForm.Name = "autoFertSetup_LabelForm"
        Me.autoFertSetup_LabelForm.Size = New System.Drawing.Size(30, 13)
        Me.autoFertSetup_LabelForm.TabIndex = 18
        Me.autoFertSetup_LabelForm.Text = "Form"
        '
        'autoFertSetup_labelP_Inorganic
        '
        Me.autoFertSetup_labelP_Inorganic.AutoSize = True
        Me.autoFertSetup_labelP_Inorganic.Location = New System.Drawing.Point(147, 144)
        Me.autoFertSetup_labelP_Inorganic.Name = "autoFertSetup_labelP_Inorganic"
        Me.autoFertSetup_labelP_Inorganic.Size = New System.Drawing.Size(61, 13)
        Me.autoFertSetup_labelP_Inorganic.TabIndex = 29
        Me.autoFertSetup_labelP_Inorganic.Text = "P Inorganic"
        '
        'autoFertSetup_labelP_Charcoal
        '
        Me.autoFertSetup_labelP_Charcoal.AutoSize = True
        Me.autoFertSetup_labelP_Charcoal.Location = New System.Drawing.Point(149, 125)
        Me.autoFertSetup_labelP_Charcoal.Name = "autoFertSetup_labelP_Charcoal"
        Me.autoFertSetup_labelP_Charcoal.Size = New System.Drawing.Size(59, 13)
        Me.autoFertSetup_labelP_Charcoal.TabIndex = 28
        Me.autoFertSetup_labelP_Charcoal.Text = "P Charcoal"
        '
        'autoFertSetup_labelP_Organic
        '
        Me.autoFertSetup_labelP_Organic.AutoSize = True
        Me.autoFertSetup_labelP_Organic.Location = New System.Drawing.Point(154, 106)
        Me.autoFertSetup_labelP_Organic.Name = "autoFertSetup_labelP_Organic"
        Me.autoFertSetup_labelP_Organic.Size = New System.Drawing.Size(54, 13)
        Me.autoFertSetup_labelP_Organic.TabIndex = 27
        Me.autoFertSetup_labelP_Organic.Text = "P Organic"
        '
        'autoFertSetup_Method
        '
        Me.autoFertSetup_Method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.autoFertSetup_Method.FormattingEnabled = True
        Me.autoFertSetup_Method.Location = New System.Drawing.Point(72, 93)
        Me.autoFertSetup_Method.MaxDropDownItems = 10
        Me.autoFertSetup_Method.Name = "autoFertSetup_Method"
        Me.autoFertSetup_Method.Size = New System.Drawing.Size(70, 21)
        Me.autoFertSetup_Method.TabIndex = 3
        '
        'autoFertSetup_labelN_NO3
        '
        Me.autoFertSetup_labelN_NO3.AutoSize = True
        Me.autoFertSetup_labelN_NO3.Location = New System.Drawing.Point(168, 87)
        Me.autoFertSetup_labelN_NO3.Name = "autoFertSetup_labelN_NO3"
        Me.autoFertSetup_labelN_NO3.Size = New System.Drawing.Size(40, 13)
        Me.autoFertSetup_labelN_NO3.TabIndex = 26
        Me.autoFertSetup_labelN_NO3.Text = "N NO3"
        '
        'autoFertSetup_labelN_NH4
        '
        Me.autoFertSetup_labelN_NH4.AutoSize = True
        Me.autoFertSetup_labelN_NH4.Location = New System.Drawing.Point(168, 68)
        Me.autoFertSetup_labelN_NH4.Name = "autoFertSetup_labelN_NH4"
        Me.autoFertSetup_labelN_NH4.Size = New System.Drawing.Size(40, 13)
        Me.autoFertSetup_labelN_NH4.TabIndex = 25
        Me.autoFertSetup_labelN_NH4.Text = "N NH4"
        '
        'autoFertSetup_Form
        '
        Me.autoFertSetup_Form.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.autoFertSetup_Form.FormattingEnabled = True
        Me.autoFertSetup_Form.Location = New System.Drawing.Point(72, 73)
        Me.autoFertSetup_Form.MaxDropDownItems = 10
        Me.autoFertSetup_Form.Name = "autoFertSetup_Form"
        Me.autoFertSetup_Form.Size = New System.Drawing.Size(70, 21)
        Me.autoFertSetup_Form.TabIndex = 2
        '
        'autoFertSetup_labelN_Organic
        '
        Me.autoFertSetup_labelN_Organic.AutoSize = True
        Me.autoFertSetup_labelN_Organic.Location = New System.Drawing.Point(11, 173)
        Me.autoFertSetup_labelN_Organic.Name = "autoFertSetup_labelN_Organic"
        Me.autoFertSetup_labelN_Organic.Size = New System.Drawing.Size(55, 13)
        Me.autoFertSetup_labelN_Organic.TabIndex = 23
        Me.autoFertSetup_labelN_Organic.Text = "N Organic"
        '
        'autoFertSetup_labelC_Charcoal
        '
        Me.autoFertSetup_labelC_Charcoal.AutoSize = True
        Me.autoFertSetup_labelC_Charcoal.Location = New System.Drawing.Point(7, 153)
        Me.autoFertSetup_labelC_Charcoal.Name = "autoFertSetup_labelC_Charcoal"
        Me.autoFertSetup_labelC_Charcoal.Size = New System.Drawing.Size(59, 13)
        Me.autoFertSetup_labelC_Charcoal.TabIndex = 22
        Me.autoFertSetup_labelC_Charcoal.Text = "C Charcoal"
        '
        'autoFertSetup_labelC_Organic
        '
        Me.autoFertSetup_labelC_Organic.AutoSize = True
        Me.autoFertSetup_labelC_Organic.Location = New System.Drawing.Point(12, 135)
        Me.autoFertSetup_labelC_Organic.Name = "autoFertSetup_labelC_Organic"
        Me.autoFertSetup_labelC_Organic.Size = New System.Drawing.Size(54, 13)
        Me.autoFertSetup_labelC_Organic.TabIndex = 21
        Me.autoFertSetup_labelC_Organic.Text = "C Organic"
        '
        'autoFertSetup_labelDepth
        '
        Me.autoFertSetup_labelDepth.AutoSize = True
        Me.autoFertSetup_labelDepth.Location = New System.Drawing.Point(30, 116)
        Me.autoFertSetup_labelDepth.Name = "autoFertSetup_labelDepth"
        Me.autoFertSetup_labelDepth.Size = New System.Drawing.Size(36, 13)
        Me.autoFertSetup_labelDepth.TabIndex = 20
        Me.autoFertSetup_labelDepth.Text = "Depth"
        '
        'autoFertSetup_labelDefaultStartDay
        '
        Me.autoFertSetup_labelDefaultStartDay.AutoSize = True
        Me.autoFertSetup_labelDefaultStartDay.Location = New System.Drawing.Point(52, 69)
        Me.autoFertSetup_labelDefaultStartDay.Name = "autoFertSetup_labelDefaultStartDay"
        Me.autoFertSetup_labelDefaultStartDay.Size = New System.Drawing.Size(44, 13)
        Me.autoFertSetup_labelDefaultStartDay.TabIndex = 6
        Me.autoFertSetup_labelDefaultStartDay.Text = "Default:"
        Me.autoFertSetup_labelDefaultStartDay.Visible = False
        '
        'autoFertSetup_LabelStartDay
        '
        Me.autoFertSetup_LabelStartDay.AutoSize = True
        Me.autoFertSetup_LabelStartDay.Location = New System.Drawing.Point(39, 49)
        Me.autoFertSetup_LabelStartDay.Name = "autoFertSetup_LabelStartDay"
        Me.autoFertSetup_LabelStartDay.Size = New System.Drawing.Size(51, 13)
        Me.autoFertSetup_LabelStartDay.TabIndex = 5
        Me.autoFertSetup_LabelStartDay.Text = "Start Day"
        '
        'autoFertSetup_LabelEndDay
        '
        Me.autoFertSetup_LabelEndDay.AutoSize = True
        Me.autoFertSetup_LabelEndDay.Location = New System.Drawing.Point(157, 49)
        Me.autoFertSetup_LabelEndDay.Name = "autoFertSetup_LabelEndDay"
        Me.autoFertSetup_LabelEndDay.Size = New System.Drawing.Size(48, 13)
        Me.autoFertSetup_LabelEndDay.TabIndex = 7
        Me.autoFertSetup_LabelEndDay.Text = "End Day"
        '
        'autoFertSetup_LabelName
        '
        Me.autoFertSetup_LabelName.AutoSize = True
        Me.autoFertSetup_LabelName.Location = New System.Drawing.Point(63, 22)
        Me.autoFertSetup_LabelName.Name = "autoFertSetup_LabelName"
        Me.autoFertSetup_LabelName.Size = New System.Drawing.Size(60, 13)
        Me.autoFertSetup_LabelName.TabIndex = 4
        Me.autoFertSetup_LabelName.Text = "Crop Name"
        '
        'autoFertSetup_Name
        '
        Me.autoFertSetup_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.autoFertSetup_Name.FormattingEnabled = True
        Me.autoFertSetup_Name.Location = New System.Drawing.Point(129, 19)
        Me.autoFertSetup_Name.MaxDropDownItems = 6
        Me.autoFertSetup_Name.Name = "autoFertSetup_Name"
        Me.autoFertSetup_Name.Size = New System.Drawing.Size(102, 21)
        Me.autoFertSetup_Name.TabIndex = 0
        '
        'grp_AutoFertilization
        '
        Me.grp_AutoFertilization.Controls.Add(Me.lv_AutoFertilization)
        Me.grp_AutoFertilization.Location = New System.Drawing.Point(372, 6)
        Me.grp_AutoFertilization.Name = "grp_AutoFertilization"
        Me.grp_AutoFertilization.Size = New System.Drawing.Size(302, 514)
        Me.grp_AutoFertilization.TabIndex = 3
        Me.grp_AutoFertilization.TabStop = False
        Me.grp_AutoFertilization.Text = "Active Operations: 0"
        '
        'lv_AutoFertilization
        '
        Me.lv_AutoFertilization.BackColor = System.Drawing.SystemColors.Window
        Me.lv_AutoFertilization.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_AutoFertilization.FullRowSelect = True
        Me.lv_AutoFertilization.Location = New System.Drawing.Point(3, 16)
        Me.lv_AutoFertilization.MultiSelect = False
        Me.lv_AutoFertilization.Name = "lv_AutoFertilization"
        Me.lv_AutoFertilization.Size = New System.Drawing.Size(296, 495)
        Me.lv_AutoFertilization.TabIndex = 0
        Me.lv_AutoFertilization.UseCompatibleStateImageBehavior = False
        '
        'btn_ChangeAutoFertOp
        '
        Me.btn_ChangeAutoFertOp.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_ChangeAutoFertOp.Location = New System.Drawing.Point(312, 271)
        Me.btn_ChangeAutoFertOp.Name = "btn_ChangeAutoFertOp"
        Me.btn_ChangeAutoFertOp.Size = New System.Drawing.Size(54, 23)
        Me.btn_ChangeAutoFertOp.TabIndex = 2
        Me.btn_ChangeAutoFertOp.Text = "f"
        Me.btn_ChangeAutoFertOp.UseVisualStyleBackColor = True
        '
        'autoFertSetup_PerformOperations
        '
        Me.autoFertSetup_PerformOperations.AutoSize = True
        Me.autoFertSetup_PerformOperations.Checked = True
        Me.autoFertSetup_PerformOperations.CheckState = System.Windows.Forms.CheckState.Checked
        Me.autoFertSetup_PerformOperations.Enabled = False
        Me.autoFertSetup_PerformOperations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autoFertSetup_PerformOperations.Location = New System.Drawing.Point(100, 88)
        Me.autoFertSetup_PerformOperations.Name = "autoFertSetup_PerformOperations"
        Me.autoFertSetup_PerformOperations.Size = New System.Drawing.Size(134, 17)
        Me.autoFertSetup_PerformOperations.TabIndex = 0
        Me.autoFertSetup_PerformOperations.Text = "Perform Operations"
        Me.autoFertSetup_PerformOperations.UseVisualStyleBackColor = True
        '
        'Tab_Crop
        '
        Me.Tab_Crop.Controls.Add(Me.grp_CropAdvancedDescrip)
        Me.Tab_Crop.Controls.Add(Me.grp_DescribedCrops)
        Me.Tab_Crop.Controls.Add(Me.grp_CropDescrip)
        Me.Tab_Crop.Controls.Add(Me.btn_AddDescribedCrop)
        Me.Tab_Crop.Controls.Add(Me.btn_ChangeDescribedCrop)
        Me.Tab_Crop.Location = New System.Drawing.Point(4, 22)
        Me.Tab_Crop.Name = "Tab_Crop"
        Me.Tab_Crop.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Crop.Size = New System.Drawing.Size(680, 547)
        Me.Tab_Crop.TabIndex = 5
        Me.Tab_Crop.Text = "Crop Descriptions"
        Me.Tab_Crop.UseVisualStyleBackColor = True
        '
        'grp_CropAdvancedDescrip
        '
        Me.grp_CropAdvancedDescrip.Controls.Add(Me.pnl_CropAdvancedDescrip)
        Me.grp_CropAdvancedDescrip.Location = New System.Drawing.Point(323, 6)
        Me.grp_CropAdvancedDescrip.Name = "grp_CropAdvancedDescrip"
        Me.grp_CropAdvancedDescrip.Size = New System.Drawing.Size(351, 320)
        Me.grp_CropAdvancedDescrip.TabIndex = 1
        Me.grp_CropAdvancedDescrip.TabStop = False
        Me.grp_CropAdvancedDescrip.Text = "Advanced Descriptions"
        '
        'pnl_CropAdvancedDescrip
        '
        Me.pnl_CropAdvancedDescrip.AutoScroll = True
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel31)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip31)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip34)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel34)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel30)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip30)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel29)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip29)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip33)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel33)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel27)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel28)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip32)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip27)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip28)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel32)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel26)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel25)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel24)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel20)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel21)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel14)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel22)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip14)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel23)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip15)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip16)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel15)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip17)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel16)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip18)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel17)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip19)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel18)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip20)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropLabel19)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip21)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip22)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip26)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip23)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip25)
        Me.pnl_CropAdvancedDescrip.Controls.Add(Me.CropDescrip24)
        Me.pnl_CropAdvancedDescrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_CropAdvancedDescrip.Location = New System.Drawing.Point(3, 16)
        Me.pnl_CropAdvancedDescrip.Name = "pnl_CropAdvancedDescrip"
        Me.pnl_CropAdvancedDescrip.Size = New System.Drawing.Size(345, 301)
        Me.pnl_CropAdvancedDescrip.TabIndex = 0
        '
        'CropLabel31
        '
        Me.CropLabel31.AutoSize = True
        Me.CropLabel31.Location = New System.Drawing.Point(194, 329)
        Me.CropLabel31.Name = "CropLabel31"
        Me.CropLabel31.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel31.Size = New System.Drawing.Size(20, 13)
        Me.CropLabel31.TabIndex = 38
        Me.CropLabel31.Text = "Kc"
        '
        'CropDescrip34
        '
        Me.CropDescrip34.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CropDescrip34.Enabled = False
        Me.CropDescrip34.FormattingEnabled = True
        Me.CropDescrip34.Items.AddRange(New Object() {"True", "False"})
        Me.CropDescrip34.Location = New System.Drawing.Point(220, 385)
        Me.CropDescrip34.MaxDropDownItems = 2
        Me.CropDescrip34.Name = "CropDescrip34"
        Me.CropDescrip34.Size = New System.Drawing.Size(78, 21)
        Me.CropDescrip34.TabIndex = 20
        '
        'CropLabel34
        '
        Me.CropLabel34.AutoSize = True
        Me.CropLabel34.Location = New System.Drawing.Point(166, 388)
        Me.CropLabel34.Name = "CropLabel34"
        Me.CropLabel34.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel34.Size = New System.Drawing.Size(48, 13)
        Me.CropLabel34.TabIndex = 41
        Me.CropLabel34.Text = "C3 or C4"
        '
        'CropLabel30
        '
        Me.CropLabel30.AutoSize = True
        Me.CropLabel30.Location = New System.Drawing.Point(131, 310)
        Me.CropLabel30.Name = "CropLabel30"
        Me.CropLabel30.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel30.Size = New System.Drawing.Size(83, 13)
        Me.CropLabel30.TabIndex = 37
        Me.CropLabel30.Text = "N Dilution Slope"
        '
        'CropLabel29
        '
        Me.CropLabel29.AutoSize = True
        Me.CropLabel29.Location = New System.Drawing.Point(107, 291)
        Me.CropLabel29.Name = "CropLabel29"
        Me.CropLabel29.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel29.Size = New System.Drawing.Size(107, 13)
        Me.CropLabel29.TabIndex = 36
        Me.CropLabel29.Text = "N Max Concentration"
        '
        'CropDescrip33
        '
        Me.CropDescrip33.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CropDescrip33.Enabled = False
        Me.CropDescrip33.FormattingEnabled = True
        Me.CropDescrip33.Location = New System.Drawing.Point(220, 365)
        Me.CropDescrip33.MaxDropDownItems = 2
        Me.CropDescrip33.Name = "CropDescrip33"
        Me.CropDescrip33.Size = New System.Drawing.Size(78, 21)
        Me.CropDescrip33.TabIndex = 19
        '
        'CropLabel33
        '
        Me.CropLabel33.AutoSize = True
        Me.CropLabel33.Location = New System.Drawing.Point(169, 368)
        Me.CropLabel33.Name = "CropLabel33"
        Me.CropLabel33.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel33.Size = New System.Drawing.Size(45, 13)
        Me.CropLabel33.TabIndex = 40
        Me.CropLabel33.Text = "Legume"
        '
        'CropLabel27
        '
        Me.CropLabel27.AutoSize = True
        Me.CropLabel27.Location = New System.Drawing.Point(108, 253)
        Me.CropLabel27.Name = "CropLabel27"
        Me.CropLabel27.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel27.Size = New System.Drawing.Size(106, 13)
        Me.CropLabel27.TabIndex = 34
        Me.CropLabel27.Text = "Harvest Index Factor"
        '
        'CropLabel28
        '
        Me.CropLabel28.AutoSize = True
        Me.CropLabel28.Location = New System.Drawing.Point(76, 272)
        Me.CropLabel28.Name = "CropLabel28"
        Me.CropLabel28.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel28.Size = New System.Drawing.Size(138, 13)
        Me.CropLabel28.TabIndex = 35
        Me.CropLabel28.Text = "Thermal Time til Emergence"
        '
        'CropDescrip32
        '
        Me.CropDescrip32.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CropDescrip32.Enabled = False
        Me.CropDescrip32.FormattingEnabled = True
        Me.CropDescrip32.Location = New System.Drawing.Point(220, 345)
        Me.CropDescrip32.MaxDropDownItems = 2
        Me.CropDescrip32.Name = "CropDescrip32"
        Me.CropDescrip32.Size = New System.Drawing.Size(78, 21)
        Me.CropDescrip32.TabIndex = 18
        '
        'CropLabel32
        '
        Me.CropLabel32.AutoSize = True
        Me.CropLabel32.Location = New System.Drawing.Point(145, 348)
        Me.CropLabel32.Name = "CropLabel32"
        Me.CropLabel32.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel32.Size = New System.Drawing.Size(69, 13)
        Me.CropLabel32.TabIndex = 39
        Me.CropLabel32.Text = "Growth Habit"
        '
        'CropLabel26
        '
        Me.CropLabel26.AutoSize = True
        Me.CropLabel26.Location = New System.Drawing.Point(121, 234)
        Me.CropLabel26.Name = "CropLabel26"
        Me.CropLabel26.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel26.Size = New System.Drawing.Size(93, 13)
        Me.CropLabel26.TabIndex = 33
        Me.CropLabel26.Text = "Min Harvest Index"
        '
        'CropLabel25
        '
        Me.CropLabel25.AutoSize = True
        Me.CropLabel25.Location = New System.Drawing.Point(118, 215)
        Me.CropLabel25.Name = "CropLabel25"
        Me.CropLabel25.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel25.Size = New System.Drawing.Size(96, 13)
        Me.CropLabel25.TabIndex = 32
        Me.CropLabel25.Text = "Max Harvest Index"
        '
        'CropLabel24
        '
        Me.CropLabel24.AutoSize = True
        Me.CropLabel24.Location = New System.Drawing.Point(75, 196)
        Me.CropLabel24.Name = "CropLabel24"
        Me.CropLabel24.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel24.Size = New System.Drawing.Size(139, 13)
        Me.CropLabel24.TabIndex = 31
        Me.CropLabel24.Text = "Transpiration Use Efficiency"
        '
        'CropLabel20
        '
        Me.CropLabel20.AutoSize = True
        Me.CropLabel20.Location = New System.Drawing.Point(19, 120)
        Me.CropLabel20.Name = "CropLabel20"
        Me.CropLabel20.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel20.Size = New System.Drawing.Size(195, 13)
        Me.CropLabel20.TabIndex = 27
        Me.CropLabel20.Text = "Maximum Temperature for Development"
        '
        'CropLabel21
        '
        Me.CropLabel21.AutoSize = True
        Me.CropLabel21.Location = New System.Drawing.Point(85, 139)
        Me.CropLabel21.Name = "CropLabel21"
        Me.CropLabel21.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel21.Size = New System.Drawing.Size(129, 13)
        Me.CropLabel21.TabIndex = 28
        Me.CropLabel21.Text = "Initial Partitioning to Shoot"
        '
        'CropLabel14
        '
        Me.CropLabel14.AutoSize = True
        Me.CropLabel14.Location = New System.Drawing.Point(48, 6)
        Me.CropLabel14.Name = "CropLabel14"
        Me.CropLabel14.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel14.Size = New System.Drawing.Size(166, 13)
        Me.CropLabel14.TabIndex = 21
        Me.CropLabel14.Text = "Min Temperature for Transpiration"
        '
        'CropLabel22
        '
        Me.CropLabel22.AutoSize = True
        Me.CropLabel22.Location = New System.Drawing.Point(87, 158)
        Me.CropLabel22.Name = "CropLabel22"
        Me.CropLabel22.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel22.Size = New System.Drawing.Size(127, 13)
        Me.CropLabel22.TabIndex = 29
        Me.CropLabel22.Text = "Final Partitioning to Shoot"
        '
        'CropLabel23
        '
        Me.CropLabel23.AutoSize = True
        Me.CropLabel23.Location = New System.Drawing.Point(91, 177)
        Me.CropLabel23.Name = "CropLabel23"
        Me.CropLabel23.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel23.Size = New System.Drawing.Size(123, 13)
        Me.CropLabel23.TabIndex = 30
        Me.CropLabel23.Text = "Radiation Use Efficiency"
        '
        'CropLabel15
        '
        Me.CropLabel15.AutoSize = True
        Me.CropLabel15.Location = New System.Drawing.Point(18, 25)
        Me.CropLabel15.Name = "CropLabel15"
        Me.CropLabel15.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel15.Size = New System.Drawing.Size(196, 13)
        Me.CropLabel15.TabIndex = 22
        Me.CropLabel15.Text = "Threshold Temperature for Transpiration"
        '
        'CropLabel16
        '
        Me.CropLabel16.AutoSize = True
        Me.CropLabel16.Location = New System.Drawing.Point(45, 44)
        Me.CropLabel16.Name = "CropLabel16"
        Me.CropLabel16.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel16.Size = New System.Drawing.Size(169, 13)
        Me.CropLabel16.TabIndex = 23
        Me.CropLabel16.Text = "Min Temperature for Cold Damage"
        '
        'CropLabel17
        '
        Me.CropLabel17.AutoSize = True
        Me.CropLabel17.Location = New System.Drawing.Point(15, 63)
        Me.CropLabel17.Name = "CropLabel17"
        Me.CropLabel17.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel17.Size = New System.Drawing.Size(199, 13)
        Me.CropLabel17.TabIndex = 24
        Me.CropLabel17.Text = "Threshold Temperature for Cold Damage"
        '
        'CropLabel18
        '
        Me.CropLabel18.AutoSize = True
        Me.CropLabel18.Location = New System.Drawing.Point(39, 82)
        Me.CropLabel18.Name = "CropLabel18"
        Me.CropLabel18.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel18.Size = New System.Drawing.Size(175, 13)
        Me.CropLabel18.TabIndex = 25
        Me.CropLabel18.Text = "Base Temperature for Development"
        '
        'CropLabel19
        '
        Me.CropLabel19.AutoSize = True
        Me.CropLabel19.Location = New System.Drawing.Point(22, 101)
        Me.CropLabel19.Name = "CropLabel19"
        Me.CropLabel19.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel19.Size = New System.Drawing.Size(192, 13)
        Me.CropLabel19.TabIndex = 26
        Me.CropLabel19.Text = "Optimum Temperature for Development"
        '
        'grp_DescribedCrops
        '
        Me.grp_DescribedCrops.Controls.Add(Me.lv_DescribedCrops)
        Me.grp_DescribedCrops.Location = New System.Drawing.Point(3, 361)
        Me.grp_DescribedCrops.Name = "grp_DescribedCrops"
        Me.grp_DescribedCrops.Size = New System.Drawing.Size(671, 183)
        Me.grp_DescribedCrops.TabIndex = 4
        Me.grp_DescribedCrops.TabStop = False
        Me.grp_DescribedCrops.Text = "Described Crops: 0"
        '
        'lv_DescribedCrops
        '
        Me.lv_DescribedCrops.BackColor = System.Drawing.SystemColors.Window
        Me.lv_DescribedCrops.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_DescribedCrops.FullRowSelect = True
        Me.lv_DescribedCrops.GridLines = True
        Me.lv_DescribedCrops.Location = New System.Drawing.Point(3, 16)
        Me.lv_DescribedCrops.MultiSelect = False
        Me.lv_DescribedCrops.Name = "lv_DescribedCrops"
        Me.lv_DescribedCrops.Size = New System.Drawing.Size(665, 164)
        Me.lv_DescribedCrops.TabIndex = 0
        Me.lv_DescribedCrops.UseCompatibleStateImageBehavior = False
        '
        'grp_CropDescrip
        '
        Me.grp_CropDescrip.Controls.Add(Me.CropDescrip13)
        Me.grp_CropDescrip.Controls.Add(Me.CropDescrip12)
        Me.grp_CropDescrip.Controls.Add(Me.CropDescrip11)
        Me.grp_CropDescrip.Controls.Add(Me.CropDescrip10)
        Me.grp_CropDescrip.Controls.Add(Me.CropDescrip5)
        Me.grp_CropDescrip.Controls.Add(Me.CropDescrip4)
        Me.grp_CropDescrip.Controls.Add(Me.CropDescrip3)
        Me.grp_CropDescrip.Controls.Add(Me.CropDescrip2)
        Me.grp_CropDescrip.Controls.Add(Me.Chkbx_UseAdvancedDescrip)
        Me.grp_CropDescrip.Controls.Add(Me.CropDescrip9)
        Me.grp_CropDescrip.Controls.Add(Me.CropDescrip8)
        Me.grp_CropDescrip.Controls.Add(Me.CropDescrip7)
        Me.grp_CropDescrip.Controls.Add(Me.CropDescrip6)
        Me.grp_CropDescrip.Controls.Add(Me.CropDescrip1)
        Me.grp_CropDescrip.Controls.Add(Me.CropLabel13)
        Me.grp_CropDescrip.Controls.Add(Me.CropLabel12)
        Me.grp_CropDescrip.Controls.Add(Me.CropLabel11)
        Me.grp_CropDescrip.Controls.Add(Me.CropLabel7)
        Me.grp_CropDescrip.Controls.Add(Me.CropLabel8)
        Me.grp_CropDescrip.Controls.Add(Me.CropLabel9)
        Me.grp_CropDescrip.Controls.Add(Me.CropLabel10)
        Me.grp_CropDescrip.Controls.Add(Me.CropLabel1)
        Me.grp_CropDescrip.Controls.Add(Me.CropLabel2)
        Me.grp_CropDescrip.Controls.Add(Me.CropLabel3)
        Me.grp_CropDescrip.Controls.Add(Me.CropLabel4)
        Me.grp_CropDescrip.Controls.Add(Me.CropLabel5)
        Me.grp_CropDescrip.Controls.Add(Me.CropLabel6)
        Me.grp_CropDescrip.Location = New System.Drawing.Point(3, 6)
        Me.grp_CropDescrip.Name = "grp_CropDescrip"
        Me.grp_CropDescrip.Size = New System.Drawing.Size(321, 320)
        Me.grp_CropDescrip.TabIndex = 0
        Me.grp_CropDescrip.TabStop = False
        Me.grp_CropDescrip.Text = "Crop Description Setup"
        '
        'CropDescrip13
        '
        Me.CropDescrip13.Enabled = False
        Me.CropDescrip13.Location = New System.Drawing.Point(203, 280)
        Me.CropDescrip13.Name = "CropDescrip13"
        Me.CropDescrip13.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip13.TabIndex = 13
        Me.CropDescrip13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CropDescrip12
        '
        Me.CropDescrip12.Enabled = False
        Me.CropDescrip12.Location = New System.Drawing.Point(203, 261)
        Me.CropDescrip12.Name = "CropDescrip12"
        Me.CropDescrip12.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip12.TabIndex = 12
        Me.CropDescrip12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CropDescrip11
        '
        Me.CropDescrip11.Enabled = False
        Me.CropDescrip11.Location = New System.Drawing.Point(203, 242)
        Me.CropDescrip11.Name = "CropDescrip11"
        Me.CropDescrip11.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip11.TabIndex = 11
        Me.CropDescrip11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CropDescrip10
        '
        Me.CropDescrip10.Enabled = False
        Me.CropDescrip10.Location = New System.Drawing.Point(203, 223)
        Me.CropDescrip10.Name = "CropDescrip10"
        Me.CropDescrip10.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip10.TabIndex = 10
        Me.CropDescrip10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CropDescrip5
        '
        Me.CropDescrip5.Enabled = False
        Me.CropDescrip5.Location = New System.Drawing.Point(203, 128)
        Me.CropDescrip5.Name = "CropDescrip5"
        Me.CropDescrip5.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip5.TabIndex = 5
        Me.CropDescrip5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Chkbx_UseAdvancedDescrip
        '
        Me.Chkbx_UseAdvancedDescrip.AutoSize = True
        Me.Chkbx_UseAdvancedDescrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chkbx_UseAdvancedDescrip.Location = New System.Drawing.Point(40, 23)
        Me.Chkbx_UseAdvancedDescrip.Name = "Chkbx_UseAdvancedDescrip"
        Me.Chkbx_UseAdvancedDescrip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Chkbx_UseAdvancedDescrip.Size = New System.Drawing.Size(264, 17)
        Me.Chkbx_UseAdvancedDescrip.TabIndex = 0
        Me.Chkbx_UseAdvancedDescrip.Text = "Modify Advanced Descriptions (not recommended)"
        Me.Chkbx_UseAdvancedDescrip.UseVisualStyleBackColor = True
        '
        'CropDescrip9
        '
        Me.CropDescrip9.Enabled = False
        Me.CropDescrip9.Location = New System.Drawing.Point(203, 204)
        Me.CropDescrip9.Name = "CropDescrip9"
        Me.CropDescrip9.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip9.TabIndex = 9
        Me.CropDescrip9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CropDescrip8
        '
        Me.CropDescrip8.Enabled = False
        Me.CropDescrip8.Location = New System.Drawing.Point(203, 185)
        Me.CropDescrip8.Name = "CropDescrip8"
        Me.CropDescrip8.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip8.TabIndex = 8
        Me.CropDescrip8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CropDescrip7
        '
        Me.CropDescrip7.Enabled = False
        Me.CropDescrip7.Location = New System.Drawing.Point(203, 166)
        Me.CropDescrip7.Name = "CropDescrip7"
        Me.CropDescrip7.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip7.TabIndex = 7
        Me.CropDescrip7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CropDescrip6
        '
        Me.CropDescrip6.Enabled = False
        Me.CropDescrip6.Location = New System.Drawing.Point(203, 147)
        Me.CropDescrip6.Name = "CropDescrip6"
        Me.CropDescrip6.Size = New System.Drawing.Size(78, 20)
        Me.CropDescrip6.TabIndex = 6
        Me.CropDescrip6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CropDescrip1
        '
        Me.CropDescrip1.FormattingEnabled = True
        Me.CropDescrip1.Location = New System.Drawing.Point(157, 51)
        Me.CropDescrip1.MaxDropDownItems = 10
        Me.CropDescrip1.Name = "CropDescrip1"
        Me.CropDescrip1.Size = New System.Drawing.Size(124, 21)
        Me.CropDescrip1.TabIndex = 1
        '
        'CropLabel13
        '
        Me.CropLabel13.AutoSize = True
        Me.CropLabel13.Location = New System.Drawing.Point(42, 283)
        Me.CropLabel13.Name = "CropLabel13"
        Me.CropLabel13.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel13.Size = New System.Drawing.Size(155, 13)
        Me.CropLabel13.TabIndex = 26
        Me.CropLabel13.Text = "Harvest Timing as % of Maturity"
        '
        'CropLabel12
        '
        Me.CropLabel12.AutoSize = True
        Me.CropLabel12.Location = New System.Drawing.Point(91, 264)
        Me.CropLabel12.Name = "CropLabel12"
        Me.CropLabel12.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel12.Size = New System.Drawing.Size(106, 13)
        Me.CropLabel12.TabIndex = 25
        Me.CropLabel12.Text = "Residue Removed %"
        '
        'CropLabel11
        '
        Me.CropLabel11.AutoSize = True
        Me.CropLabel11.Location = New System.Drawing.Point(43, 245)
        Me.CropLabel11.Name = "CropLabel11"
        Me.CropLabel11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel11.Size = New System.Drawing.Size(154, 13)
        Me.CropLabel11.TabIndex = 24
        Me.CropLabel11.Text = "Standing Residue at Harvest %"
        '
        'CropLabel7
        '
        Me.CropLabel7.AutoSize = True
        Me.CropLabel7.Location = New System.Drawing.Point(76, 169)
        Me.CropLabel7.Name = "CropLabel7"
        Me.CropLabel7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel7.Size = New System.Drawing.Size(121, 13)
        Me.CropLabel7.TabIndex = 20
        Me.CropLabel7.Text = "Average Expected Yield"
        '
        'CropLabel8
        '
        Me.CropLabel8.AutoSize = True
        Me.CropLabel8.Location = New System.Drawing.Point(72, 188)
        Me.CropLabel8.Name = "CropLabel8"
        Me.CropLabel8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel8.Size = New System.Drawing.Size(125, 13)
        Me.CropLabel8.TabIndex = 21
        Me.CropLabel8.Text = "Maximum Expected Yield"
        '
        'CropLabel9
        '
        Me.CropLabel9.AutoSize = True
        Me.CropLabel9.Location = New System.Drawing.Point(75, 207)
        Me.CropLabel9.Name = "CropLabel9"
        Me.CropLabel9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel9.Size = New System.Drawing.Size(122, 13)
        Me.CropLabel9.TabIndex = 22
        Me.CropLabel9.Text = "Minimum Expected Yield"
        '
        'CropLabel10
        '
        Me.CropLabel10.AutoSize = True
        Me.CropLabel10.Location = New System.Drawing.Point(56, 226)
        Me.CropLabel10.Name = "CropLabel10"
        Me.CropLabel10.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel10.Size = New System.Drawing.Size(141, 13)
        Me.CropLabel10.TabIndex = 23
        Me.CropLabel10.Text = "Commercial Yield Moisture %"
        '
        'CropLabel1
        '
        Me.CropLabel1.AutoSize = True
        Me.CropLabel1.Location = New System.Drawing.Point(91, 54)
        Me.CropLabel1.Name = "CropLabel1"
        Me.CropLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel1.Size = New System.Drawing.Size(60, 13)
        Me.CropLabel1.TabIndex = 14
        Me.CropLabel1.Text = "Crop Name"
        '
        'CropLabel2
        '
        Me.CropLabel2.AutoSize = True
        Me.CropLabel2.Location = New System.Drawing.Point(86, 74)
        Me.CropLabel2.Name = "CropLabel2"
        Me.CropLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel2.Size = New System.Drawing.Size(111, 13)
        Me.CropLabel2.TabIndex = 15
        Me.CropLabel2.Text = "Average Seeding Day"
        '
        'CropLabel3
        '
        Me.CropLabel3.AutoSize = True
        Me.CropLabel3.Location = New System.Drawing.Point(57, 93)
        Me.CropLabel3.Name = "CropLabel3"
        Me.CropLabel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel3.Size = New System.Drawing.Size(140, 13)
        Me.CropLabel3.TabIndex = 16
        Me.CropLabel3.Text = "Average 50% Flowering Day"
        '
        'CropLabel4
        '
        Me.CropLabel4.AutoSize = True
        Me.CropLabel4.Location = New System.Drawing.Point(88, 112)
        Me.CropLabel4.Name = "CropLabel4"
        Me.CropLabel4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel4.Size = New System.Drawing.Size(109, 13)
        Me.CropLabel4.TabIndex = 17
        Me.CropLabel4.Text = "Average Maturity Day"
        '
        'CropLabel5
        '
        Me.CropLabel5.AutoSize = True
        Me.CropLabel5.Location = New System.Drawing.Point(77, 131)
        Me.CropLabel5.Name = "CropLabel5"
        Me.CropLabel5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel5.Size = New System.Drawing.Size(120, 13)
        Me.CropLabel5.TabIndex = 18
        Me.CropLabel5.Text = "Maximum Soil Coverage"
        '
        'CropLabel6
        '
        Me.CropLabel6.AutoSize = True
        Me.CropLabel6.Location = New System.Drawing.Point(74, 150)
        Me.CropLabel6.Name = "CropLabel6"
        Me.CropLabel6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CropLabel6.Size = New System.Drawing.Size(123, 13)
        Me.CropLabel6.TabIndex = 19
        Me.CropLabel6.Text = "Maximum Rooting Depth"
        '
        'btn_ChangeDescribedCrop
        '
        Me.btn_ChangeDescribedCrop.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_ChangeDescribedCrop.Location = New System.Drawing.Point(342, 332)
        Me.btn_ChangeDescribedCrop.Name = "btn_ChangeDescribedCrop"
        Me.btn_ChangeDescribedCrop.Size = New System.Drawing.Size(54, 23)
        Me.btn_ChangeDescribedCrop.TabIndex = 3
        Me.btn_ChangeDescribedCrop.Text = "h"
        Me.btn_ChangeDescribedCrop.UseVisualStyleBackColor = True
        '
        'Tab_Soil
        '
        Me.Tab_Soil.Controls.Add(Me.soil_labelMaxLayer)
        Me.Tab_Soil.Controls.Add(Me.soil_maxLayer)
        Me.Tab_Soil.Controls.Add(Me.grp_SoilProfile)
        Me.Tab_Soil.Controls.Add(Me.soil_labelSlope)
        Me.Tab_Soil.Controls.Add(Me.soil_curve)
        Me.Tab_Soil.Controls.Add(Me.soil_slope)
        Me.Tab_Soil.Controls.Add(Me.soil_labelCurve)
        Me.Tab_Soil.Controls.Add(Me.Manual_PWP_ckbx)
        Me.Tab_Soil.Controls.Add(Me.Manual_BD_ckbx)
        Me.Tab_Soil.Controls.Add(Me.Manual_FC_ckbx)
        Me.Tab_Soil.Controls.Add(Me.soil_labelPWP1)
        Me.Tab_Soil.Controls.Add(Me.soil_labelSand1)
        Me.Tab_Soil.Controls.Add(Me.soil_labelSand2)
        Me.Tab_Soil.Controls.Add(Me.soil_labelIOM2)
        Me.Tab_Soil.Controls.Add(Me.soil_labelIOM3)
        Me.Tab_Soil.Controls.Add(Me.soil_labelFC1)
        Me.Tab_Soil.Controls.Add(Me.soil_labelFC2)
        Me.Tab_Soil.Controls.Add(Me.soil_labelFC3)
        Me.Tab_Soil.Controls.Add(Me.soil_labelPWP2)
        Me.Tab_Soil.Controls.Add(Me.soil_labelPWP3)
        Me.Tab_Soil.Controls.Add(Me.soil_labelNitrogen2)
        Me.Tab_Soil.Controls.Add(Me.soil_labelNitrogen3)
        Me.Tab_Soil.Controls.Add(Me.soil_labelAmmonium2)
        Me.Tab_Soil.Controls.Add(Me.soil_labelAmmonium3)
        Me.Tab_Soil.Controls.Add(Me.soil_labelNitrogen1)
        Me.Tab_Soil.Controls.Add(Me.soil_labelAmmonium1)
        Me.Tab_Soil.Controls.Add(Me.soil_labelLayerThickness1)
        Me.Tab_Soil.Controls.Add(Me.soil_labelLayerThickness2)
        Me.Tab_Soil.Controls.Add(Me.soil_labelLayerThickness3)
        Me.Tab_Soil.Controls.Add(Me.soil_labelCumDepth1)
        Me.Tab_Soil.Controls.Add(Me.soil_labelCumDepth2)
        Me.Tab_Soil.Controls.Add(Me.soil_labelClay1)
        Me.Tab_Soil.Controls.Add(Me.soil_labelIOM1)
        Me.Tab_Soil.Controls.Add(Me.soil_labelBD2)
        Me.Tab_Soil.Controls.Add(Me.soil_labelBD1)
        Me.Tab_Soil.Controls.Add(Me.soil_labelCumDepth3)
        Me.Tab_Soil.Controls.Add(Me.soil_labelClay2)
        Me.Tab_Soil.Controls.Add(Me.soil_labelBD3)
        Me.Tab_Soil.Controls.Add(Me.soil_labelLayer)
        Me.Tab_Soil.Location = New System.Drawing.Point(4, 22)
        Me.Tab_Soil.Name = "Tab_Soil"
        Me.Tab_Soil.Size = New System.Drawing.Size(680, 547)
        Me.Tab_Soil.TabIndex = 3
        Me.Tab_Soil.Text = "Soil Description"
        Me.Tab_Soil.UseVisualStyleBackColor = True
        '
        'soil_labelMaxLayer
        '
        Me.soil_labelMaxLayer.AutoSize = True
        Me.soil_labelMaxLayer.Location = New System.Drawing.Point(71, 50)
        Me.soil_labelMaxLayer.Name = "soil_labelMaxLayer"
        Me.soil_labelMaxLayer.Size = New System.Drawing.Size(56, 13)
        Me.soil_labelMaxLayer.TabIndex = 452
        Me.soil_labelMaxLayer.Text = "Max Layer"
        '
        'soil_maxLayer
        '
        Me.soil_maxLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.soil_maxLayer.FormattingEnabled = True
        Me.soil_maxLayer.Location = New System.Drawing.Point(133, 47)
        Me.soil_maxLayer.MaxDropDownItems = 10
        Me.soil_maxLayer.Name = "soil_maxLayer"
        Me.soil_maxLayer.Size = New System.Drawing.Size(55, 21)
        Me.soil_maxLayer.TabIndex = 2
        '
        'grp_SoilProfile
        '
        Me.grp_SoilProfile.AutoScroll = True
        Me.grp_SoilProfile.Controls.Add(Me.grp_LayerButtons)
        Me.grp_SoilProfile.Location = New System.Drawing.Point(19, 119)
        Me.grp_SoilProfile.Name = "grp_SoilProfile"
        Me.grp_SoilProfile.Size = New System.Drawing.Size(648, 406)
        Me.grp_SoilProfile.TabIndex = 450
        '
        'grp_LayerButtons
        '
        Me.grp_LayerButtons.BackColor = System.Drawing.Color.Transparent
        Me.grp_LayerButtons.Location = New System.Drawing.Point(5, 0)
        Me.grp_LayerButtons.Name = "grp_LayerButtons"
        Me.grp_LayerButtons.Size = New System.Drawing.Size(52, 20)
        Me.grp_LayerButtons.TabIndex = 1
        Me.grp_LayerButtons.TabStop = True
        '
        'soil_labelSlope
        '
        Me.soil_labelSlope.AutoSize = True
        Me.soil_labelSlope.Location = New System.Drawing.Point(93, 31)
        Me.soil_labelSlope.Name = "soil_labelSlope"
        Me.soil_labelSlope.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.soil_labelSlope.Size = New System.Drawing.Size(34, 13)
        Me.soil_labelSlope.TabIndex = 307
        Me.soil_labelSlope.Text = "Slope"
        '
        'soil_labelCurve
        '
        Me.soil_labelCurve.AutoSize = True
        Me.soil_labelCurve.Location = New System.Drawing.Point(22, 12)
        Me.soil_labelCurve.Name = "soil_labelCurve"
        Me.soil_labelCurve.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.soil_labelCurve.Size = New System.Drawing.Size(105, 13)
        Me.soil_labelCurve.TabIndex = 306
        Me.soil_labelCurve.Text = "Curve Number (CN2)"
        '
        'Manual_PWP_ckbx
        '
        Me.Manual_PWP_ckbx.AutoSize = True
        Me.Manual_PWP_ckbx.Location = New System.Drawing.Point(603, 60)
        Me.Manual_PWP_ckbx.Name = "Manual_PWP_ckbx"
        Me.Manual_PWP_ckbx.Size = New System.Drawing.Size(15, 14)
        Me.Manual_PWP_ckbx.TabIndex = 11
        Me.Manual_PWP_ckbx.UseVisualStyleBackColor = True
        '
        'Manual_BD_ckbx
        '
        Me.Manual_BD_ckbx.AutoSize = True
        Me.Manual_BD_ckbx.Location = New System.Drawing.Point(493, 60)
        Me.Manual_BD_ckbx.Name = "Manual_BD_ckbx"
        Me.Manual_BD_ckbx.Size = New System.Drawing.Size(15, 14)
        Me.Manual_BD_ckbx.TabIndex = 9
        Me.Manual_BD_ckbx.UseVisualStyleBackColor = True
        '
        'Manual_FC_ckbx
        '
        Me.Manual_FC_ckbx.AutoSize = True
        Me.Manual_FC_ckbx.Location = New System.Drawing.Point(547, 60)
        Me.Manual_FC_ckbx.Name = "Manual_FC_ckbx"
        Me.Manual_FC_ckbx.Size = New System.Drawing.Size(15, 14)
        Me.Manual_FC_ckbx.TabIndex = 10
        Me.Manual_FC_ckbx.UseVisualStyleBackColor = True
        '
        'soil_labelPWP1
        '
        Me.soil_labelPWP1.AutoSize = True
        Me.soil_labelPWP1.Location = New System.Drawing.Point(582, 77)
        Me.soil_labelPWP1.Name = "soil_labelPWP1"
        Me.soil_labelPWP1.Size = New System.Drawing.Size(58, 13)
        Me.soil_labelPWP1.TabIndex = 401
        Me.soil_labelPWP1.Text = "Permanent"
        '
        'soil_labelSand1
        '
        Me.soil_labelSand1.AutoSize = True
        Me.soil_labelSand1.Location = New System.Drawing.Point(258, 91)
        Me.soil_labelSand1.Name = "soil_labelSand1"
        Me.soil_labelSand1.Size = New System.Drawing.Size(32, 13)
        Me.soil_labelSand1.TabIndex = 394
        Me.soil_labelSand1.Text = "Sand"
        '
        'soil_labelSand2
        '
        Me.soil_labelSand2.AutoSize = True
        Me.soil_labelSand2.Location = New System.Drawing.Point(267, 105)
        Me.soil_labelSand2.Name = "soil_labelSand2"
        Me.soil_labelSand2.Size = New System.Drawing.Size(15, 13)
        Me.soil_labelSand2.TabIndex = 395
        Me.soil_labelSand2.Text = "%"
        '
        'soil_labelIOM2
        '
        Me.soil_labelIOM2.AutoSize = True
        Me.soil_labelIOM2.Location = New System.Drawing.Point(310, 91)
        Me.soil_labelIOM2.Name = "soil_labelIOM2"
        Me.soil_labelIOM2.Size = New System.Drawing.Size(37, 13)
        Me.soil_labelIOM2.TabIndex = 396
        Me.soil_labelIOM2.Text = "Matter"
        '
        'soil_labelIOM3
        '
        Me.soil_labelIOM3.AutoSize = True
        Me.soil_labelIOM3.Location = New System.Drawing.Point(321, 105)
        Me.soil_labelIOM3.Name = "soil_labelIOM3"
        Me.soil_labelIOM3.Size = New System.Drawing.Size(15, 13)
        Me.soil_labelIOM3.TabIndex = 397
        Me.soil_labelIOM3.Text = "%"
        '
        'soil_labelFC1
        '
        Me.soil_labelFC1.AutoSize = True
        Me.soil_labelFC1.Location = New System.Drawing.Point(540, 77)
        Me.soil_labelFC1.Name = "soil_labelFC1"
        Me.soil_labelFC1.Size = New System.Drawing.Size(29, 13)
        Me.soil_labelFC1.TabIndex = 398
        Me.soil_labelFC1.Text = "Field"
        '
        'soil_labelFC2
        '
        Me.soil_labelFC2.AutoSize = True
        Me.soil_labelFC2.Location = New System.Drawing.Point(532, 91)
        Me.soil_labelFC2.Name = "soil_labelFC2"
        Me.soil_labelFC2.Size = New System.Drawing.Size(48, 13)
        Me.soil_labelFC2.TabIndex = 399
        Me.soil_labelFC2.Text = "Capacity"
        '
        'soil_labelFC3
        '
        Me.soil_labelFC3.AutoSize = True
        Me.soil_labelFC3.Location = New System.Drawing.Point(539, 105)
        Me.soil_labelFC3.Name = "soil_labelFC3"
        Me.soil_labelFC3.Size = New System.Drawing.Size(34, 13)
        Me.soil_labelFC3.TabIndex = 400
        Me.soil_labelFC3.Text = "m³/m³"
        '
        'soil_labelPWP2
        '
        Me.soil_labelPWP2.AutoSize = True
        Me.soil_labelPWP2.Location = New System.Drawing.Point(578, 91)
        Me.soil_labelPWP2.Name = "soil_labelPWP2"
        Me.soil_labelPWP2.Size = New System.Drawing.Size(66, 13)
        Me.soil_labelPWP2.TabIndex = 402
        Me.soil_labelPWP2.Text = "Wilting Point"
        '
        'soil_labelPWP3
        '
        Me.soil_labelPWP3.AutoSize = True
        Me.soil_labelPWP3.Location = New System.Drawing.Point(595, 105)
        Me.soil_labelPWP3.Name = "soil_labelPWP3"
        Me.soil_labelPWP3.Size = New System.Drawing.Size(34, 13)
        Me.soil_labelPWP3.TabIndex = 403
        Me.soil_labelPWP3.Text = "m³/m³"
        '
        'soil_labelNitrogen2
        '
        Me.soil_labelNitrogen2.AutoSize = True
        Me.soil_labelNitrogen2.Location = New System.Drawing.Point(369, 91)
        Me.soil_labelNitrogen2.Name = "soil_labelNitrogen2"
        Me.soil_labelNitrogen2.Size = New System.Drawing.Size(38, 13)
        Me.soil_labelNitrogen2.TabIndex = 444
        Me.soil_labelNitrogen2.Text = "Nitrate"
        '
        'soil_labelNitrogen3
        '
        Me.soil_labelNitrogen3.AutoSize = True
        Me.soil_labelNitrogen3.Location = New System.Drawing.Point(370, 105)
        Me.soil_labelNitrogen3.Name = "soil_labelNitrogen3"
        Me.soil_labelNitrogen3.Size = New System.Drawing.Size(36, 13)
        Me.soil_labelNitrogen3.TabIndex = 445
        Me.soil_labelNitrogen3.Text = "kg/ha"
        '
        'soil_labelAmmonium2
        '
        Me.soil_labelAmmonium2.AutoSize = True
        Me.soil_labelAmmonium2.Location = New System.Drawing.Point(413, 91)
        Me.soil_labelAmmonium2.Name = "soil_labelAmmonium2"
        Me.soil_labelAmmonium2.Size = New System.Drawing.Size(58, 13)
        Me.soil_labelAmmonium2.TabIndex = 446
        Me.soil_labelAmmonium2.Text = "Ammonium"
        '
        'soil_labelAmmonium3
        '
        Me.soil_labelAmmonium3.AutoSize = True
        Me.soil_labelAmmonium3.Location = New System.Drawing.Point(424, 105)
        Me.soil_labelAmmonium3.Name = "soil_labelAmmonium3"
        Me.soil_labelAmmonium3.Size = New System.Drawing.Size(36, 13)
        Me.soil_labelAmmonium3.TabIndex = 447
        Me.soil_labelAmmonium3.Text = "kg/ha"
        '
        'soil_labelNitrogen1
        '
        Me.soil_labelNitrogen1.AutoSize = True
        Me.soil_labelNitrogen1.Location = New System.Drawing.Point(372, 77)
        Me.soil_labelNitrogen1.Name = "soil_labelNitrogen1"
        Me.soil_labelNitrogen1.Size = New System.Drawing.Size(31, 13)
        Me.soil_labelNitrogen1.TabIndex = 448
        Me.soil_labelNitrogen1.Text = "Initial"
        '
        'soil_labelAmmonium1
        '
        Me.soil_labelAmmonium1.AutoSize = True
        Me.soil_labelAmmonium1.Location = New System.Drawing.Point(425, 77)
        Me.soil_labelAmmonium1.Name = "soil_labelAmmonium1"
        Me.soil_labelAmmonium1.Size = New System.Drawing.Size(31, 13)
        Me.soil_labelAmmonium1.TabIndex = 449
        Me.soil_labelAmmonium1.Text = "Initial"
        '
        'soil_labelLayerThickness1
        '
        Me.soil_labelLayerThickness1.AutoSize = True
        Me.soil_labelLayerThickness1.Location = New System.Drawing.Point(149, 77)
        Me.soil_labelLayerThickness1.Name = "soil_labelLayerThickness1"
        Me.soil_labelLayerThickness1.Size = New System.Drawing.Size(33, 13)
        Me.soil_labelLayerThickness1.TabIndex = 391
        Me.soil_labelLayerThickness1.Text = "Layer"
        '
        'soil_labelLayerThickness2
        '
        Me.soil_labelLayerThickness2.AutoSize = True
        Me.soil_labelLayerThickness2.Location = New System.Drawing.Point(138, 91)
        Me.soil_labelLayerThickness2.Name = "soil_labelLayerThickness2"
        Me.soil_labelLayerThickness2.Size = New System.Drawing.Size(56, 13)
        Me.soil_labelLayerThickness2.TabIndex = 392
        Me.soil_labelLayerThickness2.Text = "Thickness"
        '
        'soil_labelLayerThickness3
        '
        Me.soil_labelLayerThickness3.AutoSize = True
        Me.soil_labelLayerThickness3.Location = New System.Drawing.Point(159, 105)
        Me.soil_labelLayerThickness3.Name = "soil_labelLayerThickness3"
        Me.soil_labelLayerThickness3.Size = New System.Drawing.Size(15, 13)
        Me.soil_labelLayerThickness3.TabIndex = 393
        Me.soil_labelLayerThickness3.Text = "m"
        '
        'soil_labelCumDepth1
        '
        Me.soil_labelCumDepth1.AutoSize = True
        Me.soil_labelCumDepth1.Location = New System.Drawing.Point(76, 77)
        Me.soil_labelCumDepth1.Name = "soil_labelCumDepth1"
        Me.soil_labelCumDepth1.Size = New System.Drawing.Size(59, 13)
        Me.soil_labelCumDepth1.TabIndex = 297
        Me.soil_labelCumDepth1.Text = "Cumulative"
        '
        'soil_labelCumDepth2
        '
        Me.soil_labelCumDepth2.AutoSize = True
        Me.soil_labelCumDepth2.Location = New System.Drawing.Point(87, 91)
        Me.soil_labelCumDepth2.Name = "soil_labelCumDepth2"
        Me.soil_labelCumDepth2.Size = New System.Drawing.Size(36, 13)
        Me.soil_labelCumDepth2.TabIndex = 298
        Me.soil_labelCumDepth2.Text = "Depth"
        '
        'soil_labelClay1
        '
        Me.soil_labelClay1.AutoSize = True
        Me.soil_labelClay1.Location = New System.Drawing.Point(208, 91)
        Me.soil_labelClay1.Name = "soil_labelClay1"
        Me.soil_labelClay1.Size = New System.Drawing.Size(27, 13)
        Me.soil_labelClay1.TabIndex = 299
        Me.soil_labelClay1.Text = "Clay"
        '
        'soil_labelIOM1
        '
        Me.soil_labelIOM1.AutoSize = True
        Me.soil_labelIOM1.Location = New System.Drawing.Point(306, 77)
        Me.soil_labelIOM1.Name = "soil_labelIOM1"
        Me.soil_labelIOM1.Size = New System.Drawing.Size(44, 13)
        Me.soil_labelIOM1.TabIndex = 300
        Me.soil_labelIOM1.Text = "Organic"
        '
        'soil_labelBD2
        '
        Me.soil_labelBD2.AutoSize = True
        Me.soil_labelBD2.Location = New System.Drawing.Point(481, 91)
        Me.soil_labelBD2.Name = "soil_labelBD2"
        Me.soil_labelBD2.Size = New System.Drawing.Size(42, 13)
        Me.soil_labelBD2.TabIndex = 301
        Me.soil_labelBD2.Text = "Density"
        '
        'soil_labelBD1
        '
        Me.soil_labelBD1.AutoSize = True
        Me.soil_labelBD1.Location = New System.Drawing.Point(486, 77)
        Me.soil_labelBD1.Name = "soil_labelBD1"
        Me.soil_labelBD1.Size = New System.Drawing.Size(28, 13)
        Me.soil_labelBD1.TabIndex = 302
        Me.soil_labelBD1.Text = "Bulk"
        '
        'soil_labelCumDepth3
        '
        Me.soil_labelCumDepth3.AutoSize = True
        Me.soil_labelCumDepth3.Location = New System.Drawing.Point(98, 105)
        Me.soil_labelCumDepth3.Name = "soil_labelCumDepth3"
        Me.soil_labelCumDepth3.Size = New System.Drawing.Size(15, 13)
        Me.soil_labelCumDepth3.TabIndex = 303
        Me.soil_labelCumDepth3.Text = "m"
        '
        'soil_labelClay2
        '
        Me.soil_labelClay2.AutoSize = True
        Me.soil_labelClay2.Location = New System.Drawing.Point(214, 105)
        Me.soil_labelClay2.Name = "soil_labelClay2"
        Me.soil_labelClay2.Size = New System.Drawing.Size(15, 13)
        Me.soil_labelClay2.TabIndex = 304
        Me.soil_labelClay2.Text = "%"
        '
        'soil_labelBD3
        '
        Me.soil_labelBD3.AutoSize = True
        Me.soil_labelBD3.Location = New System.Drawing.Point(483, 105)
        Me.soil_labelBD3.Name = "soil_labelBD3"
        Me.soil_labelBD3.Size = New System.Drawing.Size(38, 13)
        Me.soil_labelBD3.TabIndex = 305
        Me.soil_labelBD3.Text = "Mg/m³"
        '
        'soil_labelLayer
        '
        Me.soil_labelLayer.AutoSize = True
        Me.soil_labelLayer.Location = New System.Drawing.Point(34, 105)
        Me.soil_labelLayer.Name = "soil_labelLayer"
        Me.soil_labelLayer.Size = New System.Drawing.Size(33, 13)
        Me.soil_labelLayer.TabIndex = 390
        Me.soil_labelLayer.Text = "Layer"
        '
        'Tier1TabControl
        '
        Me.Tier1TabControl.Controls.Add(Me.Tab_Field_Inputs)
        Me.Tier1TabControl.Controls.Add(Me.Tab_Soil)
        Me.Tier1TabControl.Controls.Add(Me.Tab_Crop)
        Me.Tier1TabControl.Controls.Add(Me.Tab_FieldOperations)
        Me.Tier1TabControl.Controls.Add(Me.Tab_Log)
        Me.Tier1TabControl.HotTrack = True
        Me.Tier1TabControl.ItemSize = New System.Drawing.Size(66, 18)
        Me.Tier1TabControl.Location = New System.Drawing.Point(0, 21)
        Me.Tier1TabControl.Name = "Tier1TabControl"
        Me.Tier1TabControl.SelectedIndex = 0
        Me.Tier1TabControl.Size = New System.Drawing.Size(688, 573)
        Me.Tier1TabControl.TabIndex = 1
        '
        'Tab_Field_Inputs
        '
        Me.Tab_Field_Inputs.Controls.Add(Me.grp_OptionalReporting)
        Me.Tab_Field_Inputs.Controls.Add(Me.grp_resultsFile)
        Me.Tab_Field_Inputs.Controls.Add(Me.grp_CalculationOptions)
        Me.Tab_Field_Inputs.Controls.Add(Me.grp_Weatherfile)
        Me.Tab_Field_Inputs.Controls.Add(Me.grp_Duration)
        Me.Tab_Field_Inputs.Location = New System.Drawing.Point(4, 22)
        Me.Tab_Field_Inputs.Name = "Tab_Field_Inputs"
        Me.Tab_Field_Inputs.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Field_Inputs.Size = New System.Drawing.Size(680, 547)
        Me.Tab_Field_Inputs.TabIndex = 0
        Me.Tab_Field_Inputs.Text = "Simulation Control"
        Me.Tab_Field_Inputs.UseVisualStyleBackColor = True
        '
        'grp_OptionalReporting
        '
        Me.grp_OptionalReporting.Controls.Add(Me.DailySoilCarbonReporting)
        Me.grp_OptionalReporting.Controls.Add(Me.DailyResidueReporting)
        Me.grp_OptionalReporting.Controls.Add(Me.SeasonReporting)
        Me.grp_OptionalReporting.Controls.Add(Me.AnnualSoilProfileReporting)
        Me.grp_OptionalReporting.Controls.Add(Me.AnnualSoilReporting)
        Me.grp_OptionalReporting.Controls.Add(Me.DailyWeatherReporting)
        Me.grp_OptionalReporting.Controls.Add(Me.DailyWaterReporting)
        Me.grp_OptionalReporting.Controls.Add(Me.DailyNitrogenReporting)
        Me.grp_OptionalReporting.Controls.Add(Me.DailySoilReporting)
        Me.grp_OptionalReporting.Controls.Add(Me.DailyCropReporting)
        Me.grp_OptionalReporting.Location = New System.Drawing.Point(3, 202)
        Me.grp_OptionalReporting.Name = "grp_OptionalReporting"
        Me.grp_OptionalReporting.Size = New System.Drawing.Size(669, 73)
        Me.grp_OptionalReporting.TabIndex = 3
        Me.grp_OptionalReporting.TabStop = False
        Me.grp_OptionalReporting.Text = "Optional Reporting"
        '
        'DailySoilCarbonReporting
        '
        Me.DailySoilCarbonReporting.AutoSize = True
        Me.DailySoilCarbonReporting.Location = New System.Drawing.Point(280, 42)
        Me.DailySoilCarbonReporting.Name = "DailySoilCarbonReporting"
        Me.DailySoilCarbonReporting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DailySoilCarbonReporting.Size = New System.Drawing.Size(106, 17)
        Me.DailySoilCarbonReporting.TabIndex = 5
        Me.DailySoilCarbonReporting.Text = "Daily Soil Carbon"
        Me.DailySoilCarbonReporting.UseVisualStyleBackColor = True
        '
        'DailyResidueReporting
        '
        Me.DailyResidueReporting.AutoSize = True
        Me.DailyResidueReporting.Location = New System.Drawing.Point(150, 19)
        Me.DailyResidueReporting.Name = "DailyResidueReporting"
        Me.DailyResidueReporting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DailyResidueReporting.Size = New System.Drawing.Size(91, 17)
        Me.DailyResidueReporting.TabIndex = 2
        Me.DailyResidueReporting.Text = "Daily Residue"
        Me.DailyResidueReporting.UseVisualStyleBackColor = True
        '
        'SeasonReporting
        '
        Me.SeasonReporting.AutoSize = True
        Me.SeasonReporting.Location = New System.Drawing.Point(540, 42)
        Me.SeasonReporting.Name = "SeasonReporting"
        Me.SeasonReporting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SeasonReporting.Size = New System.Drawing.Size(62, 17)
        Me.SeasonReporting.TabIndex = 9
        Me.SeasonReporting.Text = "Season"
        Me.SeasonReporting.UseVisualStyleBackColor = True
        '
        'AnnualSoilProfileReporting
        '
        Me.AnnualSoilProfileReporting.AutoSize = True
        Me.AnnualSoilProfileReporting.Location = New System.Drawing.Point(540, 19)
        Me.AnnualSoilProfileReporting.Name = "AnnualSoilProfileReporting"
        Me.AnnualSoilProfileReporting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AnnualSoilProfileReporting.Size = New System.Drawing.Size(111, 17)
        Me.AnnualSoilProfileReporting.TabIndex = 8
        Me.AnnualSoilProfileReporting.Text = "Annual Soil Profile"
        Me.AnnualSoilProfileReporting.UseVisualStyleBackColor = True
        '
        'AnnualSoilReporting
        '
        Me.AnnualSoilReporting.AutoSize = True
        Me.AnnualSoilReporting.Location = New System.Drawing.Point(410, 42)
        Me.AnnualSoilReporting.Name = "AnnualSoilReporting"
        Me.AnnualSoilReporting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AnnualSoilReporting.Size = New System.Drawing.Size(79, 17)
        Me.AnnualSoilReporting.TabIndex = 7
        Me.AnnualSoilReporting.Text = "Annual Soil"
        Me.AnnualSoilReporting.UseVisualStyleBackColor = True
        '
        'DailyWeatherReporting
        '
        Me.DailyWeatherReporting.AutoSize = True
        Me.DailyWeatherReporting.Location = New System.Drawing.Point(20, 19)
        Me.DailyWeatherReporting.Name = "DailyWeatherReporting"
        Me.DailyWeatherReporting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DailyWeatherReporting.Size = New System.Drawing.Size(93, 17)
        Me.DailyWeatherReporting.TabIndex = 0
        Me.DailyWeatherReporting.Text = "Daily Weather"
        Me.DailyWeatherReporting.UseVisualStyleBackColor = True
        '
        'DailyWaterReporting
        '
        Me.DailyWaterReporting.AutoSize = True
        Me.DailyWaterReporting.Location = New System.Drawing.Point(150, 42)
        Me.DailyWaterReporting.Name = "DailyWaterReporting"
        Me.DailyWaterReporting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DailyWaterReporting.Size = New System.Drawing.Size(81, 17)
        Me.DailyWaterReporting.TabIndex = 3
        Me.DailyWaterReporting.Text = "Daily Water"
        Me.DailyWaterReporting.UseVisualStyleBackColor = True
        '
        'DailyNitrogenReporting
        '
        Me.DailyNitrogenReporting.AutoSize = True
        Me.DailyNitrogenReporting.Location = New System.Drawing.Point(280, 19)
        Me.DailyNitrogenReporting.Name = "DailyNitrogenReporting"
        Me.DailyNitrogenReporting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DailyNitrogenReporting.Size = New System.Drawing.Size(92, 17)
        Me.DailyNitrogenReporting.TabIndex = 4
        Me.DailyNitrogenReporting.Text = "Daily Nitrogen"
        Me.DailyNitrogenReporting.UseVisualStyleBackColor = True
        '
        'DailySoilReporting
        '
        Me.DailySoilReporting.AutoSize = True
        Me.DailySoilReporting.Location = New System.Drawing.Point(410, 19)
        Me.DailySoilReporting.Name = "DailySoilReporting"
        Me.DailySoilReporting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DailySoilReporting.Size = New System.Drawing.Size(69, 17)
        Me.DailySoilReporting.TabIndex = 6
        Me.DailySoilReporting.Text = "Daily Soil"
        Me.DailySoilReporting.UseVisualStyleBackColor = True
        '
        'DailyCropReporting
        '
        Me.DailyCropReporting.AutoSize = True
        Me.DailyCropReporting.Location = New System.Drawing.Point(20, 42)
        Me.DailyCropReporting.Name = "DailyCropReporting"
        Me.DailyCropReporting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DailyCropReporting.Size = New System.Drawing.Size(74, 17)
        Me.DailyCropReporting.TabIndex = 1
        Me.DailyCropReporting.Text = "Daily Crop"
        Me.DailyCropReporting.UseVisualStyleBackColor = True
        '
        'grp_resultsFile
        '
        Me.grp_resultsFile.Controls.Add(Me.resultsFile_selectFileBtn)
        Me.grp_resultsFile.Controls.Add(Me.resultsFile_Overwrite)
        Me.grp_resultsFile.Controls.Add(Me.resultsFile_Path)
        Me.grp_resultsFile.Controls.Add(Me.resultsFile_labelPath)
        Me.grp_resultsFile.Location = New System.Drawing.Point(3, 281)
        Me.grp_resultsFile.Name = "grp_resultsFile"
        Me.grp_resultsFile.Size = New System.Drawing.Size(669, 43)
        Me.grp_resultsFile.TabIndex = 4
        Me.grp_resultsFile.TabStop = False
        Me.grp_resultsFile.Text = "Results File"
        '
        'resultsFile_selectFileBtn
        '
        Me.resultsFile_selectFileBtn.Location = New System.Drawing.Point(558, 15)
        Me.resultsFile_selectFileBtn.Name = "resultsFile_selectFileBtn"
        Me.resultsFile_selectFileBtn.Size = New System.Drawing.Size(28, 20)
        Me.resultsFile_selectFileBtn.TabIndex = 3
        Me.resultsFile_selectFileBtn.Text = "..."
        Me.resultsFile_selectFileBtn.UseVisualStyleBackColor = True
        '
        'resultsFile_labelPath
        '
        Me.resultsFile_labelPath.AutoSize = True
        Me.resultsFile_labelPath.Location = New System.Drawing.Point(6, 18)
        Me.resultsFile_labelPath.Name = "resultsFile_labelPath"
        Me.resultsFile_labelPath.Size = New System.Drawing.Size(51, 13)
        Me.resultsFile_labelPath.TabIndex = 2
        Me.resultsFile_labelPath.Text = "Full Path:"
        '
        'grp_CalculationOptions
        '
        Me.grp_CalculationOptions.Controls.Add(Me.calcOptions_autoSulfur)
        Me.grp_CalculationOptions.Controls.Add(Me.calcOptions_autoPhosphorus)
        Me.grp_CalculationOptions.Controls.Add(Me.calcOptions_autoNitrogen)
        Me.grp_CalculationOptions.Controls.Add(Me.calcOptions_adjustedYields)
        Me.grp_CalculationOptions.Controls.Add(Me.calcOptions_waterInfiltration)
        Me.grp_CalculationOptions.Location = New System.Drawing.Point(341, 55)
        Me.grp_CalculationOptions.Name = "grp_CalculationOptions"
        Me.grp_CalculationOptions.Size = New System.Drawing.Size(331, 141)
        Me.grp_CalculationOptions.TabIndex = 2
        Me.grp_CalculationOptions.TabStop = False
        Me.grp_CalculationOptions.Text = "Calculation Options"
        '
        'calcOptions_autoSulfur
        '
        Me.calcOptions_autoSulfur.AutoSize = True
        Me.calcOptions_autoSulfur.Location = New System.Drawing.Point(97, 112)
        Me.calcOptions_autoSulfur.Name = "calcOptions_autoSulfur"
        Me.calcOptions_autoSulfur.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.calcOptions_autoSulfur.Size = New System.Drawing.Size(103, 17)
        Me.calcOptions_autoSulfur.TabIndex = 4
        Me.calcOptions_autoSulfur.Text = "Automatic Sulfur"
        Me.calcOptions_autoSulfur.UseVisualStyleBackColor = True
        '
        'calcOptions_autoPhosphorus
        '
        Me.calcOptions_autoPhosphorus.AutoSize = True
        Me.calcOptions_autoPhosphorus.Location = New System.Drawing.Point(97, 89)
        Me.calcOptions_autoPhosphorus.Name = "calcOptions_autoPhosphorus"
        Me.calcOptions_autoPhosphorus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.calcOptions_autoPhosphorus.Size = New System.Drawing.Size(132, 17)
        Me.calcOptions_autoPhosphorus.TabIndex = 3
        Me.calcOptions_autoPhosphorus.Text = "Automatic Phosphorus"
        Me.calcOptions_autoPhosphorus.UseVisualStyleBackColor = True
        '
        'calcOptions_autoNitrogen
        '
        Me.calcOptions_autoNitrogen.AutoSize = True
        Me.calcOptions_autoNitrogen.Location = New System.Drawing.Point(97, 66)
        Me.calcOptions_autoNitrogen.Name = "calcOptions_autoNitrogen"
        Me.calcOptions_autoNitrogen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.calcOptions_autoNitrogen.Size = New System.Drawing.Size(116, 17)
        Me.calcOptions_autoNitrogen.TabIndex = 2
        Me.calcOptions_autoNitrogen.Text = "Automatic Nitrogen"
        Me.calcOptions_autoNitrogen.UseVisualStyleBackColor = True
        '
        'calcOptions_waterInfiltration
        '
        Me.calcOptions_waterInfiltration.AutoSize = True
        Me.calcOptions_waterInfiltration.Location = New System.Drawing.Point(97, 43)
        Me.calcOptions_waterInfiltration.Name = "calcOptions_waterInfiltration"
        Me.calcOptions_waterInfiltration.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.calcOptions_waterInfiltration.Size = New System.Drawing.Size(145, 17)
        Me.calcOptions_waterInfiltration.TabIndex = 1
        Me.calcOptions_waterInfiltration.Text = "Sub-daily water infiltration"
        Me.calcOptions_waterInfiltration.UseVisualStyleBackColor = True
        '
        'grp_Weatherfile
        '
        Me.grp_Weatherfile.Controls.Add(Me.weatherFile_selectFileBtn)
        Me.grp_Weatherfile.Controls.Add(Me.weatherFile_Path)
        Me.grp_Weatherfile.Controls.Add(Me.weatherFile_labelPath)
        Me.grp_Weatherfile.Location = New System.Drawing.Point(3, 6)
        Me.grp_Weatherfile.Name = "grp_Weatherfile"
        Me.grp_Weatherfile.Size = New System.Drawing.Size(669, 43)
        Me.grp_Weatherfile.TabIndex = 0
        Me.grp_Weatherfile.TabStop = False
        Me.grp_Weatherfile.Text = "Weatherfile"
        '
        'weatherFile_selectFileBtn
        '
        Me.weatherFile_selectFileBtn.Location = New System.Drawing.Point(635, 15)
        Me.weatherFile_selectFileBtn.Name = "weatherFile_selectFileBtn"
        Me.weatherFile_selectFileBtn.Size = New System.Drawing.Size(28, 20)
        Me.weatherFile_selectFileBtn.TabIndex = 2
        Me.weatherFile_selectFileBtn.Text = "..."
        Me.weatherFile_selectFileBtn.UseVisualStyleBackColor = True
        '
        'weatherFile_labelPath
        '
        Me.weatherFile_labelPath.AutoSize = True
        Me.weatherFile_labelPath.Location = New System.Drawing.Point(6, 18)
        Me.weatherFile_labelPath.Name = "weatherFile_labelPath"
        Me.weatherFile_labelPath.Size = New System.Drawing.Size(51, 13)
        Me.weatherFile_labelPath.TabIndex = 1
        Me.weatherFile_labelPath.Text = "Full Path:"
        '
        'grp_Duration
        '
        Me.grp_Duration.Controls.Add(Me.duration_TotalRotations)
        Me.grp_Duration.Controls.Add(Me.duration_TotalYears)
        Me.grp_Duration.Controls.Add(Me.duration_labelTotalRotations)
        Me.grp_Duration.Controls.Add(Me.duration_labelTotalYears)
        Me.grp_Duration.Controls.Add(Me.duration_labelTotalYearsError)
        Me.grp_Duration.Controls.Add(Me.duration_RotationSize)
        Me.grp_Duration.Controls.Add(Me.duration_StopYear)
        Me.grp_Duration.Controls.Add(Me.duration_StartYear)
        Me.grp_Duration.Controls.Add(Me.duration_labelRotationSize)
        Me.grp_Duration.Controls.Add(Me.duration_labelStopYear)
        Me.grp_Duration.Controls.Add(Me.duration_labelStartYear)
        Me.grp_Duration.Location = New System.Drawing.Point(3, 55)
        Me.grp_Duration.Name = "grp_Duration"
        Me.grp_Duration.Size = New System.Drawing.Size(332, 141)
        Me.grp_Duration.TabIndex = 1
        Me.grp_Duration.TabStop = False
        Me.grp_Duration.Text = "Duration"
        '
        'duration_TotalRotations
        '
        Me.duration_TotalRotations.AutoSize = True
        Me.duration_TotalRotations.Location = New System.Drawing.Point(191, 108)
        Me.duration_TotalRotations.Name = "duration_TotalRotations"
        Me.duration_TotalRotations.Size = New System.Drawing.Size(0, 13)
        Me.duration_TotalRotations.TabIndex = 15
        '
        'duration_TotalYears
        '
        Me.duration_TotalYears.AutoSize = True
        Me.duration_TotalYears.Location = New System.Drawing.Point(191, 89)
        Me.duration_TotalYears.Name = "duration_TotalYears"
        Me.duration_TotalYears.Size = New System.Drawing.Size(0, 13)
        Me.duration_TotalYears.TabIndex = 14
        '
        'duration_labelTotalRotations
        '
        Me.duration_labelTotalRotations.AutoSize = True
        Me.duration_labelTotalRotations.Location = New System.Drawing.Point(78, 108)
        Me.duration_labelTotalRotations.Name = "duration_labelTotalRotations"
        Me.duration_labelTotalRotations.Size = New System.Drawing.Size(107, 13)
        Me.duration_labelTotalRotations.TabIndex = 13
        Me.duration_labelTotalRotations.Text = "Number of Rotations:"
        '
        'duration_labelTotalYears
        '
        Me.duration_labelTotalYears.AutoSize = True
        Me.duration_labelTotalYears.Location = New System.Drawing.Point(59, 89)
        Me.duration_labelTotalYears.Name = "duration_labelTotalYears"
        Me.duration_labelTotalYears.Size = New System.Drawing.Size(126, 13)
        Me.duration_labelTotalYears.TabIndex = 12
        Me.duration_labelTotalYears.Text = "Total Years in Simulation:"
        '
        'duration_labelTotalYearsError
        '
        Me.duration_labelTotalYearsError.AutoSize = True
        Me.duration_labelTotalYearsError.ForeColor = System.Drawing.Color.Red
        Me.duration_labelTotalYearsError.Location = New System.Drawing.Point(255, 89)
        Me.duration_labelTotalYearsError.Name = "duration_labelTotalYearsError"
        Me.duration_labelTotalYearsError.Size = New System.Drawing.Size(0, 13)
        Me.duration_labelTotalYearsError.TabIndex = 10
        '
        'duration_labelRotationSize
        '
        Me.duration_labelRotationSize.AutoSize = True
        Me.duration_labelRotationSize.Location = New System.Drawing.Point(79, 63)
        Me.duration_labelRotationSize.Name = "duration_labelRotationSize"
        Me.duration_labelRotationSize.Size = New System.Drawing.Size(106, 13)
        Me.duration_labelRotationSize.TabIndex = 7
        Me.duration_labelRotationSize.Text = "Years in the Rotation"
        '
        'duration_labelStopYear
        '
        Me.duration_labelStopYear.AutoSize = True
        Me.duration_labelStopYear.Location = New System.Drawing.Point(83, 43)
        Me.duration_labelStopYear.Name = "duration_labelStopYear"
        Me.duration_labelStopYear.Size = New System.Drawing.Size(102, 13)
        Me.duration_labelStopYear.TabIndex = 6
        Me.duration_labelStopYear.Text = "Simulation End Year"
        '
        'duration_labelStartYear
        '
        Me.duration_labelStartYear.AutoSize = True
        Me.duration_labelStartYear.Location = New System.Drawing.Point(80, 23)
        Me.duration_labelStartYear.Name = "duration_labelStartYear"
        Me.duration_labelStartYear.Size = New System.Drawing.Size(105, 13)
        Me.duration_labelStartYear.TabIndex = 5
        Me.duration_labelStartYear.Text = "Simulation Start Year"
        '
        'lbl_Weatherfile
        '
        Me.lbl_Weatherfile.AutoSize = True
        Me.lbl_Weatherfile.Location = New System.Drawing.Point(10, 18)
        Me.lbl_Weatherfile.Name = "lbl_Weatherfile"
        Me.lbl_Weatherfile.Size = New System.Drawing.Size(48, 13)
        Me.lbl_Weatherfile.TabIndex = 1
        '
        'inputErrorProvider
        '
        Me.inputErrorProvider.ContainerControl = Me
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 613)
        Me.Controls.Add(Me.Tier1TabControl)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = Me.ProductName
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Tab_Log.ResumeLayout(False)
        Me.Tab_FieldOperations.ResumeLayout(False)
        Me.FieldOperationsTabControl.ResumeLayout(False)
        Me.Tab_ActiveOperations.ResumeLayout(False)
        Me.Tab_Crops.ResumeLayout(False)
        Me.grp_PlantedCrops.ResumeLayout(False)
        Me.grp_PlantingSetup.ResumeLayout(False)
        Me.grp_PlantingSetup.PerformLayout()
        Me.Tab_Tillage.ResumeLayout(False)
        Me.Tab_Tillage.PerformLayout()
        Me.grp_TillSetup.ResumeLayout(False)
        Me.grp_TillSetup.PerformLayout()
        Me.grp_Tillage.ResumeLayout(False)
        Me.Tab_FixedIrrigation.ResumeLayout(False)
        Me.Tab_FixedIrrigation.PerformLayout()
        Me.grp_FixedIrrigation.ResumeLayout(False)
        Me.grp_fixedIrrSetup.ResumeLayout(False)
        Me.grp_fixedIrrSetup.PerformLayout()
        Me.Tab_FixedFertilization.ResumeLayout(False)
        Me.Tab_FixedFertilization.PerformLayout()
        Me.grp_FixedFertSetup.ResumeLayout(False)
        Me.grp_FixedFertSetup.PerformLayout()
        Me.grp_FixedFertOps.ResumeLayout(False)
        Me.grp_FixedFertOps.PerformLayout()
        Me.grp_FixedFertilization.ResumeLayout(False)
        Me.Tab_AutoIrrigation.ResumeLayout(False)
        Me.Tab_AutoIrrigation.PerformLayout()
        Me.grp_AutomaticIrrigation.ResumeLayout(False)
        Me.grp_AutoIrrSetup.ResumeLayout(False)
        Me.grp_AutoIrrSetup.PerformLayout()
        Me.Tab_AutoFertilization.ResumeLayout(False)
        Me.Tab_AutoFertilization.PerformLayout()
        Me.grp_AutoFertSetup.ResumeLayout(False)
        Me.grp_AutoFertSetup.PerformLayout()
        Me.grp_AutoFertOps.ResumeLayout(False)
        Me.grp_AutoFertOps.PerformLayout()
        Me.grp_AutoFertilization.ResumeLayout(False)
        Me.Tab_Crop.ResumeLayout(False)
        Me.grp_CropAdvancedDescrip.ResumeLayout(False)
        Me.pnl_CropAdvancedDescrip.ResumeLayout(False)
        Me.pnl_CropAdvancedDescrip.PerformLayout()
        Me.grp_DescribedCrops.ResumeLayout(False)
        Me.grp_CropDescrip.ResumeLayout(False)
        Me.grp_CropDescrip.PerformLayout()
        Me.Tab_Soil.ResumeLayout(False)
        Me.Tab_Soil.PerformLayout()
        Me.grp_SoilProfile.ResumeLayout(False)
        Me.Tier1TabControl.ResumeLayout(False)
        Me.Tab_Field_Inputs.ResumeLayout(False)
        Me.grp_OptionalReporting.ResumeLayout(False)
        Me.grp_OptionalReporting.PerformLayout()
        Me.grp_resultsFile.ResumeLayout(False)
        Me.grp_resultsFile.PerformLayout()
        Me.grp_CalculationOptions.ResumeLayout(False)
        Me.grp_CalculationOptions.PerformLayout()
        Me.grp_Weatherfile.ResumeLayout(False)
        Me.grp_Weatherfile.PerformLayout()
        Me.grp_Duration.ResumeLayout(False)
        Me.grp_Duration.PerformLayout()
        CType(Me.inputErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents RunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContactInformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ResetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents SimulationControlsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents TillageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents FixedIrrigationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents SoilDescriptionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents AllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents CropDescriptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Private StatusStrip1 As System.Windows.Forms.StatusStrip
    Private StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Private ProgressBar As System.Windows.Forms.ToolStripProgressBar

    Private WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private Tab_Log As System.Windows.Forms.TabPage
    Private lv_logViewer As System.Windows.Forms.ListView
    Private Tab_FieldOperations As System.Windows.Forms.TabPage
    Private FieldOperationsTabControl As System.Windows.Forms.TabControl
    Private Tab_ActiveOperations As System.Windows.Forms.TabPage
    Private WithEvents lv_ActiveFieldOperations As System.Windows.Forms.ListView
    Private Tab_Tillage As System.Windows.Forms.TabPage
    Private grp_TillSetup As System.Windows.Forms.GroupBox
    Private WithEvents tillSetup_Tool As System.Windows.Forms.ComboBox
    Private WithEvents tillSetup_Year As System.Windows.Forms.ComboBox
    Private tillSetup_Depth As System.Windows.Forms.TextBox
    Private tillSetup_labelDefaultDepth As System.Windows.Forms.Label
    Private tillSetup_labelYear As System.Windows.Forms.Label
    Private tillSetup_labelDepth As System.Windows.Forms.Label
    Private tillSetup_labelDay As System.Windows.Forms.Label
    Private tillSetup_labelTool As System.Windows.Forms.Label
    Private grp_Tillage As System.Windows.Forms.GroupBox
    Private WithEvents lv_Tillage As System.Windows.Forms.ListView
    Private WithEvents btn_AddTillageOp As System.Windows.Forms.Button
    Private WithEvents btn_ChangeTillageOp As System.Windows.Forms.Button
    Private WithEvents tillSetup_PerformOperations As System.Windows.Forms.CheckBox
    Private Tab_FixedIrrigation As System.Windows.Forms.TabPage
    Private grp_FixedIrrigation As System.Windows.Forms.GroupBox
    Private WithEvents lv_FixedIrrigation As System.Windows.Forms.ListView
    Private WithEvents fixedIrrSetup_PerformOperations As System.Windows.Forms.CheckBox
    Private grp_fixedIrrSetup As System.Windows.Forms.GroupBox
    Private fixedIrrSetup_Volume As System.Windows.Forms.TextBox
    Private fixedIrrSetup_labelYear As System.Windows.Forms.Label
    Private WithEvents fixedIrrSetup_Year As System.Windows.Forms.ComboBox
    Private fixedIrrSetup_labelVolume As System.Windows.Forms.Label
    Private fixedIrrSetup_labelDay As System.Windows.Forms.Label
    Private WithEvents btn_AddFixedIrrOp As System.Windows.Forms.Button
    Private WithEvents btn_ChangeFixedIrrOp As System.Windows.Forms.Button
    Private Tab_AutoIrrigation As System.Windows.Forms.TabPage
    Private WithEvents autoIrrSetup_PerformOperations As System.Windows.Forms.CheckBox
    Private Tab_FixedFertilization As System.Windows.Forms.TabPage
    Private grp_FixedFertSetup As System.Windows.Forms.GroupBox
    Private fixedFertSetup_labelLayer As System.Windows.Forms.Label
    Private fixedFertSetup_labelForm As System.Windows.Forms.Label
    Private fixedFertSetup_labelSource As System.Windows.Forms.Label
    Private fixedFertSetup_Form As System.Windows.Forms.ComboBox
    Private WithEvents fixedFertSetup_Source As System.Windows.Forms.ComboBox
    Private fixedFertSetup_labelMass As System.Windows.Forms.Label
    Private fixedFertSetup_Mass As System.Windows.Forms.TextBox
    Private WithEvents fixedFertSetup_Year As System.Windows.Forms.ComboBox
    Private fixedFertSetup_labelYear As System.Windows.Forms.Label
    Private fixedFertSetup_labelDay As System.Windows.Forms.Label
    Private grp_FixedFertilization As System.Windows.Forms.GroupBox
    Private WithEvents lv_FixedFertilization As System.Windows.Forms.ListView
    Private WithEvents btn_AddFixedFertOp As System.Windows.Forms.Button
    Private WithEvents btn_ChangeFixedFertOp As System.Windows.Forms.Button
    Private WithEvents fixedFertSetup_PerformOperations As System.Windows.Forms.CheckBox
    Private Tab_Crop As System.Windows.Forms.TabPage
    Private grp_CropAdvancedDescrip As System.Windows.Forms.GroupBox
    Private CropDescrip32 As System.Windows.Forms.ComboBox
    Private CropLabel32 As System.Windows.Forms.Label
    Private CropLabel26 As System.Windows.Forms.Label
    Private CropLabel25 As System.Windows.Forms.Label
    Private CropLabel24 As System.Windows.Forms.Label
    Private CropLabel20 As System.Windows.Forms.Label
    Private CropLabel21 As System.Windows.Forms.Label
    Private CropLabel14 As System.Windows.Forms.Label
    Private CropLabel22 As System.Windows.Forms.Label
    Private CropDescrip14 As System.Windows.Forms.TextBox
    Private CropLabel23 As System.Windows.Forms.Label
    Private CropDescrip15 As System.Windows.Forms.TextBox
    Private CropDescrip16 As System.Windows.Forms.TextBox
    Private CropLabel15 As System.Windows.Forms.Label
    Private CropDescrip17 As System.Windows.Forms.TextBox
    Private CropLabel16 As System.Windows.Forms.Label
    Private CropDescrip18 As System.Windows.Forms.TextBox
    Private CropLabel17 As System.Windows.Forms.Label
    Private CropDescrip19 As System.Windows.Forms.TextBox
    Private CropLabel18 As System.Windows.Forms.Label
    Private CropDescrip20 As System.Windows.Forms.TextBox
    Private CropLabel19 As System.Windows.Forms.Label
    Private CropDescrip21 As System.Windows.Forms.TextBox
    Private CropDescrip22 As System.Windows.Forms.TextBox
    Private CropDescrip26 As System.Windows.Forms.TextBox
    Private CropDescrip23 As System.Windows.Forms.TextBox
    Private CropDescrip25 As System.Windows.Forms.TextBox
    Private CropDescrip24 As System.Windows.Forms.TextBox
    Private grp_DescribedCrops As System.Windows.Forms.GroupBox
    Private WithEvents lv_DescribedCrops As System.Windows.Forms.ListView
    Private grp_CropDescrip As System.Windows.Forms.GroupBox
    Private CropDescrip9 As System.Windows.Forms.TextBox
    Private CropDescrip8 As System.Windows.Forms.TextBox
    Private CropDescrip7 As System.Windows.Forms.TextBox
    Private CropDescrip6 As System.Windows.Forms.TextBox
    Private WithEvents CropDescrip1 As System.Windows.Forms.ComboBox
    Private CropLabel13 As System.Windows.Forms.Label
    Private CropLabel12 As System.Windows.Forms.Label
    Private CropLabel11 As System.Windows.Forms.Label
    Private CropLabel7 As System.Windows.Forms.Label
    Private CropLabel8 As System.Windows.Forms.Label
    Private CropLabel9 As System.Windows.Forms.Label
    Private CropLabel10 As System.Windows.Forms.Label
    Private CropLabel1 As System.Windows.Forms.Label
    Private CropLabel2 As System.Windows.Forms.Label
    Private CropLabel3 As System.Windows.Forms.Label
    Private CropLabel4 As System.Windows.Forms.Label
    Private CropLabel5 As System.Windows.Forms.Label
    Private CropLabel6 As System.Windows.Forms.Label
    Private WithEvents btn_AddDescribedCrop As System.Windows.Forms.Button
    Private WithEvents btn_ChangeDescribedCrop As System.Windows.Forms.Button
    Private WithEvents Chkbx_UseAdvancedDescrip As System.Windows.Forms.CheckBox
    Private Tab_Soil As System.Windows.Forms.TabPage
    Private soil_labelLayer As System.Windows.Forms.Label
    Private soil_labelSlope As System.Windows.Forms.Label
    Private soil_labelCurve As System.Windows.Forms.Label
    Private soil_labelBD3 As System.Windows.Forms.Label
    Private soil_labelClay2 As System.Windows.Forms.Label
    Private soil_labelCumDepth3 As System.Windows.Forms.Label
    Private soil_labelBD1 As System.Windows.Forms.Label
    Private soil_labelBD2 As System.Windows.Forms.Label
    Private soil_labelIOM1 As System.Windows.Forms.Label
    Private soil_labelClay1 As System.Windows.Forms.Label
    Private soil_labelCumDepth2 As System.Windows.Forms.Label
    Private soil_labelCumDepth1 As System.Windows.Forms.Label
    Private soil_labelLayerThickness3 As System.Windows.Forms.Label
    Private soil_labelLayerThickness2 As System.Windows.Forms.Label
    Private soil_labelLayerThickness1 As System.Windows.Forms.Label
    Private soil_labelAmmonium1 As System.Windows.Forms.Label
    Private soil_labelNitrogen1 As System.Windows.Forms.Label
    Private soil_labelAmmonium3 As System.Windows.Forms.Label
    Private soil_labelAmmonium2 As System.Windows.Forms.Label
    Private soil_labelNitrogen3 As System.Windows.Forms.Label
    Private soil_labelNitrogen2 As System.Windows.Forms.Label
    Private soil_labelPWP3 As System.Windows.Forms.Label
    Private soil_labelPWP2 As System.Windows.Forms.Label
    Private soil_labelPWP1 As System.Windows.Forms.Label
    Private soil_labelFC3 As System.Windows.Forms.Label
    Private soil_labelFC2 As System.Windows.Forms.Label
    Private soil_labelFC1 As System.Windows.Forms.Label
    Private soil_labelIOM3 As System.Windows.Forms.Label
    Private soil_labelIOM2 As System.Windows.Forms.Label
    Private soil_labelSand2 As System.Windows.Forms.Label
    Private soil_labelSand1 As System.Windows.Forms.Label
    Private soil_curve As System.Windows.Forms.TextBox
    Private grp_LayerButtons As System.Windows.Forms.Panel
    Private soil_slope As System.Windows.Forms.TextBox
    Private WithEvents Manual_PWP_ckbx As System.Windows.Forms.CheckBox
    Private WithEvents Manual_FC_ckbx As System.Windows.Forms.CheckBox
    Private WithEvents Manual_BD_ckbx As System.Windows.Forms.CheckBox
    Private Tier1TabControl As System.Windows.Forms.TabControl
    Private Tab_Field_Inputs As System.Windows.Forms.TabPage
    Private grp_CalculationOptions As System.Windows.Forms.GroupBox
    Private grp_Weatherfile As System.Windows.Forms.GroupBox
    Private grp_Duration As System.Windows.Forms.GroupBox
    Private lbl_Weatherfile As System.Windows.Forms.Label
    Private calcOptions_adjustedYields As System.Windows.Forms.CheckBox
    Private calcOptions_waterInfiltration As System.Windows.Forms.CheckBox
    Private WithEvents weatherFile_Path As System.Windows.Forms.Label
    Private weatherFile_labelPath As System.Windows.Forms.Label
    Private WithEvents duration_RotationSize As System.Windows.Forms.ComboBox
    Private WithEvents duration_StopYear As System.Windows.Forms.ComboBox
    Private WithEvents duration_StartYear As System.Windows.Forms.ComboBox
    Private duration_labelRotationSize As System.Windows.Forms.Label
    Private duration_labelStopYear As System.Windows.Forms.Label
    Private duration_labelStartYear As System.Windows.Forms.Label
    Private grp_AutomaticIrrigation As System.Windows.Forms.GroupBox
    Private WithEvents lv_AutomaticIrrigation As System.Windows.Forms.ListView
    Private WithEvents btn_AddAutoIrrOp As System.Windows.Forms.Button
    Private WithEvents btn_ChangeAutoIrrOp As System.Windows.Forms.Button
    Private grp_AutoIrrSetup As System.Windows.Forms.GroupBox
    Private autoIrrSetup_labelName As System.Windows.Forms.Label
    Private WithEvents autoIrrSetup_Name As System.Windows.Forms.ComboBox
    Private autoIrrSetup_WaterDepletion As System.Windows.Forms.ComboBox
    Private autoIrrSetup_LastSoilLayer As System.Windows.Forms.ComboBox
    Private autoIrrSetup_labelWaterDepletion As System.Windows.Forms.Label
    Private autoIrrSetup_labelStartDay As System.Windows.Forms.Label
    Private autoIrrSetup_labelLastSoilLayer As System.Windows.Forms.Label
    Private autoIrrSetup_labelStopDay As System.Windows.Forms.Label
    Private Tab_Crops As System.Windows.Forms.TabPage
    Private WithEvents btn_AddPlantingEvent As System.Windows.Forms.Button
    Private WithEvents btn_ChangePlantingEvent As System.Windows.Forms.Button
    Private grp_PlantedCrops As System.Windows.Forms.GroupBox
    Private WithEvents lv_PlantedCrops As System.Windows.Forms.ListView
    Private grp_PlantingSetup As System.Windows.Forms.GroupBox
    Private plantingSetup_labelDay As System.Windows.Forms.Label
    Private plantingSetup_labelYear As System.Windows.Forms.Label
    Private plantingSetup_labelName As System.Windows.Forms.Label
    Private WithEvents plantingSetup_cropName As System.Windows.Forms.ComboBox
    Private plantingSetup_labelDefaultDay As System.Windows.Forms.Label
    Private CropLabel27 As System.Windows.Forms.Label
    Private CropLabel28 As System.Windows.Forms.Label
    Private CropDescrip27 As System.Windows.Forms.TextBox
    Private CropDescrip28 As System.Windows.Forms.TextBox
    Private WithEvents AutomaticIrrigationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents PlantingOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents FixedFertilizationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents AltRun As System.Windows.Forms.ToolStripMenuItem
    Private plantingSetup_AutoFert As System.Windows.Forms.CheckBox
    Private plantingSetup_AutoIrr As System.Windows.Forms.CheckBox
    Private Tab_AutoFertilization As System.Windows.Forms.TabPage
    Private grp_AutoFertSetup As System.Windows.Forms.GroupBox
    Private grp_AutoFertilization As System.Windows.Forms.GroupBox
    Private WithEvents lv_AutoFertilization As System.Windows.Forms.ListView
    Private WithEvents btn_AddAutoFertOp As System.Windows.Forms.Button
    Private WithEvents btn_ChangeAutoFertOp As System.Windows.Forms.Button
    Private WithEvents autoFertSetup_PerformOperations As System.Windows.Forms.CheckBox
    Private autoFertSetup_LabelName As System.Windows.Forms.Label
    Private WithEvents autoFertSetup_Name As System.Windows.Forms.ComboBox
    Private autoFertSetup_LabelStartDay As System.Windows.Forms.Label
    Private autoFertSetup_LabelEndDay As System.Windows.Forms.Label
    Private autoFertSetup_LabelMethod As System.Windows.Forms.Label
    Private autoFertSetup_LabelMass As System.Windows.Forms.Label
    Private autoFertSetup_LabelForm As System.Windows.Forms.Label
    Private autoFertSetup_Mass As System.Windows.Forms.TextBox
    Private autoFertSetup_LabelSource As System.Windows.Forms.Label
    Private autoFertSetup_Method As System.Windows.Forms.ComboBox
    Private autoFertSetup_Form As System.Windows.Forms.ComboBox
    Private WithEvents autoFertSetup_Source As System.Windows.Forms.ComboBox
    Private WithEvents AutomaticFertilizationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private grp_resultsFile As System.Windows.Forms.GroupBox
    Private WithEvents resultsFile_Path As System.Windows.Forms.Label
    Private resultsFile_labelPath As System.Windows.Forms.Label
    Private resultsFile_Overwrite As System.Windows.Forms.CheckBox
    Private grp_OptionalReporting As System.Windows.Forms.GroupBox
    Private SeasonReporting As System.Windows.Forms.CheckBox
    Private AnnualSoilProfileReporting As System.Windows.Forms.CheckBox
    Private AnnualSoilReporting As System.Windows.Forms.CheckBox
    Private DailyWeatherReporting As System.Windows.Forms.CheckBox
    Private DailyWaterReporting As System.Windows.Forms.CheckBox
    Private DailyNitrogenReporting As System.Windows.Forms.CheckBox
    Private DailySoilReporting As System.Windows.Forms.CheckBox
    Private DailyCropReporting As System.Windows.Forms.CheckBox
    Private calcOptions_autoSulfur As System.Windows.Forms.CheckBox
    Private calcOptions_autoPhosphorus As System.Windows.Forms.CheckBox
    Private calcOptions_autoNitrogen As System.Windows.Forms.CheckBox
    Private CropLabel30 As System.Windows.Forms.Label
    Private CropDescrip30 As System.Windows.Forms.TextBox
    Private CropLabel29 As System.Windows.Forms.Label
    Private CropDescrip29 As System.Windows.Forms.TextBox
    Private CropLabel33 As System.Windows.Forms.Label
    Private pnl_CropAdvancedDescrip As System.Windows.Forms.Panel
    Private grp_SoilProfile As System.Windows.Forms.Panel
    Private CropDescrip33 As System.Windows.Forms.ComboBox
    Private CropLabel31 As System.Windows.Forms.Label
    Private CropDescrip31 As System.Windows.Forms.TextBox
    Private CropDescrip34 As System.Windows.Forms.ComboBox
    Private CropLabel34 As System.Windows.Forms.Label
    Private soil_labelMaxLayer As System.Windows.Forms.Label
    Private WithEvents soil_maxLayer As System.Windows.Forms.ComboBox
    Private inputErrorProvider As System.Windows.Forms.ErrorProvider
    Private CropDescrip13 As System.Windows.Forms.TextBox
    Private CropDescrip12 As System.Windows.Forms.TextBox
    Private CropDescrip11 As System.Windows.Forms.TextBox
    Private CropDescrip10 As System.Windows.Forms.TextBox
    Private CropDescrip5 As System.Windows.Forms.TextBox
    Private WithEvents CropDescrip4 As System.Windows.Forms.TextBox
    Private WithEvents CropDescrip3 As System.Windows.Forms.TextBox
    Private WithEvents CropDescrip2 As System.Windows.Forms.TextBox
    Private WithEvents plantingSetup_Day As System.Windows.Forms.TextBox
    Private WithEvents tillSetup_Day As System.Windows.Forms.TextBox
    Private WithEvents autoIrrSetup_StopDay As System.Windows.Forms.TextBox
    Private WithEvents autoIrrSetup_StartDay As System.Windows.Forms.TextBox
    Private WithEvents fixedFertSetup_Day As System.Windows.Forms.TextBox
    Private WithEvents autoFertSetup_EndDay As System.Windows.Forms.TextBox
    Private WithEvents autoFertSetup_StartDay As System.Windows.Forms.TextBox
    Private DailySoilCarbonReporting As System.Windows.Forms.CheckBox
    Private DailyResidueReporting As System.Windows.Forms.CheckBox
    Private WithEvents plantingSetup_Year As System.Windows.Forms.ComboBox
    Private WithEvents fixedIrrSetup_Day As System.Windows.Forms.TextBox
    Private WithEvents weatherFile_selectFileBtn As System.Windows.Forms.Button
    Private WithEvents resultsFile_selectFileBtn As System.Windows.Forms.Button
    Private plantingSetup_DefaultDay As System.Windows.Forms.Label
    Private tillSetup_defaultDepth As System.Windows.Forms.Label
    Private autoIrrSetup_DefaultEndDay As System.Windows.Forms.Label
    Private autoIrrSetup_labelDefaultEndDay As System.Windows.Forms.Label
    Private autoIrrSetup_DefaultStartDay As System.Windows.Forms.Label
    Private autoIrrSetup_labelDefaultStartDay As System.Windows.Forms.Label
    Private grp_AutoFertOps As System.Windows.Forms.GroupBox
    Private autoFertSetup_DefaultEndDay As System.Windows.Forms.Label
    Private autoFertSetup_labelDefaultEndDay As System.Windows.Forms.Label
    Private autoFertSetup_DefaultStartDay As System.Windows.Forms.Label
    Private autoFertSetup_labelDefaultStartDay As System.Windows.Forms.Label
    Private duration_TotalRotations As System.Windows.Forms.Label
    Private WithEvents duration_TotalYears As System.Windows.Forms.Label
    Private duration_labelTotalRotations As System.Windows.Forms.Label
    Private duration_labelTotalYears As System.Windows.Forms.Label
    Private duration_labelTotalYearsError As System.Windows.Forms.Label
    Private fixedFertSetup_Layer As System.Windows.Forms.ComboBox
    Private tillSetup_labelSDR As System.Windows.Forms.Label
    Private tillSetup_labelME As System.Windows.Forms.Label
    Private tillSetup_defaultME As System.Windows.Forms.Label
    Private tillSetup_defaultSDR As System.Windows.Forms.Label
    Private tillSetup_ME As System.Windows.Forms.TextBox
    Private tillSetup_SDR As System.Windows.Forms.TextBox
    Private grp_FixedFertOps As System.Windows.Forms.GroupBox
    Private fixedFertSetup_C_Organic As System.Windows.Forms.TextBox
    Private fixedFertSetup_P_Inorganic As System.Windows.Forms.TextBox
    Private fixedFertSetup_P_Charcoal As System.Windows.Forms.TextBox
    Private fixedFertSetup_P_Organic As System.Windows.Forms.TextBox
    Private fixedFertSetup_N_NO3 As System.Windows.Forms.TextBox
    Private fixedFertSetup_N_NH4 As System.Windows.Forms.TextBox
    Private fixedFertSetup_N_Organic As System.Windows.Forms.TextBox
    Private fixedFertSetup_C_Charcoal As System.Windows.Forms.TextBox
    Private fixedFertSetup_labelS As System.Windows.Forms.Label
    Private fixedFertSetup_S As System.Windows.Forms.TextBox
    Private fixedFertSetup_labelN_Charcoal As System.Windows.Forms.Label
    Private fixedFertSetup_N_Charcoal As System.Windows.Forms.TextBox
    Private fixedFertSetup_labelK As System.Windows.Forms.Label
    Private fixedFertSetup_K As System.Windows.Forms.TextBox
    Private fixedFertSetup_labelP_Inorganic As System.Windows.Forms.Label
    Private fixedFertSetup_labelP_Charcoal As System.Windows.Forms.Label
    Private fixedFertSetup_labelP_Organic As System.Windows.Forms.Label
    Private fixedFertSetup_labelN_NO3 As System.Windows.Forms.Label
    Private fixedFertSetup_labelN_NH4 As System.Windows.Forms.Label
    Private fixedFertSetup_LabelN_Organic As System.Windows.Forms.Label
    Private fixedFertSetup_labelC_Charcoal As System.Windows.Forms.Label
    Private fixedFertSetup_labelC_Organic As System.Windows.Forms.Label
    Private fixedFertSetup_Method As System.Windows.Forms.ComboBox
    Private fixedFertSetup_labelMethod As System.Windows.Forms.Label
    Private autoFertSetup_labelS As System.Windows.Forms.Label
    Private autoFertSetup_S As System.Windows.Forms.TextBox
    Private autoFertSetup_labelN_Charcoal As System.Windows.Forms.Label
    Private autoFertSetup_N_Charcoal As System.Windows.Forms.TextBox
    Private autoFertSetup_labelK As System.Windows.Forms.Label
    Private autoFertSetup_K As System.Windows.Forms.TextBox
    Private autoFertSetup_labelP_Inorganic As System.Windows.Forms.Label
    Private autoFertSetup_labelP_Charcoal As System.Windows.Forms.Label
    Private autoFertSetup_labelP_Organic As System.Windows.Forms.Label
    Private autoFertSetup_labelN_NO3 As System.Windows.Forms.Label
    Private autoFertSetup_labelN_NH4 As System.Windows.Forms.Label
    Private autoFertSetup_labelN_Organic As System.Windows.Forms.Label
    Private autoFertSetup_labelC_Charcoal As System.Windows.Forms.Label
    Private autoFertSetup_labelC_Organic As System.Windows.Forms.Label
    Private autoFertSetup_P_Inorganic As System.Windows.Forms.TextBox
    Private autoFertSetup_P_Charcoal As System.Windows.Forms.TextBox
    Private autoFertSetup_P_Organic As System.Windows.Forms.TextBox
    Private autoFertSetup_N_NO3 As System.Windows.Forms.TextBox
    Private autoFertSetup_N_NH4 As System.Windows.Forms.TextBox
    Private autoFertSetup_N_Organic As System.Windows.Forms.TextBox
    Private autoFertSetup_C_Charcoal As System.Windows.Forms.TextBox
    Private autoFertSetup_C_Organic As System.Windows.Forms.TextBox
    Private autoFertSetup_Depth As System.Windows.Forms.TextBox
    Private autoFertSetup_labelDepth As System.Windows.Forms.Label

End Class
