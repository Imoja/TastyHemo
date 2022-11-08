using System.Reflection;
using System.Linq;
using Verse;
using RimWorld;
using UnityEngine;
using HarmonyLib;

namespace TastyHemo.HarmonyPatches
{
	// The contents of this file were typed under the most gracious tutelage of "Feldoh - The Third Guava".
	[HarmonyPatch(typeof(SanguophageUtility), "DoBite")]
	public static class PatchDoBite
	{
		public static bool Prefix(Pawn biter, Pawn victim, ref float nutritionGain)
		{
			if (!victim.Dead)
			{
				nutritionGain = IMJ_Settings.TH_NutritionfromBloodFeed * victim.BodySize;
				if (IMJ_Settings.TH_MoodletfromBloodFeed) {
					biter.needs.mood?.thoughts?.memories?.TryGainMemory(ThoughtDef.Named("IMJ_LavishSippy"));
				}
			}/*
			else
			{
				nutritionGain = 0.2f * victim.BodySize;
				if (IMJ_Settings.TH_MoodletfromBloodFeed) {
					biter.needs.mood?.thoughts?.memories?.TryGainMemory(ThoughtDef.Named("IMJ_BadSippy"));
				}
			}*/
			return true;
		}
	}
}

	/*
	[HarmonyPatch(typeof(JobGiver_GetFood), "TryGiveJob")]
	public static class PatchTryGiveJob
	{
		public static void Postfix(Pawn pawn)
		{
			Pawn_GeneTracker genes = pawn.genes;
			if (((genes != null) ? genes.GetFirstGeneOfType<Gene_Hemogen>() : null) != null && ModsConfig.BiotechActive)
			{
				Thing thing = FoodUtility.BestFoodSourceOnMap(pawn, pawn, true, out ThingDefOf.HemogenPack,
					FoodPreferability.Undefined, false, false, false, false, false, false, true, false, true, false, false, FoodPreferability.Undefined);
				JobMaker.MakeJob(JobDefOf.Ingest, thing);
			}
		} //check "thing" is not null, 
	}

		
/*		public static void Postfix(ref bool __result, Pawn getter, Pawn eater, ref Thing foodSource, ref ThingDef foodDef, bool canUseInventory, bool canUsePackAnimalInventory)
		{
			if (eater.IsFreeColonist && __result == false && canUseInventory && canUsePackAnimalInventory &&
				getter.RaceProps.ToolUser && getter.health.capacities.CapableOf(PawnCapacityDefOf.Manipulation))
			{
				Log.Message($"There be no food for " + eater);
				List<Pawn> pawns = eater.Map.mapPawns.SpawnedPawnsInFaction(Faction.OfPlayer).FindAll(
					p => p != getter &&
					!p.Position.IsForbidden(getter) &&
					getter.CanReach(p, PathEndMode.OnCell, Danger.Some)
				);
				foreach (Pawn p in pawns)
				{
					Log.Message($"Food soon rotten on " + p + "?");
					Thing thing = FoodUtility.BestFoodInInventory(p, eater, FoodPreferability.MealAwful);
					if (thing != null && thing.TryGetComp<CompRottable>() is CompRottable compRottable &&
						compRottable != null && compRottable.Stage == RotStage.Fresh && compRottable.TicksUntilRotAtCurrentTemp < GenDate.TicksPerDay / 2)
					{
						Log.Message($"Food is " + thing);
						foodSource = thing;
						foodDef = FoodUtility.GetFinalIngestibleDef(foodSource, false);
						__result = true;
						return;
					}
				}
				foreach (Pawn p in pawns)
				{
					Log.Message($"Food on " + p + "?");
					Thing thing = FoodUtility.BestFoodInInventory(p, eater, FoodPreferability.DesperateOnly, FoodPreferability.MealLavish, 0f, !eater.IsTeetotaler());
					if (thing != null)
					{
						Log.Message($"Food is " + thing);
						foodSource = thing;
						foodDef = FoodUtility.GetFinalIngestibleDef(foodSource, false);
						__result = true;
						return;
					}
				}
			}
		}
*/




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