using System;
using RimWorld;
using Verse;
namespace mostlytraits
{
	public class ThoughtWorker_Ssocial : ThoughtWorker
	{
		
		protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn other)
		{
			if ( !RelationsUtility.PawnsKnowEachOther(pawn, other))
			{
				return false;
			}
			if (other.story.traits.HasTrait(miscTraits.introverted05) || other.story.traits.HasTrait(miscTraits.hard_work05))
			{
				return ThoughtState.ActiveAtStage(0);
			}
			else if (other.story.traits.HasTrait(miscTraits.weird_neutral05))
            {
				return ThoughtState.ActiveAtStage(1);
			}
			else if (other.story.traits.HasTrait(miscTraits.slick05))
			{
				return ThoughtState.ActiveAtStage(2);
			}
			else if (other.story.traits.HasTrait(miscTraits.mostlytraits_gangster))
			{
				return ThoughtState.ActiveAtStage(3);
			}
			return false;
		}
	}
}
