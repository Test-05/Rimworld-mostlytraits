using System;
using Verse;
using RimWorld;
namespace mostlytraits
{

	public class ThoughtWorker_hardwork_Is_Day : ThoughtWorker
	{

		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
	
			return p.Awake() && (GenLocalDate.HourInteger(p) >= 5 && GenLocalDate.HourInteger(p) <= 10);

		}
	}
}