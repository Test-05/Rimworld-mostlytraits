using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace mostlytraits
{

    [StaticConstructorOnStartup]
    public class Social_Interaction_DeepTalk
    {

        static Social_Interaction_DeepTalk()
        {
            Harmony harmony = new Harmony("mostlytraits");
            MethodInfo original = AccessTools.Method(typeof(InteractionWorker_DeepTalk), "RandomSelectionWeight", null, null);
            HarmonyMethod postfix = new HarmonyMethod(typeof(Social_Interaction_DeepTalk).GetMethod("InteractionChance"));
            harmony.Patch(original, null, postfix);
        }
        public static void InteractionChance(Pawn initiator, Pawn recipient, ref float __result)
        {

            if (initiator.def.race.Humanlike || recipient.def.race.Humanlike)
            {
                
                if ((recipient.story.traits.HasTrait(miscTraits.mostlytraits_creative) || initiator.story.traits.HasTrait(miscTraits.mostlytraits_creative)))
                {
                    __result *= 1.5f;
                }

                if ((recipient.story.traits.HasTrait(miscTraits.mostlytraits_empathetic) || initiator.story.traits.HasTrait(miscTraits.mostlytraits_empathetic)))
                {
                    __result *= 2.3f;
                }

            }

        }

    }
}
