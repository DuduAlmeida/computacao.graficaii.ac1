using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float multiplier = 3f;
    public float maxVelocity = 5f;

    void Start() {
        
    }

    void Update() {
        var horizontialInput = Input.GetAxis("Horizontal");
        if (GetComponent<Rigidbody>().velocity.magnitude <= maxVelocity) { 
            GetComponent<Rigidbody>().AddForce(new Vector3(horizontialInput * multiplier,0,0));
        }
    }
}
