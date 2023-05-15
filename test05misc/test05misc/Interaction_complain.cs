using Verse;
using RimWorld;
namespace mostlytraits
{

	public class Interaction_complain : InteractionWorker
	{
		// Token: 0x06000003 RID: 3 RVA: 0x0000208C File Offset: 0x0000028C
		public override float RandomSelectionWeight(Pawn initiator, Pawn recipient)
		{
			float num = 0;
			if (recipient.story.traits.HasTrait(miscTraits.weird_neutral05))
			{
				float offset = initiator.needs.mood.CurLevel;
				if (offset >0.5 && offset < 0.8)
                {
					num = (1 / offset) * 0.3f;
				}
				if (offset <= 0.5)
                {

					num = (1 / offset) * 1.25f;
				}
					

			}
			
			return num;
		}
	}
}