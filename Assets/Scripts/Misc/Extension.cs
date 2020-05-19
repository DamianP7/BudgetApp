using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static string ToEuropeanString(this DateTime date)
    {
        return date.ToString("dd.MM.yyyy");
    }

    public static string ToEuropeanShortString(this DateTime date)
    {
        return date.ToString("dd.MM.yy");
    }
}
