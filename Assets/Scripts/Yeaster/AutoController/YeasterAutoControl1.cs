using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class YeasterAutoControl1 : YeasterAutoController
{
    public readonly float TurnProbability = 0.05f;
    public readonly float WallProbabilityMagnification = 2.5f;
    
    public GameObject HeadObject;
    private YeasterHeadManager headManager;
    
    void Start()
    {
        headManager = HeadObject.GetComponent<YeasterHeadManager>();
        headManager.ChangeDirection(YeasterDirection.Up);
    }
    
    // this update must be executed before YeasterHeadManager, after TurnSensor.
    void Update()
    {
        if (!FrameCounter.Instance.IsRightFrame()) { return; }
        
        // directions you can turn
        var TurnableDirections
          = TouchedDirection.Keys.Where(
              dir => !TouchedDirection[dir] && GameData.IsTurnable(headManager.direct, dir)
            ).ToList();
        // avoid sticking to walls
        float ProbRatio = (TurnableDirections.Count() < 3) ? WallProbabilityMagnification : 1.0f;
        // touched and it must turn, or sometimes randomly turning
        if ( TouchedDirection[headManager.direct] || UnityEngine.Random.value <= TurnProbability*ProbRatio) {
            foreach (var i in TurnableDirections) { Debug.Log(i.ToString()); }
            headManager.ChangeDirection( TurnableDirections[UnityEngine.Random.Range(0, TurnableDirections.Count())] );
        }
        
    }
}
