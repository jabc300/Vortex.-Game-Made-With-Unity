using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectionScreen : MonoBehaviour
{

    int numberStages;
    int limitStages;
    int stageValue;
    int sceneOffset;
    
    public Image ArrowFront;
    public Image ArrowBack;

    public Image FadeBackGround;
    public Image[] Stages;

   

    private Animator ArrowBackAnimator;
    private Animator ArrowFrontAnimator;
    private Animator FadeBackGroundAnimator;
    private Animator SelectionScreenAnimator;

    public TextMeshProUGUI title;
    public TextMeshProUGUI score;
    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI finalStage;

    private AudioSource arrowBackAudio;
    private AudioSource arrowFrontAudio;
    private AudioSource selectionScreenAudio;

    enum stagesState {stage1,stage2,stage3,stage4,stage5,stage6,stage7};
    stagesState actualStage;

    private bool useEnter;
    private bool ArrowAnimNoProgress;

    //ScoreData DataLoaded;
    // Start is called before the first frame update
    private void Awake()
    {
        ArrowBackAnimator = ArrowBack.GetComponent<Animator>();
        ArrowFrontAnimator = ArrowFront.GetComponent<Animator>();
        FadeBackGroundAnimator = FadeBackGround.GetComponent<Animator>();
        SelectionScreenAnimator = GetComponent<Animator>();
        selectionScreenAudio = GetComponent<AudioSource>();
        arrowBackAudio = ArrowBack.GetComponent<AudioSource>();
        arrowFrontAudio = ArrowFront.GetComponent<AudioSource>();
        //DataLoaded = SaveData.LoadScore();
        //if (DataLoaded != null) ScoreManager.UpdateTheScore(DataLoaded);
        ArrowAnimNoProgress = true;
        useEnter = true;
        ObjectsPool.pool.Clear();
        sceneOffset = 3;
        actualStage = stagesState.stage1;
        numberStages = ScoreManager.GetUnlockedStage();
        limitStages = (System.Enum.GetValues(typeof(stagesState)).Length) - 1;        
        totalScore.text = "Total Score: " + ScoreManager.TotalScore();
    }

    void Start()
    {
        AudioManager.inst.Play("SelectionScreen");
        actualStage = (stagesState)ScoreManager.GetSavedStage();
        stageValue = (int)actualStage;
    }

    // Update is called once per frame
    void Update()
    {
        if (ArrowAnimNoProgress && useEnter)
        {
            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                ArrowAnimNoProgress = false;
                if (ArrowBack.IsActive()) AudioManager.inst.Play("SelectArrow");
                StartCoroutine(ArrowAnimBack());
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                ArrowAnimNoProgress = false;
                if (ArrowFront.IsActive()) AudioManager.inst.Play("SelectArrow");
                StartCoroutine(ArrowAnimFront());
            }

            StagesSelection();
            ScoreManager.SaveSceneValue((int)actualStage);
            StageStarter((int)(actualStage) + sceneOffset);
        }

        if (stageValue <= 0) stageValue = 0;
        else if (stageValue > numberStages) stageValue = numberStages;
    }

    private void OnDisable()
    {
        AudioManager.inst.Stop("SelectionScreen");
    }

    private void StageStarter(int sceneToUse) {
        if ((Input.GetKeyDown(KeyCode.Return)) && useEnter)
        {
            useEnter = false;
            StartCoroutine(SelectorTransition(sceneToUse));
        }
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    private void StagesSelection() {
        switch (actualStage)
        {          
            case stagesState.stage1:                
                ArrowBack.gameObject.SetActive(false);
                if(ScoreManager.GetUnlockedStage() >= 1) ArrowFront.gameObject.SetActive(true);
                else ArrowFront.gameObject.SetActive(false);
                activateBgImages(true,true,false,false,false,false,false,false);
                Stages[0].rectTransform.localScale = new Vector2(2, 2);
                Stages[1].rectTransform.localScale = new Vector2(2, 2);
                Stages[1].rectTransform.anchorMin = new Vector2(1, 0);
                Stages[1].rectTransform.anchorMax = new Vector2(1, 0);
                Stages[0].rectTransform.anchoredPosition = new Vector2(100,-100);
                Stages[1].rectTransform.anchoredPosition = new Vector2(-100, 100);
                title.text = "Stage 1 \nTriangles and Squares";
                score.text = "Score: " + ScoreManager.OneScore;
                break;
            case stagesState.stage2:

                ArrowBack.gameObject.SetActive(true);
                if (ScoreManager.GetUnlockedStage() >= 2) ArrowFront.gameObject.SetActive(true);
                else ArrowFront.gameObject.SetActive(false);
                activateBgImages(false, false, true, false, false, false, false, false);
                Stages[2].rectTransform.localScale = new Vector2(2, 2);
                Stages[2].rectTransform.anchoredPosition = new Vector2(0, 0);
                title.text = "Stage 2 \nOctahedrons";
                score.text = "Score: " + ScoreManager.TwoScore;
                break;
            case stagesState.stage3:
                if (ScoreManager.GetUnlockedStage() >= 3) ArrowFront.gameObject.SetActive(true);
                else ArrowFront.gameObject.SetActive(false);
                activateBgImages(false, false, true, true, true, false, false, false);
                Stages[2].rectTransform.localScale = new Vector2(1, 1);
                Stages[3].rectTransform.localScale = new Vector2(1, 1);
                Stages[4].rectTransform.localScale = new Vector2(1, 1);
                Stages[2].rectTransform.anchoredPosition = new Vector2(0, 50);
                Stages[3].rectTransform.anchoredPosition = new Vector2(100, 100);
                Stages[4].rectTransform.anchoredPosition = new Vector2(-100, 100);
                title.text = "Stage 3 \nOctahedrons Revenge";
                score.text = "Score: " + ScoreManager.ThreeScore;
                break;
            case stagesState.stage4:
                if (ScoreManager.GetUnlockedStage() >= 4) ArrowFront.gameObject.SetActive(true);
                else ArrowFront.gameObject.SetActive(false);
                activateBgImages(false, false, false, false, false, true, false, false);
                Stages[5].rectTransform.localScale = new Vector2(2, 2);
                Stages[5].rectTransform.anchoredPosition = new Vector2(0, 0);
                title.text = "Stage 4 \nOctagons";
                score.text = "Score: " + ScoreManager.FourScore;
                break;
            case stagesState.stage5:
                if (ScoreManager.GetUnlockedStage() >= 5) ArrowFront.gameObject.SetActive(true);
                else ArrowFront.gameObject.SetActive(false);
                activateBgImages(false, false, false, false, false, true, true, true);
                Stages[5].rectTransform.localScale = new Vector2(1, 1);
                Stages[6].rectTransform.localScale = new Vector2(1, 1);
                Stages[7].rectTransform.localScale = new Vector2(1, 1);
                Stages[5].rectTransform.anchoredPosition = new Vector2(0, 50);
                Stages[6].rectTransform.anchoredPosition = new Vector2(100, 100);
                Stages[7].rectTransform.anchoredPosition = new Vector2(-100, 100);
                title.text = "Stage 5 \nMore Octagons";
                score.text = "Score: " + ScoreManager.FiveScore;
                break;
            case stagesState.stage6:
                if (ScoreManager.GetUnlockedStage() >= 6) ArrowFront.gameObject.SetActive(true);
                else ArrowFront.gameObject.SetActive(false);
                finalStage.gameObject.SetActive(false);
                activateBgImages(true, true, false, true, false, false, false, true);
                Stages[0].rectTransform.localScale = new Vector2(1, 1);
                Stages[1].rectTransform.localScale = new Vector2(1, 1);
                Stages[7].rectTransform.localScale = new Vector2(1, 1);
                Stages[0].rectTransform.anchoredPosition = new Vector2(100, -100);
                Stages[1].rectTransform.anchorMin = new Vector2(1,1);
                Stages[1].rectTransform.anchorMax = new Vector2(1,1);
                Stages[1].rectTransform.anchoredPosition = new Vector2(-100, -100);
                title.text = "Stage 6 \nBullet Hell";
                score.text = "Score: " + ScoreManager.SixScore;
                break;
            case stagesState.stage7:
                finalStage.gameObject.SetActive(true);
                activateBgImages(false, false, false, false, false, false, false, false);
                ArrowFront.gameObject.SetActive(false);         
                title.text = "Final Stage \nThe Mothership";
                score.text = "Score: " + ScoreManager.SevenScore;
                break;
        }
    }

    private IEnumerator SelectorTransition(int sceneToUse) {
        SelectionScreenAnimator.SetTrigger("Disappear");
        AudioManager.inst.Play("EnterLevel");
        //selectionScreenAudio.Play();
        yield return new WaitForSeconds(1);
        FadeBackGroundAnimator.SetTrigger("Fade");
        yield return new WaitForSeconds(1.5f);
        useEnter = true;
        SceneManager.LoadScene(sceneToUse, LoadSceneMode.Single);
        yield return null;
    }

    private IEnumerator ArrowAnimBack()
    {
        stageValue--;
        if (stageValue <= 0) stageValue = 0;
        ArrowBackAnimator.SetBool("Back", true);
        yield return new WaitForSeconds(0.2f);
        ArrowBackAnimator.SetBool("Back", false);
        actualStage = (stagesState)stageValue;
        yield return new WaitForSeconds(0.1f);
        ArrowAnimNoProgress = true;
    }

    private IEnumerator ArrowAnimFront()
    {
        stageValue++;
        if (numberStages > limitStages) numberStages = limitStages;
        if (stageValue > numberStages) stageValue = numberStages;
        ArrowFrontAnimator.SetBool("Front", true);
        yield return new WaitForSeconds(0.2f);
        ArrowFrontAnimator.SetBool("Front", false);
        actualStage = (stagesState)stageValue;
        yield return new WaitForSeconds(0.1f);
        ArrowAnimNoProgress = true;
    }

    private void activateBgImages(bool aTrangle, bool aDiamond, bool aOctahedron, bool aOctahedron1, bool octahedron2, bool aHeptagon, bool aHeptagon1, bool aHeptagon2)
    {
        Stages[0].gameObject.SetActive(aTrangle);
        Stages[1].gameObject.SetActive(aDiamond);
        Stages[2].gameObject.SetActive(aOctahedron);
        Stages[3].gameObject.SetActive(aOctahedron1);
        Stages[4].gameObject.SetActive(octahedron2);
        Stages[5].gameObject.SetActive(aHeptagon);
        Stages[6].gameObject.SetActive(aHeptagon1);
        Stages[7].gameObject.SetActive(aHeptagon2);
    }
}
