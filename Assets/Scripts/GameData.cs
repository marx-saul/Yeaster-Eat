using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static readonly uint MovePerFrame = 5;
    public static readonly uint InitBodySize = 4;
    
    public static readonly Dictionary<string, uint> ItemScore = new Dictionary<string, uint>() {
        { "Chocolate", 10 }
    };
    
    public static bool IsItemTag(string tag) {
        return ItemScore.ContainsKey(tag);
    }
}
