using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PJustBGAnimator : MonoBehaviour
{
    private Animator anim;
    private int count;
    private float timer;

    void Start()
    {
        anim = GetComponent<Animator>();
        count = 0;
        timer = timer + Time.deltaTime;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.O))
        {
            anim.SetBool("isEating", true);
        }
        else
        {
            anim.SetBool("isEating", false);
        }
        if (timer >= 10)
        {
            anim.SetBool("hasLost", true);
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
        if (count >= 10)
        {
            anim.SetBool("hasWon", true);
        }
        
    }
    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        PJustGameLoader.gameOn = false;
    }
}
