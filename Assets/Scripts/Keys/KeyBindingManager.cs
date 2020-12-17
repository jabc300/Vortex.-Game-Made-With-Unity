using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyBindingManager : MonoBehaviour
{
    Event e;
    string keyPressed;
    private TextMeshProUGUI[] changeButtons;
    private int changeIndex;
    private bool findIt;
    private bool findItCycle;
    private bool finishPick;
    public GameObject optionsMenu;
    public GameObject alreadyInUse;
    // Start is called before the first frame update

    private void OnEnable()
    {
        finishPick = true;
        findIt = false;
        findItCycle = false;
    }


    void OnGUI()
    {
        e = Event.current;
        if (e.type == EventType.KeyDown && gameObject.activeInHierarchy && finishPick)
        {
            if (Input.GetKeyDown(e.keyCode))
            {
                keyPressed = e.keyCode.ToString();
                if (changeButtons[changeIndex].text == keyPressed)
                {
                    findIt = true;
                    StartCoroutine(changeToOptions());
                }
                if (!findIt){
                    for (int i = 0; i < changeButtons.Length; i++) {
                        if (keyPressed == changeButtons[i].text)
                        {
                            findItCycle = true;
                            alreadyInUse.SetActive(true);
                            break;
                        }
                    }
                    if (!findItCycle) {
                        KeysManager.Keys[changeIndex] = keyPressed;
                        StartCoroutine(changeToOptions());
                    }
                }
            }
        }
        findItCycle = false;
    }

    public void GetTheValues(TextMeshProUGUI[] Buttons, int selectedText) {
        changeButtons = Buttons;
        changeIndex = selectedText;
    }

    private IEnumerator changeToOptions() {
        finishPick = false;
        yield return new WaitForSeconds(0.1f);
        alreadyInUse.SetActive(false);
        gameObject.SetActive(false);
        optionsMenu.SetActive(true);
    }
}
