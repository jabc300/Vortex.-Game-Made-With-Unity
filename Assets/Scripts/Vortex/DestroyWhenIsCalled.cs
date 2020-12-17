using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenIsCalled : MonoBehaviour
{
    private CameraShake Shake;
    private bool startSound;

    private void Awake()
    {
        startSound = false;
    }

    private void OnEnable()
    {
        if(startSound)AudioManager.inst.Play("Explosion");
        startSound = true;
        Shake = Camera.main.GetComponent<CameraShake>();
        StartCoroutine(Shake.Shaker(2f));
    }

    void DestroyObject() {
        ObjectsPool.returnToQueque(gameObject);
    }
}
