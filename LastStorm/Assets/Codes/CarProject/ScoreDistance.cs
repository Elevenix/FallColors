using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDistance : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    [SerializeField]
    private Transform playerPos;

    [SerializeField]
    private int divisionScore = 5;

    private float _startCount;
    private int _score = 0;
    // Start is called before the first frame update
    void Start()
    {
        _startCount = playerPos.position.x;
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        highScoreText.text = "BestScore : " + PlayerPrefs.GetInt("HighScore").ToString() +"m";
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(_score < (int)((playerPos.position.x-_startCount)/divisionScore))
        {
            _score = (int)((playerPos.position.x-_startCount) / divisionScore);
            scoreText.text = _score.ToString() + "m";
        }
    }

    public int ActualScore()
    {
        return this._score;
    }
}
