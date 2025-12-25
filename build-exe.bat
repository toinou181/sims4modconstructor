@echo off
REM Build script for creating standalone executable
REM This creates a self-contained, single-file .exe that can be distributed

echo ========================================
echo Building Sims4ModConstructor Executable
echo ========================================
echo.

if not exist "Sims4ModConstructor" (
    echo ERROR: Sims4ModConstructor directory not found!
    echo Please run this script from the repository root directory.
    echo.
    pause
    exit /b 1
)

cd Sims4ModConstructor

echo Restoring dependencies...
dotnet restore
if %ERRORLEVEL% neq 0 (
    echo Failed to restore dependencies!
    pause
    exit /b %ERRORLEVEL%
)

echo.
echo Building Release configuration...
dotnet build -c Release
if %ERRORLEVEL% neq 0 (
    echo Build failed!
    pause
    exit /b %ERRORLEVEL%
)

echo.
echo Publishing self-contained executable...
dotnet publish -c Release ^
  -r win-x64 ^
  --self-contained true ^
  -p:PublishSingleFile=true ^
  -p:PublishReadyToRun=true ^
  -o ../publish
if %ERRORLEVEL% neq 0 (
    echo Publishing failed!
    pause
    exit /b %ERRORLEVEL%
)

echo.
echo ========================================
echo Build completed successfully!
echo ========================================
echo.
echo The executable has been created at:
echo publish\Sims4ModConstructor.exe
echo.
echo File size: approximately 162 MB (includes .NET runtime)
echo.
echo You can now distribute the publish folder contents,
echo or just the .exe file (it's self-contained).
echo.
pause
