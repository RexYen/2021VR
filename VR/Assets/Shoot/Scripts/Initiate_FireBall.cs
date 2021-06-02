using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initiate_FireBall : MonoBehaviour
{
    public GameObject fireball_prefab;
    private GameObject prefab;
    private GameObject startpoint;

    void Start()
    {
        startpoint = GameObject.Find("FireStartPoint");
        prefab = fireball_prefab;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void YieldBullet() 
    {
        GameObject fireball = Instantiate(prefab, startpoint.transform.position, startpoint.transform.rotation);

    }

}
