using Verse;
using RimWorld;
namespace mostlytraits
{

	public class ThoughtWorker_hardwork_Is_Night : ThoughtWorker
	{

		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			int temp = GenLocalDate.HourInteger(p) - 4;
			bool nighttime = GenLocalDate.HourInteger(p) >= 20 || (temp >= -4 && temp <= 0);



			return p.Awake() && (nighttime);
		}
	}
}