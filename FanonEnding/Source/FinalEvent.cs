using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

using MelonLoader;
using UnityEngine.Experimental.Playables;
using System.Security.Policy;

namespace FanonEnding
{
    internal class FinalEvent
    {
        [HarmonyPatch(typeof(FinalBoss))]
        public class Cutscene
        {
            static Cutscene instance = new Cutscene();
            [HarmonyPrefix]
            [HarmonyPatch("AgroScene")]
            static bool Prefix(Interactable __instance)
            {
                if (GameMaster.GM.Save.Data.Quests.Count < 101 || GameMaster.GM.Save.Data.Quests[100] != SaveSystem.Quest.QUESTCOMPLETE) return true;
                FanonEnding.StartCoroutine(instance.Event());
                return false;
            }
            IEnumerator Event()
            {
                GameObject zolei = null;
                GameObject bolivar = null;
                GameObject big_bolivar = null;
                GameObject[] objects = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
                foreach (GameObject obj in objects)
                {
                    if (zolei == null && obj.GetComponent<Zolei>() != null)
                    {
                        zolei = new GameObject();
                        SpriteRenderer zolei_sprite = zolei.AddComponent<SpriteRenderer>();
                        Animator zolei_animation = zolei.AddComponent<Animator>();
                        zolei_sprite.sprite = obj.GetComponent<SpriteRenderer>().sprite;
                        zolei_sprite.sortingLayerName = "Interacts";
                        zolei_animation.runtimeAnimatorController = obj.GetComponent<Animator>().runtimeAnimatorController;
                        zolei_animation.SetTrigger("Form");
                        zolei.transform.position = new Vector3(2200f + 16f, -664f + 64f);
                    }
                    if (bolivar == null && obj.GetComponent<AfterImage>() != null)
                    {
                        bolivar = new GameObject();
                        SpriteRenderer bolivar_sprite = bolivar.AddComponent<SpriteRenderer>();
                        Animator bolivar_animation = bolivar.AddComponent<Animator>();
                        bolivar_sprite.sprite = obj.GetComponent<SpriteRenderer>().sprite;
                        bolivar_sprite.sortingLayerName = "Interacts";
                        bolivar_animation.runtimeAnimatorController = obj.GetComponent<Animator>().runtimeAnimatorController;
                        bolivar_animation.SetTrigger("Form");
                        bolivar.transform.position = new Vector3(2200f + 32f, -664f + 16f);
                    }
                    if (big_bolivar == null && obj.GetComponent<TrueBoss>() != null)
                    {
                        big_bolivar = new GameObject();
                        while (obj.transform.childCount > 0)
                        {
                            Transform child = obj.transform.GetChild(0);
                            child.transform.position = child.transform.localPosition;
                            child.transform.parent = big_bolivar.transform;
                        }
                        big_bolivar.transform.position = new Vector3(1944f + 8f, -1984f - 16f);
                    }
                }
                UnityEngine.Object.DontDestroyOnLoad(zolei);
                UnityEngine.Object.DontDestroyOnLoad(bolivar);
                UnityEngine.Object.DontDestroyOnLoad(big_bolivar);

                GameMaster.GM.PC.Lock();
                List<GameMaster.Speech> Chatter = new List<GameMaster.Speech>();
                if (GameMaster.GM.Save.Data.Married && GameMaster.GM.Save.Data.Wife == NPC.Name.Stranger)
                {
                    Chatter.Add(GameMaster.CreateSpeech(46, 0, "CESA,*HOW ARE YOU*DOING TODAY?", "BOLIVAR"));
                    Chatter.Add(GameMaster.CreateSpeech(46, 0, "DID YOU NEED*SOMETHING?", "BOLIVAR"));
                    Chatter.Add(GameMaster.CreateSpeech(46, 0, "AH,*LET ME GUESS.", "BOLIVAR"));
                }
                else
                {
                    Chatter.Add(GameMaster.CreateSpeech(46, 0, ". . .", "BOLIVAR"));
                    Chatter.Add(GameMaster.CreateSpeech(46, 0, "CESA,*WHAT IS THIS?", "BOLIVAR"));
                    Chatter.Add(GameMaster.CreateSpeech(46, 0, "WHERE HAVE YOU. . .*HOW?", "BOLIVAR"));
                    Chatter.Add(GameMaster.CreateSpeech(46, 0, "THIS POWER. . .*THIS LIGHT. . .", "BOLIVAR"));
                    Chatter.Add(GameMaster.CreateSpeech(46, 0, "LET'S GO,*CESA.", "BOLIVAR"));
                }
                GameMaster.GM.UI.InitiateChat(Chatter, false);
                while (GameMaster.GM.UI.Talking) yield return null;
                GameMaster.GM.CutsceneZoneLoad(2, new Vector3(2200f, -664f));
                yield return new WaitForSeconds(2f);
                GameMaster.GM.PC.Lock();

                Chatter.Clear();
                Chatter.Add(GameMaster.CreateSpeech(46, 0, ". . .", "ZOLEI"));
                GameMaster.GM.UI.InitiateChat(Chatter, false);
                while (GameMaster.GM.UI.Talking) yield return null;
                Chatter.Clear();
                Chatter.Add(GameMaster.CreateSpeech(46, 0, ". . .", GameMaster.GM.Save.Data.Name));
                GameMaster.GM.UI.InitiateChat(Chatter, false);
                while (GameMaster.GM.UI.Talking) yield return null;
                Chatter.Clear();
                Chatter.Add(GameMaster.CreateSpeech(46, 0, ". . .", "ZOLEI"));
                GameMaster.GM.UI.InitiateChat(Chatter, false);
                while (GameMaster.GM.UI.Talking) yield return null;
                Chatter.Clear();
                if (GameMaster.GM.Save.Data.Married && GameMaster.GM.Save.Data.Wife == NPC.Name.Stranger)
                {
                    Chatter.Add(GameMaster.CreateSpeech(46, 0, "I DO.*. . .*AGAIN?", "BOLIVAR"));
                }
                else Chatter.Add(GameMaster.CreateSpeech(46, 0, "I DO.", "BOLIVAR"));
                GameMaster.GM.UI.InitiateChat(Chatter, false);
                while (GameMaster.GM.UI.Talking) yield return null;

                GameMaster.GM.CutsceneZoneLoad(2, new Vector3(1944f, -1984f));
                GameMaster.GM.PC.Hide(true);
                yield return new WaitForSeconds(1f);
                Chatter.Clear();
                if (GameMaster.GM.Save.Data.Married && GameMaster.GM.Save.Data.Wife == NPC.Name.Stranger)
                {
                    Chatter.Add(GameMaster.CreateSpeech(46, 0, "JUST HAD TO MARRY*ME AGAIN,*CESA?", "BOLIVAR"));
                    Chatter.Add(GameMaster.CreateSpeech(46, 0, "I GUESS YOU LIKED*THIS CUTSCENE*THAT MUCH.", "BOLIVAR"));
                }
                else
                {
                    Chatter.Add(GameMaster.CreateSpeech(46, 0, "CESA,*NOT IN MY WILDEST*DREAMS COULD I HAVE*IMAGINED THAT THIS*WOULD HAPPEN.", "BOLIVAR"));
                    Chatter.Add(GameMaster.CreateSpeech(46, 0, "TOGETHER WE MAY YET*BRING SOME SENSE*INTO THIS WORLD.", "BOLIVAR"));
                }
                GameMaster.GM.UI.InitiateChat(Chatter, false);
                while (GameMaster.GM.UI.Talking) yield return null;
                yield return new WaitForSeconds(3f);

                GameMaster.GM.Save.Data.Married = true;
                GameMaster.GM.Save.Data.Relationships[11].Stage = SaveSystem.NPCData.Stages.MARRIED;
                GameMaster.GM.Save.Data.Wife = NPC.Name.Stranger;

                GameMaster.GM.NewDay();
                GameMaster.GM.CutsceneZoneLoad(2, new Vector3(848f, -830f, 0f));
                yield return new WaitForSeconds(1f);
                GameMaster.GM.PC.Hide(false);
                GameMaster.GM.CutsceneOver();

                UnityEngine.Object.Destroy(zolei);
                UnityEngine.Object.Destroy(bolivar);
                UnityEngine.Object.Destroy(big_bolivar);
                yield break;
            }
        }

        static bool load_game = true;
        [HarmonyPatch(typeof(SaveButton))]
        public class NewWife
        {
            [HarmonyPostfix]
            [HarmonyPatch("Setup")]
            static void Postfix(SaveButton __instance, String ___ID)
            {
                load_game = false;
                switch (___ID)
                {
                    case "1":
                        GameMaster.GM.Save.Load(SaveSystem.Slot.Slot1);
                        break;
                    case "2":
                        GameMaster.GM.Save.Load(SaveSystem.Slot.Slot2);
                        break;
                    case "3":
                        GameMaster.GM.Save.Load(SaveSystem.Slot.Slot3);
                        break;
                }
                if (GameMaster.GM.Save.Data.Married && GameMaster.GM.Save.Data.Wife == NPC.Name.Stranger)
                {

                    GameObject[] objects = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
                    foreach (GameObject obj in objects)
                    {
                        if (obj.GetComponent<Bolivar>() != null)
                        {
                            __instance.Icons[0].gameObject.GetComponent<SpriteRenderer>().sprite = obj.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
                            break;
                        }
                    }
                }
                load_game = true;
            }
        }
        [HarmonyPatch(typeof(GameMaster))]
        public class LoadPrevention
        {
            [HarmonyPrefix]
            [HarmonyPatch("LoadIntoGame")]
            static bool Prefix() {
                return load_game;
            }
        }
    }
}
