using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Zbiór metod rozszerzajacych funkcjonalności klas.
/// </summary>
public static class Extension
{
    /// <summary>
    /// Zwraca datę w formacie Dzień.Miesiąc.Rok
    /// </summary>
    public static string ToEuropeanString(this DateTime date)
    {
        return date.ToString("dd.MM.yyyy");
    }

    /// <summary>
    /// Zwraca datę w formacie Dzień.Miesiąc.Dwie_Ostatnie_Cyfry_Roku
    /// </summary>
    public static string ToEuropeanShortString(this DateTime date)
    {
        return date.ToString("dd.MM.yy");
    }
}
