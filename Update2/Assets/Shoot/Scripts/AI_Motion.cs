using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using UnityStandardAssets.Characters.ThirdPerson;

public class AI_Motion : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent monster;
    //public ThirdPersonCharacter character;
    private float wander_radius = 20;
    private float wander_timer = 4;
    private float timer;

    private Vector3 newpos;

    private Animator animator;
    private GameObject model;

    private Vector3 FireTarget;

    IEnumerator ie;
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    //private void OnEnable()
    //{
    //    ie = SetNewPosition();
    //    StartCoroutine(ie);

    //}

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        monster = this.gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();
        model = GameObject.Find("NPC3");
        
        monster.updateRotation = false;

        //ie = SetNewPosition();
        //StartCoroutine(ie);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < wander_timer)
        {
            if (monster.remainingDistance > monster.stoppingDistance)
            {
                animator.SetBool("Attack", false);
                Vector3 destination = newpos - this.gameObject.transform.position;
                Quaternion q = Quaternion.LookRotation(destination);
                this.gameObject.transform.localRotation = Quaternion.Slerp(this.gameObject.transform.localRotation, q, 1 * Time.deltaTime);
            }
            else
            {
                FireTarget = GameObject.Find("Player").transform.position;
                Vector3 dest = FireTarget - this.gameObject.transform.position;
                Quaternion r = Quaternion.LookRotation(dest);
                this.gameObject.transform.localRotation = Quaternion.Slerp(this.gameObject.transform.localRotation, r, 10 * Time.deltaTime);
                animator.SetBool("Attack", true);
            }
        }
        else
        {
            newpos = RandomNavSphere(model.transform.position, wander_radius, -1);
            monster.SetDestination(newpos);
            timer = 0;
        }
    }
}
