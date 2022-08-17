using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpSlider : MonoBehaviour
{
    [SerializeField] Slider slider;

    void Update()
    {
        
    }

    public void SetJumpSlider(int maxValue, int currentValue)
    {
        int sliderValue = maxValue - currentValue;
        slider.maxValue = maxValue;
        slider.value = sliderValue;
    }
}
