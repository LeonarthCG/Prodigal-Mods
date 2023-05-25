using System.Collections;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using System.Reflection;
using static FanonEnding.EntranceEvent;

namespace FanonEnding
{
    [HarmonyPatch(typeof(Biggun))]
    public class Biggerun
    {
        [HarmonyPrefix]
        [HarmonyPatch("OnEnable")]
        static void Prefix(Biggun __instance)
        {
            if (SceneManager.GetActiveScene().buildIndex == -1)
            {
                __instance.gameObject.transform.localScale = Vector2.one * 2;
                Enemy parent = __instance.gameObject.GetComponent<Enemy>();
                typeof(Enemy).GetField("HP", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(parent, 140);
            }
        }
    }
    internal static class Dungeon
    {
        public enum Destructables {
            AlchBomb,
            Barrel,
            Cannonball,
            KnuckleRock,
            MetalBarrel,
            MineRock,
            PinBlock,
            RockRoll,
            SteelBlock
        }
        public static GameObject GetDestructable(Destructables destructable)
        {
            return GetDestructable(destructable, Vector3.zero);
        }
        public static GameObject GetDestructable(Destructables destructable, Vector3 position)
        {
            string path = null;
            switch (destructable)
            {
                case Destructables.AlchBomb:
                    path = "Prefabs/Destructables/AlchBomb";
                    break;
                case Destructables.Barrel:
                    path = "Prefabs/Destructables/Barrel";
                    break;
                case Destructables.Cannonball:
                    path = "Prefabs/Destructables/Cannonball";
                    break;
                case Destructables.KnuckleRock:
                    path = "Prefabs/Destructables/KnuckleRock";
                    break;
                case Destructables.MetalBarrel:
                    path = "Prefabs/Destructables/MetalBarrel";
                    break;
                case Destructables.MineRock:
                    path = "Prefabs/Destructables/MineRock";
                    break;
                case Destructables.PinBlock:
                    path = "Prefabs/Destructables/PinBlock";
                    break;
                case Destructables.RockRoll:
                    path = "Prefabs/Destructables/RockRoll";
                    break;
                case Destructables.SteelBlock:
                    path = "Prefabs/Destructables/SteelBlock";
                    break;
            }
            if (path == null) return null;
            if (destructable == Destructables.Barrel)
            {

            } else if (destructable == Destructables.MetalBarrel)
            {

            }
            return Object.Instantiate<GameObject>(Resources.Load<GameObject>(path), position, new Quaternion());
        }
        public enum Interactats
        {
            BlockerDown,
            BlockerUp,
            BossDoor,
            Chest,
            EventLockBlock,
            FireAngler,
            Fireball,
            FireOrb,
            LadderDown,
            LadderUp,
            LariatHook,
            LockBlock,
            Pit,
            PuzzleWeightPlateSwitch,
            RiseFallPlatformActive,
            RiseFallPlatformInactive,
            Switch,
            Water,
            WeightPlateSwitch
        }
        public static GameObject GetInteract(Interactats interactat, Vector3 position)
        {
            string path = null;
            switch (interactat)
            {
                case Interactats.BlockerDown:
                    path = "Prefabs/Interacts/BlockerDown";
                    break;
                case Interactats.BlockerUp:
                    path = "Prefabs/Interacts/BlockerUp";
                    break;
                case Interactats.BossDoor:
                    path = "Prefabs/Interacts/BossDoor";
                    break;
                case Interactats.Chest:
                    path = "Prefabs/Interacts/Chest";
                    break;
                case Interactats.EventLockBlock:
                    path = "Prefabs/Interacts/EventLockBlock";
                    break;
                case Interactats.FireAngler:
                    path = "Prefabs/Interacts/FireAngler";
                    break;
                case Interactats.Fireball:
                    path = "Prefabs/Interacts/Fireball";
                    break;
                case Interactats.FireOrb:
                    path = "Prefabs/Interacts/FireOrb";
                    break;
                case Interactats.LadderDown:
                    path = "Prefabs/Interacts/LadderDown";
                    break;
                case Interactats.LadderUp:
                    path = "Prefabs/Interacts/LadderUp";
                    break;
                case Interactats.LariatHook:
                    path = "Prefabs/Interacts/LariatHook";
                    break;
                case Interactats.LockBlock:
                    path = "Prefabs/Interacts/LockBlock";
                    break;
                case Interactats.Pit:
                    path = "Prefabs/Interacts/Pit";
                    break;
                case Interactats.RiseFallPlatformActive:
                    path = "Prefabs/Interacts/RiseFallPlatformActive";
                    break;
                case Interactats.RiseFallPlatformInactive:
                    path = "Prefabs/Interacts/RiseFallPlatformInactive";
                    break;
                case Interactats.Switch:
                    path = "Prefabs/Interacts/Switch";
                    break;
                case Interactats.Water:
                    path = "Prefabs/Interacts/Water";
                    break;
                case Interactats.PuzzleWeightPlateSwitch:
                    path = "Prefabs/Interacts/PuzzleWeightPlateSwitch";
                    break;
                case Interactats.WeightPlateSwitch:
                    path = "Prefabs/Interacts/WeightPlateSwitch";
                    break;
            }
            if (path == null) return null;
            return Object.Instantiate<GameObject>(Resources.Load<GameObject>(path), position, new Quaternion());
        }
        public enum Enemies
        {
            Biggun,
            BoomerangGrelin,
            EvilMask,
            Imp,
            Liche,
            SkeleWarr
        }
        public static GameObject GetEnemy(Enemies enemy, Vector3 position)
        {
            string path = null;
            switch (enemy)
            {
                case Enemies.Biggun:
                    path = "Prefabs/Enemies/Biggun";
                    break;
                case Enemies.BoomerangGrelin:
                    path = "Prefabs/Enemies/BoomerangGrelin";
                    break;
                case Enemies.EvilMask:
                    path = "Prefabs/Enemies/EvilMask";
                    break;
                case Enemies.Imp:
                    path = "Prefabs/Enemies/Imp";
                    break;
                case Enemies.Liche:
                    path = "Prefabs/Enemies/Liche";
                    break;
                case Enemies.SkeleWarr:
                    path = "Prefabs/Enemies/SkeleWarr";
                    break;
            }
            if (path == null) return null;
            return Object.Instantiate<GameObject>(Resources.Load<GameObject>(path), position, new Quaternion());
        }
        static float room_width = 160f;
        static float room_height = 144f;
        static float start_x = 4.5f * room_width - 8;
        static float start_y = -5.5f * room_height;
        public static bool loading_dungeon = false;
        public static IEnumerator BuildDungeon()
        {
            while (GameMaster.GM.UI.Talking)
            {
                yield return null;
            }
            GameMaster.GM.LoadSFX(65);
            loading_dungeon = true;
            GameMaster.GM.FakeZoneLoad(new Vector2(start_x, start_y));
            GameMaster.GM.UI.TITLES.LOAD_TITLE(-1);
            yield return new WaitForSeconds(1f);
            AsyncOperation ALoad = SceneManager.LoadSceneAsync("Assets/Scenes/Grid.unity");
            while (!ALoad.isDone) yield return null;
            GameMaster.GM.PC.AnimDirection(PlayerCharacter.Direction.Down);

            MakePits();
            MakeWater();

            GameObject rooms = new GameObject("Rooms");
            rooms.transform.position = new Vector3(-8, 8, 0);

            GameObject container = new GameObject();
            container.SetActive(false);

            GameObject blocker1 = GetInteract(Interactats.EventLockBlock, TileToPosition(4, 3, y_offset: 8));
            AddParent(container, blocker1);
            GameObject blocker2 = GetInteract(Interactats.EventLockBlock, TileToPosition(5, 3, y_offset: 8));
            AddParent(container, blocker2);
            GameObject puzzle = new GameObject();
            BuildPuzzle(
                puzzle,
                1,
                blockers: new List<EventBlocker>() {
                    blocker1.GetComponent<EventBlocker>(),
                    blocker2.GetComponent<EventBlocker>()
                }
            );
            AddParent(container, puzzle);
            blocker1 = GetInteract(Interactats.EventLockBlock, TileToPosition(4, 2, y_offset: 8));
            AddParent(container, blocker1);
            blocker2 = GetInteract(Interactats.EventLockBlock, TileToPosition(5, 2, y_offset: 8));
            AddParent(container, blocker2);
            puzzle = new GameObject();
            BuildPuzzle(
                puzzle,
                4,
                blockers: new List<EventBlocker>() {
                    blocker1.GetComponent<EventBlocker>(),
                    blocker2.GetComponent<EventBlocker>()
                }
            );
            AddParent(container, puzzle);
            blocker1 = GetInteract(Interactats.EventLockBlock, TileToPosition(4, 1, y_offset: 8));
            AddParent(container, blocker1);
            blocker2 = GetInteract(Interactats.EventLockBlock, TileToPosition(5, 1, y_offset: 8));
            AddParent(container, blocker2);
            puzzle = new GameObject();
            BuildPuzzle(
                puzzle,
                5,
                blockers: new List<EventBlocker>() {
                    blocker1.GetComponent<EventBlocker>(),
                    blocker2.GetComponent<EventBlocker>()
                }
            );
            AddParent(container, puzzle);
            MakeRoom(rooms, 4, 5, children: container);

            container = new GameObject();
            container.SetActive(false);
            AddParent(container, MakeLock(0, 7, 2));
            AddParent(container, MakeLock(1, 2, 4));
            AddParent(container, MakeLock(2, 7, 6));
            MakeRoom(rooms, 4, 4, children: container);

            container = new GameObject();
            container.SetActive(false);
            GameObject boss = GetEnemy(Enemies.Biggun, TileToPosition(9, 9));
            GameObject mask_object = new GameObject();
            SpriteRenderer mask = mask_object.AddComponent<SpriteRenderer>();
            mask.sprite = FanonEnding.new_sprites[1];
            mask.sortingLayerName = "Interacts";
            mask.sortingOrder = 1;
            AddParent(boss, mask_object);
            mask.transform.localPosition = new Vector2(0, 16);
            mask_object.transform.localScale = Vector2.one * 1;
            GameObject boss_event = new GameObject();
            boss_event.AddComponent<CustomBossEvent>();
            AddParent(boss_event, boss);
            AddParent(container, boss_event);
            MakeRoom(rooms, 4, 2.5f, width: 2, height: 2, children: container);

            MakeRoom(rooms, 4, 6);

            container = new GameObject();
            container.SetActive(false);
            GameObject switch1 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(12, 12));
            GameObject switch2 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(13, 12));
            GameObject switch3 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(16, 12));
            GameObject switch4 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(17, 12));
            GameObject switch5 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(12, 13));
            GameObject switch6 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(13, 13));
            GameObject switch7 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(14, 13));
            GameObject switch8 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(15, 13));
            GameObject switch9 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(16, 13));
            GameObject switch10 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(17, 13));
            GameObject switch11 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(12, 14));
            GameObject switch12 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(13, 14));
            GameObject switch13 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(14, 14));
            GameObject switch14 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(15, 14));
            GameObject switch15 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(16, 14));
            GameObject switch16 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(17, 14));
            GameObject switch17 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(13, 15));
            GameObject switch18 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(14, 15));
            GameObject switch19 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(15, 15));
            GameObject switch20 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(16, 15));
            puzzle = new GameObject();
            BuildPuzzle(
                puzzle,
                5,
                switches: new List<SwitchObject>() {
                    switch1.GetComponent<SwitchObject>(),
                    switch2.GetComponent<SwitchObject>(),
                    switch3.GetComponent<SwitchObject>(),
                    switch4.GetComponent<SwitchObject>(),
                    switch5.GetComponent<SwitchObject>(),
                    switch6.GetComponent<SwitchObject>(),
                    switch7.GetComponent<SwitchObject>(),
                    switch8.GetComponent<SwitchObject>(),
                    switch9.GetComponent<SwitchObject>(),
                    switch10.GetComponent<SwitchObject>(),
                    switch11.GetComponent<SwitchObject>(),
                    switch12.GetComponent<SwitchObject>(),
                    switch13.GetComponent<SwitchObject>(),
                    switch14.GetComponent<SwitchObject>(),
                    switch15.GetComponent<SwitchObject>(),
                    switch16.GetComponent<SwitchObject>(),
                    switch17.GetComponent<SwitchObject>(),
                    switch18.GetComponent<SwitchObject>(),
                    switch19.GetComponent<SwitchObject>(),
                    switch20.GetComponent<SwitchObject>()
                }
            );
            GameObject chest = GetInteract(Interactats.Chest, TileToPosition(14, 2, x_offset: 0, y_offset: -8));
            chest.GetComponent<Chest>().ID = 0x130000 + 2;
            chest.GetComponent<Chest>().Puzz = puzzle.GetComponent<Puzzle>();
            chest.GetComponent<Chest>().ChestState = Chest.Status.Hidden;
            chest.GetComponent<Loot>().ID = 39;
            AddParent(container, chest);
            puzzle.GetComponent<Puzzle>().Reward = chest.GetComponent<Chest>();
            AddParent(puzzle, switch1);
            AddParent(puzzle, switch2);
            AddParent(puzzle, switch3);
            AddParent(puzzle, switch4);
            AddParent(puzzle, switch5);
            AddParent(puzzle, switch6);
            AddParent(puzzle, switch7);
            AddParent(puzzle, switch8);
            AddParent(puzzle, switch9);
            AddParent(puzzle, switch10);
            AddParent(puzzle, switch11);
            AddParent(puzzle, switch12);
            AddParent(puzzle, switch13);
            AddParent(puzzle, switch14);
            AddParent(puzzle, switch15);
            AddParent(puzzle, switch16);
            AddParent(puzzle, switch17);
            AddParent(puzzle, switch18);
            AddParent(puzzle, switch19);
            AddParent(puzzle, switch20);
            AddParent(container, puzzle);

            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(12, 12)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(17, 12)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(13, 15)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(16, 15)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(14, 9)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(15, 9)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(13, 13)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(16, 13)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(14, 14)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(15, 14)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(6, 6)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(7, 7)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(4, 10)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(4, 11)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(23, 6)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(22, 7)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(25, 10)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(25, 11)));

            AddParent(container, GetDestructable(Destructables.Cannonball, TileToPosition(7, 9)));
            AddParent(container, GetDestructable(Destructables.Cannonball, TileToPosition(7, 10)));
            AddParent(container, GetDestructable(Destructables.Cannonball, TileToPosition(7, 14)));
            AddParent(container, GetDestructable(Destructables.Cannonball, TileToPosition(9, 15)));

            AddParent(container, GetDestructable(Destructables.Cannonball, TileToPosition(22, 9)));
            AddParent(container, GetDestructable(Destructables.Cannonball, TileToPosition(22, 10)));
            AddParent(container, GetDestructable(Destructables.Cannonball, TileToPosition(22, 14)));
            AddParent(container, GetDestructable(Destructables.Cannonball, TileToPosition(20, 15)));

            MakeRoom(rooms, 4, 7.5f, width: 3, height: 2, children: container);

            container = new GameObject();
            container.SetActive(false);
            GameObject ladder = GetInteract(Interactats.LadderDown, TileToPosition(18, 1));
            ladder.GetComponent<EntryExit>().ArrivalLocation = new Vector2(1248, -192);
            AddParent(container, ladder);
            AddParent(container, GetEnemy(Enemies.Liche, TileToPosition(2, 1)));
            AddParent(container, GetEnemy(Enemies.Liche, TileToPosition(4, 1)));
            AddParent(container, GetEnemy(Enemies.Liche, TileToPosition(6, 1)));
            AddParent(container, GetEnemy(Enemies.Liche, TileToPosition(8, 1)));
            AddParent(container, GetEnemy(Enemies.Liche, TileToPosition(10, 1)));
            AddParent(container, GetEnemy(Enemies.Liche, TileToPosition(2, 7)));
            AddParent(container, GetEnemy(Enemies.Liche, TileToPosition(4, 7)));
            AddParent(container, GetEnemy(Enemies.Liche, TileToPosition(6, 7)));
            AddParent(container, GetEnemy(Enemies.Liche, TileToPosition(8, 7)));
            AddParent(container, GetEnemy(Enemies.Liche, TileToPosition(10, 7)));
            MakeRoom(rooms, 5.5f, 5, width: 2, children: container);

            container = new GameObject();
            container.SetActive(false);
            ladder = GetInteract(Interactats.LadderUp, TileToPosition(18, 2));
            ladder.GetComponent<EntryExit>().ArrivalLocation = new Vector2(1088, -752);
            AddParent(container, ladder);
            switch1 = new GameObject();
            AddParent(switch1, GetEnemy(Enemies.BoomerangGrelin, TileToPosition(9, 6, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.BoomerangGrelin, TileToPosition(25, 8, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.BoomerangGrelin, TileToPosition(11, 22, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.BoomerangGrelin, TileToPosition(5, 18, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.BoomerangGrelin, TileToPosition(4, 9, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.BoomerangGrelin, TileToPosition(4, 23, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.BoomerangGrelin, TileToPosition(12, 8, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.BoomerangGrelin, TileToPosition(7, 6, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.BoomerangGrelin, TileToPosition(11, 15, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.BoomerangGrelin, TileToPosition(22, 4, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.BoomerangGrelin, TileToPosition(26, 22, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.EvilMask, TileToPosition(12, 12, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.EvilMask, TileToPosition(13, 13, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.EvilMask, TileToPosition(14, 12, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.EvilMask, TileToPosition(22, 19, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.EvilMask, TileToPosition(23, 20, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.EvilMask, TileToPosition(23, 19, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.EvilMask, TileToPosition(11, 13, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.EvilMask, TileToPosition(17, 13, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.EvilMask, TileToPosition(12, 15, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.Imp, TileToPosition(5, 4, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.Imp, TileToPosition(2, 11, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.Imp, TileToPosition(2, 20, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.Imp, TileToPosition(5, 25, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.Imp, TileToPosition(18, 24, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.Imp, TileToPosition(30, 21, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.Imp, TileToPosition(28, 14, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.Imp, TileToPosition(27, 9, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.Liche, TileToPosition(9, 22, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.Liche, TileToPosition(18, 21, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.Liche, TileToPosition(23, 24, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.Liche, TileToPosition(4, 23, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.Liche, TileToPosition(19, 19, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.Liche, TileToPosition(6, 21, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.SkeleWarr, TileToPosition(11, 8, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.SkeleWarr, TileToPosition(7, 16, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.SkeleWarr, TileToPosition(26, 6, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.SkeleWarr, TileToPosition(19, 16, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.SkeleWarr, TileToPosition(27, 19, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.SkeleWarr, TileToPosition(7, 11, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.SkeleWarr, TileToPosition(15, 18, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.SkeleWarr, TileToPosition(16, 3, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.SkeleWarr, TileToPosition(22, 3, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.SkeleWarr, TileToPosition(23, 12, x_offset: 0)));
            AddParent(switch1, GetEnemy(Enemies.SkeleWarr, TileToPosition(20, 10, x_offset: 0)));
            switch1.AddComponent<CustomChallenge>();
            puzzle = new GameObject();
            BuildPuzzle(
                puzzle,
                4
            );
            switch1.GetComponent<CustomChallenge>().puzzle = puzzle.GetComponent<Puzzle>();
            chest = GetInteract(Interactats.Chest, TileToPosition(16, 6, x_offset: 0, y_offset: -8));
            chest.GetComponent<Chest>().ID = 0x130000 + 1;
            chest.GetComponent<Chest>().Puzz = puzzle.GetComponent<Puzzle>();
                chest.GetComponent<Chest>().ChestState = Chest.Status.Hidden;
            chest.GetComponent<Loot>().ID = 39;
            AddParent(container, chest);
            puzzle.GetComponent<Puzzle>().Reward = chest.GetComponent<Chest>();
            AddParent(container, puzzle);
            AddParent(container, switch1);
            MakeRoom(rooms, 7, 2, width: 3, height: 3, children: container);

            container = new GameObject();
            container.SetActive(false);
            AddParent(container, GetDestructable(Destructables.Barrel, TileToPosition(1, 2)));
            AddParent(container, GetDestructable(Destructables.MetalBarrel, TileToPosition(7, 6)));
            AddParent(container, GetInteract(Interactats.LariatHook, TileToPosition(6, 3)));
            MakeRoom(rooms, 3, 5, children: container);

            container = new GameObject();
            container.SetActive(false);
            AddParent(container, GetDestructable(Destructables.Barrel, TileToPosition(7, 7)));
            blocker1 = GetInteract(Interactats.EventLockBlock, TileToPosition(5, 0, y_offset: 8));
            AddParent(container, blocker1);
            switch1 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(7, 1));
            switch2 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(3, 5));
            puzzle = new GameObject();
            BuildPuzzle(
                puzzle,
                0,
                blockers: new List<EventBlocker>() {
                    blocker1.GetComponent<EventBlocker>()
                },
                switches: new List<SwitchObject>() {
                    switch1.GetComponent<SwitchObject>(),
                    switch2.GetComponent<SwitchObject>()
                }
            );
            AddParent(container, puzzle);
            AddParent(puzzle, switch1);
            AddParent(puzzle, switch2);
            AddParent(container, GetInteract(Interactats.LariatHook, TileToPosition(8, 1)));
            AddParent(container, GetInteract(Interactats.LariatHook, TileToPosition(6, 5)));
            blocker1 = GetInteract(Interactats.EventLockBlock, TileToPosition(0, 4, y_offset: 8));
            AddParent(container, blocker1);
            puzzle = new GameObject();
            BuildPuzzle(
                puzzle,
                1,
                blockers: new List<EventBlocker>() {
                    blocker1.GetComponent<EventBlocker>()
                }
            );
            AddParent(container, puzzle);
            MakeRoom(rooms, 2, 5, children: container);
            
            container = new GameObject();
            container.SetActive(false);
            blocker1 = GetInteract(Interactats.EventLockBlock, TileToPosition(4, 0, y_offset: 8));
            AddParent(container, blocker1);
            switch1 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(4, 1));
            switch2 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(3, 2));
            switch3 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(2, 6));
            puzzle = new GameObject();
            BuildPuzzle(
                puzzle,
                2,
                blockers: new List<EventBlocker>() {
                    blocker1.GetComponent<EventBlocker>()
                },
                switches: new List<SwitchObject>() {
                    switch1.GetComponent<SwitchObject>(),
                    switch2.GetComponent<SwitchObject>(),
                    switch3.GetComponent<SwitchObject>()
                }
            );
            AddParent(container, puzzle);
            AddParent(puzzle, switch1);
            AddParent(puzzle, switch2);
            AddParent(puzzle, switch3);
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(2, 4)));
            MakeRoom(rooms, 2, 4, children: container);

            container = new GameObject();
            container.SetActive(false);
            blocker1 = GetInteract(Interactats.EventLockBlock, TileToPosition(4, 17, y_offset: 8));
            AddParent(container, blocker1);
            blocker2 = GetInteract(Interactats.EventLockBlock, TileToPosition(5, 17, y_offset: 8));
            AddParent(container, blocker2);
            puzzle = new GameObject();
            BuildPuzzle(
                puzzle,
                3,
                blockers: new List<EventBlocker>() {
                    blocker1.GetComponent<EventBlocker>(),
                    blocker2.GetComponent<EventBlocker>()
                }
            );
            GameObject fire_switch = GetInteract(Interactats.FireOrb, TileToPosition(2, 1));
            fire_switch.GetComponent<FireOrb>().Puzzle = puzzle.GetComponent<Puzzle>();
            AddParent(container, fire_switch);
            AddParent(container, puzzle);
            AddParent(container, GetDestructable(Destructables.MetalBarrel, TileToPosition(10, 8)));
            AddParent(container, GetInteract(Interactats.Fireball, TileToPosition(10, 12)));
            AddParent(container, GetInteract(Interactats.FireAngler, TileToPosition(5, 12)));
            AddParent(container, GetInteract(Interactats.FireAngler, TileToPosition(5, 14)));
            AddParent(container, GetInteract(Interactats.FireAngler, TileToPosition(16, 14)));
            AddParent(container, GetInteract(Interactats.FireAngler, TileToPosition(16, 3)));
            AddParent(container, GetInteract(Interactats.FireAngler, TileToPosition(5, 3)));
            AddParent(container, GetInteract(Interactats.FireAngler, TileToPosition(2, 12)));
            GameObject weight_switch = GetInteract(Interactats.WeightPlateSwitch, TileToPosition(9, 8));
            blocker1 = GetInteract(Interactats.BlockerDown, TileToPosition(10, 14, y_offset: 8));
            blocker2 = GetInteract(Interactats.BlockerUp, TileToPosition(10, 3, y_offset: 8));
            GameObject blocker3 = GetInteract(Interactats.BlockerDown, TileToPosition(2, 2, y_offset: 8));
            weight_switch.GetComponent<SwitchObject>().Partners = new List<GameObject> {
                blocker1,
                blocker2,
                blocker3
            };
            AddParent(container, weight_switch);
            AddParent(container, blocker1);
            AddParent(container, blocker2);
            AddParent(container, blocker3);
            MakeRoom(rooms, 1.5f, 2.5f, width: 2, height: 2, children: container);

            container = new GameObject();
            container.SetActive(false);
            blocker1 = GetInteract(Interactats.EventLockBlock, TileToPosition(9, 13, y_offset: 8));
            AddParent(container, blocker1);
            switch1 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(1, 1));
            switch2 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(1, 7));
            switch3 = GetInteract(Interactats.PuzzleWeightPlateSwitch, TileToPosition(1, 10));
            puzzle = new GameObject();
            BuildPuzzle(
                puzzle,
                1,
                blockers: new List<EventBlocker>() {
                    blocker1.GetComponent<EventBlocker>()
                },
                switches: new List<SwitchObject>() {
                    switch1.GetComponent<SwitchObject>(),
                    switch2.GetComponent<SwitchObject>(),
                    switch3.GetComponent<SwitchObject>()
                }
            );
            chest = GetInteract(Interactats.Chest, TileToPosition(4, 15, x_offset: 0, y_offset: -8));
            chest.GetComponent<Chest>().ID = 0x130000 + 0;
            chest.GetComponent<Chest>().Puzz = puzzle.GetComponent<Puzzle>();
            chest.GetComponent<Chest>().ChestState = Chest.Status.Hidden;
            chest.GetComponent<Loot>().ID = 39;
            AddParent(container, chest);
            puzzle.GetComponent<Puzzle>().Reward = chest.GetComponent<Chest>();
            AddParent(puzzle, switch1);
            AddParent(puzzle, switch2);
            AddParent(puzzle, switch3);
            AddParent(container, puzzle);
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(6, 1)));
            AddParent(container, GetDestructable(Destructables.RockRoll, TileToPosition(6, 7)));
            switch5 = GetInteract(Interactats.Switch, TileToPosition(8, 16));
            switch5.GetComponent<SwitchObject>().Type = SwitchObject.SType.RiseFall;
            GameObject platform1 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(1, 2));
            AddParent(container, platform1);
            GameObject platform2 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(2, 2));
            AddParent(container, platform2);
            GameObject platform3 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(7, 2));
            AddParent(container, platform3);
            GameObject platform4 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(8, 2));
            AddParent(container, platform4);
            GameObject platform5 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(1, 3));
            AddParent(container, platform5);
            GameObject platform6 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(2, 3));
            AddParent(container, platform6);
            GameObject platform7 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(7, 3));
            AddParent(container, platform7);
            GameObject platform8 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(8, 3));
            AddParent(container, platform8);
            GameObject platform9 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(1, 6));
            AddParent(container, platform9);
            GameObject platform10 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(2, 6));
            AddParent(container, platform10);
            GameObject platform11 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(7, 6));
            AddParent(container, platform11);
            GameObject platform12 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(8, 6));
            AddParent(container, platform12);
            GameObject platform13 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(1, 8));
            AddParent(container, platform13);
            GameObject platform14 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(2, 8));
            AddParent(container, platform14);
            GameObject platform15 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(7, 8));
            AddParent(container, platform15);
            GameObject platform16 = GetInteract(Interactats.RiseFallPlatformInactive, TileToPosition(8, 8));
            AddParent(container, platform16);
            switch5.GetComponent<SwitchObject>().Partners = new List<GameObject>() {
                platform1, platform2, platform3, platform4,
                platform5, platform6, platform7, platform8,
                platform9, platform10, platform11, platform12,
                platform13, platform14, platform15, platform16
            };
            AddParent(container, switch5);
            MakeRoom(rooms, 1, 4.5f, height: 2, children: container);
            yield break;
        }
        static GameObject MakeWalls(List<Vector3Int> positions)
        {
            GameObject walls = new GameObject("COLLISION");
            walls.tag = "Walls";
            walls.layer = LayerMask.NameToLayer("Walls");
            Tilemap tiles = walls.AddComponent<Tilemap>();
            walls.AddComponent<TilemapRenderer>();
            walls.AddComponent<TilemapCollider2D>();
            TileBase tile = TileBase.CreateInstance<TileBase>();
            foreach (Vector3Int v in positions) tiles.SetTile(v, tile);
            return walls;
        }
        static Vector3 TileToPosition(int x, int y, float x_offset = -8f, float y_offset = 0f)
        {
            return new Vector3(x * 16 + x_offset, (-y) * 16 + y_offset, 0f);
        }
        static void AddParent(GameObject parent, GameObject child)
        {
            child.transform.SetParent(parent.transform);
        }
        static GameObject MakeLock(int ID, int x, int y)
        {
            GameObject lock_block = GetInteract(Interactats.LockBlock, TileToPosition(x, y, y_offset: 8));
            lock_block.GetComponent<LockBlock>().ID = 0x130000 + ID;
            lock_block.GetComponent<BoxCollider2D>().enabled = true;
            return lock_block;
        }
        static void BuildPuzzle(GameObject puzzle_parent, int ID, List<EventBlocker> blockers = null, List<SwitchObject> switches = null)
        {
            puzzle_parent.layer = LayerMask.NameToLayer("Triggers");
            Puzzle puzzle = puzzle_parent.AddComponent<Puzzle>();
            puzzle.PuzzleID = 0x130000 + ID;
            if (blockers != null) puzzle.EBs = blockers;
            if (switches != null)
            {
                foreach (SwitchObject switch_object in switches) switch_object.enabled = true;
                puzzle.Switches = switches;
            }
        }
        static void MakeRoom(GameObject parent, float x, float y, int width = 1, int height = 1, int song = 8, GameObject children = null)
        {
            GameObject room = new GameObject();
            room.tag = "Room";
            room.layer = LayerMask.NameToLayer("Room");
            room.transform.position = new Vector3((x + 0.5f) * room_width - 8, (-y - 0.5f) * room_height + 8, 0);
            room.transform.localScale = new Vector3(room_width / 16f * width, room_height / 16f * height, 1);
            BoxCollider2D room_hitbox = room.AddComponent<BoxCollider2D>();
            room_hitbox.size = new Vector2(16, 16);
            Room room_script = room.AddComponent<Room>();
            room_script.RT = Room.RoomType.Dungeon;
            room_script.SongID = song;
            if (children != null)
            {
                children.transform.position += room.transform.position;
                children.transform.position -= new Vector3((width * room_width / 2f) - 16f, (height * -room_height / 2f) + 8f, 0f);
                room_script.RoomItems = children;
                AddParent(parent, children);
            }
            AddParent(parent, room);
        }
        static GameObject MakePits()
        {
            GameObject pits = new GameObject("Pits");
            pits.transform.position = new Vector3(-8, 8, 0);
            foreach (Vector2Int v in new List<Vector2Int> {
                new Vector2Int(13, 38),
                new Vector2Int(14, 38),
                new Vector2Int(15, 38),
                new Vector2Int(16, 38),
                new Vector2Int(13, 39),
                new Vector2Int(14, 39),
                new Vector2Int(15, 39),
                new Vector2Int(16, 39),
                new Vector2Int(13, 42),
                new Vector2Int(14, 42),
                new Vector2Int(15, 42),
                new Vector2Int(16, 42),
                new Vector2Int(13, 44),
                new Vector2Int(14, 44),
                new Vector2Int(15, 44),
                new Vector2Int(16, 44),
            }) AddParent(pits, GetInteract(Interactats.Pit, TileToPosition(v.x, v.y, x_offset: 0)));
            return pits;
        }
        static GameObject MakeWater()
        {
            GameObject water = new GameObject("Water");
            water.transform.position = new Vector3(-8, 8, 0);
            foreach (Vector2Int v in new List<Vector2Int> {
                new Vector2Int(20, 30),
                new Vector2Int(24, 38),
                new Vector2Int(25, 38),
                new Vector2Int(26, 38),
                new Vector2Int(23, 40),
                new Vector2Int(24, 40),
                new Vector2Int(26, 40),
                new Vector2Int(27, 40),
                new Vector2Int(21, 41),
                new Vector2Int(22, 41),
                new Vector2Int(27, 41),
                new Vector2Int(28, 41),
                new Vector2Int(21, 42),
                new Vector2Int(28, 42),
                new Vector2Int(21, 43),
                new Vector2Int(22, 43),
                new Vector2Int(27, 43),
                new Vector2Int(28, 43),
                new Vector2Int(22, 52),
                new Vector2Int(21, 46),
                new Vector2Int(22, 46),
                new Vector2Int(23, 46),
                new Vector2Int(24, 46),
                new Vector2Int(26, 46),
                new Vector2Int(21, 47),
                new Vector2Int(26, 47),
                new Vector2Int(27, 47),
                new Vector2Int(28, 47),
                new Vector2Int(26, 48),
                new Vector2Int(27, 48),
                new Vector2Int(28, 48),
                new Vector2Int(26, 49),
                new Vector2Int(27, 49),
                new Vector2Int(28, 49),
                new Vector2Int(31, 42),
                new Vector2Int(30, 43),
                new Vector2Int(31, 43),
                new Vector2Int(32, 43),
                new Vector2Int(33, 43),
                new Vector2Int(30, 44),
                new Vector2Int(31, 44),
                new Vector2Int(32, 44),
                new Vector2Int(33, 44),
                new Vector2Int(34, 44),
                new Vector2Int(30, 45),
                new Vector2Int(31, 45),
                new Vector2Int(32, 45),
                new Vector2Int(33, 45),
                new Vector2Int(34, 45),
                new Vector2Int(31, 46),
                new Vector2Int(32, 46),
                new Vector2Int(33, 46),
                new Vector2Int(34, 46),
                new Vector2Int(35, 46),
                new Vector2Int(32, 47),
                new Vector2Int(33, 47),
                new Vector2Int(34, 47),
                new Vector2Int(35, 47),
                new Vector2Int(33, 48),
                new Vector2Int(34, 48),
                new Vector2Int(35, 48),
                new Vector2Int(33, 49),
                new Vector2Int(34, 49),
                new Vector2Int(35, 49),
                new Vector2Int(36, 49),
                new Vector2Int(33, 50),
                new Vector2Int(34, 50),
                new Vector2Int(35, 50),
                new Vector2Int(36, 50),
                new Vector2Int(33, 51),
                new Vector2Int(34, 51),
                new Vector2Int(35, 51),
                new Vector2Int(36, 51),
                new Vector2Int(32, 52),
                new Vector2Int(33, 52),
                new Vector2Int(34, 52),
                new Vector2Int(35, 52),
                new Vector2Int(36, 52),
                new Vector2Int(37, 52),
                new Vector2Int(32, 53),
                new Vector2Int(33, 53),
                new Vector2Int(34, 53),
                new Vector2Int(35, 53),
                new Vector2Int(36, 53),
                new Vector2Int(37, 53),
                new Vector2Int(38, 53),
                new Vector2Int(31, 54),
                new Vector2Int(32, 54),
                new Vector2Int(33, 54),
                new Vector2Int(34, 54),
                new Vector2Int(35, 54),
                new Vector2Int(36, 54),
                new Vector2Int(37, 54),
                new Vector2Int(38, 54),
                new Vector2Int(41, 47),
                new Vector2Int(48, 47),
                new Vector2Int(41, 52),
                new Vector2Int(48, 52),
                new Vector2Int(62, 43),
                new Vector2Int(62, 44),
                new Vector2Int(62, 45),
                new Vector2Int(63, 45),
                new Vector2Int(62, 46),
                new Vector2Int(63, 46),
                new Vector2Int(64, 46),
                new Vector2Int(51, 47),
                new Vector2Int(52, 47),
                new Vector2Int(53, 47),
                new Vector2Int(54, 47),
                new Vector2Int(55, 47),
                new Vector2Int(56, 47),
                new Vector2Int(57, 47),
                new Vector2Int(58, 47),
                new Vector2Int(59, 47),
                new Vector2Int(60, 47),
                new Vector2Int(61, 47),
                new Vector2Int(62, 47),
                new Vector2Int(51, 51),
                new Vector2Int(52, 51),
                new Vector2Int(53, 51),
                new Vector2Int(54, 51),
                new Vector2Int(55, 51),
                new Vector2Int(56, 51),
                new Vector2Int(57, 51),
                new Vector2Int(58, 51),
                new Vector2Int(59, 51),
                new Vector2Int(60, 51),
                new Vector2Int(61, 51),
                new Vector2Int(67, 49),
                new Vector2Int(68, 49),
                new Vector2Int(66, 50),
                new Vector2Int(67, 50),
                new Vector2Int(68, 50),
                new Vector2Int(69, 50),
                new Vector2Int(63, 51),
                new Vector2Int(64, 51),
                new Vector2Int(65, 51),
                new Vector2Int(66, 51),
                new Vector2Int(67, 51),
                new Vector2Int(68, 51),
                new Vector2Int(69, 51),
                new Vector2Int(64, 52),
                new Vector2Int(65, 52),
                new Vector2Int(66, 52),
                new Vector2Int(67, 52),
                new Vector2Int(68, 52),
                new Vector2Int(69, 52),
                new Vector2Int(65, 53),
                new Vector2Int(66, 53),
                new Vector2Int(67, 53),
                new Vector2Int(68, 53),
                new Vector2Int(69, 53),
                new Vector2Int(66, 54),
                new Vector2Int(67, 54),
                new Vector2Int(68, 54),
                new Vector2Int(43, 65),
                new Vector2Int(46, 65),
                new Vector2Int(43, 66),
                new Vector2Int(46, 66),
                new Vector2Int(42, 67),
                new Vector2Int(44, 67),
                new Vector2Int(45, 67),
                new Vector2Int(47, 67),
                new Vector2Int(42, 68),
                new Vector2Int(44, 68),
                new Vector2Int(45, 68),
                new Vector2Int(47, 68),
                new Vector2Int(41, 69),
                new Vector2Int(48, 69),
                new Vector2Int(41, 70),
                new Vector2Int(48, 70),
                new Vector2Int(40, 71),
                new Vector2Int(43, 71),
                new Vector2Int(46, 71),
                new Vector2Int(49, 71),
                new Vector2Int(40, 72),
                new Vector2Int(43, 72),
                new Vector2Int(46, 72),
                new Vector2Int(49, 72),
                new Vector2Int(39, 73),
                new Vector2Int(50, 73),
                new Vector2Int(39, 74),
                new Vector2Int(42, 74),
                new Vector2Int(43, 74),
                new Vector2Int(46, 74),
                new Vector2Int(47, 74),
                new Vector2Int(50, 74),
                new Vector2Int(39, 75),
                new Vector2Int(40, 75),
                new Vector2Int(41, 75),
                new Vector2Int(44, 75),
                new Vector2Int(45, 75),
                new Vector2Int(48, 75),
                new Vector2Int(49, 75),
                new Vector2Int(50, 75),
                new Vector2Int(40, 76),
                new Vector2Int(41, 76),
                new Vector2Int(48, 76),
                new Vector2Int(49, 76),
                new Vector2Int(41, 77),
                new Vector2Int(48, 77),
                new Vector2Int(42, 78),
                new Vector2Int(47, 78),
                new Vector2Int(43, 79),
                new Vector2Int(44, 79),
                new Vector2Int(45, 79),
                new Vector2Int(46, 79),
                new Vector2Int(71, 20),
                new Vector2Int(72, 20),
                new Vector2Int(73, 20),
                new Vector2Int(74, 20),
                new Vector2Int(70, 21),
                new Vector2Int(71, 21),
                new Vector2Int(72, 21),
                new Vector2Int(73, 21),
                new Vector2Int(74, 21),
                new Vector2Int(75, 21),
                new Vector2Int(76, 21),
                new Vector2Int(72, 22),
                new Vector2Int(73, 22),
                new Vector2Int(74, 22),
                new Vector2Int(75, 22),
                new Vector2Int(81, 27),
                new Vector2Int(82, 27),
                new Vector2Int(81, 28),
                new Vector2Int(82, 28),
                new Vector2Int(74, 31),
                new Vector2Int(75, 31),
                new Vector2Int(76, 31),
                new Vector2Int(71, 32),
                new Vector2Int(72, 32),
                new Vector2Int(73, 32),
                new Vector2Int(74, 32),
                new Vector2Int(75, 32),
                new Vector2Int(76, 32),
                new Vector2Int(77, 32),
                new Vector2Int(78, 32),
                new Vector2Int(79, 32),
                new Vector2Int(59, 8),
                new Vector2Int(60, 8),
                new Vector2Int(61, 8),
                new Vector2Int(62, 8),
                new Vector2Int(63, 8),
                new Vector2Int(64, 8),
                new Vector2Int(65, 8),
                new Vector2Int(66, 8),
                new Vector2Int(67, 8),
                new Vector2Int(68, 8),
                new Vector2Int(69, 8),
                new Vector2Int(70, 8),
                new Vector2Int(71, 8),
                new Vector2Int(72, 8),
                new Vector2Int(84, 8),
                new Vector2Int(85, 8),
                new Vector2Int(86, 8),
                new Vector2Int(87, 8),
                new Vector2Int(88, 8),
                new Vector2Int(89, 8),
                new Vector2Int(90, 8),
                new Vector2Int(59, 9),
                new Vector2Int(60, 9),
                new Vector2Int(61, 9),
                new Vector2Int(62, 9),
                new Vector2Int(63, 9),
                new Vector2Int(64, 9),
                new Vector2Int(65, 9),
                new Vector2Int(66, 9),
                new Vector2Int(67, 9),
                new Vector2Int(68, 9),
                new Vector2Int(69, 9),
                new Vector2Int(70, 9),
                new Vector2Int(71, 9),
                new Vector2Int(84, 9),
                new Vector2Int(85, 9),
                new Vector2Int(86, 9),
                new Vector2Int(87, 9),
                new Vector2Int(88, 9),
                new Vector2Int(89, 9),
                new Vector2Int(90, 9),
                new Vector2Int(59, 10),
                new Vector2Int(60, 10),
                new Vector2Int(61, 10),
                new Vector2Int(62, 10),
                new Vector2Int(63, 10),
                new Vector2Int(64, 10),
                new Vector2Int(65, 10),
                new Vector2Int(66, 10),
                new Vector2Int(67, 10),
                new Vector2Int(68, 10),
                new Vector2Int(69, 10),
                new Vector2Int(86, 10),
                new Vector2Int(87, 10),
                new Vector2Int(88, 10),
                new Vector2Int(89, 10),
                new Vector2Int(90, 10),
                new Vector2Int(59, 11),
                new Vector2Int(60, 11),
                new Vector2Int(61, 11),
                new Vector2Int(62, 11),
                new Vector2Int(63, 11),
                new Vector2Int(64, 11),
                new Vector2Int(65, 11),
                new Vector2Int(66, 11),
                new Vector2Int(67, 11),
                new Vector2Int(86, 11),
                new Vector2Int(87, 11),
                new Vector2Int(88, 11),
                new Vector2Int(89, 11),
                new Vector2Int(90, 11),
                new Vector2Int(59, 12),
                new Vector2Int(60, 12),
                new Vector2Int(61, 12),
                new Vector2Int(62, 12),
                new Vector2Int(63, 12),
                new Vector2Int(64, 12),
                new Vector2Int(65, 12),
                new Vector2Int(87, 12),
                new Vector2Int(88, 12),
                new Vector2Int(89, 12),
                new Vector2Int(90, 12),
                new Vector2Int(59, 13),
                new Vector2Int(60, 13),
                new Vector2Int(61, 13),
                new Vector2Int(62, 13),
                new Vector2Int(63, 13),
                new Vector2Int(64, 13),
                new Vector2Int(88, 13),
                new Vector2Int(89, 13),
                new Vector2Int(90, 13),
                new Vector2Int(59, 14),
                new Vector2Int(60, 14),
                new Vector2Int(61, 14),
                new Vector2Int(62, 14),
                new Vector2Int(63, 14),
                new Vector2Int(88, 14),
                new Vector2Int(89, 14),
                new Vector2Int(90, 14),
                new Vector2Int(59, 15),
                new Vector2Int(60, 15),
                new Vector2Int(61, 15),
                new Vector2Int(62, 15),
                new Vector2Int(63, 15),
                new Vector2Int(88, 15),
                new Vector2Int(89, 15),
                new Vector2Int(90, 15),
                new Vector2Int(59, 16),
                new Vector2Int(60, 16),
                new Vector2Int(61, 16),
                new Vector2Int(62, 16),
                new Vector2Int(87, 16),
                new Vector2Int(88, 16),
                new Vector2Int(89, 16),
                new Vector2Int(90, 16),
                new Vector2Int(59, 17),
                new Vector2Int(60, 17),
                new Vector2Int(61, 17),
                new Vector2Int(87, 17),
                new Vector2Int(88, 17),
                new Vector2Int(89, 17),
                new Vector2Int(90, 17),
                new Vector2Int(59, 18),
                new Vector2Int(60, 18),
                new Vector2Int(61, 18),
                new Vector2Int(86, 18),
                new Vector2Int(87, 18),
                new Vector2Int(88, 18),
                new Vector2Int(89, 18),
                new Vector2Int(90, 18),
                new Vector2Int(59, 19),
                new Vector2Int(60, 19),
                new Vector2Int(61, 19),
                new Vector2Int(86, 19),
                new Vector2Int(87, 19),
                new Vector2Int(88, 19),
                new Vector2Int(89, 19),
                new Vector2Int(90, 19),
                new Vector2Int(59, 20),
                new Vector2Int(60, 20),
                new Vector2Int(61, 20),
                new Vector2Int(86, 20),
                new Vector2Int(87, 20),
                new Vector2Int(88, 20),
                new Vector2Int(89, 20),
                new Vector2Int(90, 20),
                new Vector2Int(59, 21),
                new Vector2Int(60, 21),
                new Vector2Int(61, 21),
                new Vector2Int(86, 21),
                new Vector2Int(87, 21),
                new Vector2Int(88, 21),
                new Vector2Int(89, 21),
                new Vector2Int(90, 21),
                new Vector2Int(59, 22),
                new Vector2Int(60, 22),
                new Vector2Int(61, 22),
                new Vector2Int(87, 22),
                new Vector2Int(88, 22),
                new Vector2Int(89, 22),
                new Vector2Int(90, 22),
                new Vector2Int(59, 23),
                new Vector2Int(60, 23),
                new Vector2Int(61, 23),
                new Vector2Int(62, 23),
                new Vector2Int(87, 23),
                new Vector2Int(88, 23),
                new Vector2Int(89, 23),
                new Vector2Int(90, 23),
                new Vector2Int(59, 24),
                new Vector2Int(60, 24),
                new Vector2Int(61, 24),
                new Vector2Int(62, 24),
                new Vector2Int(87, 24),
                new Vector2Int(88, 24),
                new Vector2Int(89, 24),
                new Vector2Int(90, 24),
                new Vector2Int(59, 25),
                new Vector2Int(60, 25),
                new Vector2Int(61, 25),
                new Vector2Int(88, 25),
                new Vector2Int(89, 25),
                new Vector2Int(90, 25),
                new Vector2Int(59, 26),
                new Vector2Int(60, 26),
                new Vector2Int(61, 26),
                new Vector2Int(88, 26),
                new Vector2Int(89, 26),
                new Vector2Int(90, 26),
                new Vector2Int(59, 27),
                new Vector2Int(60, 27),
                new Vector2Int(61, 27),
                new Vector2Int(88, 27),
                new Vector2Int(89, 27),
                new Vector2Int(90, 27),
                new Vector2Int(59, 28),
                new Vector2Int(60, 28),
                new Vector2Int(61, 28),
                new Vector2Int(88, 28),
                new Vector2Int(89, 28),
                new Vector2Int(90, 28),
                new Vector2Int(59, 29),
                new Vector2Int(60, 29),
                new Vector2Int(61, 29),
                new Vector2Int(88, 29),
                new Vector2Int(89, 29),
                new Vector2Int(90, 29),
                new Vector2Int(59, 30),
                new Vector2Int(60, 30),
                new Vector2Int(61, 30),
                new Vector2Int(88, 30),
                new Vector2Int(89, 30),
                new Vector2Int(90, 30),
                new Vector2Int(59, 31),
                new Vector2Int(60, 31),
                new Vector2Int(61, 31),
                new Vector2Int(88, 31),
                new Vector2Int(89, 31),
                new Vector2Int(90, 31),
                new Vector2Int(59, 32),
                new Vector2Int(60, 32),
                new Vector2Int(61, 32),
                new Vector2Int(62, 32),
                new Vector2Int(87, 32),
                new Vector2Int(88, 32),
                new Vector2Int(89, 32),
                new Vector2Int(90, 32),
                new Vector2Int(59, 33),
                new Vector2Int(60, 33),
                new Vector2Int(61, 33),
                new Vector2Int(62, 33),
                new Vector2Int(63, 33),
                new Vector2Int(64, 33),
                new Vector2Int(65, 33),
                new Vector2Int(66, 33),
                new Vector2Int(67, 33),
                new Vector2Int(68, 33),
                new Vector2Int(69, 33),
                new Vector2Int(70, 33),
                new Vector2Int(71, 33),
                new Vector2Int(72, 33),
                new Vector2Int(73, 33),
                new Vector2Int(74, 33),
                new Vector2Int(75, 33),
                new Vector2Int(76, 33),
                new Vector2Int(77, 33),
                new Vector2Int(78, 33),
                new Vector2Int(79, 33),
                new Vector2Int(80, 33),
                new Vector2Int(81, 33),
                new Vector2Int(82, 33),
                new Vector2Int(83, 33),
                new Vector2Int(84, 33),
                new Vector2Int(85, 33),
                new Vector2Int(86, 33),
                new Vector2Int(87, 33),
                new Vector2Int(88, 33),
                new Vector2Int(89, 33),
                new Vector2Int(90, 33),
                new Vector2Int(59, 34),
                new Vector2Int(60, 34),
                new Vector2Int(61, 34),
                new Vector2Int(62, 34),
                new Vector2Int(63, 34),
                new Vector2Int(64, 34),
                new Vector2Int(65, 34),
                new Vector2Int(66, 34),
                new Vector2Int(67, 34),
                new Vector2Int(68, 34),
                new Vector2Int(69, 34),
                new Vector2Int(70, 34),
                new Vector2Int(71, 34),
                new Vector2Int(72, 34),
                new Vector2Int(73, 34),
                new Vector2Int(74, 34),
                new Vector2Int(75, 34),
                new Vector2Int(76, 34),
                new Vector2Int(77, 34),
                new Vector2Int(78, 34),
                new Vector2Int(79, 34),
                new Vector2Int(80, 34),
                new Vector2Int(81, 34),
                new Vector2Int(82, 34),
                new Vector2Int(83, 34),
                new Vector2Int(84, 34),
                new Vector2Int(85, 34),
                new Vector2Int(86, 34),
                new Vector2Int(87, 34),
                new Vector2Int(88, 34),
                new Vector2Int(89, 34),
                new Vector2Int(90, 34),
                new Vector2Int(59, 35),
                new Vector2Int(60, 35),
                new Vector2Int(61, 35),
                new Vector2Int(62, 35),
                new Vector2Int(63, 35),
                new Vector2Int(64, 35),
                new Vector2Int(65, 35),
                new Vector2Int(66, 35),
                new Vector2Int(67, 35),
                new Vector2Int(68, 35),
                new Vector2Int(69, 35),
                new Vector2Int(70, 35),
                new Vector2Int(71, 35),
                new Vector2Int(72, 35),
                new Vector2Int(73, 35),
                new Vector2Int(74, 35),
                new Vector2Int(75, 35),
                new Vector2Int(76, 35),
                new Vector2Int(77, 35),
                new Vector2Int(78, 35),
                new Vector2Int(79, 35),
                new Vector2Int(80, 35),
                new Vector2Int(81, 35),
                new Vector2Int(82, 35),
                new Vector2Int(83, 35),
                new Vector2Int(84, 35),
                new Vector2Int(85, 35),
                new Vector2Int(86, 35),
                new Vector2Int(87, 35),
                new Vector2Int(88, 35),
                new Vector2Int(89, 35),
                new Vector2Int(90, 35),
                new Vector2Int(59, 36),
                new Vector2Int(60, 36),
                new Vector2Int(61, 36),
                new Vector2Int(62, 36),
                new Vector2Int(63, 36),
                new Vector2Int(64, 36),
                new Vector2Int(65, 36),
                new Vector2Int(66, 36),
                new Vector2Int(67, 36),
                new Vector2Int(68, 36),
                new Vector2Int(69, 36),
                new Vector2Int(70, 36),
                new Vector2Int(71, 36),
                new Vector2Int(72, 36),
                new Vector2Int(73, 36),
                new Vector2Int(74, 36),
                new Vector2Int(75, 36),
                new Vector2Int(76, 36),
                new Vector2Int(77, 36),
                new Vector2Int(78, 36),
                new Vector2Int(79, 36),
                new Vector2Int(80, 36),
                new Vector2Int(81, 36),
                new Vector2Int(82, 36),
                new Vector2Int(83, 36),
                new Vector2Int(84, 36),
                new Vector2Int(85, 36),
                new Vector2Int(86, 36),
                new Vector2Int(87, 36),
                new Vector2Int(88, 36),
                new Vector2Int(89, 36),
                new Vector2Int(90, 36)
            }) AddParent(water, GetInteract(Interactats.Water, TileToPosition(v.x, v.y, x_offset: 0)));
            return water;
        }
        public class CustomChallenge : MonoBehaviour
        {
            public Puzzle puzzle;
            void Update()
            {
                if (GameMaster.GM.Save.Data.CompletedPuzzles.Contains(puzzle.PuzzleID))
                {
                    gameObject.SetActive(false);
                    return;
                }
                foreach (Transform child in gameObject.transform)
                {
                    if (child.GetComponent<Enemy>() != null && child.gameObject.activeSelf) return;
                }
                puzzle.PuzzleCompletion();
            }
        }
        public class CustomBossEvent : MonoBehaviour
        {
            bool started = false;
            void Update()
            {
                if (started) return;
                if (gameObject.transform.childCount > 0) return;
                started = true;
                FanonEnding.StartCoroutine(Event());
            }

            IEnumerator Event()
            {
                GameMaster.GM.PC.Lock();
                List<GameMaster.Speech> Chatter = new List<GameMaster.Speech>();
                Chatter.Add(GameMaster.CreateSpeech(PEPPO.PEPPO_ID, 0, "GOOD JOB!*LET'S GO GET*YOU YOUR PRIZE.", "PEPPO'S VOICE"));
                GameMaster.GM.UI.InitiateChat(Chatter, false);
                while (GameMaster.GM.UI.Talking) yield return null;
                GameMaster.GM.ZoneLoad(2, new Vector2(160, -1072));
                GameMaster.GM.PC.AnimDirection(PlayerCharacter.Direction.Up);
                while (SceneManager.GetActiveScene().buildIndex == -1) yield return null;
                GameMaster.GM.PC.Lock();
                yield return new WaitForSeconds(2f);
                Chatter.Clear();
                Chatter.Add(GameMaster.CreateSpeech(PEPPO.PEPPO_ID, 0, "I'M GOING TO SHARE*SOME OF MY POWER*WITH YOU.*USE IT WISELY!*I'M SURE HE WON'T*BE ABLE TO SAY NO.", "PEPPO'S VOICE"));
                GameMaster.GM.UI.InitiateChat(Chatter, false);
                while (GameMaster.GM.UI.Talking) yield return null;
                GameMaster.GM.Save.Data.Quests[100] = SaveSystem.Quest.QUESTCOMPLETE;
                GameMaster.GM.BGM.ForceInto(18);
                yield break;
            }
        }
    }
}
