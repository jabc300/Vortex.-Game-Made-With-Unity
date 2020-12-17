using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public float speed;
    private float sizeInworldfromcamerax;
    private float orthographicShipPositionx;
    private float middleWidthOfTheShip;
    private float timer;
    public int life;
    

    private bool revive;
    private bool alive;
    private bool notInvulnerable;
    private bool UseTheShield;

    private bool vortexNotInUse;
    private bool laserNotInUse;
    private bool shieldNotInUse;

    private Camera cameraRef;
    private CameraShake Shake;

    private Vector2 rightVector;
    private Vector2 upVector;
    private Vector3 inFront;
    private Vector2 initialPosition;
    private Vector2 shipPositionPixels;

    private Animator shipAnimator;
    private Animator shieldAnimator;

    public GameObject Bullet;
    public GameObject Shield;
    public GameObject Laser;
    public GameObject Explosion;

    private AudioSource explosionSound;

    private Color colorForAlpha;

    private Shield shieldComponent;

    private KeyCode VortexKey;
    private KeyCode LeftMovementKey;
    private KeyCode RightMovementKey;
    private KeyCode LaserKey;
    private KeyCode ShieldKey;

    // Start is called before the first frame update
    void Start()
    {
        LeftMovementKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), KeysManager.Keys[0]);
        RightMovementKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), KeysManager.Keys[1]);
        VortexKey = (KeyCode) System.Enum.Parse(typeof(KeyCode), KeysManager.Keys[2]);       
        LaserKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), KeysManager.Keys[3]);
        ShieldKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), KeysManager.Keys[4]);

        timer = 0;

        vortexNotInUse = true;
        laserNotInUse = true;
        shieldNotInUse = true;

        notInvulnerable = true;
        alive = true;
        //explosionSound = GetComponent<AudioSource>();
        revive = true;
        initialPosition = new Vector2(0,-4f);
        colorForAlpha = gameObject.GetComponent<Renderer>().material.color;
        EventsManager.eventsManager.ChangeTheLifeValue(life);
        cameraRef = Camera.main;
        Shake = cameraRef.GetComponent<CameraShake>();
        sizeInworldfromcamerax = cameraRef.orthographicSize * cameraRef.aspect;
        speed = 4.5f;
        rightVector = new Vector2(1f, 0);
        upVector = new Vector2(0, 1f);

        shipAnimator = gameObject.GetComponent<Animator>();
        shieldAnimator = Shield.GetComponent<Animator>();

        shieldComponent = Shield.GetComponent<Shield>();
        middleWidthOfTheShip = gameObject.GetComponent<SpriteRenderer>().size.x/5;
    }

    void Update() {
        timer += Time.deltaTime;
        if (revive)
        {
            if (laserNotInUse && shieldNotInUse)
            {
                if (timer >= 0.5f && (Input.GetKeyDown(VortexKey)))
                {
                    vortexNotInUse = false;
                    shipAnimator.SetTrigger("Attack");
                    timer = 0;
                }
                else if (Input.GetKeyUp(VortexKey)) vortexNotInUse = true;
            }

            if (vortexNotInUse && laserNotInUse && ScoreManager.unlockedShield) {
                if (Input.GetKey(ShieldKey))
                {
                    shieldNotInUse = false;
                    shieldAnimator.SetBool("Activated", true);
                }
                else if (Input.GetKeyUp(ShieldKey))
                {
                    shieldNotInUse = true;
                    shieldAnimator.SetBool("Activated", false);
                }
            }

            if (vortexNotInUse && shieldNotInUse && ScoreManager.unlockedLaser) {
                if (Input.GetKey(LaserKey))
                {
                    laserNotInUse = false;
                    Laser.SetActive(true);
                }
                else if (Input.GetKeyUp(LaserKey)) {
                    laserNotInUse = true;
                    Laser.SetActive(false);
                }
            }
        }
        //---------------------------------

        //if (Input.GetKey(KeyCode.Escape)) Application.Quit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Calculate the width of the screen
        shipPositionPixels = cameraRef.WorldToScreenPoint(transform.position);
        orthographicShipPositionx = (shipPositionPixels.x / Screen.width) * sizeInworldfromcamerax;
        //---------------------------------

        //Controls-------------------------
        if (Input.GetKey(RightMovementKey) && orthographicShipPositionx + middleWidthOfTheShip <= sizeInworldfromcamerax && revive) transform.position += (Vector3)rightVector * Time.deltaTime * speed;
        else if (Input.GetKey(LeftMovementKey) && orthographicShipPositionx - middleWidthOfTheShip > 0 && revive) transform.position -= (Vector3)rightVector * Time.deltaTime * speed;
    }

    void shootVortex() {
        inFront = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        AudioManager.inst.Play("ShipShoot");
        ObjectsPool.UsePoolObject("BulletVortex", inFront, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Healing"))
        {
            life ++;
            EventsManager.eventsManager.ChangeTheLifeValue(life);
            //numberlife.text = "Lives: " + life;
            ObjectsPool.returnToQueque(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Shield")) {
            if (shieldComponent.shieldLife <= 0)
            {
                shieldAnimator.SetBool("DestroyedShield",false);
                Shield.GetComponent<BoxCollider2D>().enabled = true;
            }
            shieldComponent.shieldLife += 5;
            EventsManager.eventsManager.ChangeTheShieldValue(shieldComponent.shieldLife);
            ObjectsPool.returnToQueque(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet") && notInvulnerable) 
        {
            ObjectsPool.returnToQueque(collision.gameObject);
            changeTheAlfa(0);
            ObjectsPool.UsePoolObject("Explosion", gameObject.transform.position, Quaternion.identity);

            if (notInvulnerable)
            {
                ScoreManager.ResetScoreMultiplierAndDeadCounter();
                EventsManager.eventsManager.ChangeTheScore();
                life --;
                // TURN OFF LASER, SHIELD
                shieldAnimator.SetBool("Activated", false);
                Laser.SetActive(false);
                vortexNotInUse = true;
                laserNotInUse = true;
                shieldNotInUse = true;
                //----------------------
            }
            notInvulnerable = false;
            revive = false;
            
            if (life <= 0)
            {
                life = 0;
                alive = false;
                StartCoroutine(Dead());
            }
            else if (life > 0 && alive) StartCoroutine(Revive());
            EventsManager.eventsManager.ChangeTheLifeValue(life);
        }
    }

    IEnumerator Revive() {
        yield return new WaitForSeconds(0.6f);
        revive = true;
        changeTheAlfa(0.5f);
        yield return new WaitForSeconds(3.0f);
        changeTheAlfa(1f);
        notInvulnerable = true;
        yield return null;
    }

    void changeTheAlfa(float porcentageAlpha) {
        colorForAlpha.a = porcentageAlpha;
        GetComponent<Renderer>().material.color = colorForAlpha;
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.5f);
        EventsManager.eventsManager.ActivateGameOver();
        yield return new WaitForSeconds(3f);
        ScoreManager.ResetScore();
        ScoreManager.ResetScoreMultiplierAndDeadCounter();
        SceneManager.LoadScene("Selection", LoadSceneMode.Single);
        yield return null;
    }

    void ShakeTheCamera() {
        StartCoroutine(Shake.Shaker(0.15f));
    }

}
