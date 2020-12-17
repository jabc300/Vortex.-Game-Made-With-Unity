using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : EnemiesStats
{
    private CameraShake Shake;

    private bool movingToTheZone;
    public bool deadBoss;
    protected bool startDeadAnimation;
    public bool animationStart;

    public GameObject[] BossParts;
    public GameObject miniBoss;

    private float alphaChange;

    private Life lifeComponent;

    private int lifeInt;

    Color colorBossShip;
    private void Awake()
    {
        animationStart = true;
    }
    // Start is called before the first frame update
    void Start()
    {       
        lifeComponent = GetComponent<Life>();
        lifeInt = (int)lifeComponent.life;
        colorBossShip = GetComponent<SpriteRenderer>().color;
        alphaChange = colorBossShip.a;
        deadBoss = false;
        startDeadAnimation = true;
        Shake = Camera.main.GetComponent<CameraShake>();
        movingToTheZone = false;
        randomPositionX = 5.2f;
        Addedforce = 425;
        timeTillShoot = 0.3f;
        SetTimer(timeTillShoot, () => ShootingMethod());
    }

    // Update is called once per frame
    void Update()
    {
        if (animationStart) MoveToCenter();
        else if(!deadBoss && !animationStart) Move();

        if (lifeComponent.life < 1  && startDeadAnimation) {            
            miniBoss = ObjectsPool.UsePoolObject("miniBoss", transform.position, Quaternion.identity);
            deadBoss = true;
            ScoreManager.TheDeadCounter();
            ScoreManager.Score(10000);
            BossParts[9].transform.position = new Vector2(4000f,0f);
            StartCoroutine(DeadAnimation());
            StartCoroutine(BanishShip());
            startDeadAnimation = false;
        }
    }

    private void MoveToCenter() {
        correctedSpeed = speed * Time.deltaTime;
        target = new Vector2(0, 1);
        transform.position = Vector2.MoveTowards(transform.position, target, correctedSpeed);
        if (transform.position.y == target.y) animationStart = false;
    }

    private new void Move() {
        TimerStart();
        if (!movingToTheZone)
        {
            randomPositionX = -1 * randomPositionX;
            randomPositionY = Random.Range(1f, 2f);
            target = new Vector2(randomPositionX, randomPositionY);
            movingToTheZone = true;
        }
        else
        {
            correctedSpeed = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, correctedSpeed);
            if (transform.position.x == target.x && transform.position.y == target.y) {
                movingToTheZone = false;
            }
        }
    }
    private new IEnumerator Shoot()
    {
        AudioManager.inst.Play("ShootEnemy");
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", new Vector2(transform.position.x - 0.4f, transform.position.y - 0.5f), transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * Addedforce);
        yield return new WaitForSeconds(0.1f);
        AudioManager.inst.Play("ShootEnemy");
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", new Vector2(transform.position.x + 0.4f, transform.position.y - 0.5f), transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * Addedforce);
        SetTimer(timeTillShoot, () => ShootingMethod());
        yield return null;
    }

    private void ShootingMethod() {
        StartCoroutine(Shoot());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            AudioManager.inst.Play("BossHit");
            lifeComponent.life -= 1;
            lifeInt = (int) lifeComponent.life;
            EventsManager.eventsManager.ChangeTheBossLifeValue(lifeInt);
            ShakeTheCamera(0.2f);
            if(collision.gameObject.layer == LayerMask.NameToLayer("ReturnedBullet")) collision.gameObject.layer = LayerMask.NameToLayer("Bullet");
            ObjectsPool.returnToQueque(collision.gameObject);
        }

    }

    private IEnumerator DeadAnimation() {
        ShakeTheCamera(10f);
        for (int i = 0; i < 40; i++){
            yield return new WaitForSeconds(0.25f);
            randomPositionX = Random.Range(-1,1f);
            randomPositionY = Random.Range(0, 2.3f);
            ObjectsPool.UsePoolObject("Explosion", new Vector2(transform.position.x +randomPositionX , transform.position.y + randomPositionY), Quaternion.identity);
        }
        yield return null;
    }

    private IEnumerator BanishShip()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        for (int i = 1; i <= 255; i++) {
            yield return new WaitForSeconds(0.039f);
            foreach (GameObject part in BossParts){
                colorBossShip = part.GetComponent<SpriteRenderer>().color;
                colorBossShip.a = 1f / 255f;
                part.GetComponent<SpriteRenderer>().color -= new Color(0,0,0,colorBossShip.a);
            }
        }
        yield return new WaitForSeconds(0.01f);
        gameObject.SetActive(false);
        yield return null;
    }

    

    void ShakeTheCamera(float time)
    {
        StartCoroutine(Shake.Shaker(time));
    }

}
