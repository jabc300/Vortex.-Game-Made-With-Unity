using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBullets : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet")|| collision.CompareTag("BulletVortex"))
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("ReturnedBullet")) gameObject.layer = LayerMask.NameToLayer("Bullet");
            ObjectsPool.returnToQueque(collision.gameObject);
        }
    }
}
