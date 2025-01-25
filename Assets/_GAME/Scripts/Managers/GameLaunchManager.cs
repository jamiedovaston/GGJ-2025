using JetBrains.Annotations;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameLaunchManager
{
    [RuntimeInitializeOnLoadMethod]
    public static void Intialise()
    {
        int bIndex = SceneManager.GetActiveScene().buildIndex;
        SceneToolManager.InitialiseScene(SceneDataSO.GetLevelByBuildIndex(bIndex));
    }
}
