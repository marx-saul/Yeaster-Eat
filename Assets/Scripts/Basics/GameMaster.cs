using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : SingletonMonoBehaviour<GameMaster>
{
    //public int score { get; private set; } = 0;
    // stage number
    private int stageNum = 0;
    
    //public void PlusScore(int num) {
    //    int prevScore = score;
    //    score += num;
    //    // grow
    //    var growNum = score/GameData.GrowPerScore - prevScore/GameData.GrowPerScore;
    //    if (num > 0 && growNum > 0 ) {
    //        GameObject.Find("PlayerBody").GetComponent<YeasterBodyManager>().Add(growNum);
    //    }
    //}
    
    public void LoadStage(int num) {
        var sceneName = (num > 0 ? "Stage" + num.ToString() : "StartMenu" );
        // load scene
        SceneManager.LoadScene(sceneName);
        // initialize
        stageNum = num;
        FrameCounter.Instance.Init(75);    // this must be after LoadScene
        ItemManager.Instance.Init(stageNum);
    }
    
    
    // increase the score
    //void ItemGet(GameObject) {
    //    if (GameData.IsItemTag(name)) { Score += GameData.ItemScore[name]; }
    //}
    
    public void Missed() {
        Debug.Log("Missed!");
    }
    
    private bool StageClearCondition() {
        if (stageNum == 1) { return ItemManager.Instance.itemNum == 10; }
        return false;
    }
    
    private void Update() {
        if (StageClearCondition()) {
            stageNum++;
            if (stageNum > GameData.StageNumber) { stageNum = 1; }
            LoadStage(stageNum);
        }
    }
}
