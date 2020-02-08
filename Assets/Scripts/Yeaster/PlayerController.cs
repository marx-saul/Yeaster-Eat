using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float width  { private set; get; }
    public float height { private set; get; }
    private YeasterHeadManager yeasterHeadManager;
    
    // Start is called before the first frame update
    void Start()
    {
        width  = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        height = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        yeasterHeadManager = gameObject.GetComponent<YeasterHeadManager>();
        yeasterHeadManager.InitializeDirection(YeasterDirection.Right);
    }
    
    private bool leftPushed = false, rightPushed = false, upPushed = false, downPushed = false;
    // Update is called once per frame
    void Update()
    {
        // get key down during the stopping frames
        leftPushed  = leftPushed  || Input.GetKeyDown(KeyCode.LeftArrow);
        rightPushed = rightPushed || Input.GetKeyDown(KeyCode.RightArrow);
        upPushed    = upPushed    || Input.GetKeyDown(KeyCode.UpArrow);
        downPushed  = downPushed  || Input.GetKeyDown(KeyCode.DownArrow);
        
        // accept key inputs if frameMod = 0;
        if (!FrameCounter.Instance.IsRightFrame()) {
            return;
        }
        
        // change direction
        if      (leftPushed)  { yeasterHeadManager.ChangeDirection(YeasterDirection.Left);  }
        else if (rightPushed) { yeasterHeadManager.ChangeDirection(YeasterDirection.Right); }
        else if (upPushed)    { yeasterHeadManager.ChangeDirection(YeasterDirection.Up);    }
        else if (downPushed)  { yeasterHeadManager.ChangeDirection(YeasterDirection.Down);  }
        
        // reset key down
        leftPushed  = false;
        rightPushed = false;
        upPushed    = false;
        downPushed  = false;
        
    }
}
