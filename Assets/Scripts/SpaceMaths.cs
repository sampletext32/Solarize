using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class SpaceMaths
{
    /// <summary>
    /// Возвращает период обращения планеты по орбите планеты и отношением массы звезды к солнечной
    /// </summary>
    /// <param name="orbitRadius">Радиус орбиты по Тициусу-Боде</param>
    /// <param name="starToSunMassRatio">Отношение массы звезды к массе солнца</param>
    public static float GetPeriodForPlanetFromOrbitRadius(float orbitRadius, float starToSunMassRatio)
    {
        //приведённый 2 закон Ньютона
        return (float) Math.Sqrt(Math.Pow(orbitRadius, 3) / starToSunMassRatio) * 365f * 24f * 60f * 60f;
    }

    /// <summary>
    /// Функция получает коэффициент радиуса орбиты планеты по Тициусу-Боде в зависимости от её индекса
    /// </summary>
    /// <param name="index">Индекс планеты в системе</param>
    public static float GetPlanetRadiusByTitius_Bode(int index)
    {
        //формула Тициуса-Боде
        if (index == 0)//Для нулевой планеты степень не считаем
        {
            return 0.4f;
        }
        else
        {
            return 0.4f + 0.3f * Mathf.Pow(2, index - 1);//т.к. идёт смещение геометрической прогрессии, вычитаем 1
        }
    }

    /// <summary>
    /// Функция переводит астрономические единицы в метры
    /// </summary>
    /// <param name="units">Астрономические единицы</param>
    public static float AstronomicalUnitsToMeters(float units)
    {
        return units * 149597870700f;
    }
}