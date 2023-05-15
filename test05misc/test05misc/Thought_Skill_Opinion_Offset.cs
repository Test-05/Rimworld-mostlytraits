using System;
using RimWorld;
using Verse;
namespace mostlytraits
{
	public class ThoughtWorker_Skill : ThoughtWorker
	{

		protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn other)
		{
			if (!RelationsUtility.PawnsKnowEachOther(pawn, other))
			{
				return false;
			}
			if (other.story.traits.HasTrait(miscTraits.mostlytraits_surgeon) || other.story.traits.HasTrait(miscTraits.mostlytraits_combat_medic))
			{
				return ThoughtState.ActiveWithReason("Skill bonus");
			}
			return false;
	}
}
}
