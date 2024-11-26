using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaPresion : MonoBehaviour
{
    private float speed;

    public Transform finalPosition;



    void Start()
    {
        speed = 2;
    }


    void Update()
    {

    }

    public void OpenDoor1()
    {
        Vector3 a = transform.position;
        Vector3 b = finalPosition.position;

        transform.position = Vector3.Lerp(a, b, speed);
    }

   
}
