using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class AnimationText : MonoBehaviour
{
    protected Action FinishWriting;

    protected int Index;

    public float speed;
    
    private string refText;
    public string GoToScene;
    public string[] Paragraphs;
    
    protected bool notBlocked;
    public bool AnimationOn;

    public TextMeshProUGUI AnimText;
    

    private AudioSource textAudio;
    private Animator backgroundFadeControl;

    void Start()
    {
        textAudio = GetComponent<AudioSource>();
        backgroundFadeControl = GetComponent<Animator>();

        AnimText.text = "";
        if (AnimationOn)
        {
            StartCoroutine(TextAnimator());
        }
    }

    protected IEnumerator TextAnimator() {
        yield return new WaitForSeconds(0.5f);
        refText = Paragraphs[Index];
        for (int i = 0; i < refText.Length; i++)
        {
            if (refText[i] == '\\') {
                AnimText.text = AnimText.text + "\n";
                continue;
            }
            
            AudioManager.inst.Play("TextSound");
            if (refText[i] == '*') AnimText.text = AnimText.text + KeysManager.Keys[2];
            else if (refText[i] == '-') AnimText.text = AnimText.text + KeysManager.Keys[3];
            else if (refText[i] == '+') AnimText.text = AnimText.text + KeysManager.Keys[4];
            else AnimText.text = AnimText.text + refText[i];
            if (refText[i] == ' ') continue;
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(0.3f);       
        StartCoroutine(SceneTransition());
        FinishWriting?.Invoke();
        yield return null;
    }

    public virtual IEnumerator SceneTransition() {
        yield return new WaitForSeconds(1);
        AnimText.GetComponent<Animator>().SetTrigger("Fadeout");
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(GoToScene, LoadSceneMode.Single);
        yield return null;
    }
}
