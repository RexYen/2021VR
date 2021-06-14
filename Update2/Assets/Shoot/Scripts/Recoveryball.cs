using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoveryball : MonoBehaviour
{
    // Start is called before the first frame update
    public ProgressBar Pb;
    public GameObject exp2;
    


    
    //public int Valeur ;
    void Start(){
       
         
        
    }
    
    
    // Update is called once per frame
    void Update()
    {
      
      
    }
    void OnCollisionEnter(Collision other){

        if(other.gameObject.tag=="1"){
            Pb.BarValue -=35 ;
            Destroy(this.gameObject);
            Instantiate(exp2,transform.position,transform.rotation);
        }
        
        
        
    }
       
    
    void attack(){
        Pb.BarValue -=10 ;
        //CancelInvoke("attack");
    }
}
