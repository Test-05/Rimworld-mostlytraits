
using RimWorld;
using Verse;
using HarmonyLib;
using UnityEngine;
using Verse.AI;


namespace mostlytraits
{
	[StaticConstructorOnStartup]

	public class After_meal
	{

		static After_meal()
		{
			Harmony harmony = new Harmony("mostlytraits");

			harmony.Patch(AccessTools.Method(typeof(Toils_Ingest), "FinalizeIngest"), null, new HarmonyMethod(typeof(After_meal), nameof(aftermeal)));


		}


	

		public static Toil aftermeal(Toil __result, Pawn ingester, TargetIndex ingestibleInd)
		{
			

				
			if (ingester.RaceProps.Humanlike && (ingester.story.traits.HasTrait(miscTraits.table_enjoyer) || ingester.health.hediffSet.HasHediff(miscHediffDefs.eating_protection) || ingester.story.traits.HasTrait(miscTraits.mostlytraits_foodie)))
			{
		
				__result.Clear();
				Toil toil = ToilMaker.MakeToil("FinalizeIngest");
				toil.initAction = delegate ()
				{
					Pawn actor = toil.actor;
					Job curJob = actor.jobs.curJob;
					Thing thing = curJob.GetTarget(ingestibleInd).Thing;
					if (ingester.needs.mood != null && thing.def.IsNutritionGivingIngestible && thing.def.ingestible.chairSearchRadius > 10f)
					{
						if (!(ingester.Position + ingester.Rotation.FacingCell).HasEatSurface(actor.Map) && ingester.GetPosture() == PawnPosture.Standing && !ingester.IsWildMan() && thing.def.ingestible.tableDesired)
						{
							if (ingester.health.hediffSet.HasHediff(miscHediffDefs.eating_protection))
                            {
								ingester.needs.mood.thoughts.memories.TryGainMemory(ThoughtDefOf.AteWithoutTable, null, null);
							}
							
							if (ingester.story.traits.HasTrait(miscTraits.table_enjoyer))
							{


								if (Rand.Chance(0.075f))
								{
									ingester.story.traits.RemoveTrait(ingester.story.traits.GetTrait(miscTraits.table_enjoyer));
									string letterTitle = $"{ingester.LabelShort}'s trait has changed";
									string letterText = $"{ingester.LabelShort} has accepted the reality and lost the table enjoyer trait";
									Find.LetterStack.ReceiveLetter(letterTitle, letterText, LetterDefOf.PositiveEvent, null, null, null, null, null);
									ingester.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_lost_table_enjoyer);


								}
								else
								{

									ingester.health.AddHediff(miscHediffDefs.table_shock).Severity = 0.01f;
								}
							}


						}


						if (ingester.story.traits.HasTrait(miscTraits.mostlytraits_foodie))
						{
							ThingDef fooddef = thing.def;
							FoodPreferability preferability = fooddef.ingestible.preferability;



							switch (preferability)
							{
			
								case FoodPreferability.RawBad:
									ingester.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_foodie_aterawbad);
									break;

								case FoodPreferability.RawTasty:
									ingester.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_foodie_aterawtasty);
									break;

								case FoodPreferability.MealTerrible:
									ingester.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_foodie_ateterriblemeal);
									break;
								case FoodPreferability.MealAwful:
									ingester.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_foodie_ateawfulmeal);
									break;
								case FoodPreferability.MealSimple:

									ingester.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_foodie_atesimplemeal);
									ingester.needs.joy.CurLevel += 0.08f;
									break;
								case FoodPreferability.MealFine:

									ingester.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_foodie_atefinemeal);
									ingester.needs.joy.CurLevel += 0.35f;
									break;
								case FoodPreferability.MealLavish:

									ingester.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_foodie_atelavishmeal);
									ingester.health.AddHediff(miscHediffDefs.ate_good_food);
									ingester.needs.joy.CurLevel = ingester.needs.joy.MaxLevel;
									break;

								default:

									break;
							}






						}
						Room room = ingester.GetRoom(RegionType.Set_All);
						if (room != null)
						{
							int scoreStageIndex = RoomStatDefOf.Impressiveness.GetScoreStageIndex(room.GetStat(RoomStatDefOf.Impressiveness));
							if (ThoughtDefOf.AteInImpressiveDiningRoom.stages[scoreStageIndex] != null)
							{
								ingester.needs.mood.thoughts.memories.TryGainMemory(ThoughtMaker.MakeThought(ThoughtDefOf.AteInImpressiveDiningRoom, scoreStageIndex), null);
							}
						}
					}
					float num = ingester.needs.food.NutritionWanted;
					if (curJob.ingestTotalCount)
					{
						num = thing.GetStatValue(StatDefOf.Nutrition, true, -1) * (float)thing.stackCount;
					}
					else if (curJob.overeat)
					{
						num = Mathf.Max(num, 0.75f);
					}
					float num2 = thing.Ingested(ingester, num);
					if (!ingester.Dead)
					{
						ingester.needs.food.CurLevel += num2;
					}
					ingester.records.AddTo(RecordDefOf.NutritionEaten, num2);
				};
				toil.defaultCompleteMode = ToilCompleteMode.Instant;
				__result = toil;
				return __result;





			}
			
			return __result;
		}

	}


}





		
	

