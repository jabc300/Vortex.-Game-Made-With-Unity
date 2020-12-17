using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager eventsManager;

    private void Awake()
    {
        eventsManager = this;
    }


    #region UI ELEMENTS
    public event Action OnEnemyDead;
    //ScoreUI-------------------------
    public void ChangeTheScore() {
        OnEnemyDead?.Invoke();
    }
    //--------------------------------

    public event Action<int> OnShieldUp;
    //ShieldUI--------------------
    public void ChangeTheShieldValue(int value) {
        OnShieldUp?.Invoke(value);
    }
    //----------------------------

    public event Action<int> OnLivesUp;
    //LivesUI--------------------
    public void ChangeTheLifeValue(int value)
    {
        OnLivesUp?.Invoke(value);
    }
    //----------------------------

    public event Action OnDeadPlayer;
    //GameOverUI--------------------
    public void ActivateGameOver() {
        OnDeadPlayer?.Invoke();
    }
    //------------------------------

    public event Action OnGameFinish;
    //StageCompleteUI---------------
    public void ActivateStageComplete() {
        OnGameFinish?.Invoke();
    }
    //------------------------------
    #endregion

    
    public event Action<int> OnVortexCatch;
    //Vortexcatch-------------------
    public void DestroyEnemy(int id)
    {
        OnVortexCatch?.Invoke(id);
    }

    public bool CheckOnVortexCatch() {
        return OnVortexCatch != null;
    }
    //------------------------------

    public event Action<int> OnBossLivesUp;
    //LivesUI--------------------
    public void ChangeTheBossLifeValue(int value)
    {
        OnBossLivesUp?.Invoke(value);
    }
    //----------------------------
}
