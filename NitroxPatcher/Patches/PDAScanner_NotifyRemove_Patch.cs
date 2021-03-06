﻿using System;
using System.Reflection;
using Harmony;
using NitroxClient.GameLogic;
using NitroxModel.Core;
using NitroxModel.Logger;

namespace NitroxPatcher.Patches
{
    public class PDAScanner_NotifyRemove_Patch : NitroxPatch
    {
        public static readonly Type TARGET_CLASS = typeof(PDAScanner);
        public static readonly MethodInfo TARGET_METHOD = TARGET_CLASS.GetMethod("NotifyRemove", BindingFlags.NonPublic | BindingFlags.Static);

        public static void Prefix(PDAScanner.Entry entry)
        {
            if (entry != null)
            { 
                NitroxServiceLocator.LocateService<PDAManagerEntry>().Remove(entry);
            }
        }

        public override void Patch(HarmonyInstance harmony)
        {
            PatchPrefix(harmony, TARGET_METHOD);
        }
    }
}
