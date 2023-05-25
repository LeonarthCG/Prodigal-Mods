using UnityEngine;
using MelonLoader;
using HarmonyLib;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Reflection;

[assembly: MelonInfo(typeof(FanonEnding.FanonEnding), "FanonEnding", "1.0.0", "LeonarthCG")]
[assembly: MelonGame("Colorgrave", "Prodigal")]

namespace FanonEnding
{
    public class FanonEnding : MelonMod
    {
        static MonoBehaviour reference = null;
        public static List<Sprite> new_sprites = new List<Sprite>();
        public static bool got_assets = false;
        public static AssetBundle spriteBundle;
        public static AssetBundle dungeonBundle;
        static IEnumerator GetAssets()
        {
            got_assets = true;
            var assembly = Assembly.GetExecutingAssembly();
            byte[] bytes;
            using (Stream stream = assembly.GetManifestResourceStream("FanonEnding.sprites"))
            {
                bytes = new byte[stream.Length];
                using (MemoryStream ms = new MemoryStream())
                {
                    for (int i = 0; i < bytes.Length; i++) bytes[i] = (byte)stream.ReadByte();
                }
            }
            AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(bytes);
            yield return request;
            spriteBundle = request.assetBundle;
            Texture2D texture = spriteBundle.LoadAsset<Texture2D>(@"assets/sprite/texture.png");
            Vector2 pivot = new Vector2(0.5f, 0.5f);
            // 0 - Title Card
            new_sprites.Add(Sprite.Create(
                texture,
                new Rect(
                    0, 0,
                    148, 28
                ),
                pivot,
                1
                )
            );
            // 1 - Pepppo Mask
            new_sprites.Add(Sprite.Create(
                texture,
                new Rect(
                    160, 0,
                    32, 32
                ),
                pivot,
                1
                )
            );
            using (Stream stream = assembly.GetManifestResourceStream("FanonEnding.dungeon"))
            {
                bytes = new byte[stream.Length];
                using (MemoryStream ms = new MemoryStream())
                {
                    for (int i = 0; i < bytes.Length; i++) bytes[i] = (byte)stream.ReadByte();
                }
            }
            request = AssetBundle.LoadFromMemoryAsync(bytes);
            yield return request;
            dungeonBundle = request.assetBundle;
        }
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (got_assets) return;
            StartCoroutine(GetAssets());
        }
        public static MonoBehaviour GetReference()
        {
            if (reference != null) return reference;
            reference = GameObject.Find("GameMaster").GetComponent<GameMaster>();
            return reference;

        }
        public static void StartCoroutine(IEnumerator routine)
        {
            GetReference().StartCoroutine(routine);
        }
    }
    [HarmonyPatch(typeof(BGMControl))]
    public class MusicPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("CROSSFADE")]
        [HarmonyPatch("FORCEID")]
        [HarmonyPatch("ForceInto")]
        [HarmonyPatch("Transition")]
        static void PrefixForceMusic(ref int ID)
        {
            if (GameMaster.GM.Save.Data.Quests.Count < 101) return;
            if (GameMaster.GM.Save.Data.Quests[100] < SaveSystem.Quest.QUESTCOMPLETE) return;
            ID = 18;
        }
        [HarmonyPrefix]
        [HarmonyPatch("Pause")]
        [HarmonyPatch("Unpause")]
        [HarmonyPatch("Interrupt")]
        [HarmonyPatch("Uninterrupt")]
        static bool PrefixStopStop()
        {
            if (GameMaster.GM.Save.Data.Quests.Count < 101) return true;
            return GameMaster.GM.Save.Data.Quests[100] < SaveSystem.Quest.QUESTCOMPLETE;
        }
    }
    [HarmonyPatch(typeof(PlayerCharacter))]
    public class StarPower
    {
        static class CustomColorList
        {
            static int current_index = 0;
            static CustomColor[] color_list =
            {
                new CustomColor(
                    new Color32(215, 123, 186, byte.MaxValue),
                    new Color32(118, 66, 138, byte.MaxValue)
                ),
                new CustomColor(
                    new Color32(217, 87, 99, byte.MaxValue),
                    new Color32(172, 50, 50, byte.MaxValue)
                ),
                new CustomColor(
                    new Color32(251, 242, 54, byte.MaxValue),
                    new Color32(223, 113, 38, byte.MaxValue)
                ),
                new CustomColor(
                    new Color32(153, 229, 80, byte.MaxValue),
                    new Color32(106, 190, 48, byte.MaxValue)
                ),
                new CustomColor(
                    new Color32(95, 205, 228, byte.MaxValue),
                    new Color32(55, 148, 110, byte.MaxValue)
                ),
                new CustomColor(
                    new Color32(99, 155, 255, byte.MaxValue),
                    new Color32(91, 110, 225, byte.MaxValue)
                ),
                new CustomColor(
                    new Color32(91, 110, 225, byte.MaxValue),
                    new Color32(48, 96, 130, byte.MaxValue)
                ),
                new CustomColor(
                    new Color32(118, 66, 138, byte.MaxValue),
                    new Color32(63, 63, 116, byte.MaxValue)
                )
            };
            class CustomColor
            {
                public Color32 a1 { get; }
                public Color32 a2 { get; }
                public Color32 a3 { get; } = new Color32(54, 57, 67, byte.MaxValue);
                public CustomColor(Color32 a1, Color32 a2)
                {
                    this.a1 = a1;
                    this.a2 = a2;
                }
            }
            public static void Apply()
            {
                int next_index = (current_index + 1) % color_list.Length;
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_A1", color_list[current_index].a1);
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_A2", color_list[current_index].a2);
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_A3", color_list[current_index].a3);
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_A4", color_list[current_index].a3);
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_B1", color_list[current_index].a1);
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_B2", color_list[current_index].a2);
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_B3", color_list[current_index].a3);
                GameMaster.GM.COLOR.PLAYER.SetColor("_COLOR_B4", color_list[next_index].a1);
                current_index = next_index;
            }
        }
        static int frame = 0;
        static int rate = 2;
        [HarmonyPrefix]
        [HarmonyPatch("FixedUpdate")]
        static void Color()
        {
            if (GameMaster.GM.Save.Data.Quests.Count < 101) return;
            if (GameMaster.GM.Save.Data.Quests[100] < SaveSystem.Quest.QUESTCOMPLETE) return;
            if (frame % rate == 0) CustomColorList.Apply();
            frame = (frame + 1) % rate;
        }
        [HarmonyPrefix]
        [HarmonyPatch("FixedUpdate")]
        [HarmonyPatch("SwingPick")]
        static void Power(PlayerCharacter.MovementState ___PlayerState, ref int ___Charge)
        {
            if (GameMaster.GM.Save.Data.Quests.Count < 101) return;
            if (GameMaster.GM.Save.Data.Quests[100] < SaveSystem.Quest.QUESTCOMPLETE) return;
            switch (___PlayerState)
            {
                case PlayerCharacter.MovementState.Acting:
                    ___Charge = 999;
                    break;
                case PlayerCharacter.MovementState.PunchCharge:
                    if (___Charge >= 10) ___Charge = 999;
                    break;
            }
        }
    }
    [HarmonyPatch(typeof(TITLE_CONTROL))]
    public class CustomTitle
    {
        [HarmonyPrefix]
        [HarmonyPatch("LOAD_TITLE")]
        static void Prefix(ref int ID, out int __state)
        {
            __state = ID;
            if (__state == -1) ID = 0;
        }
        [HarmonyPostfix]
        [HarmonyPatch("LOAD_TITLE")]
        static void Postfix(SpriteRenderer ___TITLE, ref int __state)
        {
            if (__state != -1) return;
            ___TITLE.sprite = FanonEnding.new_sprites[0];
        }
    }
    [HarmonyPatch(typeof(GameMaster))]
    public class ReplyCatcher
    {
        public static bool waiting;
        public static bool reply;
        [HarmonyPrefix]
        [HarmonyPatch("SystemConfirm")]
        static void ConfirmPrefix(bool Yes)
        {
            reply = Yes;
            waiting = false;
        }
        [HarmonyPrefix]
        [HarmonyPatch("LoadFade")]
        static void LevelPrefix(ref int ___CurrentScene)
        {
            if (!Dungeon.loading_dungeon) return;
            ___CurrentScene = -1;
            Dungeon.loading_dungeon = false;
        }
    }
    public class CustomNPC : MonoBehaviour
    {
        public IEnumerator GetAnswer()
        {
            ReplyCatcher.waiting = true;
            while (ReplyCatcher.waiting) yield return null;
            yield break;
        }
    }
}
