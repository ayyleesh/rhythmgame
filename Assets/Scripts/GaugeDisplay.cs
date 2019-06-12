using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeDisplay : MonoBehaviour
{
    public Image[] gaugeBars;
    public Sprite redBar, yellowBar, blueBar, purpleBar;
    public float sliderValue;
    GameObject slider;
    int barCount;

    // Start is called before the first frame update
    void Start()
    {
        barCount = gaugeBars.Length;
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (gameObject.GetComponent<Slider>().value > 4 * (i + 1))
            {
                gaugeBars[i].sprite = redBar;
            }
        }
        for (int k = 5; k < 11; k++)
        {
            if (gameObject.GetComponent<Slider>().value > 4 * (k + 1))
            {
                gaugeBars[k].sprite = yellowBar;
            }
        }
        for (int l = 11; l < 21; l++)
        {
            if (gameObject.GetComponent<Slider>().value > 4 * (l + 1))
            {
                gaugeBars[l].sprite = blueBar;
            }
        }
        for (int m = 21; m < 24; m++)
        {
            if (gameObject.GetComponent<Slider>().value > 4 * (m + 1))
            {
                gaugeBars[m].sprite = purpleBar;
            }
        }
    }
}
