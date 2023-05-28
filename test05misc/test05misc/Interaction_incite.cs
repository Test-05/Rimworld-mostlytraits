
	using Verse;
	using RimWorld;
	namespace mostlytraits
	{

		public class InteractionWorker_incite : InteractionWorker
		{
		// Token: 0x06000003 RID: 3 RVA: 0x0000208C File Offset: 0x0000028C
		public override float RandomSelectionWeight(Pawn initiator, Pawn recipient)
		{

		
			if (initiator.RaceProps.Humanlike && initiator.story.traits.HasTrait(miscTraits.mostlytraits_gangster))
			{
				
				float num = this.moodCurve.Evaluate(initiator.needs.mood.CurLevel) * this.opinionCurve.Evaluate(initiator.relations.OpinionOf(recipient)) * this.compatbilityCurve.Evaluate(initiator.relations.CompatibilityWith(recipient));

				return num;
			}
			return 0f;
		}

		public SimpleCurve opinionCurve = new SimpleCurve
		{
			{
				new CurvePoint(-100, 1.75f),
				true
			},
			{
				new CurvePoint(-80, 1.5f),
				true
			},
			{
				new CurvePoint(-60, 1.4f),
				true
			},
			{
				new CurvePoint(-40, 1.25f),
				true
			},
			{
				new CurvePoint(-20, 1.1f),
				true
			},
			{
				new CurvePoint(0, 1f),
				true
			},
			{
				new CurvePoint(20, 0.75f),
				true
			},
			{
				new CurvePoint(40, 0.5f),
				true
			},
			{
				new CurvePoint(60, 0.3f),
				true
			},
			{
				new CurvePoint(80, 0.15f),
				true
			},
			{
				new CurvePoint(100, 0.05f),
				true
			}
		};
		public SimpleCurve moodCurve = new SimpleCurve
		{
			{
				new CurvePoint(0f, 2f),
				true
			},
			{
				new CurvePoint(0.1f, 1f),
				true
			},
			{
				new CurvePoint(0.2f, 0.8f),
				true
			},
			{
				new CurvePoint(0.3f, 0.65f),
				true
			},
			{
				new CurvePoint(0.5f, 0.3f),
				true
			},
			{
				new CurvePoint(0.7f, 0.1f),
				true
			},
			{
				new CurvePoint(0.9f, 0.05f),
				true
			}
		};
		public SimpleCurve compatbilityCurve = new SimpleCurve
		{
			{
				new CurvePoint(-3f, 3f),
				true
			},
			{
				new CurvePoint(-2f, 2f),
				true
			},
			{
				new CurvePoint(-1f, 1.5f),
				true
			},
			{
				new CurvePoint(0f, 1f),
				true
			},
			{
				new CurvePoint(1f, 0.5f),
				true
			},
			{
				new CurvePoint(2f, 0.3f),
				true
			},
			{
				new CurvePoint(3f, 0.1f),
				true
			}
		};

	}
	}

