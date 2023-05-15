using System;
using RimWorld;
using System.Reflection;
using Verse;

namespace mostlytraits
{
    [DefOf]
    internal class miscTraits
    {
        static miscTraits()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(miscTraits));
        }
#pragma warning disable 0649
        public static TraitDef mostlytrait_defender;

        public static TraitDef blind_psy;

        public static TraitDef test;

        public static TraitDef weird_neutral05;

        public static TraitDef slick05;

        public static TraitDef professional_miner;

        public static TraitDef table_enjoyer;

        public static TraitDef mostlytraits_foodie;

        public static TraitDef hard_work05;

        public static TraitDef mostlytraits_gangster;

        public static TraitDef mostlytraits_veteran;

        public static TraitDef MassOffset;

        public static TraitDef introverted05;

        public static TraitDef mostlytraits_good_builder;

        public static TraitDef mostlytraits_creative;

        public static TraitDef fast_load;

        public static TraitDef mostlytraits_combat_medic;

        public static TraitDef mostlytraits_surgeon;

        public static TraitDef mostlytraits_empathetic;

        public static TraitDef mostlytrait_epiphany;

        public static TraitDef mostlytraits_accoffset;

        public static TraitDef mostlytraits_shaky;

#pragma warning restore 0649
    }
}
