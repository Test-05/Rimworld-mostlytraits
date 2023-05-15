using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace mostlytraits
{
    public class IngestionOutcomeDoer_end_inspiration : IngestionOutcomeDoer
    {
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
        {
            int randomNumber = UnityEngine.Random.Range(1, 101);
            InspirationHandler inspirationHandler = pawn.mindState.inspirationHandler;
            if (pawn.Inspired)
            {
               
                inspirationHandler.EndInspiration(pawn.InspirationDef);
            }
         

            if (randomNumber <= 60 && randomNumber >= 54)
            {
                
                InspirationDef randomInspirationDef = inspirationHandler.GetRandomAvailableInspirationDef();
                inspirationHandler.TryStartInspiration(randomInspirationDef, "By having a bizarre experience,", true);
            }

            if (randomNumber <= 15)
            {
                pawn.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_smoke_bad_mood);
            }
            else if (randomNumber > 90)
            {
                pawn.needs.mood.thoughts.memories.TryGainMemory(miscThoughts.mostlytraits_smoke_good_mood);
            }
       
        }

       
    }
    
}
