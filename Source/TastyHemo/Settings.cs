using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using System.Globalization;
using System.Linq;
using RimWorld;
using Verse.Sound;

namespace TastyHemo
{
	internal class DefaultValues
	{
		public const float TastyHemo_NutritionfromBloodFeed = 0.2f;
		public const float TastyHemo_NutritionfromHemogenPack = 1.0f;
	}
	public class IMJ_Settings : ModSettings
	{

		public static float TH_NutritionfromBloodFeed = DefaultValues.TastyHemo_NutritionfromBloodFeed;

		public void DoWindowContents(Rect inRect)
		{
			var options = new Listing_Standard();
			options.Begin(inRect);

			options.Label("Food gained from BloodFeeding : " + TH_NutritionfromBloodFeed.ToString("0.00") + " (1.0 is 100%)");
			TH_NutritionfromBloodFeed = options.Slider(TH_NutritionfromBloodFeed, 0.00f, 2.00f);

			options.Gap();

			options.End();
		}

		public override void ExposeData()
		{
			Scribe_Values.Look(ref TH_NutritionfromBloodFeed, "TastyHemo_NutritionfromBloodFeed");
		}
	}
}