using UnityEngine;

namespace WeatherElectric.UnitySceneAutoSave
{
	public class AutoSaveSettings : ScriptableObject
	{
		[Tooltip("Whether to even auto save or not")]
		public bool Enabled = true;
		[Tooltip("How long between autosaves, in seconds")]
		public float AutoSaveInterval = 300f;
	}
}