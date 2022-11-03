using System.Reflection;
using System.Linq;
using Verse;
using RimWorld;
using UnityEngine;
using HarmonyLib;

namespace TastyHemo
{
	public class IMJ_Mod : Verse.Mod
	{
		public IMJ_Mod(ModContentPack content) : base(content)
		{

			new Harmony("Imoja.rimworld.TastyHemoBeta.main").PatchAll();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			base.DoSettingsWindowContents(inRect);
			GetSettings<IMJ_Settings>().DoWindowContents(inRect);
		}

		public override string SettingsCategory()
		{
			return "TastyHemo";
		}
	}
}