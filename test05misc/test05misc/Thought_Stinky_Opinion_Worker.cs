using System;
using RimWorld;
using Verse;
namespace mostlytraits
{
	public class Thought_Stinky_Opinion_Worker : ThoughtWorker
	{
		protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn other)
		{

			if (other.story.traits.HasTrait(miscTraits.mostlytraits_stinky))
			{
				return true;
			}
			return ThoughtState.Inactive;
		}
	}
}