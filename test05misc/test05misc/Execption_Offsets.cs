using RimWorld;
using Verse;
using HarmonyLib;
using System;


namespace mostlytraits
{
	[StaticConstructorOnStartup]
	public class expectationOffset
	{
		static expectationOffset()
		{
			Harmony harmony = new Harmony("mostlytraits");

			harmony.Patch(
				AccessTools.Method(typeof(ThoughtWorker_Expectations), "CurrentStateInternal"),
				postfix: new HarmonyMethod(typeof(expectationOffset), nameof(PostfixExpectation))
			);
		}

	
		private static ThoughtState PostfixExpectation(ThoughtState __result, Pawn p)
		{
			if (p.story.traits.HasTrait(miscTraits.hard_work05))
			{
				return ThoughtState.ActiveAtStage(Math.Min(__result.StageIndex + 2, 5));
			}
			return __result;
		}
	}
}