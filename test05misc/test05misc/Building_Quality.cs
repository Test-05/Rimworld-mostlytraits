using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using UnityEngine;
using System;

namespace mostlytraits
{

    [StaticConstructorOnStartup]
    public class QualityOffset
    {

        static QualityOffset()
        {
            Harmony harmony = new Harmony("mostlytraits");

            harmony.Patch(AccessTools.Method(typeof(QualityUtility), "GenerateQualityCreatedByPawn", new Type[] { typeof(Pawn), typeof(SkillDef) }),

                postfix: new HarmonyMethod(typeof(QualityOffset), nameof(Offset)));







        }

        static void Offset(Pawn pawn, SkillDef relevantSkill, ref QualityCategory __result)
        {
            if (pawn.story.traits.HasTrait(miscTraits.mostlytraits_good_builder) && relevantSkill == SkillDefOf.Construction)
            {
                __result = (QualityCategory)Mathf.Min((int)(__result + 1), 6);
            }

            if (pawn.story.traits.HasTrait(miscTraits.mostlytraits_creative) && relevantSkill == SkillDefOf.Artistic)
            {
                __result = (QualityCategory)Mathf.Min((int)(__result + 1), 6);
            }

            if (pawn.story.traits.HasTrait(miscTraits.mostlytrait_epiphany))
            {
                int relevantSkillLevel = pawn.RaceProps.IsMechanoid ? pawn.RaceProps.mechFixedSkillLevel : pawn.skills.GetSkill(relevantSkill).Level;
                int randomNumber = UnityEngine.Random.Range(1, 101);
                int skillOffset = randomNumber + (20 - relevantSkillLevel);
                int ledchance = 7;
                int lossquality = UnityEngine.Random.Range(1, 101);

                int temp = GenLocalDate.HourInteger(pawn) - 7;
                bool nighttime = GenLocalDate.HourInteger(pawn) >= 20 || (temp >= -7 && temp <= 0);

                if (nighttime)
                {
                    ledchance += 3;
                }

                if (__result != QualityCategory.Legendary)
                {
              
                    if (skillOffset <= ledchance)
                    {
                        __result = QualityCategory.Legendary;
                  

                    }
                    else if (skillOffset >= ledchance && lossquality < 66)
                    {
                        __result = (QualityCategory)Mathf.Max((int)(__result - 1), 0);
            
                    }


                    if (ModsConfig.IdeologyActive && pawn.Ideo != null)
                    {
                        Precept_Role role = pawn.Ideo.GetRole(pawn);
                        if (role != null && role.def.roleEffects != null)
                        {
                            RoleEffect roleEffect = role.def.roleEffects.FirstOrDefault((RoleEffect eff) => eff is RoleEffect_ProductionQualityOffset);
                            if (roleEffect != null)
                            {
                                if (skillOffset <= (ledchance + 8))
                                {
                                    __result = QualityCategory.Legendary;
                                }
                                else if (skillOffset >= (ledchance + 8) && lossquality < 66)
                                {
                                    __result = (QualityCategory)Mathf.Max((int)(__result - 1), 0);
                                }
                            }
                        }
                    }
                }
            }


        }
    }
}
  

 
