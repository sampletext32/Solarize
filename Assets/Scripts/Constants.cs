using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Constants : MonoBehaviour
{
    public static float TimeScale = 1; //86400*365;
    public static float AstronomicalUnitScale = 25f;

    public static float CurrentWorldRealTime;

    public TextMeshProUGUI WorldRealtimeText;


    public static float CameraDistanceFromCenter = 200f;
    public const float CameraIsometricAngle = 35.264f;

    // Start is called before the first frame update
    void Start()
    {
        CurrentWorldRealTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentWorldRealTime += Time.deltaTime * TimeScale;
        long seconds = (long) CurrentWorldRealTime;
        long minutes = seconds / 60;
        long hours = minutes / 60;
        long days = hours / 24;
        long years = days / 365;
        WorldRealtimeText.text = (years).ToString("00") + " лет, " +
                                 (days % (365)).ToString("00") + " дней, " +
                                 (hours % (24)).ToString("00") + " часов, " +
                                 (minutes % (60)).ToString("00") + " минут, " +
                                 (seconds % (60)).ToString("00") + " секунд";
    }

    public void SetTimeScale(Slider slider)
    {
        TimeScale = slider.value;
    }
}