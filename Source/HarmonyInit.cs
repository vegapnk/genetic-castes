using Verse;
using HarmonyLib;
using System;

namespace GeneticCastes
{
    [StaticConstructorOnStartup]
    internal static class HarmonyInit
    {
        static HarmonyInit()
        {
            Harmony harmony = new Harmony("GeneticCastes");
            harmony.PatchAll();
        }
    }
}