using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject stageSlide;
    
    // load stage when the button is clicked
    public void OnClick() {
        GameMaster.Instance.LoadStage(Mathf.RoundToInt(stageSlide.GetComponent<Slider>().value));
    }
}
