using Verse;
using RimWorld;

namespace mostlytraits
{

	public class ThoughtWorker_Sensitive_Random_Mood : ThoughtWorker
    {
        bool todaymood = true;
        int moodstate;
        int currectdate;
        bool initialize = true;

        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
          
            if (initialize) 
            {
                currectdate = GenLocalDate.DayOfYear(p);
                initialize = false;
            }

            if (this.todaymood && (GenLocalDate.DayOfYear(p) != currectdate))
            {
                currectdate = GenLocalDate.DayOfYear(p);
                this.todaymood = false;
              
            }
            else if (currectdate == GenLocalDate.DayOfYear(p) && !this.todaymood)
            {
                this.todaymood = true;

                int randomNumber = UnityEngine.Random.Range(1, 101);


                if (randomNumber == 1)
                {
                    this.moodstate = 0;
                    return ThoughtState.ActiveAtStage(0);
                }
                else if (randomNumber > 1 && randomNumber <= 5)
                {
                    this.moodstate = 1;
                    return ThoughtState.ActiveAtStage(1);
                }
                else if (randomNumber > 5 && randomNumber <= 11)
                {
                    this.moodstate = 2;
                    return ThoughtState.ActiveAtStage(2);
                }
                else if (randomNumber > 11 && randomNumber <= 23)
                {
                    this.moodstate = 3;
                    return ThoughtState.ActiveAtStage(3);
                }
                else if (randomNumber > 23 && randomNumber <= 35)
                {
                    this.moodstate = 4;
                    return ThoughtState.ActiveAtStage(4);
                }
                else if (randomNumber > 35 && randomNumber <= 57)
                {
                    this.moodstate = 5;
                    return ThoughtState.ActiveAtStage(5);
                }
                else if (randomNumber > 57 && randomNumber <= 75)
                {
                    this.moodstate = 6;
                    return ThoughtState.ActiveAtStage(6);
                }
                else if (randomNumber > 75 && randomNumber <= 85)
                {
                    this.moodstate = 7;
                    return ThoughtState.ActiveAtStage(7);
                }
                else if (randomNumber > 85 && randomNumber <= 93)
                {
                    this.moodstate = 8;
                    return ThoughtState.ActiveAtStage(8);
                }
                else if (randomNumber > 93 && randomNumber <= 98)
                {
                    this.moodstate = 9;
                    return ThoughtState.ActiveAtStage(9);
                }
                else if (randomNumber > 98 && randomNumber <= 100)
                {
                    this.moodstate = 10;
                    return ThoughtState.ActiveAtStage(10);
                }
            }


            return ThoughtState.ActiveAtStage(this.moodstate);




        }
        
    }
}