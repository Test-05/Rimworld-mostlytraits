using System;
using RimWorld;
using System.Reflection;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using HarmonyLib;


namespace mostlytraits
{

    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            Harmony harmony = new Harmony("mostlytraits");

            harmony.Patch(
                AccessTools.Method(typeof(Recipe_Surgery), "CheckSurgeryFail"),
                postfix: new HarmonyMethod(typeof(HarmonyPatches), nameof(SurgeryFailedPatch))
            );
        }

        public static void SurgeryFailedPatch(Pawn surgeon, Pawn patient, List<Thing> ingredients, BodyPartRecord part, Bill bill, ref bool __result)
        {
            if (__result && surgeon.story.traits.HasTrait(miscTraits.mostlytraits_surgeon))
            {
                if (!patient.Dead && patient.IsColonist)
                {
                    surgeon.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_failed_surgery);
                    
                    
                }
                else if (patient.Dead && patient.IsColonist)
                {
                    surgeon.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_surgery_death);
                   surgeon.mindState.mentalStateHandler.TryStartMentalState(DefDatabase<MentalStateDef>.GetNamed("Tantrum"));
                }
            }
           
        }
    }
}