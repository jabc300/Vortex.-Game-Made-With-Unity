using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI shieldUI;
    public TextMeshProUGUI livesUI;
    public TextMeshProUGUI GameOver;
    public TextMeshProUGUI StageComplete;

    // Start is called before the first frame update
    void Start()
    {
        //SCORE-------------------------------------------------------------------
        ScoreManager.ScoreMultiplier = 1;
        ScoreManager.DeadCounter = 0;
        scoreUI.text = "Score: " + 0;

        EventsManager.eventsManager.OnEnemyDead += updateTheScore;
        scoreUI.text = " Score: " + ScoreManager.GetScore() + "\n x" + ScoreManager.ScoreMultiplier;
        //------------------------------------------------------------------------

        //SHIELD------------------------------------------------------------------
        EventsManager.eventsManager.OnShieldUp += ObtainShieldValue;
        if(ScoreManager.unlockedShield)shieldUI.text = "Shield: " + 10;
        else shieldUI.text = "Shield: " + 0;
        //------------------------------------------------------------------------

        //LIFE-------------------------------------------------------------------
        EventsManager.eventsManager.OnLivesUp += ObtainLifeValue;
        livesUI.text = "Lives: " + 5;
        //------------------------------------------------------------------------

        //GAMEOVER----------------------------------------------------------------
        EventsManager.eventsManager.OnDeadPlayer += GameOverOn;
        //------------------------------------------------------------------------

        //STAGECOMPLETE-----------------------------------------------------------
        EventsManager.eventsManager.OnGameFinish += CompleteStageOn;
        //------------------------------------------------------------------------


    }
    //SCORE-----------------------------------------------------------------------
    public void updateTheScore()
    {
        scoreUI.text = " Score: " + ScoreManager.GetScore() + "\n x" + ScoreManager.ScoreMultiplier;
    }
    //-----------------------------------------------------------------------------
    //SHIELD-----------------------------------------------------------------------
    public void ObtainShieldValue(int value)
    {
        shieldUI.text = "Shield: " + value;
    }
    //-----------------------------------------------------------------------------
    //LIFE-----------------------------------------------------------------------
    public void ObtainLifeValue(int value)
    {
        livesUI.text = "Lives: " + value;
    }
    //-----------------------------------------------------------------------------

    public void GameOverOn() {
        GameOver.gameObject.SetActive(true);
    }

    public void CompleteStageOn()
    {
        StageComplete.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        EventsManager.eventsManager.OnEnemyDead -= updateTheScore;
        EventsManager.eventsManager.OnShieldUp -= ObtainShieldValue;
        EventsManager.eventsManager.OnLivesUp -= ObtainLifeValue;
        EventsManager.eventsManager.OnDeadPlayer -= GameOverOn;
        EventsManager.eventsManager.OnGameFinish -= CompleteStageOn;
    }

    

}
