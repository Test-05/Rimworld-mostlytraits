using System;
using RimWorld;
using System.Reflection;
using Verse;
using HarmonyLib;
using System.Collections.Generic;


namespace mostlytraits
{

	/*[StaticConstructorOnStartup]
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


			if (pawn.health.hediffSet.HasHediff(miscHediffDefs.eating_protection) && !pawn.story.traits.HasTrait(miscTraits.mostlytraits_foodie) && !pawn.story.traits.HasTrait(miscTraits.table_enjoyer))
			{
				return;
			}

			if (def == DefDatabase<ThoughtDef>.GetNamed("AteWithoutTable"))
			{
				if (pawn.health.hediffSet.HasHediff(miscHediffDefs.eating_protection))
				{
					__result = false;
					Log.Message("eating protect");
				}
				else if (pawn.story.traits.HasTrait(miscTraits.table_enjoyer))
				{
			

					if (Rand.Chance(0.08f))
					{
						pawn.story.traits.RemoveTrait(pawn.story.traits.GetTrait(miscTraits.table_enjoyer));
						string letterTitle = $"{pawn.Name}'s trait has changed";
						string letterText = $"{pawn.Name} has accepted the reality and lost the table enjoyer trait";
						Find.LetterStack.ReceiveLetter(letterTitle, letterText, LetterDefOf.PositiveEvent, null, null, null, null, null);
						pawn.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_lost_table_enjoyer);


					}
					else
					{

						pawn.health.AddHediff(miscHediffDefs.table_shock).Severity = 0.01f;
					}
				}
            }

			if (pawn.story.traits.HasTrait(miscTraits.mostlytraits_foodie))
            {

				if (def == ThoughtDefOf.AteLavishMeal)
				{
					pawn.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_foodie_atelavishmeal);
					pawn.health.AddHediff(miscHediffDefs.ate_good_food);
					pawn.needs.joy.CurLevel = pawn.needs.joy.MaxLevel;
				}
				else if (def == ThoughtDefOf.AteFineMeal)
				{

					pawn.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_foodie_atefinemeal);

					pawn.needs.joy.CurLevel = pawn.needs.joy.MaxLevel;

				}



			}
		

	

		}	
	}*/
}