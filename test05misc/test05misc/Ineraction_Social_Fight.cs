using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace mostlytraits
{
    [StaticConstructorOnStartup]
    public class Social_Fight
    {
        static Social_Fight() {
            Harmony harmony = new Harmony("mostlytraits");
            MethodInfo original = AccessTools.Method(typeof(Pawn_InteractionsTracker), "SocialFightChance", null, null);
            HarmonyMethod postfix = new HarmonyMethod(typeof(Social_Fight).GetMethod("Interaction_Social_Fight"));
            harmony.Patch(original, null, postfix);
        }
    

    
        public static void Interaction_Social_Fight(InteractionDef interaction, Pawn initiator, ref float __result)
        {

            if (initiator.def.race.Humanlike)
            {
                if (initiator.story.traits.HasTrait(miscTraits.mostlytraits_gangster))
                {

                    __result *= 1.5f;
                }
            }
        }

    }
}
    
