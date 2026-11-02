using BepInEx;
using BepInEx.Logging;
using Comfort.Common;
using DrakiaXYZ.VersionChecker;
using DynamicMaps.Config;
using DynamicMaps.Patches;
using DynamicMaps.UI;
using DynamicMaps.Utils;
using EFT;
using EFT.UI;
using EFT.UI.Map;
using SPT.Custom.Utils;
using System;
using System.Diagnostics;
using System.Reflection;

namespace DynamicMaps
{
    // the version number here is generated on build and may have a warning if not yet built
    // zzap: the name carries the release (BepInEx needs a numeric version; 1.2.2 also keeps the Korean addon's 1.2.1 hooks off)
    [BepInPlugin("com.mpstark.dynamicmaps", "DynamicMaps zzap-bootleg- v1", BuildInfo.Version)]
    [BepInDependency("com.SPT.custom", "4.1.0")]
    [BepInDependency("com.SamSWAT.HeliCrash.ArysReloaded", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("com.fika.core", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("com.fika.headless", BepInDependency.DependencyFlags.SoftDependency)]
    public class Plugin : BaseUnityPlugin
    {
        public const int TarkovVersion = 40743;
        public static Plugin Instance;
        public static ManualLogSource Log => Instance.Logger;
        public static string Path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public ModdedMapScreen Map;

        internal void Awake()
        {
            if (!VersionChecker.CheckEftVersion(Logger, Info, Config))
            {
                throw new Exception("Invalid EFT Version");
            }

            Instance = this;

            ExternalModSupport.ModDetection.CheckforMods();

            Settings.Init(Config);
            Config.SettingChanged += (x, y) =>
            {
                // zzap: zoom values change every frame while zooming, they don't need a full config re-read
                if (y.ChangedSetting == Settings.ZoomMainMap || y.ChangedSetting == Settings.ZoomMiniMap)
                {
                    return;
                }

                Map?.ReadConfig();
            };

            // Logger.LogWarning("TEST BUILD OF DYNAMIC MAPS, NO SUPPORT OFFERED.");

            // patches
            new BattleUIScreenShowPatch().Enable();
            new CommonUIAwakePatch().Enable();
            new MapScreenShowPatch().Enable();
            new MapScreenClosePatch().Enable();
            new GameStartedPatch().Enable();
            new GameWorldOnDestroyPatch().Enable();
            new GameWorldUnregisterPlayerPatch().Enable();
            new LootItemInitPatch().Enable();
            new GameWorldDestroyLootPatch().Enable();
            new AirdropBoxOnBoxLandPatch().Enable();
            new PlayerOnDeadPatch().Enable();
            new PlayerInventoryThrowItemPatch().Enable();
            new ShowViewButtonPatch().Enable();
            new MenuLoadPatch().Enable();
        }

        /// <summary>
        /// Attach to the map screen
        /// </summary>
        internal void TryAttachToMapScreen(MapScreen mapScreen)
        {
            if (Map is not null) return;
            
            Log.LogInfo("Trying to attach to MapScreen");

            // attach to common UI first to call awake and set things up, then attach to sleeping map screen
            Map = ModdedMapScreen.Create(Singleton<CommonUI>.Instance.gameObject);
            Map.transform.SetParent(mapScreen.transform);
        }

        /// <summary>
        /// Attach the peek component
        /// </summary>
        internal void TryAttachToBattleUIScreen(EftBattleUIScreen battleUI)
        {
            if (Map is null || GameUtils.GetMainPlayer() is HideoutPlayer)
            {
                return;
            }
            
            Map.TryAddPeekComponent(battleUI);
        }

        // Check if the necessary type is available, and tell the user if they installed the mod wrong
        static Plugin()
        {
            if (Type.GetType("Unity.VectorGraphics.SVGParser, Unity.VectorGraphics") == null)
            {
                MessageBoxHelper.Show("You have incorrectly installed Dynamic Maps.\nPlease reinstall correctly.\nQuitting.", "DynamicMaps Error", MessageBoxHelper.MessageBoxType.OK);
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
