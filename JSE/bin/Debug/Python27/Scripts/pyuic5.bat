@echo off
if "%WINPYDIR%"=="" call "%~dp0..\..\scripts\env.bat"
"%WINPYDIR%\python.exe" -m PyQt5.uic.pyuic %1 %2 %3 %4 %5 %6 %7 %8 %9