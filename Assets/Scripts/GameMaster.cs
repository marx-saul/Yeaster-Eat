using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : SingletonMonoBehaviour<GameMaster>
{   
    public uint Score = 0;
    
    // increase the score
    //void ItemGet(GameObject) {
    //    if (GameData.IsItemTag(name)) { Score += GameData.ItemScore[name]; }
    //}
    
    public void Missed() {
        Debug.Log("Missed!");
    }
}
