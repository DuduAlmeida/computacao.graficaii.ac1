using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
  public float multiplier = 3f;
  public float maxVelocity = 5f;

  private static Rigidbody rb;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  void Update()
  {
    var horizontialInput = Input.GetAxis("Horizontal");
    var horizontalVelocityToAdd = horizontialInput * multiplier;

    if (rb.velocity.magnitude <= maxVelocity)
    {
      rb.AddForce(new Vector3(horizontalVelocityToAdd, 0, 0));
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Hazard"))
    {
      GameManager.GameOver();

      Destroy(gameObject);
    }
  }

  public static float GetPlayerXPosition(){

    return rb.position.x;
  }
}
