using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public static class Logger
{
    [Conditional("DEV_VER")]
    public static void Log(string msg)
    {
        Debug.LogFormat("{0},{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg);
    }

    [Conditional("DEV_VER")]
    public static void LogWarning(string msg)
    {
        Debug.LogWarningFormat("{0},{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg);
    }

    public static void LogError(string msg)
    {
        Debug.LogErrorFormat("{0},{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg);
    }
}