To Install and use this TigerLink with EasyDental version 12 or similar, 

1) Run InstallEzBridge.exe from the e\Programs\EasyDentalBridge

    For the EzDental Program Folder, use the folder that the registry points to (e.g. C:\Program Files (x86)\EzDental. This directory should include EasyDental.exe.
    For the TigerView Folder, use the folder that contains the Tiger1.exe file.
    For the bridge name, I recommend "TigerLink", but the program should work with any alphabetic string of reasonable length.
    Click Configure
	
2) Start EasyDental
	Select a patient by going to the patient icon in the upper left corner and filling out enough information to select a patient.
	Click on the three interconnected circles at the right end of the toolbar icon collection (might be near the top middle of the screen)
	Click OK
	Notice the TigerView icon appears in the upper-right corner.
	Left-click on the icon and verify that TigerView opens to the selected patient in the patient search field.
	
3) If anything goes wrong, look at the easyLink.ini file in the EzDental program file folder. It should look like this:

[General]
Orientation=0
XPosition=1773
YPosition=0
DisplayStyle=2
AlwaysOnTop=0
HideToolTip=0
ShowDescriptions=0
HideSplash=0
SmallIcons=0
MaxToolsShowing=10
TopTool=0
[TigerLink]
Description = Link to TigerView Application
Installed Link Version=12
ExeFile = C:\Users\Peter\source\repos\TigerView8\bin\x86\Build\Tiger1.exe
WorkDir =
KeyFile = TigerLink.dll
IconIndex = 0
DisplayOrder = 0
DisplayStyle = 0

The last nine lines are the ones that control the behavior of the link.
The exeFile should be the path to the TigerView Professional Tiger1.exe file.
The KeyFile should exist in the same directory with this ini file.
	