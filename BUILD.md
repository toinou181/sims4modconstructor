# Building Executable (.exe) for Sims4ModConstructor

This document explains how to create a standalone executable (.exe) file for the Sims4ModConstructor application.

## Prerequisites

- .NET 8.0 SDK or later installed
- Windows operating system (for running the application)
- Approximately 200 MB of disk space for the build output

## Quick Start

### Using the Build Script (Recommended)

**On Windows:**
1. Open Command Prompt or PowerShell
2. Navigate to the repository root
3. Run:
   ```batch
   build-exe.bat
   ```

**On Linux/macOS:**
1. Open Terminal
2. Navigate to the repository root
3. Run:
   ```bash
   ./build-exe.sh
   ```

The executable will be created at `publish/Sims4ModConstructor.exe`

### Manual Build

If you prefer to build manually or need custom options:

```bash
cd Sims4ModConstructor
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishReadyToRun=true -o ../publish
```

## Build Output

After building, you'll find these files in the `publish/` folder:

- **Sims4ModConstructor.exe** (≈162 MB) - The main executable (self-contained)
- Supporting DLL files for Windows Forms rendering
- Sims4ModConstructor.pdb - Debug symbols (optional, can be removed)

## Deployment

### Single File Distribution

The `Sims4ModConstructor.exe` file is self-contained and includes the .NET runtime. You can:

1. **Simple distribution**: Just share the `Sims4ModConstructor.exe` file
   - Users can double-click to run (no .NET installation required)
   - The application will extract necessary files on first run

2. **Full distribution**: Share the entire `publish/` folder
   - Includes all necessary DLL files
   - Slightly faster startup time (no extraction needed)

### System Requirements

The generated executable requires:
- Windows 7 SP1 or later (x64)
- No separate .NET installation needed (it's self-contained)
- Approximately 200 MB of disk space

## Build Options Explained

The build command uses these options:

- `-c Release` - Build in Release configuration (optimized)
- `-r win-x64` - Target Windows x64 runtime
- `--self-contained true` - Include .NET runtime (no installation needed)
- `-p:PublishSingleFile=true` - Bundle into a single .exe file
- `-p:PublishReadyToRun=true` - Pre-compile for faster startup
- `-o ../publish` - Output to the publish folder

## Advanced Build Options

### Trimming (Smaller File Size)

To create a smaller executable with unused code removed:

```bash
dotnet publish -c Release -r win-x64 --self-contained true \
  -p:PublishSingleFile=true \
  -p:PublishTrimmed=true \
  -p:TrimMode=link \
  -o ../publish-trimmed
```

⚠️ **Warning**: Trimming may cause issues with WinForms applications. Test thoroughly!

### Framework-Dependent Build

If your users have .NET 8.0+ installed, you can create a smaller executable:

```bash
dotnet publish -c Release -r win-x64 --self-contained false \
  -p:PublishSingleFile=true \
  -o ../publish-framework-dependent
```

This creates a much smaller file (≈10 MB) but requires .NET 8.0+ to be installed.

## Troubleshooting

### Build Errors

**Error: "SDK not found"**
- Install .NET 8.0 SDK from https://dotnet.microsoft.com/download

**Error: "Project targeting net8.0-windows"**
- This is normal - the project requires Windows-specific features

### Runtime Issues

**"Application failed to start"**
- Ensure the user has a 64-bit Windows OS
- Check that Windows Defender or antivirus isn't blocking the executable

**"Slow first startup"**
- Self-contained single-file executables extract on first run
- Subsequent launches will be faster
- Consider distributing the full `publish/` folder for faster startup

## File Size

The self-contained executable is large (≈162 MB) because it includes:
- The .NET 8.0 runtime
- Windows Forms libraries
- All application code
- Pre-compiled ready-to-run images

This is normal for self-contained .NET applications and ensures users don't need to install anything separately.

## Continuous Integration

To build the executable in CI/CD pipelines:

### GitHub Actions Example

```yaml
- name: Publish Executable
  run: |
    cd Sims4ModConstructor
    dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o ../publish
    
- name: Upload Artifact
  uses: actions/upload-artifact@v3
  with:
    name: Sims4ModConstructor-exe
    path: publish/Sims4ModConstructor.exe
```

## Version Management

To update the version number of your executable, edit `Sims4ModConstructor.csproj` and add:

```xml
<PropertyGroup>
  <Version>1.0.0</Version>
  <AssemblyVersion>1.0.0.0</AssemblyVersion>
  <FileVersion>1.0.0.0</FileVersion>
  <Product>Sims4ModConstructor</Product>
  <Company>Your Name</Company>
  <Copyright>Copyright © 2024</Copyright>
</PropertyGroup>
```

## Additional Resources

- [.NET Publishing Overview](https://learn.microsoft.com/en-us/dotnet/core/deploying/)
- [Single-file deployment](https://learn.microsoft.com/en-us/dotnet/core/deploying/single-file)
- [ReadyToRun compilation](https://learn.microsoft.com/en-us/dotnet/core/deploying/ready-to-run)

## Support

For issues with building or distributing the executable, please check:
1. The main README.md for application usage
2. GitHub Issues for known problems
3. .NET documentation for SDK-specific issues
