using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayKeys : MonoBehaviour
{
    public int keyValue;
    public TextMeshProUGUI textRef;
    // Start is called before the first frame update

    private void OnEnable()
    {
        textRef.text = KeysManager.Keys[keyValue];
    }
}
