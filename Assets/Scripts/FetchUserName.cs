using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FetchUserName : MonoBehaviour
{
    string highScorer;
    int bestScore;

    private Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        FetchAndDisplayUserName();
    }

    public void FetchAndDisplayUserName(){
        highScorer = DataPersistence.Instance.highScorer;
        bestScore = DataPersistence.Instance.bestScore;

        highScoreText = GameObject.Find("High Score Text").GetComponent<Text>();
        highScoreText.text = "Best Score : " + highScorer + " : " + bestScore;
    }
}
