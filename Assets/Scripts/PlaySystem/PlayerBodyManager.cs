using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBodyManager : MonoBehaviour
{
    public GameObject PlayerBodyPrefab;     // Yeaster-Cell
    public GameObject PlayerBodyObject;     // PlayerBody
    public GameObject PlayerHead;                       // PlayerHead
    private GameObject FrameCounter;
    private GameObject[] Cells = new GameObject[1];     // this array has PlayerHead as its top.
    
    // initialize
    void Start()
    {
        Cells[0] = PlayerHead;
        // generate
        for (int i=0; i < GameData.InitBodySize; i++) {
            Add();
        }
        FrameCounter = GameObject.Find("FrameCounter");
    }
    
    // grow
    public void Add() {
        var TailPos  = Cells[Cells.Length-1].transform.position; // the position of the PlayerHead
        var HeadSizeX = PlayerHead.GetComponent<SpriteRenderer>().bounds.size.x;
        // generate
        GameObject tmp = Instantiate(PlayerBodyPrefab, PlayerBodyObject.transform);
        tmp.transform.position = TailPos - ( new Vector3(HeadSizeX, 0) );
        // add to the array
        Array.Resize(ref Cells, Cells.Length+1);
        Cells[Cells.Length-1] = tmp;
    }
    
    // Update is called once per frame
    // this is called before executing the player's input to player-head.
    void Update()
    {
        if (!FrameCounter.GetComponent<FrameCounter>().isRightFrame()) { return; }
        
        // move to the next cell
        // after this, player-head moves.
        foreach ( var i in Enumerable.Range(1, Cells.Length-1).Reverse() ) {
            Cells[i].transform.position = Cells[i-1].transform.position; 
        }
        
    }
}
