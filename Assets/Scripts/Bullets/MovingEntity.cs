using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntity : MonoBehaviour
{

    Vector2 upVector;
    public float speed;

    private void OnEnable()
    {
        Invoke("destroyEntity", 5f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }


    void Update()
    {
        transform.position += (Vector3) Vector2.down * Time.deltaTime * speed;
    }

    private void destroyEntity() {
        ObjectsPool.returnToQueque(gameObject);
    }
}
