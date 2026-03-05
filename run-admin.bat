@echo off
REM RdpScopeToggler - Run as Administrator

REM Get the directory where this batch file is located
cd /d "%~dp0"

REM Change to the Release build directory
cd bin\Release\net8.0-windows10.0.19041.0\

REM Run the application
start RdpScopeToggler.exe

REM Exit this batch window
exit /b
