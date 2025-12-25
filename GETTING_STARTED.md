# Getting Started with Sims 4 Mod Constructor

This guide will help you get started with creating your first Sims 4 mod.

## Quick Start

### Option 1: Using Pre-built Executable (Easiest)

1. **Get the executable**
   - Run `build-exe.bat` (Windows) or `./build-exe.sh` (Linux/macOS) to create it
   - Or download a pre-built release if available
   
2. **Run the application**
   - Navigate to the `publish/` folder
   - Double-click `Sims4ModConstructor.exe`
   - No .NET installation required!

### Option 2: Run from Source (For Developers)

1. **Build the application**
   ```bash
   cd Sims4ModConstructor
   dotnet build -c Release
   ```

2. **Run the application** (on Windows)
   ```bash
   dotnet run
   ```
   Or double-click the executable in `bin/Release/net8.0-windows/`

## Creating Your First Mod

### Step 1: Set Up Your Project
1. Launch the application
2. Go to **File → New Project**
3. In the **Project Info** tab, enter:
   - **Project Name**: e.g., "MyFirstMod"
   - **Author**: Your name
   - **Version**: 1.0.0
   - **Mod Type**: Choose XML, Python, or Both
   - **Description**: Brief description of your mod

### Step 2: Create an Interaction
1. Go to the **Interactions** tab
2. Click **Add**
3. Fill in the interaction details:
   - **Name (Internal)**: `MyInteraction` (no spaces, used in code)
   - **Display Name**: "My Interaction" (what players see)
   - **Description**: What the interaction does
   - **Category**: Choose from Social, Friendly, Funny, Mean, Mischief, Romance, Special
   - **Priority**: 1-100 (higher = more likely to appear)
   - **Is Autonomous**: Check if sims can do this on their own
   - **Buffs to Apply**: Add buff names (optional)
4. Click **OK**

### Step 3: Create a Buff
1. Go to the **Buffs** tab
2. Click **Add**
3. Fill in the buff details:
   - **Name (Internal)**: `MyBuff` (no spaces)
   - **Display Name**: "My Buff" (what players see)
   - **Description**: What the buff does
   - **Mood Type**: Choose the mood (Happy, Sad, Angry, etc.)
   - **Mood Weight**: How strong the mood effect is (-10 to 10)
   - **Duration**: How long it lasts (in sim minutes)
   - **Visible in UI**: Check if players should see this buff
4. Click **OK**

### Step 4: Create a Trait
1. Go to the **Traits** tab
2. Click **Add**
3. Fill in the trait details:
   - **Name (Internal)**: `MyTrait` (no spaces)
   - **Display Name**: "My Trait" (what players see)
   - **Description**: What the trait does
   - **Category**: Personality, Lifestyle, Social, Hobby, or Career
   - **Conflicting Traits**: Add traits that conflict with this one
4. Click **OK**

### Step 5: Save Your Project
1. Go to **File → Save Project**
2. Choose a location and filename (e.g., `MyFirstMod.s4mp`)
3. Click **Save**

### Step 6: Export Your Mod
1. Go to **File → Export Mod**
2. Select a folder where you want to save the exported files
3. Click **OK**

## Understanding the Output

### XML Format
If you selected XML or Both, you'll get:
```
XML/
├── ModInfo.xml          (Mod information)
├── Interactions/        (Interaction definitions)
├── Buffs/              (Buff definitions)
└── Traits/             (Trait definitions)
```

### Python Format (.ts4script)
If you selected Python or Both, you'll get:
```
Python/
├── __init__.py          (Main script)
├── README.md            (Installation instructions)
├── interactions/        (Interaction scripts)
│   ├── __init__.py
│   └── [interaction].py
├── buffs/              (Buff scripts)
│   ├── __init__.py
│   └── [buff].py
└── traits/             (Trait scripts)
    ├── __init__.py
    └── [trait].py
```

## Installing Your Mod in Sims 4

### For XML Mods
1. XML files need to be packaged into a `.package` file using tools like Sims 4 Studio or Package Editor
2. Place the `.package` file in your Sims 4 Mods folder
3. Enable mods in game settings

### For Python Mods (.ts4script)
1. Create a `.zip` file with all the Python folder contents
2. Rename the `.zip` file to `.ts4script`
3. Place the `.ts4script` file in your Sims 4 Mods folder
4. **Enable script mods** in game settings (important!)

## Tips for Good Mods

1. **Use descriptive names**: Make internal names clear (e.g., `FriendlyHug` not just `Hug`)
2. **Test interactions**: Start with simple interactions before creating complex ones
3. **Balance buffs**: Don't make mood weights too high (2-3 is usually good)
4. **Reasonable durations**: Consider that 60 sim minutes ≈ 1 sim hour
5. **Set conflicting traits**: Prevent incompatible traits (e.g., Outgoing conflicts with Loner)

## Example Project

Check the `Examples/` folder for a complete example project (`ExampleProject.s4mp`) that you can:
- Open and study
- Modify for your own use
- Export to see the generated files

## Need Help?

- Check the main README.md for detailed feature documentation
- Look at the example project for reference
- The exported Python files include comments to help you understand the structure

## Advanced Usage

### Multiple Buffs on One Interaction
When creating an interaction, you can add multiple buffs in the "Buffs to Apply" section. Each buff will be applied when the interaction is used.

### Mod Type Selection
- **XML**: Traditional tuning files, requires packaging tools
- **Python**: Script mods, more powerful but requires Python knowledge
- **Both**: Generate both formats simultaneously

Happy modding! 🎮
