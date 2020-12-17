using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("destroyTheBullet", 3.2f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void destroyTheBullet() {
        if (gameObject.layer == LayerMask.NameToLayer("ReturnedBullet")) gameObject.layer = LayerMask.NameToLayer("Bullet");
        ObjectsPool.returnToQueque(gameObject);
    }
}
