using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVars : MonoBehaviour {
    public static int points = 0;
    public static int rottenPoints = 0;
    public static float foodForce = 19;
    public static bool period = true;
    public static float timeLeft = 10f;
    public static float timeLimit = 5f;
    public static int totalFood = 0;

    public static void ResetVars()
    {
             points = 0;
        rottenPoints = 0;
         foodForce = 19;
        period = true;
         timeLeft = 10f;
        timeLimit = 5f;
        totalFood = 0;
    }
}
