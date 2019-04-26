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

    public static float TimeScale = 1; //86400*365;
    public static float ViewScale = 25f;

    public static float CurrentWorldRealTime;

    public TextMeshProUGUI WorldRealtimeText;


    public static float CameraDistanceFromCenter = 200f;
    public const float CameraIsometricAngle = 35.264f;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentWorldRealTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentWorldRealTime += Time.deltaTime * TimeScale;
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
        TimeScale = slider.value;
    }
}