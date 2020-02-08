using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum YeasterDirection { Left, Right, Up, Down }

public static class GameData
{
    public static bool IsTurnable(YeasterDirection from, YeasterDirection to) {
        return (to == YeasterDirection.Left  && from != YeasterDirection.Right)
            || (to == YeasterDirection.Right && from != YeasterDirection.Left )
            || (to == YeasterDirection.Up    && from != YeasterDirection.Down )
            || (to == YeasterDirection.Down  && from != YeasterDirection.Up   );
    }
    public static readonly int  StageNumber  = 2;
    public static readonly uint MovePerFrame = 5;
    public static readonly int  InitBodySize = 4;
    public static readonly int  GrowPerScore = 100;
    private static GameObject Chocolate = (GameObject)Resources.Load("Prefabs/Chocolate");
    private static GameObject WhiteChocolate = (GameObject)Resources.Load("Prefabs/WhiteChocolate");
    public static Dictionary<GameObject, int>[] ItemAppearProb = new Dictionary<GameObject, int>[2] {
        // stage 1
        new Dictionary<GameObject, int>() {
            { Chocolate, 85 }, { WhiteChocolate, 15 }
        },
        
        new Dictionary<GameObject, int> () {
            { Chocolate, 85 }, { WhiteChocolate, 15 }
        },
    };
    
}
