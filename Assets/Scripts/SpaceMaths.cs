using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class SpaceMaths
{
    //Пусть масса Солнца = 1
    
    /// <summary>
    /// Функция получает коэффициент радиуса орбиты планеты по Тициусу-Боде в зависимости от её индекса
    /// </summary>
    /// <param name="index">Индекс планеты в системе</param>
    public static float GetPlanetRadiusByTitius_Bode(int index)
    {
        if (index == 0) //Для нулевой планеты степень не считаем
        {
            return 0.4f;
        }
        else
        {
            return 0.4f + 0.3f * Mathf.Pow(2, index - 1); //т.к. идёт смещение геометрической прогрессии, вычитаем 1
        }
    }

    /// <summary>
    /// <para>Радиус обращения планеты по закону Кеплера</para>
    /// <para>!Возвращает радиус в астрономических единицах!</para>
    /// </summary>
    /// <param name="period">Период обращения планеты в годах</param>
    /// <param name="starToSunMassRatio">Отношение массы звезды к массе Солнца</param>
    public static float KeplerLawRadius(float period, float starToSunMassRatio)
    {
        return Mathf.Pow(Mathf.Pow(period, 2) * starToSunMassRatio, 1 / 3f);
    }

    /// <summary>
    /// <para>Период обращения планеты по закону Кеплера</para>
    /// <para>!Возвращает время в годах!</para>
    /// </summary>
    /// <param name="radius">Радиус орбиты в астрономических единицах</param>
    /// <param name="starToSunMassRatio">Отношение массы звезды к массе Солнца</param>
    public static float KeplerLawPeriod(float radius, float starToSunMassRatio)
    {
        return Mathf.Sqrt(Mathf.Pow(radius, 3) / starToSunMassRatio);
    }

    public static float YearsToSeconds(float years)
    {
        return years * 60 * 60 * 24 * 365;
    }
}