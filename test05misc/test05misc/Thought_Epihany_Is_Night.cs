using Verse;
using RimWorld;
namespace mostlytraits
{

	public class ThoughtWorker_Epihany_Night : ThoughtWorker
	{

		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			int temp = GenLocalDate.HourInteger(p) - 7;
			bool nighttime = GenLocalDate.HourInteger(p) >= 20 || (temp >= -7 && temp <= 0);
			
		

				if (nighttime)
                {
				p.health.AddHediff(miscHediffDefs.mostlytraits_epihany_night_hediff);
				}

	
			return p.Awake() && (nighttime);
		}
	}
}