using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStage : MonoBehaviour
{
    Text ScoreText;
    // Start is called before the first frame update

    void Start()
    {
        ScoreManager.ScoreMultiplier = 1;
        ScoreManager.DeadCounter = 0;
        ScoreText = GetComponent<Text>();
        ScoreText.text = "Score: " + 0;
        EventsManager.eventsManager.OnEnemyDead += updateTheScore;
        ScoreText.text = " Score: " + ScoreManager.GetScore() + "\n x" + ScoreManager.ScoreMultiplier;
    }

    // Update is called once per frame

    private void OnDestroy()
    {
        EventsManager.eventsManager.OnEnemyDead -= updateTheScore;
    }

    public void updateTheScore()
    {
        ScoreText.text = " Score: " + ScoreManager.GetScore() + "\n x" + ScoreManager.ScoreMultiplier;
    }
}
