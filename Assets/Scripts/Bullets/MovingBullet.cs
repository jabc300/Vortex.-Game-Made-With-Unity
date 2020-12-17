using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBullet : MonoBehaviour
{
    public GameObject Vortex;

    Vector2 upVector;
    private GameObject InstantVortex;
    public float speed;

    void Start()
    {
        upVector = new Vector2(0, 1f);
        speed = 11;       
    }

    private void OnEnable()
    {
        Invoke("destroyTheBullet",1.5f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void Update()
    {
        transform.position += (Vector3) upVector * Time.deltaTime * speed;
    }

    private void destroyTheBullet()
    {
        ObjectsPool.returnToQueque(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && (!collision.transform.Find("AntigravitatoryDevice")))
        {
            ObjectsPool.UsePoolObject("Vortex", gameObject.transform.position, Quaternion.identity);
            ObjectsPool.returnToQueque(gameObject);
        }
        else if (collision.CompareTag("Boss") || (collision.CompareTag("Enemy") && (collision.transform.Find("AntigravitatoryDevice")))) ObjectsPool.returnToQueque(gameObject);       
    }
}
