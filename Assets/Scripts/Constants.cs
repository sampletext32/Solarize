using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityUnitConverters;

public class Constants : MonoBehaviour
{
    public static UnityUnitAsBase UnityUnitConverter = new UnityUnitAsAstronomicalUnitConverter();

    public float TimeScale = 1; //86400*365;
    public static float ViewScale = 25f;

    private static double CurrentWorldRealTime_Inner;

    public static double CurrentWorldRealTime
    {
        get { return CurrentWorldRealTime_Inner + TimeTemp; }
    }

    private static float TimeTemp;

    public TextMeshProUGUI WorldRealtimeText;


    public static float CameraDistanceFromCenter = 200f;
    public const float CameraIsometricAngle = 35.264f;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentWorldRealTime_Inner = 20 * 86400*365;
        TimeTemp = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        TimeTemp += Time.deltaTime * TimeScale;

        if (TimeTemp > 10f)
        {
            CurrentWorldRealTime_Inner += TimeTemp;
            TimeTemp = 0f;
        }

        int sec = (int) (CurrentWorldRealTime % 60);
        int min = (int) (CurrentWorldRealTime / 60) % 60;
        int hrs = (int) (CurrentWorldRealTime / 60 / 60) % 24;
        int dys = (int) (CurrentWorldRealTime / 60 / 60 / 24) % 365;
        int yrs = (int) (CurrentWorldRealTime / 60 / 60 / 24 / 365);
        WorldRealtimeText.text = (yrs).ToString() + " лет, " +
                                 (dys).ToString("000") + " дней, " +
                                 (hrs).ToString("00") + " часов, " +
                                 (min).ToString("00") + " минут, " +
                                 (sec).ToString("00") + " секунд";
    }

    public void SetTimeScale(Slider slider)
    {
        if (Math.Abs(slider.value) < 0.0000001f)
        {
            TimeScale = 1.1f;
        }
        else
        {
            TimeScale = slider.normalizedValue * 86400 * 365;
        }
    }
}