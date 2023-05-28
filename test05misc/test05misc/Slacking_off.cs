using RimWorld;
using Verse;
using Verse.AI;
namespace mostlytraits
{
	public class ThoughtWorker_slack : ThoughtWorker
	{
		// Token: 0x06004967 RID: 18791 RVA: 0x00198AE0 File Offset: 0x00196CE0

		protected override ThoughtState CurrentStateInternal(Pawn p)
		{

			JobDriver curDriver = p.jobs.curDriver;
			if (curDriver == null || curDriver.ActiveSkill == null || p.skills == null || p.health.hediffSet.HasHediff(miscHediffDefs.mostlytraits_slacking))
			{
				if (p.health.hediffSet.HasHediff(miscHediffDefs.mostlytraits_passion_working_speed))
				{
					p.health.RemoveHediff(p.health.hediffSet.GetFirstHediffOfDef(miscHediffDefs.mostlytraits_passion_working_speed));
				}
				return ThoughtState.Inactive;
			}


			SkillRecord skill = p.skills.GetSkill(curDriver.ActiveSkill);
			if (skill == null)
			{
				return ThoughtState.Inactive;
			}


			//add working speed offset if working and work requires skill
			p.health.AddHediff(miscHediffDefs.mostlytraits_passion_working_speed);	
			SkillDef skilldef = skill.def;
			//extra xp and joy based on passion
			if (skill.passion == Passion.Major)
			{
				if (skill.Level < 20)
				{
					//set "true" for this extra xp adding directly, not count into the 4000XP daily learning cap and won't x20% when reaching the cap
					p.skills.Learn(skilldef, skill.Level * 0.5f, true);
				}
				p.needs.joy.CurLevel += 0.004f;
				p.health.hediffSet.GetFirstHediffOfDef(miscHediffDefs.mostlytraits_passion_working_speed).Severity = 0.51f;
			}
			else if (skill.passion == Passion.Minor)
			{
				if (skill.Level < 20)
				{

					p.skills.Learn(skilldef, skill.Level * 0.4f);
				}
				p.needs.joy.CurLevel += 0.0025f;
			
			}
			else if (skill.passion == Passion.None)
            {
				p.needs.joy.CurLevel -= 0.001f;
				p.health.hediffSet.GetFirstHediffOfDef(miscHediffDefs.mostlytraits_passion_working_speed).Severity = 0.02f;
			}







			//random slack when job is not related to combat
				if (skilldef != SkillDefOf.Shooting && skilldef != SkillDefOf.Melee && !p.health.hediffSet.HasHediff(miscHediffDefs.mostlytraits_slacked) && !p.health.hediffSet.HasHediff(miscHediffDefs.mostlytraits_slack_caught))
            {
				if (skill.passion == Passion.Minor)
				{
					relaxchance(p, ((1 - p.needs.joy.CurLevel) / 10));
				}

				else if (skill.passion == Passion.None)
				{
					relaxchance(p, 0.05f);
				}
			}


			
			return ThoughtState.Inactive;
		}




		public void relaxchance(Pawn p, float chance)
		{


			if (Rand.Chance(chance))
			{

				p.health.AddHediff(miscHediffDefs.mostlytraits_slacking);


			}

		}

	}
}


