using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerDirection { Left, Right, Up, Down }

public class PlayerController : MonoBehaviour
{
    public PlayerDirection direct { private set; get; }
    private float width, height;
    private GameObject FrameCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        direct = PlayerDirection.Right;
        width  = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        height = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        FrameCounter = GameObject.Find("FrameCounter");
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
        if (!FrameCounter.GetComponent<FrameCounter>().isRightFrame()) {
            return;
        }
        // change direction
        if      ( leftPushed  && direct != PlayerDirection.Right ) { direct = PlayerDirection.Left;  }
        else if ( rightPushed && direct != PlayerDirection.Left  ) { direct = PlayerDirection.Right; }
        else if ( upPushed    && direct != PlayerDirection.Down  ) { direct = PlayerDirection.Up;    }
        else if ( downPushed  && direct != PlayerDirection.Up    ) { direct = PlayerDirection.Down;  }
        
        // move direction
        var dr = new Vector3(0, 0);
        if      ( direct == PlayerDirection.Left  ) { dr = new Vector3(-width, 0); }
        else if ( direct == PlayerDirection.Right ) { dr = new Vector3(+width, 0); }
        else if ( direct == PlayerDirection.Up    ) { dr = new Vector3(0, +height); }
        else if ( direct == PlayerDirection.Down  ) { dr = new Vector3(0, -height); }
        transform.position += dr;
        
        // reset key down
        leftPushed  = false;
        rightPushed = false;
        upPushed    = false;
        downPushed  = false;
        
    }
}
