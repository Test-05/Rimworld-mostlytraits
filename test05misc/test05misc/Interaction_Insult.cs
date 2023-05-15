using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace mostlytraits
{

    [StaticConstructorOnStartup]
    public class Social_Interaction_Insult
    {

        static Social_Interaction_Insult()
        {
            Harmony harmony = new Harmony("mostlytraits");
            MethodInfo original = AccessTools.Method(typeof(InteractionWorker_Insult), "RandomSelectionWeight", null, null);
            HarmonyMethod postfix = new HarmonyMethod(typeof(Social_Interaction_Insult).GetMethod("RandomSelectionWeight"));
            harmony.Patch(original, null, postfix);
        }

        public static void RandomSelectionWeight(Pawn initiator, Pawn recipient, ref float __result)
        {



            if (initiator.def.race.Humanlike || recipient.def.race.Humanlike)
            {

                
                    __result *= initiator.GetStatValue(miscStats.mostlytraits_insult_chance, true, -1);
                

                if (recipient.story.traits.HasTrait(miscTraits.mostlytraits_combat_medic) || recipient.story.traits.HasTrait(miscTraits.mostlytraits_surgeon))
                {
                    __result *= 0.25f;
                }


                if (recipient.story.traits.HasTrait(miscTraits.introverted05) && !LovePartnerRelationUtility.LovePartnerRelationExists(initiator, recipient))
                {
                    __result *= 2f;
                }

       

            }
        }

            
             



        }
    }

