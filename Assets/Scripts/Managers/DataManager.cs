using UnityEngine;
using System.Collections;

public static class DataManager  {

    public static void SetHighScore(float time)
    {
        if (time > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", time);
        }
    }

    public static float GetHighScore()
    {
        return PlayerPrefs.GetFloat("HighScore");
    }

    public static void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }

}
