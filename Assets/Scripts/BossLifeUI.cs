using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossLifeUI : MonoBehaviour
{
    private TextMeshProUGUI LifeUI;
    // Start is called before the first frame update
    void Start()
    {
        LifeUI = GetComponent<TextMeshProUGUI>();
        EventsManager.eventsManager.OnBossLivesUp += ObtainLifeValue;
    }
    public void ObtainLifeValue(int value)
    {
        LifeUI.text = "Boss:\n" + value;
    }

    private void OnDestroy()
    {
        EventsManager.eventsManager.OnBossLivesUp -= ObtainLifeValue;
    }
}
