// NULLcode Studio © 2016
// null-code.ru

// этот скрипт будет работать только в редакторе
#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Localization))]

public class LocalizationEditor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		Localization lcz = (Localization)target;
		if(GUILayout.Button("Build Default Locale"))
		{
			lcz.BuildDefaultLocale();
		}
	}
}
#endif
