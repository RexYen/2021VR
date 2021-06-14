using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour
{

    float fMoveSpeed = 3; //移動速度

    float fRotateSpeed = 60; //旋轉速度

    void Start() { }

    void Update()
    {

        PlayerControl1();

    }

    void PlayerControl1()

    {

        //移動

        if (Input.GetKey(KeyCode.W))

        {

            transform.Translate(Vector3.forward * Time.deltaTime * fMoveSpeed);

        }

        else if (Input.GetKey(KeyCode.S))

        {

            transform.Translate(Vector3.back * Time.deltaTime * fMoveSpeed);

        }

        //旋轉

        if (Input.GetKey(KeyCode.A))

        {

            transform.Rotate(Vector3.up * Time.deltaTime * fRotateSpeed);

        }

        else if (Input.GetKey(KeyCode.S))

        {

            transform.Rotate(Vector3.down * Time.deltaTime * fRotateSpeed);

        }

    }

}