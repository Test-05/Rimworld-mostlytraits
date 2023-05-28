using Verse;
using RimWorld;
namespace mostlytraits
{

	public class Interaction_complain : InteractionWorker
	{
		// Token: 0x06000003 RID: 3 RVA: 0x0000208C File Offset: 0x0000028C
		public override float RandomSelectionWeight(Pawn initiator, Pawn recipient)
		{
		
			if (initiator.RaceProps.Humanlike && recipient.story.traits.HasTrait(miscTraits.weird_neutral05))
			{

				float num = this.moodCurve.Evaluate(initiator.needs.mood.CurLevel);

				return num;
			}
			
			 return 0f;
		}




		public SimpleCurve moodCurve = new SimpleCurve
		{
			{
				new CurvePoint(0f, 10f),
				true
			},

			{
				new CurvePoint(0.1f, 10f),
				true
			},
			{
				new CurvePoint(0.2f, 5f),
				true
			},
			{
				new CurvePoint(0.3f, 0.75f),
				true
			},
			{
				new CurvePoint(0.4f, 0.5f),
				true
			},
			{
				new CurvePoint(0.5f, 0.35f),
				true
			},
			{
				new CurvePoint(0.7f, 0.1f),
				true
			},
		};
	}
}