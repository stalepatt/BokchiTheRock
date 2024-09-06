using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public static class Logger
{
    [Conditional("DEV_VER")]
    public static void Log(string msg)
    {
        UnityEngine.Debug.LogFormat("{0:yyyy-MM-dd HH:mm:ss.fff},{1}", System.DateTime.Now, msg);
    }

    [Conditional("DEV_VER")]
    public static void LogWarning(string msg)
    {
        UnityEngine.Debug.LogWarningFormat("{0:yyyy-MM-dd HH:mm:ss.fff},{1}", System.DateTime.Now, msg);
    }
    
    public static void LogError(string msg)
    {
        UnityEngine.Debug.LogErrorFormat("{0:yyyy-MM-dd HH:mm:ss.fff},{1}", System.DateTime.Now, msg);
    }
}