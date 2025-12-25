#!/bin/bash
# Build script for creating standalone executable
# This creates a self-contained, single-file .exe that can be distributed

echo "========================================"
echo "Building Sims4ModConstructor Executable"
echo "========================================"
echo ""

cd Sims4ModConstructor

echo "Restoring dependencies..."
dotnet restore
if [ $? -ne 0 ]; then
    echo "Failed to restore dependencies!"
    exit 1
fi

echo ""
echo "Building Release configuration..."
dotnet build -c Release
if [ $? -ne 0 ]; then
    echo "Build failed!"
    exit 1
fi

echo ""
echo "Publishing self-contained executable..."
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishReadyToRun=true -o ../publish
if [ $? -ne 0 ]; then
    echo "Publishing failed!"
    exit 1
fi

echo ""
echo "========================================"
echo "Build completed successfully!"
echo "========================================"
echo ""
echo "The executable has been created at:"
echo "publish/Sims4ModConstructor.exe"
echo ""
echo "File size: approximately 162 MB (includes .NET runtime)"
echo ""
echo "You can now distribute the publish folder contents,"
echo "or just the .exe file (it's self-contained)."
echo ""
