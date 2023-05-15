using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace mostlytraits
{
    [StaticConstructorOnStartup]
    
    public static class Drafted
    {


        static Drafted()
        {

            Harmony harmony = new Harmony("test05misc");

            MethodInfo original = AccessTools.Method(typeof(Pawn_DraftController), "set_Drafted");

            HarmonyMethod postfix = new HarmonyMethod(typeof(Drafted), nameof(checkDrafted));

            harmony.Patch(original,null, postfix);


        }



        static void checkDrafted(Pawn_DraftController __instance, Pawn ___pawn, bool value)
        {
   
            
            Hediff boosted = ___pawn.health.hediffSet.GetFirstHediffOfDef(miscHediffDefs.drafted_move_boost);
            Hediff blind_psy_drafted = ___pawn.health.hediffSet.GetFirstHediffOfDef(miscHediffDefs.blind_psy_drafted);
            Hediff blind_psy_hediff = ___pawn.health.hediffSet.GetFirstHediffOfDef(miscHediffDefs.blind_psy_hediff);
            bool hasRushTrait = ___pawn.story.traits.HasTrait(miscTraits.mostlytrait_defender);
            bool hasBlindPsyTrait = ___pawn.story.traits.HasTrait(miscTraits.blind_psy);
            bool is_boosted = ___pawn.health.hediffSet.HasHediff(miscHediffDefs.drafted_move_boost);
            bool is_blind = ___pawn.health.hediffSet.HasHediff(miscHediffDefs.blind_psy_hediff);
            bool has_blind_drafted_hediff = ___pawn.health.hediffSet.HasHediff(miscHediffDefs.blind_psy_drafted);
            if (value == true)
            {
 
                if (!hasRushTrait & !hasBlindPsyTrait & !___pawn.story.traits.HasTrait(miscTraits.mostlytraits_combat_medic))
                {
                    return;
                }
                if (hasRushTrait)
                {
                    ___pawn.health.AddHediff(miscHediffDefs.drafted_move_boost);






                }
                if (hasBlindPsyTrait)
                {
                    
                    ___pawn.health.AddHediff(miscHediffDefs.blind_psy_drafted);
                }

                if (hasBlindPsyTrait && !is_blind)
                {
                    ___pawn.health.AddHediff(miscHediffDefs.blind_psy_drafted);
                    ___pawn.health.AddHediff(miscHediffDefs.blind_psy_hediff);
                }
                if (___pawn.story.traits.HasTrait(miscTraits.mostlytraits_combat_medic))
                {
                    ___pawn.health.AddHediff(miscHediffDefs.mostlytraits_combat_medic_buff); 
                }


                 return;



            }
            else if (value == false)

            {
                if (!hasBlindPsyTrait & is_blind)
                {
                    ___pawn.health.RemoveHediff(blind_psy_hediff);
                }

                if (___pawn.health.hediffSet.HasHediff(miscHediffDefs.mostlytraits_combat_medic_buff))
                {
                    ___pawn.health.RemoveHediff(___pawn.health.hediffSet.GetFirstHediffOfDef(miscHediffDefs.mostlytraits_combat_medic_buff));
                }

                if (!is_boosted & !has_blind_drafted_hediff)
                {
                    return;
                }    

            
                if (is_boosted)
                {
                  
                    ___pawn.health.RemoveHediff(boosted);
                    

                }
                if (has_blind_drafted_hediff)
                {
                    ___pawn.health.RemoveHediff(blind_psy_drafted);
                    
                }
                
                return;

            }

            


        }
            

            
               
            }
        }
    
            

            
            
        
    



