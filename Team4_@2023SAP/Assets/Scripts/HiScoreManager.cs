using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiScoreManager : Singleton<HiScoreManager>
{
    public struct Score
    {
        public string name;
        public float val;
    }

    List<Score> scores = new List<Score>();

    public const string kID = "HS"; //this is so the key to get data is unique if we ever use playerprefs again

    private void Start()
    {
        LoadScores();
        //print(scores[0].name + ", " + scores[0].val);
    }

    public void LoadScores()
    {
        bool stop = false;
        int i = 0;
        while (stop == false)
        {
            Score newScore = new Score { name = PlayerPrefs.GetString(kID + i),
                val = PlayerPrefs.GetFloat(kID + "f" + i) };
            if (newScore.name != "")
            {
                scores.Add(newScore);
            }
            else
            { stop = true; }

            i++;
        }
    }

    public void SaveScores()
    {
        PlayerPrefs.DeleteAll();

        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetString(kID + i, scores[i].name);
            PlayerPrefs.SetFloat(kID + "f" + i, scores[i].val);
        }

        PlayerPrefs.Save();
    }

    public void addScore(Score score)
    {
        scores.Add(score);
    }

    public void removeScore(int index)
    {
        scores.Remove(scores[index]);
    }

    public List<Score> GetScores() { return scores; }
    public Score GetScore(int index) { return scores[index];}
}
