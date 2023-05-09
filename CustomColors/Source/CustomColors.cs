using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using MelonLoader;
using HarmonyLib;
using Newtonsoft.Json;

[assembly: MelonInfo(typeof(CustomColors.CustomColors), "CustomColors", "1.0.0", "LeonarthCG")]
[assembly: MelonGame("Colorgrave", "Prodigal")]

namespace CustomColors
{
    public class CustomColors : MelonMod
    {
        public static CustomColorList custom_colors;
        public static bool urn_message = false;
        public class CustomColorList
        {
            public CustomColor[] color_list { get; set; }
            public int current_index = 0;
            public int last_index_applied = -1;
            public class CustomColor
            {
                public string name { get; set; }
                public Color32 a1 { get; set; }
                public Color32 a2 { get; set; }
                public Color32 a3 { get; set; }
                public Color32 a4 { get; set; }
                public Color32 b1 { get; set; }
                public Color32 b2 { get; set; }
                public Color32 b3 { get; set; }
                public Color32 b4 { get; set; }
            }
            public void Apply()
            {
                if (color_list.Length == 0) { return; }
                if (last_index_applied == current_index) { return; }
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_A1", color_list[current_index].a1);
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_A2", color_list[current_index].a2);
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_A3", color_list[current_index].a3);
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_A4", color_list[current_index].a4);
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_B1", color_list[current_index].b1);
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_B2", color_list[current_index].b2);
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_B3", color_list[current_index].b3);
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_B4", color_list[current_index].b4);
                last_index_applied = current_index;
                Melon<CustomColors>.Logger.Msg("New palette applied: " + color_list[current_index].name);
            }
            public void Previous()
            {
                --current_index;
                if (current_index < 0) current_index = color_list.Length - 1;
                Apply();
            }
            public void Next()
            {
                ++current_index;
                if (current_index >= color_list.Length) current_index = 0;
                Apply();
            }
        }
        public override void OnInitializeMelon()
        {
            using (Stream stream = File.OpenRead(@".\Mods\CustomColors.json"))
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                custom_colors = JsonConvert.DeserializeObject<CustomColorList>(json);
                switch (custom_colors.color_list.Length)
                {
                    case 0:
                        Melon<CustomColors>.Logger.Msg("No custom player palettes loaded, no palette will be applied");
                        break;
                    case 1:
                        Melon<CustomColors>.Logger.Msg("Loaded 1 custom player palette");
                        break;
                    default:
                        Melon<CustomColors>.Logger.Msg("Loaded " + custom_colors.color_list.Length + " custom player palettes");
                        Melon<CustomColors>.Logger.Msg("You can swap between palettes using the PageUp and PageDown buttons");
                        break;
                }
            }
        }
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            custom_colors.Apply();
            urn_message = false;
        }
        public override void OnLateUpdate()
        {
            if (Keyboard.current[Key.PageDown].wasPressedThisFrame)
            {
                custom_colors.Previous();
            }
            if (Keyboard.current[Key.PageUp].wasPressedThisFrame)
            {
                custom_colors.Next();
            }
        }
    }
    [HarmonyPatch(typeof(COLOR_CONTROL))]
    class ColorPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("COLOR_CORRECT")]
        [HarmonyPatch("SET_PLAYER")]
        static bool Prefix()
        {
            return CustomColors.custom_colors.color_list.Length == 0;
        }
    }
    [HarmonyPatch(typeof(COLOR_JAR))]
    class JarPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("INTERACT")]
        static void Prefix(bool ___COLLECTED)
        {
            if (___COLLECTED && !CustomColors.urn_message)
            {
                Melon<CustomColors>.Logger.Msg("Sorry, if you want to use the urn colors you'll have to add them to the CustomColors.json file in your Mods folder or stop using this mod");
                CustomColors.urn_message = true;
            }
        }
    }
}
