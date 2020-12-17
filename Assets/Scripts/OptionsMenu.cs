using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider sliderVolume;
    public GameObject messageKeyBinding;
    private KeyBindingManager kbm;
    public TextMeshProUGUI[] Buttons;
    private TextMeshProUGUI ButtonToChange;
    static float sliderValue;
    private string keyPressed;
    
    // Start is called before the first frame update
    void Start()
    {
        sliderVolume.value = sliderValue;
        kbm = messageKeyBinding.GetComponent<KeyBindingManager>();
    }

    public void VolumeControl(float volume) {
        audioMixer.SetFloat("MasterVolume", volume);
        sliderValue = volume;
    }

    public void ChangeKeyMessage(int index) {        
        gameObject.SetActive(false);
        kbm.GetTheValues(Buttons, index);
        messageKeyBinding.SetActive(true);
    }
}
