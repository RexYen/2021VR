using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFire : MonoBehaviour
{

        
    private Transform target;
    private Vector3 BallisticVel2(Transform origin, Transform destination, float angle)
    {
        Vector3 direction = destination.position - origin.position;
        float height = direction.y;
        direction.y = 0;

        float distance = direction.magnitude;
        float a = angle * Mathf.Deg2Rad;
        direction.y = distance * Mathf.Tan(a);
        distance += height / Mathf.Tan(a);
        if (distance < 0.0) distance = -1 * distance;
        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * direction.normalized;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Destroy", 10);
        target = GameObject.Find("Player").transform;
        this.gameObject.GetComponent<Rigidbody>().velocity = BallisticVel2(transform,target, 30.0f);
        
    }

    // Update is called once per frame
    private void Update()
    {

    }

   
}
