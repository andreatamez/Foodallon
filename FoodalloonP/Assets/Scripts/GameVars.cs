using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVars : MonoBehaviour {
    public static int points = 0;
    public static int rottenPoints = 0;
    public static float foodForce = 20;
    public static bool period = true;
    public static float timeLeft = 30f;
    public static float timeLimit = 5f;
    public static int totalFood = 0;
    public static bool moving = false;

    public static int levelToUnlock = 1;
    public static string versionName = "a2";

    public static void ResetVars()
    {
        points = 0;
        rottenPoints = 0;
        foodForce = 19;
        period = true;
        timeLeft = 30f;
        timeLimit = 5f;
        totalFood = 0;
        moving = false;
    }
}
