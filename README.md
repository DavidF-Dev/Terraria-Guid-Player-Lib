# Guid Player Library
[![Release](https://img.shields.io/github/v/release/DavidF-Dev/Terraria-Guid-Player-Lib?style=flat-square)](https://github.com/DavidF-Dev/Terraria-Guid-Player-Lib/releases/latest)
[![Downloads](https://img.shields.io/steam/downloads/3408408416?style=flat-square)](https://steamcommunity.com/sharedfiles/filedetails/?id=3408408416)
[![File Size](https://img.shields.io/steam/size/3408408416?style=flat-square)](https://steamcommunity.com/sharedfiles/filedetails/?id=3408408416)
[![Issues](https://img.shields.io/github/issues/DavidF-Dev/Terraria-Guid-Player-Lib?style=flat-square)](https://github.com/DavidF-Dev/Terraria-Guid-Player-Lib/issues)
[![License](https://img.shields.io/github/license/DavidF-Dev/Terraria-Guid-Player-Lib?style=flat-square)](https://github.com/DavidF-Dev/Terraria-Guid-Player-Lib/blob/main/LICENSE.md)

A Terraria tModLoader library mod that provides a globally unique identifier (GUID) for each player.<br />
The GUID is synced and can be accessed from server and client safely.

## Usage
### Requirements
- tModLoader for `1.4.4`.

### Referencing the library
- Add `modReferences = GuidPlayerLib` to your mod's `build.txt` file.
- Add `GuidPlayerLib.dll` to your project as a reference (download from [Releases](https://github.com/DavidF-Dev/Terraria-Guid-Player-Lib/releases/latest)).
- Subscribe to the library mod on the [Steam Workshop](https://steamcommunity.com/sharedfiles/filedetails/?id=3408408416).

Note: this library depends on my [Easy Packet Library](https://github.com/DavidF-Dev/Terraria-Easy-Packets-Lib).
tModLoader should handle subscribing to it automatically.
In the odd case that it doesn't, simply subscribe to it manually.

### Public methods
All calls are available via extension methods in the `GuidPlayerExtensions` static class.
```csharp
// Retrieve a player's GUID
Guid guid = player.GetGuid();
```

### Mod calls
```csharp
// Retrieve a player's GUID
Mod mod = ModLoader.GetMod("GuidPlayerLibMod");
Guid guid = (Guid)mod.Call("GetGuid", player);
```

## Contact & Support

If you have any questions or would like to get in contact, shoot me an email at `contact@davidfdev.com`.<br>
Alternatively, you can send me a direct message on Twitter at [@DavidF_Dev](https://twitter.com/DavidF_Dev).
