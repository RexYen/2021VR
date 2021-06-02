using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject exp1;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other){
      
        
           
            Instantiate(exp1,transform .position,transform .rotation);
            Destroy(gameObject);

        

    }
}
