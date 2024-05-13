using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

namespace WeatherElectric.UnitySceneAutoSave
{

	[InitializeOnLoad]
	public class AutoSaver
	{
		private static AutoSaveSettings _settings;
		private static float _lastSaveTime;


		static AutoSaver()
		{
			EditorApplication.update += Update;
			
			Init();
		}
		
		private static void Init()
		{
			string[] assetGuids = AssetDatabase.FindAssets("t:AutoSaveSettings");
			if (assetGuids.Length > 0)
			{
				string assetPath = AssetDatabase.GUIDToAssetPath(assetGuids[0]);
				_settings = AssetDatabase.LoadAssetAtPath<AutoSaveSettings>(assetPath);
				
				for (int i = 1; i < assetGuids.Length; i++)
				{
					string extraAssetPath = AssetDatabase.GUIDToAssetPath(assetGuids[i]);
					AssetDatabase.DeleteAsset(extraAssetPath);
					Debug.Log($"Deleted extra AutoSaveSettings at: {extraAssetPath}");
				}
			}
			else
			{
				_settings = ScriptableObject.CreateInstance<AutoSaveSettings>();
				AssetDatabase.CreateAsset(_settings, "Assets/AutoSaveSettings.asset");
				AssetDatabase.SaveAssets();
			}
		}


		private static void Update()
		{
			if (!_settings.Enabled) return;
			if (EditorApplication.timeSinceStartup - _lastSaveTime > _settings.AutoSaveInterval)
			{
				SaveScene();
				_lastSaveTime = (float)EditorApplication.timeSinceStartup;
			}
		}

		private static void SaveScene()
		{
			if (EditorSceneManager.SaveOpenScenes())
			{
				Debug.Log("Scene saved at: " + System.DateTime.Now);
			}
			else
			{
				Debug.LogWarning("Failed to save scene!");
			}
		}
	}
}