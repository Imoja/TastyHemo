using System.Reflection;
using System.Linq;
using Verse;
using RimWorld;
using UnityEngine;
using HarmonyLib;

namespace TastyHemoBeta.HarmonyPatches
{
	// The contents of this file were typed under the most gracious tutelage of "Feldoh - The Third Guava".
	[HarmonyPatch(typeof(SanguophageUtility), "DoBite")]
	public static class PatchDoBite
	{
		public static bool Prefix(Pawn biter, Pawn victim, ref float nutritionGain)
		{
			if (!victim.Dead)
			{
				biter.needs.mood?.thoughts?.memories?.TryGainMemory(ThoughtDef.Named("IMJ_LavishSippy"));
				nutritionGain = Settings.TH_NutritionfromBloodFeed * victim.BodySize;
			}
			else
			{
				biter.needs.mood?.thoughts?.memories?.TryGainMemory(ThoughtDef.Named("IMJ_BadSippy"));
				nutritionGain = 0.5f * victim.BodySize;
			}
			return true;
		}
	}

	//	[HarmonyPatch(typeof(TargetingParameters), "ForBloodfeeding")]
	//	public static class PatchforBloodfeeding
	//	{
	//		public static void Postfix(ref TargetingParameters __result)
	//		{
	//			__result.canTargetCorpses = true;
	//		}
	//  }

	//	[HarmonyPatch(typeof(CompAbilityEffect_BloodfeederBite), "Apply")]
	//	public static class PatchCompAbilityEffect_BloodfeederBite
	//	{
	//		public static void Prefix(LocalTargetInfo target, LocalTargetInfo dest)
	//		{
	//			base.Apply(target, dest);
	//			Pawn pawn = target.Pawn;
	//			SanguophageUtility.DoBite(this.parent.pawn, pawn, this.Props.hemogenGain, this.Props.nutritionGain, this.Props.targetBloodLoss, this.Props.resistanceGain, this.Props.bloodFilthToSpawnRange, this.Props.thoughtDefToGiveTarget, this.Props.opinionThoughtDefToGiveTarget);
	//			return;
	//		}
	//	}
}