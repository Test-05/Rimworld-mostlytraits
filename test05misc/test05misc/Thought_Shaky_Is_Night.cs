using System;
using Verse;
using RimWorld;
namespace mostlytraits
{

	public class ThoughtWorker_Shaky : ThoughtWorker
	{

		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			int temp = GenLocalDate.HourInteger(p) - 7;
			bool nighttime = GenLocalDate.HourInteger(p) >= 20 || (temp >= -7 && temp <= 0);

			if (GenLocalDate.HourInteger(p) >= 8 && GenLocalDate.HourInteger(p) <= 19)
			{
				p.health.AddHediff(miscHediffDefs.mostlytraits_shaky_day_hediff);
			
			}
			if (nighttime)
			{
				p.health.AddHediff(miscHediffDefs.mostlytraits_shaky_night_hediff);
	
			}
			return false;
		}
	}
}