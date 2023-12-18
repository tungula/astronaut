using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions
{
    public static List<int> TryRemove(this List<int> list, int value)
    {
        try
        {
            list.Remove(value);
        }
        catch (Exception)
        {
        }
        return list;
    }

    public static void TrySet(this char[,] array, int y, int x, char value)
    {
        try
        {
            array[y, x] = value;
        }
        catch (Exception)
        {
        }
    }
}
