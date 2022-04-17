using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeChange : MonoBehaviour
{
    public Image ChangedImage;

    public Slider SlidingSlider;

    public Sprite Pic1;
    public Sprite Pic2;
    public Sprite Pic3;

    public Material DaySB;
    public Material NightSB;
    public Material SunriseSB;

    public float Value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Value = SlidingSlider.value;

        if (Value == 0)
        {
            ChangedImage.GetComponent<Image>().sprite = Pic1;

            RenderSettings.skybox = DaySB;
        }

        if (Value == 1)
        {
            ChangedImage.GetComponent<Image>().sprite = Pic2;

            RenderSettings.skybox = NightSB;
        }

        if (Value == 2)
        {
            ChangedImage.GetComponent<Image>().sprite = Pic3;

            RenderSettings.skybox = SunriseSB;
        }
    }
}
