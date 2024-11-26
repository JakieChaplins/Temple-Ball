using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaPresion2 : MonoBehaviour
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

    public void OpenDoor2()
    {
        Vector3 a = transform.position;
        Vector3 b = finalPosition.position;

        transform.position = Vector3.Lerp(a, b, speed);
    }

    public void PlacaDown2()
    {
        Vector3 a = transform.position;
        Vector3 b = finalPosition.position;

        transform.position = Vector3.Lerp(a, b, speed);
    }
}
