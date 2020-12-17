using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrack : MonoBehaviour
{
    public string playTrack;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.inst.Play(playTrack);
    }

    private void OnDisable()
    {
        AudioManager.inst.Stop(playTrack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
