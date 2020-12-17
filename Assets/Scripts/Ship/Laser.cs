using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float distanceBetweenLaserEnemy;
    private bool collisionWithEnemy;
    private float damage;
    private float decendingColor;
    Color colorEnemy;

    private float MaxValueY;
    public GameObject Sparkles;
    private ParticleSystem.EmissionModule sparklesParticles;
    private Vector2 origin;
    private Vector2 boxSize;
    private Collider2D[] results;

    public LayerMask LayerEnemy;
    private ContactFilter2D filterEnemyContact;
    private RaycastHit2D isTouchingEnemy;


    GameObject TouchedEnemy;

    private Life lifeComponent;
    //bool isTouchingEnemy;
    private float timer;
    public int startingLaser;
    private int lifeInt;
    // Start is called before the first frame update
    void Start()
    {
        startingLaser = 0;
        MaxValueY = 15;
        sparklesParticles = Sparkles.GetComponent<ParticleSystem>().emission;
        damage = 0.1f;
        decendingColor = 0;       
        boxSize = new Vector2(0.13f, 0.1f);
    }

    void Update()
    {
        origin = new Vector2(transform.position.x, transform.position.y + 0.05f);
        isTouchingEnemy = Physics2D.BoxCast(origin, boxSize, 0, Vector2.up, MaxValueY, LayerEnemy);

        if (isTouchingEnemy)
        {
            Sparkles.transform.localPosition = new Vector3(0f, 1f, -1f);
            sparklesParticles.enabled = true;
            TouchedEnemy = Physics2D.BoxCast(origin, boxSize, 0, Vector2.up, MaxValueY, LayerEnemy).transform.gameObject;
            if (TouchedEnemy.layer == LayerMask.NameToLayer("Enemy"))
            {
                lifeComponent = TouchedEnemy.GetComponent<Life>();
                distanceBetweenLaserEnemy = TouchedEnemy.transform.position.y - transform.position.y;
                transform.localScale = new Vector3(1f, distanceBetweenLaserEnemy, 1f);
                lifeComponent.life -= damage;
                if (TouchedEnemy.CompareTag("Boss")) {
                    lifeInt = (int)lifeComponent.life;
                    EventsManager.eventsManager.ChangeTheBossLifeValue(lifeInt);
                }
                decendingColor = (70f / 255f) / (lifeComponent.MaxLife * 10f);

                colorEnemy = TouchedEnemy.GetComponent<SpriteRenderer>().color;
                TouchedEnemy.GetComponent<SpriteRenderer>().color = new Color(colorEnemy.r - decendingColor, colorEnemy.g - decendingColor, colorEnemy.b - decendingColor);

                if ((lifeComponent.life <= 0) && (TouchedEnemy.CompareTag("Enemy") || TouchedEnemy.CompareTag("RotatoryEnemy") || TouchedEnemy.CompareTag("Device")))
                {
                    if (TouchedEnemy.CompareTag("Device")) lifeComponent.createExplosionForNoQueue();
                    else
                    {
                        if(lifeComponent.activateScore) ScoreManager.Score(5);
                        lifeComponent.createExplosion();
                    }
                    decendingColor = 0;
                }
            }
        }
        else{
            transform.localScale = new Vector3(1f, MaxValueY, 1f);
        }
    }
}
