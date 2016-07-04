SRCDS Server Monitor Release Version 0.13.2

This program requires .NET Framework 4.5.1 to run.
You can find the link to 4.5.1 below, which should also work.
http://www.microsoft.com/en-gb/download/details.aspx?id=40779

Most of this program is self explanatory.
A few notes:
- !!! MAKE SURE YOU SET THE CORRECT IP !!!
- Only IPv4 is supported
- You can exit the program without closing the srcds instances.
- If you exited while srcds was still running, you can relaunch this program again and try to start the server; if srcds is still there, it will monitor srcds without it having to restart.
- You can edit the pid of the server in the list to an existing server that is already running, it will monitor it when you try to start it, instead of starting a new srcds window. (Make sure the ip and port is correct!)
- The IP address that should be used should be the one that srcds reports internally ( type status in the console to find it )
- You can edit the polling time and the threshold before restarting, do not set the threshold too low or cpu usage will be higher.
- The default wait time is 120 seconds, it should be enough for most servers; mine loads in under 25 seconds, so I can have it set at 30 seconds.
- The default command line is to run prop hunt, because that's what I run. Deal with it.
- The config file is stored at C:\Users\<username>\AppData\Local\banana-ph.com\<version> ; I suggest not touching it unless you want to break stuff. (or back it up first if you decide to mess with it)
- Added ability to export settings to xml.
- Auto start option added. Configure each server individually. Add SRCDS Server Monitor to your start up folder or set up a task schedule to automate.

THERE IS NO WARRANTY FOR THE PROGRAM, TO THE EXTENT PERMITTED BY
APPLICABLE LAW.  EXCEPT WHEN OTHERWISE STATED IN WRITING THE COPYRIGHT
HOLDERS AND/OR OTHER PARTIES PROVIDE THE PROGRAM "AS IS" WITHOUT WARRANTY
OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING, BUT NOT LIMITED TO,
THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
PURPOSE.  THE ENTIRE RISK AS TO THE QUALITY AND PERFORMANCE OF THE PROGRAM
IS WITH YOU.  SHOULD THE PROGRAM PROVE DEFECTIVE, YOU ASSUME THE COST OF
ALL NECESSARY SERVICING, REPAIR OR CORRECTION.