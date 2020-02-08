using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeasterHeadManager : MonoBehaviour
{
    public GameObject PlayerBodyObject;
    public int score { get; private set; } = 0;
    public void PlusScore(int num) {
        int prevScore = score;
        score += num;
        // grow
        var growNum = score/GameData.GrowPerScore - prevScore/GameData.GrowPerScore;
        if (num > 0 && growNum > 0 ) { PlayerBodyObject.GetComponent<YeasterBodyManager>().Add(growNum); }
    }
    
    public YeasterDirection direct { private set; get; }
    public void ChangeDirection(YeasterDirection dir) {
        if (GameData.IsTurnable(direct, dir)) { direct = dir; }
    }
    public void InitializeDirection(YeasterDirection dir) { direct = dir; }
    
    public float width  { private set; get; }
    public float height { private set; get; }
    
    // Start is called before the first frame update
    void Start()
    {
        width  = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        height = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
    }
    
    // Update is called once per frame
    void Update()
    {   
        if (!FrameCounter.Instance.IsRightFrame()) {
            return;
        }
        // move direction
        var dr = new Vector3(0, 0);
        if      ( direct == YeasterDirection.Left  ) { dr = new Vector3(-width, 0); }
        else if ( direct == YeasterDirection.Right ) { dr = new Vector3(+width, 0); }
        else if ( direct == YeasterDirection.Up    ) { dr = new Vector3(0, +height); }
        else if ( direct == YeasterDirection.Down  ) { dr = new Vector3(0, -height); }
        transform.position += dr;   
    }
    
}
