using Verse;
using RimWorld;
namespace mostlytraits
{

	public class InteractionWorker_comfort : InteractionWorker
	{

		public override float RandomSelectionWeight(Pawn initiator, Pawn recipient)
		{
		
			
			if (initiator.RaceProps.Humanlike  && initiator.story.traits.HasTrait(miscTraits.mostlytraits_empathetic))
			{
				float num= this.moodCurve.Evaluate(recipient.needs.mood.CurLevel);
			
				return num;
			}


			return 0f;
		}



		public SimpleCurve moodCurve = new SimpleCurve
		{
			{
				new CurvePoint(0f, 50f),
				true
			},
			{
				new CurvePoint(0.1f, 50f),
				true
			},
			{
				new CurvePoint(0.2f, 30f),
				true
			},
			{
				new CurvePoint(0.3f, 10f),
				true
			},
			{
				new CurvePoint(0.4f, 0.5f),
				true
			},
			{
				new CurvePoint(0.5f, 0.1f),
				true
			},
			{
				new CurvePoint(0.6f, 0f),
				true
			},
		};




	}
}