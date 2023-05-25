using HarmonyLib;
using System.Collections;
using System.Collections.Generic;

namespace FanonEnding
{
    internal class EntranceEvent
    {
        [HarmonyPatch(typeof(Interactable))]
        public class PEPPO : CustomNPC
        {
            public const int PEPPO_ID = 46;
            static PEPPO instance = new PEPPO();
            List<GameMaster.Speech> Chatter = new List<GameMaster.Speech>();
            [HarmonyPrefix]
            [HarmonyPatch("Interact")]
            static bool Prefix(Interactable __instance)
            {
                if (GameMaster.GM.Save.Data.CurrentAct != SaveSystem.Act.Act2 && GameMaster.GM.Save.Data.CurrentAct != SaveSystem.Act.Act3) return true;
                SpecialGuest peppo_maybe = __instance.gameObject.GetComponent<SpecialGuest>();
                if (peppo_maybe == null || peppo_maybe.ID != PEPPO_ID) return true;
                while (GameMaster.GM.Save.Data.Quests.Count < 103) GameMaster.GM.Save.Data.Quests.Add(SaveSystem.Quest.INACTIVE);
                FanonEnding.StartCoroutine(instance.PeppoEvent(__instance));
                return false;
            }
            IEnumerator PeppoEvent(Interactable __instance)
            {
                if (GameMaster.GM.Save.Data.Quests.Count < 101) yield break;
                Chatter.Clear();
                GameMaster.GM.PC.Interacting = true;
                GameMaster.GM.Int = __instance;
                GameMaster.GM.PC.Lock();
                switch (GameMaster.GM.Save.Data.Quests[100])
                {
                    case SaveSystem.Quest.INACTIVE:
                        GameMaster.GM.Save.Data.Quests[100] = SaveSystem.Quest.STAGE0;
                        Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "AH," + GameMaster.GM.Save.Data.Name + ",*THERE YOU ARE.", "PEPPO"));
                        Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "A LITTLE BIRD TOLD*ME THAT YOU COULD*USE SOME HELP.", "PEPPO"));
                        Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "YOU KNOW,*WITH that.", "PEPPO"));
                        Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "THE ONLY THING YOU*NEED TO DO IS GET*THROUGH A DUNGEON.*YOU ARE, LIKE,*AN EXPERT AT THOSE*BY NOW, RIGHT?", "PEPPO"));
                        Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "I MADE IT*ALL BY MYSELF,*JUST FOR YOU.", "PEPPO"));
                        Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "SO,*WHAT DO YOU SAY?", "PEPPO"));
                        Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "SHOULD WE*GET STARTED?", "PEPPO"));
                        GameMaster.GM.UI.InitiateChat(Chatter, true);
                        FanonEnding.StartCoroutine(GetAnswer());
                        while (ReplyCatcher.waiting) yield return null;
                        Chatter.Clear();
                        if (ReplyCatcher.reply)
                        {
                            GameMaster.GM.Save.Data.Quests[100] = SaveSystem.Quest.STAGE1;
                            Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "LET'S GO!", "PEPPO"));
                            GameMaster.GM.UI.InitiateChat(Chatter, false);
                            FanonEnding.StartCoroutine(Dungeon.BuildDungeon());
                        }
                        else
                        {
                            Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "DO YOU NEED*SOME TIME TO*PREPARE?", "PEPPO"));
                            Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "I'LL BE WAITING*RIGHT HERE.", "PEPPO"));
                            GameMaster.GM.UI.InitiateChat(Chatter, false);
                        }
                        break;
                    case SaveSystem.Quest.STAGE0:
                        Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "CHANGED YOUR MIND?", "PEPPO"));
                        GameMaster.GM.UI.InitiateChat(Chatter, true);
                        FanonEnding.StartCoroutine(GetAnswer());
                        while (ReplyCatcher.waiting) yield return null;
                        Chatter.Clear();
                        if (ReplyCatcher.reply)
                        {
                            GameMaster.GM.Save.Data.Quests[100] = SaveSystem.Quest.STAGE1;
                            Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "LET'S GO!", "PEPPO"));
                            GameMaster.GM.UI.InitiateChat(Chatter, false);
                            FanonEnding.StartCoroutine(Dungeon.BuildDungeon());
                        }
                        else
                        {
                            Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "WELL,*TAKE AS LONG*AS YOU NEED.", "PEPPO"));
                            Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "I'LL BE WAITING*RIGHT HERE.", "PEPPO"));
                            GameMaster.GM.UI.InitiateChat(Chatter, false);
                        }
                        break;
                    case SaveSystem.Quest.STAGE1:
                        GameMaster.GM.Save.Data.Quests[100] = SaveSystem.Quest.STAGE2;
                        Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "WAIT,*WHEN DID YOU*GET OUT?", "PEPPO"));
                        Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "WERE YOU PECKISH*OR SOMETHING?", "PEPPO"));
                        Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "ANYWAY,*ARE YOU GOING*BACK IN?", "PEPPO"));
                        GameMaster.GM.UI.InitiateChat(Chatter, true);
                        FanonEnding.StartCoroutine(GetAnswer());
                        while (ReplyCatcher.waiting) yield return null;
                        Chatter.Clear();
                        if (ReplyCatcher.reply)
                        {
                            Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "LET'S GO!", "PEPPO"));
                            GameMaster.GM.UI.InitiateChat(Chatter, false);
                            FanonEnding.StartCoroutine(Dungeon.BuildDungeon());
                        }
                        else
                        {
                            Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "WELL,*TAKE AS LONG*AS YOU NEED.", "PEPPO"));
                            Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "I'LL BE WAITING*RIGHT HERE.", "PEPPO"));
                            GameMaster.GM.UI.InitiateChat(Chatter, false);
                        }
                        break;
                    case SaveSystem.Quest.STAGE2:
                        Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "ARE YOU GOING*BACK IN?", "PEPPO"));
                        GameMaster.GM.UI.InitiateChat(Chatter, true);
                        FanonEnding.StartCoroutine(GetAnswer());
                        while (ReplyCatcher.waiting) yield return null;
                        Chatter.Clear();
                        if (ReplyCatcher.reply)
                        {
                            Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "LET'S GO!", "PEPPO"));
                            GameMaster.GM.UI.InitiateChat(Chatter, false);
                            FanonEnding.StartCoroutine(Dungeon.BuildDungeon());
                        }
                        else
                        {
                            Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "WELL,*TAKE AS LONG*AS YOU NEED.", "PEPPO"));
                            Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "I'LL BE WAITING*RIGHT HERE.", "PEPPO"));
                            GameMaster.GM.UI.InitiateChat(Chatter, false);
                        }
                        break;
                    default:
                        Chatter.Add(GameMaster.CreateSpeech(PEPPO_ID, 0, "I STILL LOVE YOU.", "PEPPO"));
                        GameMaster.GM.UI.InitiateChat(Chatter, false);
                        break;
                }
                yield break;
            }
        }
    }
}
