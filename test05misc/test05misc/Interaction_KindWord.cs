using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace mostlytraits
{

    [StaticConstructorOnStartup]
    public class Social_Interaction_Kind
    {

        static Social_Interaction_Kind()
        {
            Harmony harmony = new Harmony("mostlytraits");
            MethodInfo original = AccessTools.Method(typeof(InteractionWorker_KindWords), "RandomSelectionWeight", null, null);
            HarmonyMethod postfix = new HarmonyMethod(typeof(Social_Interaction_Kind).GetMethod("RandomSelectionWeight"));
            harmony.Patch(original, null, postfix);
        }

        public static void RandomSelectionWeight(Pawn initiator, Pawn recipient, ref float __result)
        {


           
            if (initiator.def.race.Humanlike || recipient.def.race.Humanlike)
            {
                __result *= initiator.GetStatValue(miscStats.mostlytraits_kindword_chance, true, -1);
                __result *= recipient.GetStatValue(miscStats.mostlytraits_kindword_receive_chance, true, -1);
            }

        }
    }
}
