
    using System;
    using System.Reflection;
    using HarmonyLib;
    using RimWorld;
    using Verse;

namespace mostlytraits
{
    [StaticConstructorOnStartup]
    public static class SkillDecay
    {
        static SkillDecay()
        {

            Harmony harmony = new Harmony("mostlytraits");
            MethodInfo original = AccessTools.Method(typeof(SkillRecord), "Learn", null, null); ;
            HarmonyMethod prefix = new HarmonyMethod(typeof(SkillDecay).GetMethod("SkillDecayRate"));
            harmony.Patch(original,prefix);
        }

        public static void SkillDecayRate(SkillRecord __instance, Pawn ___pawn, ref float xp, bool direct)
        {
   
            if (___pawn.story.traits.HasTrait(miscTraits.hard_work05) && xp < 0f)
            {
             
                    xp *= 1.65f;
                    
                
            }

        }
    } 
}

    
   

