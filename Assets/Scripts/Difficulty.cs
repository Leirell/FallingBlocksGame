using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty :MonoBehaviour {

    static float secondsToMaxDifficult = 60;

    public static float GetDifficultPercentage () {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficult);
    }
}
