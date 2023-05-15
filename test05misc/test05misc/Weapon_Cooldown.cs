using System;
using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;

namespace mostlytraits
{
	// Token: 0x020002AD RID: 685

	[StaticConstructorOnStartup]
	public static class CooldownPatch
	{
		static CooldownPatch()
		{

			Harmony harmony = new Harmony("mostlytraits");
			MethodInfo original = AccessTools.Method(typeof(VerbProperties), "AdjustedCooldown", new Type[] { typeof(Tool),typeof(Pawn), typeof(Thing) });
			HarmonyMethod postfix = new HarmonyMethod(typeof(CooldownPatch).GetMethod("Postfix"));
			harmony.Patch(original, null,postfix);
		}
		
		public static void Postfix(VerbProperties __instance, ref float __result, Tool tool, Pawn attacker, Thing equipment)
		{



			if (attacker != null && __instance != null && equipment != null && tool == null)
			{
				__result *= attacker.GetStatValue(miscStats.mostlytraits_ranged_cooldown, true, -1);
			}
			else if (attacker != null && __instance != null && equipment != null && tool != null)
			{
				__result *= attacker.GetStatValue(miscStats.mostlytraits_melee_cooldown, true, -1);
			}
			




		}
	}
}