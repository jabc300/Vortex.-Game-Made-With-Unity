using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 InitialPosition;
    public float force;

    void Start()
    {
        InitialPosition = this.transform.localPosition;
        gameObject.transform.position = transform.localPosition;
    }

    public IEnumerator Shaker(float maxtime)
    {

        float duration = 0f;
        while (duration < maxtime)
        {
            gameObject.transform.position = new Vector3(Random.Range(-force, force), Random.Range(-force, force), -10);
            duration = duration + Time.deltaTime;
            yield return null;
        }
        this.gameObject.transform.localPosition = InitialPosition;
    }
}
