using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
       void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate (new Vector3 (30, 75, 45) * Time.deltaTime);
    }
}
