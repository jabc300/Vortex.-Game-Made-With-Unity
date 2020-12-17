using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public float Addedforce;
    private Vector3 changeddirection;
    public int shieldLife;

    private Animator animatorRef;
    // Start is called before the first frame update

    private void Start()
    {
        animatorRef = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            changeddirection = new Vector3(0, -1*collision.GetComponent<Rigidbody2D>().velocity.y);
            changeddirection.Normalize();

            collision.GetComponent<Rigidbody2D>().AddForce(changeddirection*Addedforce);
            collision.gameObject.layer = LayerMask.NameToLayer("ReturnedBullet");
            shieldLife -= 1;
            EventsManager.eventsManager.ChangeTheShieldValue(shieldLife);

            if (shieldLife <= 0) {
                animatorRef.SetBool("DestroyedShield", true);
                shieldLife = 0;
                EventsManager.eventsManager.ChangeTheShieldValue(shieldLife);
            }
        }
    }

    private void DeactivateShield() {
        gameObject.SetActive(false);
    }
}
