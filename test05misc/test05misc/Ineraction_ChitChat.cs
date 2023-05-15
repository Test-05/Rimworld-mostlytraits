using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace mostlytraits
{

    [StaticConstructorOnStartup]
    public class Social_Interaction_ChitChat
    {

        static Social_Interaction_ChitChat()
        {
            Harmony harmony = new Harmony("mostlytraits");
            MethodInfo original = AccessTools.Method(typeof(InteractionWorker_Chitchat), "RandomSelectionWeight", null, null);
            HarmonyMethod postfix = new HarmonyMethod(typeof(Social_Interaction_ChitChat).GetMethod("InteractionChance"));
            harmony.Patch(original, null, postfix);
        }
        public static void InteractionChance(Pawn initiator, Pawn recipient, ref float __result)
        {

            if (initiator.def.race.Humanlike || recipient.def.race.Humanlike)
            {
                __result *= initiator.GetStatValue(miscStats.mostlytraits_chitchat_chance, true, -1);
                __result *= recipient.GetStatValue(miscStats.mostlytraits_chitchat_receive_chance, true, -1);
                if ((recipient.story.traits.HasTrait(miscTraits.introverted05) || initiator.story.traits.HasTrait(miscTraits.introverted05)) && LovePartnerRelationUtility.LovePartnerRelationExists(initiator, recipient))
                {
                    __result += 1f;
                }
               
            }
            
        }

    }
}
    
