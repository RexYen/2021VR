﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyattack : MonoBehaviour
{
    // Start is called before the first frame update
    public ProgressBar Pb;
    
    


    
    //public int Valeur ;
    void Start(){
       
        Pb.BarValue=100;     
        
    }
    
    
    // Update is called once per frame
    void Update()
    {
      
      
    }
    void OnCollisionEnter(Collision other){

        if(other.gameObject.tag=="1"){
            Pb.BarValue -=20 ;
            
            
        }
        
        
        
    }
       
    

}
