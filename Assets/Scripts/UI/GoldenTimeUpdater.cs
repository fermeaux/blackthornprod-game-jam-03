using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldenTimeUpdater : MonoBehaviour
{
    public float maxTime;
    public static GoldenTimeUpdater instance;
    private Slider slider;
    private float time;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        instance = this;
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            slider.value = time / maxTime;
        }
        else
        {
            slider.value = 0;
        }
    }

    public void Replay()
    {
        time = maxTime;
    }
}
