# Sims 4 Mod Constructor

A Windows Forms application for creating Sims 4 mods with support for both XML and Python (.ts4script) formats.

## Features

- **Project Management**: Create, save, and load mod projects
- **Mod Type Support**: Generate XML mods, Python mods, or both
- **Interaction Creator**: Define custom interactions with configurable properties
  - Name and display name
  - Description
  - Category (Social, Friendly, Funny, Mean, Mischief, Romance, Special)
  - Priority level
  - Autonomous behavior
  - Buff applications
- **Buff Creator**: Create custom mood buffs
  - Name and display name
  - Description
  - Mood type (Happy, Sad, Angry, Playful, Flirty, Confident, Focused, etc.)
  - Mood weight
  - Duration
  - Visibility settings
- **Trait Creator**: Design custom traits
  - Name and display name
  - Description
  - Category (Personality, Lifestyle, Social, Hobby, Career)
  - Conflicting traits
- **Export Functionality**: Export complete mod structure with generated files

## Requirements

- .NET 8.0 or later (for development)
- Windows operating system (WinForms application)

## Getting the Application

### Option 1: Download Pre-built Executable (Recommended for Users)

Run the build script to create a standalone executable:
- **Windows**: Double-click `build-exe.bat` or run it from command line
- **Linux/macOS**: Run `./build-exe.sh` in terminal

The executable will be created at `publish/Sims4ModConstructor.exe` (≈162 MB, includes .NET runtime).

See [BUILD.md](BUILD.md) for detailed build instructions and options.

### Option 2: Run from Source (For Developers)

```bash
cd Sims4ModConstructor
dotnet restore
dotnet build
dotnet run
```

## Usage

1. **Create a New Project**: File → New Project
2. **Configure Project Settings**: Go to "Project Info" tab and set:
   - Project name
   - Author
   - Version
   - Mod type (XML, Python, or Both)
   - Description
3. **Add Interactions**: Go to "Interactions" tab and click "Add" to create new interactions
4. **Add Buffs**: Go to "Buffs" tab and click "Add" to create new buffs
5. **Add Traits**: Go to "Traits" tab and click "Add" to create new traits
6. **Save Project**: File → Save Project (saves as .s4mp file)
7. **Export Mod**: File → Export Mod (generates XML and/or Python files)

## Exported Structure

### XML Mod
```
XML/
├── ModInfo.xml
├── Interactions/
│   └── [InteractionName].xml
├── Buffs/
│   └── [BuffName].xml
└── Traits/
    └── [TraitName].xml
```

### Python Mod (.ts4script)
```
Python/
├── __init__.py
├── interactions/
│   ├── __init__.py
│   └── [interaction_name].py
├── buffs/
│   ├── __init__.py
│   └── [buff_name].py
├── traits/
│   ├── __init__.py
│   └── [trait_name].py
└── README.md
```

## License

This project is open source and available for use in creating Sims 4 mods.