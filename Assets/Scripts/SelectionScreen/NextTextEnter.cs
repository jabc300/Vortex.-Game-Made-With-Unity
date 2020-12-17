using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class NextTextEnter : AnimationText
{

    public TextMeshProUGUI EnterToContinue;
    public int RefDialogue;
    bool changeScene;

    private void OnEnable()
    {
        FinishWriting += ToContinue;
    }
    private void OnDisable()
    {
        FinishWriting -= ToContinue;
    }

    private void Awake()
    {
        Paragraphs = DataUpload.ListTextData[ScoreManager.AnimSelected].Paragraphs;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && notBlocked)
        {
            EnterToContinue.gameObject.SetActive(false);
            notBlocked = false;
            NextParagraph();
            StartCoroutine(SceneTransition());
        }
    }

    void ToContinue() {
        EnterToContinue.gameObject.SetActive(true);
        notBlocked = true;
        if (Index == Paragraphs.Length - 1) changeScene = true;
    }

    private void NextParagraph()
    {
        if (Index < Paragraphs.Length - 1)
        {
            Index++;
            AnimText.text = "";
            StartCoroutine(TextAnimator());
        }
    }

    public override IEnumerator SceneTransition()
    {
        if (changeScene)
        {
            yield return new WaitForSeconds(0.5f);
            AnimText.GetComponent<Animator>().SetTrigger("Fadeout");
            yield return new WaitForSeconds(0.8f);
            SaveData.SaveScore();
            SceneManager.LoadScene(GoToScene, LoadSceneMode.Single);
            yield return null;
        }
    }
}
