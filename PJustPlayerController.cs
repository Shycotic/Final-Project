using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PJustPlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;
    private float timer;
    private int wholetime;
    private int count;
    private Animator anim;

    public Text CollectText;
    public Text endText;

    public float barTimer;
    public float barTimer_threshold = 1f;
    public bool moveRight;

    private AudioSource source;
    public AudioClip buttonPress;
    public AudioClip loseSound;
    public AudioClip winSound;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        endText.text = "";
        SetCountText();
    }

    void Awake()
    {

        source = GetComponent<AudioSource>();

    }

    void FixedUpdate ()
    {
        if (moveRight == true)
        {
            barTimer += Time.deltaTime;
            if (barTimer >= barTimer_threshold)
            {
                barTimer = 0;
                moveRight = false;
            }
            transform.Translate(-transform.right * Time.deltaTime * speed, Space.Self);

        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(buttonPress);

            moveRight = true;
            barTimer = 1;           
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            moveRight = true;
            barTimer = 1;
        }
        timer = timer + Time.deltaTime;
        if(timer >= 10)
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(loseSound);

            endText.text = "Well...that's a waste.";            
            StartCoroutine(ByeAfterDelay(2));
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EndGame"))
        {
            count = count + 10;
            PJustGameLoader.AddScore(1);
           
            SetCountText();
        }
    }
    void SetCountText()
    {
        CollectText.text = "Score: " + count.ToString();

        if (count >= 10)
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(winSound);

            endText.text = "Finished!!";
            StartCoroutine(ByeAfterDelay(2));
        }
    }
    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        PJustGameLoader.gameOn = false;
    }
}
