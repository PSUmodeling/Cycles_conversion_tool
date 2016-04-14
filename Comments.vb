Friend Module Comments
    'Proposed or pending changes and known errors
    '==========================================================================================================================================================
    '   Read from a database (weather, crop info, soil info)
    '   Handle multi-area/batch runs
    '   Handle multiple simultaeous crops (ability to create has been handled)
    '   Auto Fertilization not implemented
    '   Auto Fertilization parameters not correct

    'Changes List
    '==========================================================================================================================================================
    'February, 2013
    '   Error in initialization of N mineralization of manure corrected
    'December 11, 2009
    '   Daily operations stripped from Main and placed into a separate class
    '       Contains all calls that happen on a unique day
    '       Done so that a multi-area run can run on a daily basis instead of annual
    '       All associated subroutines moved to new class
    '       Used Classes that do not retain persistent data day to day instanciated inside the daily class even if used in the caller
    '   Modules (excepty SideSubs and FileOps) turned into classes

    'December 2, 2009
    '   Auto Fertilization disabled as it is not supported in the model yet
    '   Fixed Fertilization expanded
    '       New parameters added to the interface
    '       New parameters added to an array in the model (treated same as the crop array and tillage tool array)
    '   Model partially supports fixed fertilization

    'November 24, 2009
    '   Cleaned up file operations on the interface
    '   RealizedCrop parameters added
    '       each crops unique ID
    '       active status to distinguish between old and current for a unique crop event
    '   Main turned into a subarea class to allow for multiarea runs

    'November 23, 2009
    '   CropClass extensively changed to allow for multiple simultaneous crops
    '       CropClass placed within a Crops Module
    '       All routines except those dealing with a unique crop moved to the module 
    '       CropClass now based on a LinkedList
    '       NewCrop creates a new node in the list and passed the auto irrigation and fertilization parameters
    '       Each new crop has a unique number assigned to it

    'November 17, 2009
    '   Added default dates for auto irrigation and fertilization based upon user provided planting and maturity dates
    '   User specified dates no longer required for field operations when a default date is provided
    '   Interface default fields behavior and appearance changed

    'November 16, 2009
    '   Tool tips updated
    '   Added a calendar to the date selection
    '       Calendar is not a requirement to populate the fields
    '       Calendar date is split into year and month/day, which are then used to populate forms fields as required
    '       1-366 values are still used on the interface

    ' November 13, 2009
    '   Daily outputs revised
    '   Daily SoilCarbon and Daily Residue added to the interface

    'November 10, 2009
    '   Validation handlers being added to to make validation more precise for individual fields
    '   Runtime check added to ensure required fields are filled
    '       Fields are not checked to see if the fields are filled properly as this is handled by Validation

    'November 9, 2009
    '   Validation added to all user input fields (listviews not checked directly)
    '       Prefer on-demand checking instead of runtime checking
    '       Replaces DataVerification
    '       Listviews are checked when the listview is populated

    'November 6, 2009
    '   Soil Descriptions Tab overhauled
    '       All descriptions fields deleted
    '       All description fields will be added dynamically by a new max soil layer combo box
    '       Layers shown in excess of the max layer field will be deleted from the form
    '   Tab order across the entire form fixed
    '   Minor soil descriptions headers issue fixed

    'November 4, 2009
    '   Output and Import/Export array positions for the header and data are controlled by an incremented variable instead of statically placed
    '       Will allow easier placement, removal, and addition of I/O data

    'October 6, 2009
    '   Output class overhauled
    '       Daily outputs no reduced from 3 dimensions to 2 (year dimension dropped).  Requires that daily outputs be printed at the end of each year
    '       Consolidated the external call to Outputs for storing and printing data
    '       Annually-printed-data's consolidated-call has no parameters passed to permit Threading
    '   Threading implemented
    '       At the end of each daily loop a printing thread is started.
    '       The printing thread must finish before another can be started

    'September 30, 2009
    '   Tillage fix where date check was being passed sim year instead of calender year.   Modified the sub so the implementation will prompt for rotation year
    '   Output sub only prints used data

    'September 29, 2009
    '   Outputs layer outputs changed so that columns only have headers for described layers
    '   Daily Water Output added to the daily Reporting options
    '   Soil Infiltration streamlined
    '   A few Fertilizer bugs removed (mass not being recorded into the linked list)

    'September 25, 2009
    '   ForcedMaturity sub fixed. Date check of 1 year rotations was bad

    'September 24, 2009
    '   Outputs turned back into a class (requirement for outputs to be run on a separate thread)
    '   Problems when totalCropsPerRotation = 1
    '       ForcedMaturity sub not working for rotation size 1
    '       CropClass parameter totalCropsPerRotation removed,upperbound of the plantingOrder array now used

    'September 22, 2009
    '   AutoIrrigation stores the plant available water for each soil layer 
    '       PAW is re-calculated every day 
    '       Multiple simultaneous crops can retrieve PAW values based on thier unique settings without nulifying other crop auto irrigation settings

    'September 16, 2009
    '   Tillage master array now zero based and tool number removed as a paramater.  Size reduced from 430 to 255 (86x5 to 85x3)
    '   SDR and ME added to the tillage linked list during AddOperation by Tillage internally
    '   toolName replaces toolNumber as a simulation parameter
    '   Cleaned up the linked list operations

    'September 15, 2009
    '   Auto Irrigation enabled
    '       plantingOrder booleans combined with performOperations option allow for all, some, and no instances of crops to use automatic parameters

    'September 10, 2009
    '   Custom crops enabled
    '   Aggrigate list performs as expected (was not responding to clear interface and unchecking "perform operations"
    '   booleans added to plantingOrder no longer error out

    'September 8, 2009
    '   Auto Fertilization tab added to the interface
    '       Fertilization interface objects names changed to "fixed" fertilization
    '       Auto Fertilization pushed throughtout code imports and exports
    '       Auto Fertilization class created
    '   Planting Order tab setup parameters increased to include checkboxes for auto field operations
    '       If auto option check box is checked, the relevant crop will attempt to use the automatic parameters, if any exist
    '   Armen's custom auto fill enabled
    '       Will read from a code level pre-defined setup file.  

    'September 1, 2009
    '   Import/Export re-enabled
    '       Now 8 sheets instead of 4.  Field operations each given their own sheet (3 new) and planting order given its own sheet (1 new)
    '       Crop descriptions are now row based instead of column based, similar to field operations and planting order
    '   Form reads/writes go through a class structure that must be instanciated prior to use making its implementation similar to I/E
    '   Model revision numbering changed to traditional ##.##.## structure to enable build revision being printed with the results

    'August 24, 2009
    '   Field Operations changed from an array of linked lists to a single linked list (should have less wasted space)
    '   Main.Initialize supports gui input or alternate source input (so Armen can tinker without using the interface or altering I/E)
    '   Fertilization now has nitrate and ammonium listed with source and a generic mass field for all types

    'August 19, 2009
    '   Import/Export disabled is it is hopelessly out of date
    '   Selection start/stop dates fills total years field, which then populates comboboxes that are based on rotation years
    '   Max number of field operation removed
    '       Listview removes the maximum limitation
    '       Simulation already changed to support multiple operations per day

    'August 18, 2009
    '   Datacheck now used soley to error check the USER inputs
    '       Weather finds, reads, and error checks input data directly without Datacheck
    '       Datacheck removed from Main and now called exclusively from the GUI
    '       Datacheck no longer stores interface parameters
    '   Main.Initialize calls UI read subroutines to get the parameters directly
    '   Crop rotation size expanded 175 years, effectively making use of a rotation optional
    '   Auto Irrigation now based on a particular crop instead of all crops
    '   Crops can be planted on a day other than the described planting day
    '   10 x 2 rotation eliminated in favor of a listview
    '       Supports more than 2 crops per year with a limitless rotation size

    '==========================================================================================================================================================
    'July 17, 2009
    '   C-Farm officially frozen.  New Project by new name started

    'July 15, 2009
    '   Available Crop List sorted according to master list array order instead of alphabetically.  Added significant overhead during add

    'July 14, 2009
    '   Crops listed in the described crops listview are removed from the description setup combo box

    'July 8, 2009
    '   CropClass describedCrops and calculatedData arrays now only hold data for crops used, not all crops described by the user

    'June 26, 2009
    '   Incorporated Nitrogen fixes from Armen
    '   Added more detail to runtime status bar feedback

    'June 25, 2009
    '   One Linked List class is used for field operations and realized crops

    'June 24, 2009
    '   Progress Bar behavior modified
    '   Application source directory used as working setup's directory

    'June 23, 2009
    '   RealizedCropClass now accepts a day of year
    '   SeasonOutputs uses day of year, combined with the year, to produce a calender date
    '   SeasonOutputs no longer writes a line when the crop is not killed/harvested/foraged (last crop error)
    '   Deleting a described crop updates the rotation crop list boxes on the form
    '   No crop simulations produced a variety of loop based errors: fixed

    'June 19, 2009
    '   RealizedCropOrder removed entirely
    '       RealizedCropClass created
    '       Crops now report at every harvest and forage event separately
    '       Structure is a linked list instead of an array: Needed as the total number of forage events unknown
    '   All calculations to find the number of crops planted during a runtime have been removed
    '   Crop stage name and stage growth array removed from crop and placed in main as string variables for daily reporting

    'June 16, 2009
    '   Crop no longer required in the first position, first year of the simulation
    '   Crop no longer required at all
    '   Added current date and time to the out file
    '   Crop rotation data limited to crops used

    'June 10, 2009
    '   Field Operations changed from a 3 dimentional array of type object to a 1 dimensional array of type linked list
    '       Each position in the array represents a year
    '       Each node of the linked list represents an operation in that list's year
    '       Each node's data is an array dimensioned during the node's creation
    '       Effectively removes any cap on years, operation count, and aspects of an operation

    'May 28, 2009
    '   Outputs.Season_Output_Vars changed from public to private accesssable via public properties
    '   CropRotationMap:
    '       Duties of CropRotationMap placed in Main
    '       CropRotationMap deleted entirely
    '   Class declarations in main made module level private with assignments made in main
    '   Tillage kill op no longer required to kill a perennial.  
    '       10 days before a crop conflict likely to occur ANY growing crop is killed and harvested
    '   Field ops no longer capped at 1 operation per day

    'May 20, 2009
    '   Weather arrays made private with readonly access through readonly properties the use internal indexes
    '   Active year and day set through public sub

    'May 19, 2009
    '   Crop class changes as follows
    '       Base class contains the master crop list that is instanciated at class creation
    '       Base class contains functions to control bools for growing, killed, and mature and has readonly properties to access these bools
    '       Master crop list fallow position set to 0 instead of 1
    '       Crop class inherits base class
    '       Crop class cannot access the master crop list directly
    '       Chaged or added 3 arrays:
    '           1d array containing each crop in a rotation in order of use
    '           described crop that come from the user
    '           calculated data that comes from the simulation
    '           base class master crop list shortened and set to read only via readonly properties
    '       Functions for stepping through the crop list, these functions also synch up the 4 crop arrays
    '       All crop properties (except calculated) have both a passed an internal index version
    '       Properties names are named to group catagories and sub catagories
    '   Datacheck CropInfo arrray removed entirely in favor of the described list
    '   Changes to CropRotationMap:
    '       Removed StoreCropData as it was redundant
    '       Removed LoadNextCrop as it was redundant
    '       Temporary variables for crop data removed

    'May 12, 2009
    '   Datacheck turned back into a class to force information passing instead of having defacto globals
    '   CropClass following in the steps of Field Operations
    '       Removed RotationTemplate as the location of the crop used in the simulation is not an aspect of the crop
    '       An internal integer controls the active crop and is set via public functions
    '       Aspects of the crop are accessed through properties with the internal crop number controlling which crop's data is returned
    '       Readonly or read/write aspects of the crop controlled through properties
    '       State of a crop is set through 4 functions that use 3 booleans (growing, mature, killed)
    '           CropRotationMap and Main use these states and they needed to be handled strictly

    'May 5, 2009
    '   Field operations fully converted to strict classes with a common inheritable only base class
    '       Base class contains properties and functions that are common to all the field operations
    '       User can add and step through the operations, but cannot access the underlying arrays directly.
    '       Tillage array has been made private

    'May 1, 2009
    '   The operations classes are now closer to operation classes, in which aspects of AN operation can be retrieved
    '       Tillage, Irrigation, and Fertilization input array has been hidden from the user
    '       tillage array is readonly for issues arising from CropRotationMap
    '       Array controls are now internal operators (year, operation number)
    '       Property Get is used to retrieve aspects of a particular operation
    '       Properties and subroutines have class neutral names.  Location will be indicated by the class call
    '       Changes made to the array must go through public subs and functions within the class

    'April 14, 2009
    '   Removed all references to the remaining hashtable.  Now reference the Listview directly
    '   Modularized adding and removing from a listview to minimize errors

    'April 9, 2009
    '   Importing Nitrogen routines from CropSyst
    '   Using the "New" constructor for classes to initialize the classes automatically instead of calling them manually

    'April 7, 2009
    '   Stored control searches into form level global arrays with appropriate names so searches will be minimized
    '       Instead of performing a search to use a control, reference the array and array position

    'April 2, 2009
    '   Import:
    '       When reading from the xls file, formats the tillage and irrigation information properly and discards improper information
    '       Any invalid or overflow operations will be assigned to the inactive listview
    '   Active Tillage and Irrigation listviews now checks total operations per year and existing operation in that year/day

    'March 19, 2009
    '   Progress Bar finished.  Has a uniform enough progression regardless of sim setup and resets properly
    '       Placement of calls to advance the bar only within main
    '       Status label now mirrors log 

    'March 17, 2009
    '   Net result of following changes: Interface should be faster
    '       Consolidated hash tables to one table
    '       Rotation boxes are filled from this table
    '       Rotation year/position unique data is entered only when rotation boxes are empty
    '       Cleaned up listview reads for crops, tillage, and irrigation
    '   Pop up windows will no longer be partly displayed through duration of simulation runtime
    '   Status Strip added
    '       Progress bar will display percentage complete including rotation map, simulation loop, and closing routines
    '       Status label will display a generic "what is happening now label"

    'March 9, 2009
    '   Residue arrays were set to total soil layers, reset to ceiling(totalrotations * total crops per rotation)
    '   delete interface sub made public.  Delete interface should not happen if user cancels an import

    'March 6, 2009
    '   Set Datacheck variables to readonly properties.  Datacheck variables needed to be used as a "fixed in stone" fall back variable
    '   Delete option added to listviews where selecting a row and pressing the delete key deletes the selected line

    'March 4, 2009
    '   Counts added to active and inactive till/irr lists and described crops list

    'March 3, 2009
    '   Sim uses advanced crop descriptions that have been passed through the GUI
    '   Cleaned up some issues relating to redimming null sized arrays
    '   Removed rotation number from tillage.  Is now a Main variable that is passed to a tillage function

    'February 25, 2009
    '   fixed crop to listview button not grabbing advanced descriptions
    '   Import misbehaving with regard to incomplete soil layer descriptions

    'February 24, 2009
    '   Made private all objects on the user form.  To read or modify an object, the user must go through a public function of the form
    '       Significatly reduces the number of objects listed when referencing the main form
    '       Removes possibility of the form being changed by the simulation at runtime
    '   Cleaned up Import and Export routines to be similar in nature and more modular

    'February 23, 2008
    '   Dimensioned arrays based on datacheck values in an effort to reduce unused variable space

    'February 17, 2009
    '   Classes that have no business being such have been changed to Modules
    '       includes, DataVerification, Initialize, Output, ImportExport, CropRotationMap

    'February 16, 2009
    '   Tested on a box using Office '03 Pro.  xlsx files were not handled very well.  Default file changed to xls
    '   Initial attempts to open a workbook are done through try/catch, with fails ending the sub with a fail tag

    'February 13, 2009
    '   Crop Advanced descriptions enabled in interface, simulation does not use them yet

    'February 11, 2009
    '   ImportExport modified to allow for longer crop descriptions
    '       adding additional crop settings will no longer conflict with settings file
    '       checkboxes at bottom of sheet changed from column D to column B
    '       Associated header information moved or added

    'February 10, 2009
    '   Crop descriptions converted to a listview
    '   Field Inputs modified and a new tab added, Crop Descriptions
    '   Reworked a ton of code to allow for resuability related to the hash tables and the crop listview

    'February 6, 2009
    '   Max total field operations increased to 100.  10 per year * 10 years
    '   Import and adding tillage/Irrigation uses precision on floating point numbers
    '   Adding tillage/Irrigation operations is error proofed better

    'February 4, 2009
    '   Soil Inputs and Crop Inputs now read within Datacheck instead of Initialize
    '   Cleaned up log writing

    'February 2, 2009
    '   Excel attempted to start at form load time and it's instance is a form level private variable
    '       Instance is passed to every location it is needed to keep from having to start a new instance every time
    '       Inability to create this instance results in application closing
    '       Only one instance started, so closing becomes simple
    '   Weatherfile textbox double clicking now opens the weather file selection box

    'January 29, 2009
    '   Interface appearance made more uniform
    '   Removed listview counters
    '   File creation is more object oriented.  
    '       One sub for file creation with other subs calling that sub and adding to the created file as neccesary

    'January 28, 2009
    '   Output sheets freeze frame enabled
    '   Imported some optimized code into ExecuteTillage
    '   Cleaned up Import where operation counts were wrong
    '   Changed Result headers and sheets names to match Field Inputs options
    '   Added an activity log to the tabs

    'January 27, 2009
    '   Import and Management tab operations are sorted on the interface by year then day

    'January 26, 2009
    '   Cleaned up listboxes and improved functionality.
    '   Tillage listbox adds default depth if user does not select one.  
    '       Simulation does not require a depth and will still search for one if missing
    '   Added inactive Till/Irr operations to import option
    '       Import and Restore options send valid operations to Active List, operations missing only the year to Inactive List, and ignores the rest
    '   Enabled Export via "CFarm Settings" file
    '       Only exports valid operations
    '   Clear inputs enabled for individual tabs and entire form

    'January 23 2009
    '   Converted Irrigation and Tillage operation interfaces to use Listview instead of many, many, MANY comboboxes and text boxes

    'January 14 2009
    '   IsFileOpen function re-implemented
    '   Cleaned up outfile appearance
    '   Input sheets on import are range read
    '   Results file settings are range written

    'January 13 2009
    '   Current settings saved on exit and loaded if available. Save option is user specified

    'January 9 2009
    '   Import cleaned up to better initialize user form (soil later set, rotation map visibility)

    'January 6 2009
    '   Headers and titles placed on outputs

    'December 19 2008
    '   All cell read/writes with regards to Excel have been converted to range read/writes.

    'December 3 2008
    '   Excel C-Farm dated 3 Dec 2008 has been transfered to the standalone verion.

    'December 2 2008
    '   Excel usage cleaned up and workbook and worksheet passing minimized
    '   Excel termination changed do to stubborn COM issues
    '   Output workbook created and saved, and sheets initialized properly

    'November 24 2008
    '   Consolidated Excel instances to simplify closing the COM and to prevent excel.exe remaining open after program close
    '       Main, Import/Export, Select Weather File are the only instances of Excel.application
    '       3 instances because they are separate/finite sub-programs

    'November 19 2008
    '   Weather file is read properly at runtime
    '   OutputClass outputs being converted to use Excel properly until database up and running

    'November 18 2008
    '   ErrorHandler, Main, Initialize, & DataVerification modified to allow errors to end the simulation without closing the form
    '       DataVerification Subs all made private and turned into functions
    '       ErrorHandler returns a False instead of ending the program
    '       Main, not Initialize, calls DataVerification

    'November 17 2008
    '   Soil text boxes being converted into masked text boxes to ensure only numerical values entered
    '   Hash tables for tillage and master crop list changed to a straight "Items.Add"
    '   Rotation cbox year selections are added at runtime based on MAX_ROTATIONS

    'November 14 2008
    '   Weather file skimmed through at time of selection.  Selection must be done through dialog box
    '   Weather file selection fills to/from year combo boxes on Field Inputs

    'November 12 2008
    '   Layer selection and optional checkbox selection enable and disable soil layers as appropriate
    '   Crop descriptions only enabled if crop selected
    '   Tillage and Irrigation option only enabled if user chooses to use them

    'November 5 2008
    '   tillage and irrigation options disabled unless user chooses to use them
    '   Crop 2 disabled unless user selects a valid crop for Crop 1
    '   Crop descriptions disabled unless user selects a crop to describe
    '   Interface nearing completion

    'November 4 2008
    '   Update removed
    '       Hash tables created at form load, replacing update actions
    '       Hash tables used to add crops to crop lists and to usable crop list, and add to tillage lists
    '   Optional soil descriptions disabled unless user chooses to use them

    'October 25, 2008
    '   Stand alone version interface work proceeding.  Massive work to be done.

    'Jan 15 2008
    '   Imported Excel code into VB from VBA
    '   Small change in Import
    '   CropHarvest: Season Output conditional changed to include all relevant lines instead of just the first line
    '   Import now assumes 0% residue removed instead of calculating a value

    'October 25
    '   Corrected additional issue related to redesign of FI sheet where crop description still being looked for in old location.
    '       Crops described error checking not properly changed to account for 2 additional columns being added
    '   Optimized Crop Class reading from datacheck info so that once all described crops are read, it exits loop. Previous version not very good.
    '   Fields added to FI sheet to support further crop individualization
    '   Original constant "Standing Residue" removed in favor of the user defined version
    '   Added import check to see if settings file newer than current program version
    '   Import recognizes and differentiates current and last 2 versions (070612.01 - 071025.01)
    '       This is going to get out of hand fast if the formats keep changing

    'October 22
    '   Corrected issue related to redesign of FI sheet where crop description still being looked for in old location.
    '       The central cause of the error is that the initial reads were corrected, but not all read instances (at least 3)
    '   Added global variable for max crops able to be described

    'October 19
    '   Improved SimulationYearUpdate to correct dates to weather file correct dates more accurately
    '       If Both dates wrong, simulation period is preserved if possible, else dates changes to start and end of weather file
    '       If one date wrong, that date changed to either start or end of weather file dates, whichever was exceeded
    '   Corrected error catching instructions telling user to look at Crop 1 or "left slot" when that position is now the "top slot"
    '   Added ability to import from version 70612.01 and later.
    '       Export will create a file in the new format.
    '       Import will import in the current and last format depending on the read version number
    '       Import will still warn user before importing from an unknown version or pre-70612.01 file

    'October 1
    '   Expanded Number of years in the rotation from 5 to 10
    '       Expansion required a re-design of the FI sheet & a large re-work of code
    '       Expansion makes previous FI sheet from older settings files unusable

    'September 13
    '   Pre-release changes:
    '       Code password protected as a pre-cursor to the official release of the program
    '       FI, Mgmnt, Soil, And Settings sheets protected to ensure program does not crash due to meddling with the formats
    '       Contact information for Armen And Claudio placed on the FI sheet and a Pop-up at startup
    '       Ensured my information is on the top of Main
    '       Runtime removed from FI sheet

    'August 2
    '   DataVerification - Crops are error checked with more precision

    'July 10
    '   Fixed visual errors

    'June 29
    '   Following done to prevent a user from running a sim, importing a setting, and exporting new settings with old outputs:
    '       Consolidated clear-sheet usage
    '       ClearAll split into 3 subs, a master, ClearInputs, and ClearOutputs.  Allows for better code reusability.
    '       ClearInputs now clears years available so without a weatherfile selected, no years are available.
    '       Import now calls ClearOutputs to clear and hide output sheets
    '       Import does not clear the Settings sheet so a user can see the last used settings if importing after running a sim
    '   Starting a simulation calls ClearOutputs and individual clearcontents statements have been removed
    '   Update moved from the FI sheet to the Lists sheet.  Should only be used by authorized people to reflect
    '       lists changes or fix combobox errors (to date, no combobox errors have happened)
    '   Update changed to a 3 step option(update, re-update, no update).  Double update done to ensure Comboboxes show Lists sheet changes
    '   Update Crops now stores the crops described before update and writes back to the sheet after update
    '   Update halts sim execution after the last update completed to prevent possible runtime errors
    '   Import now checks revision stamp of imported file and compares to earliest compatible version

    'June 22
    '   Start and end positions of weather file no longer passed to ReadWeatherData
    '   ReadWeatherData loop conditions revised for speed and to be independent of the weather file
    '   Revised Tillage and Irrigation Checks for speed
    '   Adjusted Yields now only displays on output sheet if selected in Field Input sheet
    '   CalculateDerivedWeather optimized for speed
    '   Adjusted position of Management Delete line boxes to enable copying of cells

    'June 21
    '   Humification calculations modified slightly
    '   Forced Maturity margin reduced from 21 days to 15 days

    'June 20
    '   Unique crops counter on Settings sheet not displaying correct number, fixed
    '   Settings sheets hidden by default and on ClearAll execution

    'June 19
    '   Sped up Daily outputs by combining separate loops
    '   Changed year on daily outputs to Day-Month-Year to help readability
    '   Removed loops used to clear output sheets. Now simply clears all rows and from first to last used column
    '   Added crop name to Daily Outputs. Will only show when that crop is in the ground
    '   ReadWeatherData no longer opens the weather file, but instead is passed the information from DataVerification

    'June 18
    '   Fixed a few logic errors and a loop condition in DataCheck.CropCheck that allowed cropinfo() to go beyond end of array
    '   Fixed duplicate code issue in RotationMapClass where a loop and a sub were supposed to be doing the same thing and were not
    '   Cleaned up a "crop not becoming mature fast enough then not being harvested" issue

    'June 15
    '   Opening a weatherfile or settings file now initiates an IsFileOpen function
    '   Fixed issue where importing a settings file with a bad weather file address did not update the address after the weather file prompt completed
    '   Fixed a division by zero error when calculating derived weather
    '   Temporary patched issue where harvest date was set beyond end of year (unreachable) due to slower than normal growing crop

    'June 14
    '   Import now reads weather file dates and updates the sim year selection comboboxes

    'June 13
    '   Fixed ComputeRootBiomassInputToSoilLayers calculations
    '   Minor visual improvements on outputs sheets to allow for longer simulation runs
    '   Added revision number to main header, FI sheet, and exported sheet
    '   Date/Time of last import and export added to FI sheet

    'June 12
    '   Last imported and exported filename now stored on the FI sheet
    '   Header on SoilCarbonTotals corrupted, fixed
    '   Date/Time of last successful simulation added to FI sheet
    '   Slight redesign of Outputs section on the FI sheet
    '   Capped max simulation run to 175 years and enforced this limit, single spreadsheet limited to 65536 cells (179.4 yrs)

    'June 11
    '   New Weather file checker misbehaving, corrected
    '   Weather file checker now records data which is read by ReadWeatherData
    '   Weather file checker now only checks USED dates
    '   SimulationDateChecker now overrides dates (with user's permission) to weather file correct dates
    '   All instances of "Single" variables changed to "Double" to allow for long(150+ yrs) simulations
    '   All instances of "Integer" variables changed to "long" to allow for a speed boost.

    'June 8
    '   Weather file data error checked within DataVerification.  Values are not stored.
    '   Array storing end of year day was name changed to YearSpecificLastDOY() to help with name understanding and initialized to 365 instead of zero
    '   THIS sheet (yes, the one you are reading right now) added as a separate module

    'June 1
    '   Variable storing last day of year changed to array to enable leap year
    '   Leap year now supported.  Sim will no longer change years on day 365 only
    '   Chickpeas added to crop list

    'May 23
    '   Export now also copies data created from the last sucessful simulation

    'May 22
    '   Added options for Export, Import, and ClearAll sheets.
    '       Export copies data used to create the simulation
    '       Import copies only user defined data
    '       ClearAll clears all sheets and sets spreadsheet back to default state

    'May 21
    '   Added more crops.  Crop names changed to actual names instead of initials
    '   Reorganized layout of sheet tabs so UI's come first in order of priority

    'May 18
    '   All Output sheets cleaned up and made to look similar
    '   Automated certain tasks on the output sheets that were originally written as independent cell values

    'May 16
    '   Update now updates the comboboxes associated with the crops to keep from having to update them manually

    'May 10
    '   Update option added to update the crop and Tillage Ops sheets automatically but only on demand
    '   Crops array position no longer defined. Allows for easier addition and deletion of crops

    'May 9
    '   Runoff now supported

    'May 8
    '   89+ year sim crash problem solved
    '       years >= 90  w/ daily outputs on is greater than 32656 (max size for "Integer" variables) {365.25 * 90+}
    '       relevant variables changed to "long"

    'May 7
    '   Sim Start and End dates now provided to user automatically from the weather file via comboboxes

    'May 3
    '   Settings sheet created
    '   Location and File handling for the weather file now performed through gui
    '   Groundwork laid for checking sheet & file existence

    'May 1
    '   Error trapped in which 89+ year sims with daily outputs on would crash

    'April 27
    '   Remaining constants removed from constants class to be actual global constants

    'April 19
    '   All ongoing data-checking moved to separate class
    '   Ensured all data read from the UI sheets only one time

    'April 16
    '   Crops error checked

    'April 5
    '   Common variable values changed to global constants
    '   Irrigation error checked
    '   Tillage error checked

    'March 30
    '   Tillage operations specific array position removed.  Allows for easier addition and deletion of operations
    '   Soil error checked

    'March 29
    '   Comboboxes used to select crop names.
    '   Rotation crops to be used can only be selected from described crops
    '   "Management" quick delete cleaned up to be easier to use

    'March 26
    '   Comboboxes being played with for use with "Field Inputs" crops lists
    '   Redesigned "Soil" sheet
    '   "Management" sheet provided option for quick delete of operations

    'March 22
    '   Redesigned "Management" sheet
    '   Comboboxes now used to select tillage operations instead of memorizing tillage codes
    '   Hid "Tillage Tools" from the user

    'March 21
    '   Redesigned "Field Inputs" sheet
    '   Simcontrol error checks FI sheet

    'March 18
    '   Redesigned "Soil" sheet

    'March 15
    '   Added option to use Manual or Calculated soil parameters

    'March 14
    '   Checkboxes added to replace true/false fields on all UI sheets

    'March 12 2007
    '   Initial
End Module
