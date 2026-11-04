<p align="center">
  <a href="README.md"><img alt="한국어" src="https://img.shields.io/badge/%ED%95%9C%EA%B5%AD%EC%96%B4-%ED%95%9C%EA%B5%AD%EC%96%B4%EB%A1%9C%20%EB%B3%B4%EA%B8%B0-6e7681?style=for-the-badge"></a>
  <a href="README.en.md"><img alt="English (this page)" src="https://img.shields.io/badge/English-This%20page-1f6feb?style=for-the-badge"></a>
</p>

# SPT-DynamicMap-zzap--bootleg-

---

### ⚠️ IMPORTANT NOTICE / DISCLAIMER

- **Original Author:** Michael P. Starkweather (mpstark) — 1.2.x maintained by acidphantasm
- **Original Repository:** SPT-DynamicMaps
- **Original Link:** https://github.com/mpstark/SPT-DynamicMaps
- **License:** MIT (code) · map images: see each map folder (CC BY-NC-SA 4.0 / MIT data)

1. **Reflection & Take-Downs:** I deeply reflect on the ECOT incident. As an AI-assisted "vibe coder," I will immediately delete files if the original authors ask.
2. **No Re-Distribution:** These ported builds are unverified, temporary fixes. Please do NOT re-upload or share them anywhere else.
3. **Do Not Pester Original Authors:** Never report bugs or pester original modders regarding issues from my unofficial ports.
4. **Full Credit & Respect:** I will always credit original creators on GitHub and prioritize their decisions above all else.
5. **Support Original Creators:** Instead of using my ports, please visit the original authors' Forge pages to leave kind words or tips.

---

## Changelog

The full changelog (2 entries) is in the [`changelog/`](changelog/) folder, 10 per file (higher number = newer, latest: [`CHANGELOG-001.md`](changelog/CHANGELOG-001.md)). Per-release summaries: [Releases](../../releases).

## What's different

An edited build of DynamicMaps for SPT 4.1, the mod that replaces the in-game map screen with a usable map.

- **New maps**: Terminal, Interchange rework, Lighthouse rework, Labs rework (office above the boiler room), and Factory Classic. Includes labels, extractions, transit points, locked doors, and switches. Three newly drawn maps also show minefields (red), sniper zones (orange hatching), and inaccessible areas (darkened), positioned from game data.
- **Labs**: the first-floor Secret Lab, previously clipped outside the map bounds, was drawn from game map data on both original and rework maps. Labs (Rework) floor 2 is ManimalLabs' office above the boiler room.
- **Icebreaker**: included in the release ZIP (map art by 파인애플애호가), but not uploaded to this repository.
- **Automatic original/rework map selection**: shows the rework map if MapVariants or a Manimal backport runs that raid on the rework; otherwise shows the original.
- **Korean**: BepInEx Configuration Manager (F12) settings and map text (locations, extractions, doors, floor names). F12 언어 (Language) = 자동 (Auto) / 한국어 (Korean) / English.
- **Bot colors by faction**: RUAF, RUAF Remnant, Black Division, Raiders, Rogues, Cultists, boss followers, and Terminal civilians each get their own colors instead of the Scav color. Change them in F12's 6. 마커 색 (6. Marker Colors), or disable 세력별 색 구분 (Color bots by faction) to restore Scav colors.
- **Reduced minimap stutter**: avoids recalculating on the same floor, saves zoom only once after adjustment ends, and draws markers separately from map art. Added a minimap update interval setting in F12.
- Original feature documentation: [`Plugin/README.md`](Plugin/README.md).

## Installation

- Extract the release's `DynamicMaps-zzap--bootleg--v2.zip` into the SPT folder and overwrite. Settings are retained.
- **Do not install alongside DynamicMaps-Extended** (a different edited version of the same mod; they conflict).

## Original authors / Licenses

- Plugin code: Michael P. Starkweather (mpstark)'s [SPT-DynamicMaps](https://github.com/mpstark/SPT-DynamicMaps), MIT ©2024 — [`Plugin/LICENSE`](Plugin/LICENSE). 1.2.x maintained by acidphantasm. Code changes in this build are also MIT.
- Original maps/data: TarkovData (TarkovTracker), TarkovDev (MIT ©2019 Oskar Risberg), and Shebuka map art (CC BY-NC-SA 4.0) — [`map_and_data_credits.txt`](Plugin/Resources/Maps/map_and_data_credits.txt) and each map folder's LICENSE.
- Marker icons: [`marker_credits.txt`](Plugin/Resources/Markers/marker_credits.txt) (BTR icon by Kuromi).
- Lighthouse and Interchange reworks use the original DynamicMaps art (Shebuka), changing only reworked areas with data taken from game terrain; Terminal was drawn directly from the installed game's terrain. All use CC BY-NC-SA 4.0 (each folder's `LICENSE-MODIFIED BY ZZAP.md` and `zzap-LICENSE.md`). Game assets belong to their original rights holders.
- Labs expands the original Labs art (Shebuka), adding the first-floor Secret Lab and reworked second-floor office under the same CC BY-NC-SA 4.0 (`Labs_TarkovDev/Layers/zzap-CHANGES.md`). Factory Classic uses original DynamicMaps Factory art unchanged, under its original license.

---

## English

An edited build of DynamicMaps for SPT 4.1 (the mod that turns the in-game map screen into a usable map).

- **New maps**: Terminal, Interchange rework, Lighthouse rework, Labs rework (office above the boiler room), Factory Classic, and Icebreaker. Labels, extracts, transits, locked doors and switches included. The three newly drawn maps also show minefields (red), sniper zones (orange hatching) and out-of-bounds areas (darkened) from the game data.
- **Labs**: the first-floor Secret Lab, cut off by the old map bounds, is drawn from the game's map data (both Labs maps). Labs (Rework) floor 2 shows the ManimalLabs office above the boiler room.
- **Icebreaker**: shipped in the release zip only, not in this repository (map art by 파인애플애호가).
- **Original/rework map picked automatically**: when MapVariants or a Manimal backport runs the rework map for a raid, the rework map is shown; otherwise the original.
- **Korean**: F12 settings and map texts. F12 "Language" = Auto (follows the game language) / Korean / English.
- **Bot colors by faction**: RUAF, RUAF Remnant, Black Division, Raiders, Rogues, Cultists, boss followers and Terminal civilians get their own marker colors instead of the Scav color. Change them in F12 "6. Marker Colors", or turn off "Color bots by faction".
- **Less minimap stutter**: no recalculation on the same floor, zoom saved once after you stop, markers drawn apart from the map image. New F12 minimap update interval.

### Install

- Extract `DynamicMaps-zzap--bootleg--v2.zip` from the release into your SPT folder and overwrite. Settings are kept.
- **Do not install together with DynamicMaps-Extended** (another edit of the same mod; they conflict).

### Credits / License

- Plugin code: [SPT-DynamicMaps](https://github.com/mpstark/SPT-DynamicMaps) by Michael P. Starkweather (mpstark), MIT ©2024 — [`Plugin/LICENSE`](Plugin/LICENSE). 1.2.x maintained by acidphantasm. Changes in this build are MIT as well.
- Original maps and data: TarkovData (TarkovTracker), TarkovDev (MIT ©2019 Oskar Risberg), Shebuka map art (CC BY-NC-SA 4.0) — [`map_and_data_credits.txt`](Plugin/Resources/Maps/map_and_data_credits.txt) and the LICENSE in each map folder.
- Marker icons: [`marker_credits.txt`](Plugin/Resources/Markers/marker_credits.txt) (BTR icon by Kuromi).
- Lighthouse and Interchange reworks start from the original DynamicMaps (Shebuka) art and add only what the rework changed, taken from the game's terrain; Terminal is drawn from the installed game's terrain. All CC BY-NC-SA 4.0 — `LICENSE-MODIFIED BY ZZAP.md` / `zzap-LICENSE.md` in each folder. Game assets belong to their owners.
- Labs widens the original Shebuka Labs art and adds the first-floor Secret Lab and the rework office on floor 2, same CC BY-NC-SA 4.0 (`Labs_TarkovDev/Layers/zzap-CHANGES.md`). Factory Classic uses the original DynamicMaps Factory art as is (original license).
