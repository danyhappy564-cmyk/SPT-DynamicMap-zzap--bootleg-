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

## 변경 이력

- 2026-11-03 01:03 — v1: 새 지도 6종(터미널·인터체인지 리워크·등대 리워크·연구소 리워크·공장 클래식·쇄빙선), 지도·F12 한국어(자동이면 게임 언어를 따름), 원본/리워크 지도 자동 선택, 미니맵 끊김 줄이기. 원본 1.2.1 기준.

## 무엇이 다른가

SPT 4.1용 DynamicMaps(게임 지도 화면을 쓸 만한 지도로 바꾸는 모드)를 고친 판입니다.

- **새 지도**: 터미널, 인터체인지 리워크, 등대 리워크, 연구소 리워크(보일러실 위 사무실), 공장 클래식. 지명·탈출구·이동 지점·잠긴 문·스위치 표시 포함.
- **쇄빙선**: 릴리즈 zip에 들어 있습니다(그림 제작: 파인애플애호가). 저장소에는 올리지 않았습니다.
- **원본/리워크 지도 자동 선택**: MapVariants나 Manimal 백포트 모드가 그 판을 리워크 맵으로 돌리면 리워크 지도, 아니면 원본 지도를 띄웁니다.
- **한국어**: F12 설정과 지도 글자(지명·탈출구·문·층 이름). F12 "언어" = 자동 / 한국어 / English.
- **미니맵 끊김 줄이기**: 같은 층이면 다시 계산하지 않고, 확대가 끝난 뒤 한 번만 저장하고, 마커와 지도 그림을 따로 그립니다. F12에 미니맵 갱신 간격 설정 추가.
- 원본 기능 설명은 [`Plugin/README.md`](Plugin/README.md).

## 설치

- 릴리즈의 `DynamicMaps-zzap--bootleg--v1.zip`을 SPT 폴더에 풀어 덮어쓰기. 설정은 그대로 유지됩니다.
- **DynamicMaps-Extended와 같이 설치하지 마세요**(같은 모드를 고친 다른 판이라 충돌합니다).

## 원작자·라이선스

- 플러그인 코드: Michael P. Starkweather(mpstark)의 [SPT-DynamicMaps](https://github.com/mpstark/SPT-DynamicMaps), MIT ©2024 — [`Plugin/LICENSE`](Plugin/LICENSE). 1.2.x 유지보수 acidphantasm. 이 판에서 고친 코드도 MIT.
- 원본 지도·데이터: TarkovData(TarkovTracker), TarkovDev(MIT ©2019 Oskar Risberg), Shebuka 지도 그림(CC BY-NC-SA 4.0) — [`map_and_data_credits.txt`](Plugin/Resources/Maps/map_and_data_credits.txt)와 각 지도 폴더의 LICENSE.
- 마커 아이콘: [`marker_credits.txt`](Plugin/Resources/Markers/marker_credits.txt) (BTR 아이콘 Kuromi).
- 이 판에서 새로 만든 지도 그림(터미널·인터체인지 리워크·등대 리워크)은 설치된 게임 지형에서 직접 만든 것으로 CC BY-NC-SA 4.0 — 각 폴더의 `zzap-LICENSE.md`. 게임 자산의 권리는 원권리자에게 있습니다.
- 연구소 리워크는 원본 Labs 그림(Shebuka)의 2층만 고친 것으로 원본과 같은 CC BY-NC-SA 4.0. 공장 클래식은 원본 DynamicMaps의 공장 그림을 그대로 씁니다(원래 라이선스 그대로).

---

## English

An edited build of DynamicMaps for SPT 4.1 (the mod that turns the in-game map screen into a usable map).

- **New maps**: Terminal, Interchange rework, Lighthouse rework, Labs rework (office above the boiler room), Factory Classic, and Icebreaker. Labels, extracts, transits, locked doors and switches included.
- **Icebreaker**: shipped in the release zip only, not in this repository (map art by 파인애플애호가).
- **Original/rework map picked automatically**: when MapVariants or a Manimal backport runs the rework map for a raid, the rework map is shown; otherwise the original.
- **Korean**: F12 settings and map texts. F12 "Language" = Auto (follows the game language) / Korean / English.
- **Less minimap stutter**: no recalculation on the same floor, zoom saved once after you stop, markers drawn apart from the map image. New F12 minimap update interval.

### Install

- Extract `DynamicMaps-zzap--bootleg--v1.zip` from the release into your SPT folder and overwrite. Settings are kept.
- **Do not install together with DynamicMaps-Extended** (another edit of the same mod; they conflict).

### Credits / License

- Plugin code: [SPT-DynamicMaps](https://github.com/mpstark/SPT-DynamicMaps) by Michael P. Starkweather (mpstark), MIT ©2024 — [`Plugin/LICENSE`](Plugin/LICENSE). 1.2.x maintained by acidphantasm. Changes in this build are MIT as well.
- Original maps and data: TarkovData (TarkovTracker), TarkovDev (MIT ©2019 Oskar Risberg), Shebuka map art (CC BY-NC-SA 4.0) — [`map_and_data_credits.txt`](Plugin/Resources/Maps/map_and_data_credits.txt) and the LICENSE in each map folder.
- Marker icons: [`marker_credits.txt`](Plugin/Resources/Markers/marker_credits.txt) (BTR icon by Kuromi).
- New map art made for this build (Terminal, Interchange rework, Lighthouse rework) was drawn from the installed game's terrain, CC BY-NC-SA 4.0 — `zzap-LICENSE.md` in each folder. Game assets belong to their owners.
- Labs rework edits only the second floor of the original Shebuka Labs art, same CC BY-NC-SA 4.0. Factory Classic uses the original DynamicMaps Factory art as is (original license).
