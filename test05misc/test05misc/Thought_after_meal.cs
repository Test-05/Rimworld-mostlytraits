using System;
using RimWorld;
using System.Reflection;
using Verse;
using HarmonyLib;
using System.Collections.Generic;


namespace mostlytraits
{
	[StaticConstructorOnStartup]
	public class Thought_after_meal
	{
		static Thought_after_meal()
		{
			Harmony harmony = new Harmony("mostlytraits");

			harmony.Patch(AccessTools.Method(typeof(ThoughtUtility), "CanGetThought"),

				null, new HarmonyMethod(typeof(Thought_after_meal), nameof(ThoughtWhenTrait)));
		}




		public static void ThoughtWhenTrait(Pawn pawn, ThoughtDef def, ref bool __result)
		{
			ThoughtDef AteWithoutTable = DefDatabase<ThoughtDef>.GetNamed("AteWithoutTable");
			//ThoughtDef AteLavishMeal = DefDatabase<ThoughtDef>.GetNamed("AteLavishMeal");
			//ThoughtDef AteFineMeal = DefDatabase<ThoughtDef>.GetNamed("AteFineMeal");

			bool hasTableEnjoyerTrait = pawn.story.traits.HasTrait(miscTraits.table_enjoyer);
			bool hasFoodieTrait = pawn.story.traits.HasTrait(miscTraits.mostlytraits_foodie);


			if (def == AteWithoutTable && pawn.health.hediffSet.HasHediff(miscHediffDefs.eating_protection))
			{
				__result = false;
			}
			if (!hasFoodieTrait && !hasTableEnjoyerTrait)
			{
				return;
			}

			

			if (def == AteWithoutTable && hasTableEnjoyerTrait && !pawn.health.hediffSet.HasHediff(miscHediffDefs.eating_protection))
			{
				pawn.health.AddHediff(miscHediffDefs.table_shock).Severity= 0.01f;
				
			}
			if (def == ThoughtDefOf.AteLavishMeal && hasFoodieTrait)
            {
				pawn.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_foodie_atelavishmeal);
				pawn.health.AddHediff(miscHediffDefs.ate_good_food);
				pawn.needs.joy.CurLevel = pawn.needs.joy.MaxLevel;
			}
			else if (def == ThoughtDefOf.AteFineMeal && hasFoodieTrait)
			{
	
				pawn.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_foodie_atefinemeal);

				pawn.needs.joy.CurLevel = pawn.needs.joy.MaxLevel;

			}

	

		}	
	}
}