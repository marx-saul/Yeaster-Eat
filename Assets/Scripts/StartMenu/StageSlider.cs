using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSlider : MonoBehaviour
{
    public GameObject StageText;
    
    public void OnValueChanged() {
        StageText.GetComponent<Text>().text = "Stage: " + Mathf.RoundToInt(GetComponent<Slider>().value).ToString();
    }
}
