using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    // Number of seconds until maximum difficulty reached
    static float secondsToMaxDifficulty = 60;

    public static float GetDifficultyPercent()
    {
        // Method returns numberof seconds unitl max difficulty
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
}
