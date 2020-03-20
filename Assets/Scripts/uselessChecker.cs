using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Проверяет, использовался ли выбранный файл в какой-либо сцене и если да, то в какой
/// Добавляется в контекстное меню файлов в папке проекта
/// </summary>
public static class SystemObjectFindUsables
{
    [MenuItem("Assets/Где используется?")]
    public static void CheckUsables()
    {
        var path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (string.IsNullOrEmpty(path))
        {
            Debug.LogWarning("Выберите файл из проекта для проверки на использование");
            return;
        }

        var guid = AssetDatabase.AssetPathToGUID(path);
        var references = GetReferencesScenes(guid);
        Debug.Log("[" + Path.GetFileName(path) + "] Связанные сцены: " + references.Count + "\n" + string.Join("\n", references.ToArray()));  
    }

    private static List<string> GetReferencesScenes(string guid)
    {
        var paths = AssetDatabase.GetAllAssetPaths();
        var result = new List<string>();
        foreach (var path in paths)
        {
            if (!path.EndsWith(".unity"))
                continue;

            var sceneAsText = File.ReadAllText(path);
            if (sceneAsText.Contains(guid))
                result.Add(path);
        }
        return result;
    }
}