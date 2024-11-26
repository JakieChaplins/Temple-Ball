using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaPresion0_2 : MonoBehaviour
{
    private float speed;

    public Transform finalPosition;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlacaDown1()
    {
        Vector3 a = transform.position;
        Vector3 b = finalPosition.position;

        transform.position = Vector3.Lerp(a, b, speed);
    }
}
