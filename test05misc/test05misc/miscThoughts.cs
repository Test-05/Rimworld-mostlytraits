
using Verse;
using RimWorld;

namespace mostlytraits
{
    [DefOf]
    public static class miscThoughts
    {

        // Token: 0x06009642 RID: 38466 RVA: 0x00369B66 File Offset: 0x00367D66
        static miscThoughts()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThoughtDefOf));
        }


        public static ThoughtDef mostlytraits_failed_surgery;
        public static ThoughtDef mostlytraits_surgery_death;
        public static ThoughtDef mostlytraits_foodie_atefinemeal;
        public static ThoughtDef mostlytraits_foodie_atelavishmeal;
        public static ThoughtDef mostlytraits_smoke_bad_mood;
        public static ThoughtDef mostlytraits_smoke_good_mood;


    }
}
