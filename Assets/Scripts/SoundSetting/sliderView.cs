using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderView : MonoBehaviour
{
    private Slider slider;
    private Text text;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        text = gameObject.transform.Find("Text").GetComponent<Text>();
    }
    
    // Update is called once per frame
    void Update()
    {
        text.text = Math.Round(slider.value,1,MidpointRounding.AwayFromZero)+"";
    }
}
