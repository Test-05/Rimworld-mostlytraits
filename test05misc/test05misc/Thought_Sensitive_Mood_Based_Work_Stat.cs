using Verse;
using RimWorld;
using System.Xml;
namespace mostlytraits
{

    public class ThoughtWorker_Sensitive_Mood_Based_Work_Stat : ThoughtWorker
    {
        int refreshtick = 0;
 
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            if (!p.health.hediffSet.HasHediff(miscHediffDefs.mostlytraits_mood_based_workspeed_offset))
            { p.health.AddHediff(miscHediffDefs.mostlytraits_mood_based_workspeed_offset).Severity = p.needs.mood.CurLevel + 0.01f; }

            else if (Find.TickManager.TicksGame > refreshtick + 600 && p.health.hediffSet.HasHediff(miscHediffDefs.mostlytraits_mood_based_workspeed_offset))
            {
                refreshtick = Find.TickManager.TicksGame;
                p.health.hediffSet.GetFirstHediffOfDef(miscHediffDefs.mostlytraits_mood_based_workspeed_offset).Severity = p.needs.mood.CurLevel + 0.01f;
            }
            return ThoughtState.Inactive;
        }
    }
}