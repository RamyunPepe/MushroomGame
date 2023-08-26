using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float raycast_lenght;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, trasform.foward * raycast_lenght, Color.red);
    }
}
