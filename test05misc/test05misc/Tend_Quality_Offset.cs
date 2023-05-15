using Verse;
using Verse.AI;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using System;
using System.Reflection;


namespace mostlytraits
{

    [StaticConstructorOnStartup]

 
    public static class TendQuality_Postfix
    {
        static TendQuality_Postfix()
        {
            Harmony harmony = new Harmony("mostlytraits");
            MethodInfo original = AccessTools.Method(typeof(TendUtility), "CalculateBaseTendQuality", new Type[] { typeof(Pawn), typeof(Pawn), typeof(float), typeof(float) }, null);
            HarmonyMethod postfix = new HarmonyMethod(typeof(TendQuality_Postfix).GetMethod("TendOffset"));
            harmony.Patch(original, null, postfix);
        }
  
        public static void TendOffset(Pawn doctor, Pawn patient, float medicinePotency, float medicineQualityMax, ref float __result)
        {
       
            if (doctor !=null && patient !=null && doctor.story.traits.HasTrait(miscTraits.mostlytraits_surgeon) && patient.Faction == Faction.OfPlayer)
            {
                if (!patient.health.hediffSet.HasHediff(miscHediffDefs.mostlytraits_meticulous_treatment))
                {
                    patient.health.AddHediff(miscHediffDefs.mostlytraits_meticulous_treatment);
                }
         
                __result *= 1.25f;

            }
        }
    }
}