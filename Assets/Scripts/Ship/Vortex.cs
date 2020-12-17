using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour
{
    private const float shakerTime = 10f;

    private const int limitTime = 10;
    private const int zeroChild = 0;

    private static int counter;

    private CameraShake Shake;

    private Life lifeComponent;

    public event Action OnVortexCatch;

    void OnEnable()
    {
        counter++;
        AudioManager.inst.Play("Vortex");
        Shake = Camera.main.GetComponent<CameraShake>();
        StartCoroutine(Shake.Shaker(shakerTime));
        Invoke("destroyChildrenAndVortex", limitTime);
    }

    private void OnDisable()
    {
        counter--;
        if (counter <= 0 && AudioManager.inst) AudioManager.inst.Stop("Vortex");
        CancelInvoke();
    }

    void destroyChildrenAndVortex()
    {
        OnVortexCatch?.Invoke();
        ObjectsPool.returnToQueque(gameObject);

    }
}
