using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tempScoreButton : MonoBehaviour
{
    public TMP_InputField Name;
    public TMP_InputField Score;

    Button button;

    void Start()
    {
        button = GetComponent<Button>();
    }

    public void buttonPressed()
    {
        string newName = Name.text;
        float newScore = float.Parse(Score.text);

        if (name != "")
        {
            HiScoreManager manager = HiScoreManager.Instance;

            manager.addScore(new HiScoreManager.Score {name = newName, val = newScore});
            manager.removeScore(1);
            manager.SaveScores();

            print("------------------------");
            foreach (HiScoreManager.Score score in manager.GetScores())
            {
                print(score.name + ": " + score.val);
            }
        }
        
    }
}
