using System;
using Verse;
using RimWorld;

namespace mostlytraits
{
	// Token: 0x02000B3A RID: 2874
	public class ThoughtWorker_EMPdevice : ThoughtWorker
	{
		// Token: 0x06004930 RID: 18736 RVA: 0x00198010 File Offset: 0x00196210
		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			if ((p.apparel.WornApparel.Any(a => a.def.defName == "mostlytraits_EMPdevice"))){
				Apparel empDevice = p.apparel.WornApparel.Find(a => a.def.defName == "mostlytraits_EMPdevice");
				CompReloadable reloadable = empDevice.GetComp<CompReloadable>();
				int remainingCharges = reloadable.RemainingCharges;
	

				if (remainingCharges < 1)
				{

					empDevice.Destroy(DestroyMode.Vanish);
				}
			}
			

			return false;
		}
	}
}