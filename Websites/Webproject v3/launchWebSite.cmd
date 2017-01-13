@echo off
REM Web Application Design - Web Server Launcher v3.0 Spring 2015
TITLE Web Site

ver | findstr /i "5\.1\." > nul
IF %ERRORLEVEL% EQU 0 goto ver_XP
ver | findstr /i "6\.1\." > nul
IF %ERRORLEVEL% EQU 0 goto ver_Win7
goto warn_and_exit

:ver_Win7
:Run Windows 7 specific commands here
REM echo OS Version: Windows 7 (debug line)
"C:\Program Files (x86)\IIS Express\iisexpress.exe" /port:7777 /path:"C:\Users\%USERNAME%\desktop\Webproject v3\WebSite"
goto end

:warn_and_exit
echo Machine OS cannot be determined.

:end 