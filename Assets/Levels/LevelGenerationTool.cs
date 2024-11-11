using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class LevelGenerationTool : EditorWindow
{
    private string levelName;
    private List<string> words = new List<string>();
    private List<string> sentences = new List<string>();
    private int complexity;

    [MenuItem("Tools/Word Puzzle Level Generator")]
    public static void ShowWindow()
    {
        GetWindow<LevelGenerationTool>("Level Generator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Level Settings", EditorStyles.boldLabel);

        levelName = EditorGUILayout.TextField("Level Name", levelName);
        complexity = EditorGUILayout.IntSlider("Complexity", complexity, 1, 10);

        GUILayout.Label("Words", EditorStyles.boldLabel);
        for (int i = 0; i < words.Count; i++)
        {
            words[i] = EditorGUILayout.TextField("Word " + (i + 1), words[i]);
        }

        if (GUILayout.Button("Add Word"))
        {
            words.Add("");
        }
        if (GUILayout.Button("Remove Last Word"))
        {
            if (words.Count > 0) words.RemoveAt(words.Count - 1);
        }

        GUILayout.Label("Correct Sentences", EditorStyles.boldLabel);
        for (int i = 0; i < sentences.Count; i++)
        {
            sentences[i] = EditorGUILayout.TextField("Sentence " + (i + 1), sentences[i]);
        }

        if (GUILayout.Button("Add Sentence"))
        {
            sentences.Add("");
        }
        if (GUILayout.Button("Remove Last Sentence"))
        {
            if (sentences.Count > 0) sentences.RemoveAt(sentences.Count - 1);
        }

        if (GUILayout.Button("Save Level"))
        {
            SaveLevel();
        }
    }

    private void SaveLevel()
    {
        LevelData levelData = ScriptableObject.CreateInstance<LevelData>();
        levelData.levelName = levelName;
        levelData.words = new List<string>(words);
        levelData.correctSentences = new List<string>(sentences);
        levelData.complexity = complexity;

        string path = $"Assets/Levels/{levelName}.asset";
        AssetDatabase.CreateAsset(levelData, path);
        AssetDatabase.SaveAssets();

        EditorUtility.DisplayDialog("Level Saved", "Level saved successfully!", "OK");
    }
}
