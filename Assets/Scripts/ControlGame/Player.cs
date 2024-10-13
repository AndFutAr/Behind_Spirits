using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _speedCam = 5;

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += gameObject.transform.forward * _speedCam * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position -= gameObject.transform.forward * _speedCam * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position -= gameObject.transform.right * _speedCam * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += gameObject.transform.right * _speedCam * Time.deltaTime;
        }

        Camera.main.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 10;
    }
}
