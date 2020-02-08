using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCounter : SingletonMonoBehaviour<FrameCounter>
{
    private uint FrameMod = 0;
    private int PausingFrame = 20;
    
    public void Init(int frames) {
        PausingFrame = frames;
        FrameMod = 0;
    }
    
    public bool IsRightFrame() {
        return PausingFrame <= 0 && FrameMod == 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (PausingFrame > 0) {
            PausingFrame--;
            return;
        }
        FrameMod++;
        FrameMod %= GameData.MovePerFrame;
    }
}
