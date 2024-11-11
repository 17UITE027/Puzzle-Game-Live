using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "NewLevel", menuName = "WordPuzzle/Level")]
public class LevelData : ScriptableObject
{
    public string levelName;
    public List<string> words;         
    public List<string> correctSentences; 
    public int complexity;              
}
