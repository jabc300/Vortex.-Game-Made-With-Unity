using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject CreditsMenu;
    public GameObject textMessageKey;

    public GameObject optionsButton, creditsButton, sliderOptions;

    private bool firstTime;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.inst.Play("Intro");
    }

    private void OnEnable()
    {
        firstTime = false;
    }

    private void OnDisable()
    {
        AudioManager.inst.Stop("Intro");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            firstTime = false;
            if (MainMenu.activeInHierarchy) Application.Quit();
            else if (OptionsMenu.activeInHierarchy)
            {
                EventSystem.current.SetSelectedGameObject(null);
                OptionsMenu.SetActive(false);
                MainMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(optionsButton);
            }
            else if (CreditsMenu.activeInHierarchy)
            {
                EventSystem.current.SetSelectedGameObject(null);
                CreditsMenu.SetActive(false);
                MainMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(creditsButton);
            }
            else if (textMessageKey.activeInHierarchy) {
                textMessageKey.SetActive(false);
                OptionsMenu.SetActive(true);
            }
        }
    }

    public void StartTheGame(){
        if (ScoreManager.unlockedAnim0) SceneManager.LoadScene("Selection", LoadSceneMode.Single);
        else if (!ScoreManager.unlockedAnim0)
        {
            ScoreManager.AnimSelected = 0;
            ScoreManager.unlockedAnim0 = true;
            SceneManager.LoadScene("AnimationTransition", LoadSceneMode.Single);
        }
    }

    public void StartTheCredits()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void StartTheOptions() {
        EventSystem.current.SetSelectedGameObject(null);
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);        
        EventSystem.current.SetSelectedGameObject(sliderOptions);
    }

    public void playSound() {
        if(firstTime)AudioManager.inst.Play("SelectArrow");
        firstTime = true;
    }
}
