
using System.Text;
using HarmonyLib;
using RimWorld;
using Verse;

namespace mostlytraits
{
	[StaticConstructorOnStartup]

	public static class Spectrum_Trait_Mass
	{
		static Spectrum_Trait_Mass()
		{
			Harmony harmony = new Harmony("mostlytraits");

			harmony.Patch(AccessTools.Method(typeof(MassUtility), "Capacity"),

				postfix: new HarmonyMethod(typeof(Spectrum_Trait_Mass), nameof(New_Mass)));
		}



		public static float New_Mass(float capacity, Pawn p)

		{

			float num = capacity;
			float num2;

			if (p.def.race.Humanlike)
			{


				/*if (p.story.traits.HasTrait(miscTraits.MassOffset) && num > 0)
				{
					Trait MassOffset = p.story.traits.GetTrait(miscTraits.MassOffset);


					switch (MassOffset.Degree)
					{
						case 0:
							num -= 10f;
							break;
						case 1:
							num -= 5f;
							break;
						case 2:
							num += 10f;
							break;
						case 3:
							num += 15f;
							break;
						default:
							break;
					}


				}*/
				num += p.GetStatValue(miscStats.mostlytraits_carry_mass_offset, true, -1);

				if (p.def.race.Humanlike && p.health.hediffSet.HasHediff(miscHediffDefs.mostlytraits_installed_exoskeleton))
				{

					num2 = 15f;
					num += num2;
				}
				return num;

			}
			return num;
		}
		}
	}



	
	


