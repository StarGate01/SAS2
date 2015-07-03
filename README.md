# SAS2
## Scratch Arduino Server Version 2

This is a extension for the Scratch 2.0 Offline Editor, adding support for programming with the Arduino. 

You speak German? --> https://www.vb-paradise.de/index.php/Thread/109864-Update-Scratch-Arduino-Server-2-0/

###Requirements:
 - Windows
 - Arduino with installed drivers and connection to your PC
 - Adobe AIR, required by
 - Scratch 2.0 Offline Editor
 - At least .NET Framework 4 

###Requirements to compile:
 - Visual Studio 2013
 - Arduino IDE
 - Visual Micro for Visual Studio and Arduino

###In order to use this software:
 - Plug in your Arduino and install all drivers etc. if you have not already
 - Find the COM-port your Arduino is attached to
 - Start the Windows server and connect
	- If this does not work, make sure you 
	- selected the correct port and 
	- have permission to open the HTTP server (see below)
 - Start Scratch and load the extension via shift+click on "File" -> "Import experimental HTTP extension"
 - Have fun using the the new blocks in the "More Blocks" section


###Notes:
 - This software is beta and is still being developed. You are using this software at your own risk. The author cannot be held responsible for any damage done to your software environment or your hardware. (I probably will feel sorry for you tho)
 - For optimal performance, minimize the Windows server window
 - If the server or Scratch stutters or does strange things:
	- Disconnect the server
	- Restart your Arduino with its hardware button
	- Connect the server again
	- Scratch should pick up the connection automatically, if it doesn't restart Scratch too
 - Running the server requires administrative rights. So you either
	- Start the executable as administrator
	- Allow using the connection via 
	```
	netsh http add urlacl url=http://+:45133/ user=<user> listen=yes
	```
	Replace \<user\> with your needed user or group, e.g. "Everyone" (German: "Jeder") or "DOMAIN\User".

	Reset it with
	```
	netsh http delete urlacl url=http://+:45133/
	```
	These commands must be executed as administrator


###Links:
 - Scratch: http://scratch.mit.edu/scratch2download/


