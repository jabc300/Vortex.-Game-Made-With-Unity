using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private bool Notblocked;
    private void Start()
    {
        Notblocked = true;
        EventsManager.eventsManager.OnGameFinish += blockedEscape;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Notblocked)
        {
            SceneManager.LoadScene("Selection", LoadSceneMode.Single);
        }
    }

    private void OnDisable()
    {
        EventsManager.eventsManager.OnGameFinish -= blockedEscape;
        ScoreManager.ResetScore();
        ScoreManager.ResetScoreMultiplierAndDeadCounter();
    }

    private void blockedEscape() {
        Notblocked = false;
    }
}
