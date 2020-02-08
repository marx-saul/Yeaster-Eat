using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : SingletonMonoBehaviour<ItemManager>
{
    // count the number of items that appeared in the stage.
    public  int itemNum { get; private set; } = 0;
    private int stageNum = 1;
    public  GameObject parentObject;
    
    public void Init(int stageNum) {
        this.stageNum = stageNum;
        itemNum = 0;
        // the code below does not work because the coroutine is called before the scene is loaded and Awake's are called.
        //GenerateItem();
        //RandomlyGenerateItem();
    }
    
    private void Start() {
        RandomlyGenerateItem();
    }
    
    // life span end
    public void ItemRemoved(GameObject item) {
        Destroy(item);
        GenerateItem();
    }
    
    // player got the item
    public void ItemGet(GameObject item) {
        Destroy(item);
        GenerateItem();
    }
    
    // generate item
    private void GenerateItem() {
        itemNum++;
        var generateItem = WaitRandomlyGenerateItem();
        StartCoroutine(generateItem);
    }
    
    // randomly generate item
    private IEnumerator WaitRandomlyGenerateItem( int minMsec = 30, int maxMsec = 80 ) {
        var rand = new System.Random();
        yield return new WaitForSeconds(rand.Next(minMsec, maxMsec)/10.0f);
        
        RandomlyGenerateItem();
    }
    
    private void RandomlyGenerateItem( int minMsec = 30, int maxMsec = 80 ) {
        var ItemType = GameData.ItemAppearProb[stageNum-1].GetByRouletteSelection();
        var tmp = Instantiate ( ItemType, parentObject.transform );
        tmp.transform.position += RandomPosition();
        tmp.transform.parent = parentObject.transform;
    }
    
    // generate the item in the random position
    private float width = 0.16f, height = 0.16f; 
    private Vector3 RandomPosition() {
        var rand = new System.Random();
        int x_grid = 0, y_grid = 0;
        if (stageNum == 1) {
            x_grid = (rand.Next(0, 77)*2 - 77);
            y_grid = (rand.Next(0, 27)*2 - 27);
            // avoid the center wall
            if ( x_grid * x_grid == 1 && -9 <= y_grid && y_grid <= 9 ) {
                x_grid *= (rand.Next(0,1)*6 - 3);
            }
        }
        return new Vector3(x_grid*width, y_grid*height);
    }
}
