using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class ExtentionMethods
{
    public static T GetRandomItem<T>(this List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            Debug.LogWarning("can't get random item: list is null or count == 0");
            return default(T);
        }

        return list[StaticRandom.Instance.Next(0, list.Count)];
    }
}

public static class StaticRandom
{
    private static int seed;

    private static ThreadLocal<System.Random> threadLocal = new ThreadLocal<System.Random>
                    (() => new System.Random(Interlocked.Increment(ref seed)));

    static StaticRandom() => seed = Environment.TickCount;

    public static System.Random Instance { get { return threadLocal.Value; } }
}
