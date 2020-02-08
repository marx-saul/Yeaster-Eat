using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class YeasterBodyManager : MonoBehaviour
{
    public  GameObject YeasterBodyPrefab;     // Yeaster-Cell
    public  GameObject YeasterBodyObject;     // Body
    public  GameObject YeasterHead;                       // Head
    private GameObject[] Cells = new GameObject[1];     // this array has YeastHead as its top.
    
    // initialize
    void Start()
    {
        Cells[0] = YeasterHead;
        
        // generate (see Update)
        LeftToAdd = GameData.InitBodySize + YeasterHead.GetComponent<YeasterHeadManager>().score/GameData.GrowPerScore;
        
    }
    
    // grow
    private void Add() {
        var TailPos  = Cells[Cells.Length-1].transform.position; // the position of the Tail
        var HeadSizeX = YeasterHead.GetComponent<SpriteRenderer>().bounds.size.x;
        var diff = Cells.Length >= 2 ? TailPos - Cells[Cells.Length-2].transform.position : new Vector3(-HeadSizeX, 0);
        // generate
        GameObject tmp = Instantiate(YeasterBodyPrefab, YeasterBodyObject.transform);
        tmp.transform.position = TailPos + diff;
        // add to the array
        Array.Resize(ref Cells, Cells.Length+1);
        Cells[Cells.Length-1] = tmp;
    }
    public void Add(int num) {
        if (num >= 0) { LeftToAdd += num; }
    }
    
    private int LeftToAdd = 0;
    
    // Update is called once per frame
    // this is called before executing the player's input to player-head.
    void Update()
    {
        if (!FrameCounter.Instance.IsRightFrame()) { return; }
        
        // growing in every step
        if (LeftToAdd > 0) {
            Add();
            LeftToAdd--;
        }
        
        // move to the next cell
        // after this, player-head moves.
        // Update order is set.
        foreach ( var i in Enumerable.Range(1, Cells.Length-1).Reverse() ) {
            Cells[i].transform.position = Cells[i-1].transform.position; 
        }
        
    }
}
