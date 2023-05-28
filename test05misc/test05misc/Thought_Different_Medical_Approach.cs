using Verse;
using RimWorld;
using System;
namespace mostlytraits
{

		public class Thought_different_medical_approach : ThoughtWorker
	{
		protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn other)
		{

			if (!RelationsUtility.PawnsKnowEachOther(pawn, other))
			{
				return false;

			}
			if (pawn.story.traits.HasTrait(miscTraits.mostlytraits_surgeon) && other.story.traits.HasTrait(miscTraits.mostlytraits_combat_medic))
			{
				return true;
			}
			else if (pawn.story.traits.HasTrait(miscTraits.mostlytraits_combat_medic) && other.story.traits.HasTrait(miscTraits.mostlytraits_surgeon))
			{
				return true;
			}
			return false;
		}
	}
	
}

