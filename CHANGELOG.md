# Change Log

## [1.4.31] - 2024-04-25
### Added
- Support for 2D Asset Layer Assets
- GLB creation on asset creation.
### Changed
- Restricted access to config scriptable object (use project settings).
- Restricted access to variable of LoadCurrentSelection script.
- Added cache size setting to `AssetBundleCacheManager` to manage asset unloading and caching more effectively.
### Fixed
- Package conflict with different collection package versions (umul 128 error).
- Assets not loading upon reselection.

## [1.4.30] - 2024-03-28
### Changed
- Improved naming resolution and selection of required slot scripts.
- Updating your assets updates the slot scripts as well

## [1.4.29] - 2024-03-12
### Changed
- Inventory now preloads user ID to ensure last selected assets are unique to each account, preventing cross-account asset display.
- Fires an event upon account loading, sending the user ID to listeners.
- Inventory now sorts assets by updatedAt and auto selects the newest. 

## [1.4.28] - 2024-03-05
### Changed
- Switched to glTFast package for `.glb` file import to enhance performance and compatibility.
### Fixed
- Resolved issues with WebGL builds that affected game performance and stability.

## [1.4.27] - 2024-02-28
### Added
- Support for importing `.glb` files.
### Fixed
- Issues with using several `AssetLayerGameObjects` simultaneously.
- Added variable to `AssetBundleImporter` script to only load specific collection IDs.

## [1.4.26] - 2024-02-21
### Changed
- Removed `[InitializeOnLoad]` from `ScriptLoader` to stop automatic required slot script loading on Unity editor start.

## [1.4.25] - 2024-02-20
### Fixed
- Fixed CORS issue with game server.
- Fixed Null Exceptions of Inventory.
- Fixed Issues with Slots not showing up in Inventory in non-editor builds.

## [1.4.24] - 2024-02-18
### Fixed
- Fixed the slots without Unity expressions issue for newer versions of Unity.

## [1.4.23] - 2024-02-18
### Fixed
- Fixed the slots without Unity expressions issue.
