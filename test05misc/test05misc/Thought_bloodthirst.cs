using System;
using Verse;
using RimWorld;
namespace mostlytraits
{

	public class ThoughtWorker_bloodthirst : ThoughtWorker
	{

		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			float painTotal = p.health.hediffSet.PainTotal;
			if ((!p.health.hediffSet.HasHediff(miscHediffDefs.mostlytraits_blood_thirst_hediff))){
				p.health.AddHediff(miscHediffDefs.mostlytraits_blood_thirst_hediff);
			}

			if (painTotal < 0.1 || p.Downed )
			{

				if (p.health.hediffSet.HasHediff(miscHediffDefs.mostlytraits_blood_thirst_hurt_hediff))
				{
					p.health.RemoveHediff(p.health.hediffSet.GetFirstHediffOfDef(miscHediffDefs.mostlytraits_blood_thirst_hurt_hediff));
				}
			}

			else if (painTotal >= 0.1 && painTotal <= 0.99)
			{
				if (p.health.hediffSet.HasHediff(miscHediffDefs.mostlytraits_blood_thirst_hurt_hediff))
				{
					Hediff Hediff = p.health.hediffSet.GetFirstHediffOfDef(miscHediffDefs.mostlytraits_blood_thirst_hurt_hediff);
					Hediff.Severity = p.health.hediffSet.PainTotal;
			
				}
				else
				{
					p.health.AddHediff(miscHediffDefs.mostlytraits_blood_thirst_hurt_hediff);
					Hediff Hediff = p.health.hediffSet.GetFirstHediffOfDef(miscHediffDefs.mostlytraits_blood_thirst_hurt_hediff);
					Hediff.Severity = p.health.hediffSet.PainTotal;
				}


				if (painTotal <= 0.3)
				{
					return ThoughtState.ActiveAtStage(0);
				}
				else if (painTotal > 0.3 && painTotal <= 0.5 )
				{
					return ThoughtState.ActiveAtStage(1);
				}
				else if (painTotal > 0.5)
				{
					return ThoughtState.ActiveAtStage(2);
				}
			}


			return ThoughtState.Inactive;
		}
			
	}
}