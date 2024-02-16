using BepInEx;
using LethalLib.Modules;
using System.IO;
using System.Reflection;
using UnityEngine;


namespace DigiMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency(LethalLib.Plugin.ModGUID)] 
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            int iRarity = 45;
            string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "digimod.asset");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);

            Item digiRouter = bundle.LoadAsset<Item>("Assets/router.asset");
            NetworkPrefabs.RegisterNetworkPrefab(digiRouter.spawnPrefab);
            Utilities.FixMixerGroups(digiRouter.spawnPrefab);
            Items.RegisterScrap(digiRouter, iRarity, Levels.LevelTypes.All);

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
