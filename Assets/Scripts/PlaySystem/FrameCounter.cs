using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCounter : MonoBehaviour
{
    private uint FrameMod = 0;
    
    public bool isRightFrame() {
        return FrameMod == 0;
    }
    
    /*
    class A { public int x = 0; }
    private void change(A a) { a.x = 100; }
    void Start() {
        var a = new A();
        change(a);
        Debug.Log(a.x); // 100
    }
    */
    
    // Update is called once per frame
    void Update()
    {
        FrameMod++;
        FrameMod %= GameData.MovePerFrame;
    }
}
