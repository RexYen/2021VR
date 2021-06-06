using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public float movementSpeed;

    // Use this for initialization
    void Start()
    {

    }

    //Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("q") && !Input.GetKey("e"))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * movementSpeed * 5);
        }
        else if (Input.GetKey("e") && !Input.GetKey("q"))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * movementSpeed * 5);
        }

        if (Input.GetKey("w") && !Input.GetKey("s"))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("s") && !Input.GetKey("w"))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
    }
}