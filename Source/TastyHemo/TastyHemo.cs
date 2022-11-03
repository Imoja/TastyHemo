using System.Reflection;
using System.Linq;
using Verse;
using RimWorld;
using UnityEngine;
using HarmonyLib;

namespace TastyHemoBeta
{
	public class Mod : Verse.Mod
	{
		public Mod(ModContentPack content) : base(content)
		{

			new Harmony("Imoja.rimworld.TastyHemoBeta.main").PatchAll();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			base.DoSettingsWindowContents(inRect);
			GetSettings<Settings>().DoWindowContents(inRect);
		}

		public override string SettingsCategory()
		{
			return "TastyHemoBeta";
		}
	}
}