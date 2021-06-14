using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;
public class NPC3_Manager : MonoBehaviour
{
    public GameObject monster;
    public GameObject fireringAppear;
    public GameObject fireringQuit;
    public Animator anima;
    private Vector3 origin; 

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        origin = this.gameObject.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        ////// Appear /////
        if (timer <= 10)  // start a fire ring every 60 seconds
        {
            fireringAppear.GetComponent<Transform>().position = origin;
            monster.GetComponent<Transform>().position = fireringAppear.GetComponent<Transform>().position;

            fireringAppear.GetComponent<VisualEffect>().enabled = true;
            if (timer >= 5 && timer <= 10)
            {
                monster.SetActive(true);
                //anima.SetBool("End", false);
            }
        }
        else if (timer > 10 && timer < 70) //moster start attack within 60 seconds
        {
            fireringAppear.GetComponent<VisualEffect>().enabled = false;
            monster.GetComponent<AI_Motion>().enabled = true;
        }
        ///// Disappear /////
        else if (timer >= 70 && timer < 80) // start a fire ring every 60 seconds
        {
            monster.GetComponent<AI_Motion>().enabled = false;

            fireringQuit.GetComponent<Transform>().position = monster.GetComponent<Transform>().position;
            fireringQuit.GetComponent<VisualEffect>().enabled = true;

            //anima.SetBool("End", true);
            if (timer >= 75 && timer < 80)
            {
                monster.SetActive(false);
            }
        }
        else if (timer >= 80 && timer < 140) // monster cd time
        {
            fireringQuit.GetComponent<VisualEffect>().enabled = false;
        }
        else if (timer >= 140) //end the loop
        {
            timer = 0;
        }
    }

}
