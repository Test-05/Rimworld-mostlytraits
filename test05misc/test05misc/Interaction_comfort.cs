using Verse;
using RimWorld;
namespace mostlytraits
{

	public class InteractionWorker_comfort : InteractionWorker
	{
		// Token: 0x06000003 RID: 3 RVA: 0x0000208C File Offset: 0x0000028C
		public override float RandomSelectionWeight(Pawn initiator, Pawn recipient)
		{
			float num = 0;
			float offset = recipient.needs.mood.CurLevel;
			if (initiator.story.traits.HasTrait(miscTraits.mostlytraits_empathetic))
			{
				if (offset <= 0.6 && offset > 0.35)
                {
					num = (1 - offset) * 10f;
                }
				else if (offset <= 0.35)
                {
					num = (1 - offset) * 20f;
				}

			}


				return num;
		}
	}
}