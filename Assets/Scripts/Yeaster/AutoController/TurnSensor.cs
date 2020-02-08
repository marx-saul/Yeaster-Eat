using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSensor : MonoBehaviour
{
    public YeasterDirection SensorDirection;
    public GameObject HeadObject;
    private YeasterAutoController yeasterAutoController;
    
    void Start() {
        yeasterAutoController = HeadObject.GetComponent<YeasterAutoController>();
    }
    
    void OnTriggerStay2D(Collider2D col) {
        // sensor
        yeasterAutoController.TouchedDirection[SensorDirection] = true;
        
    }
    void OnTriggerExit2D(Collider2D col) {
        // sensor
        yeasterAutoController.TouchedDirection[SensorDirection] = false;
    }
}
