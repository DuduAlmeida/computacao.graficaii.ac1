using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
  Vector3 rotation;

  private void Start()
  {
    rotation = new Vector3(0, 0, 0.5f);
  }

  private void Update()
  {
    transform.Rotate(rotation);
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (!collision.gameObject.CompareTag("Syringe") && !collision.gameObject.CompareTag("Hazard"))
    {
      if(collision.gameObject.CompareTag("Player")) {
        GameManager.OnColideWithSyringe();
      }
      
      Destroy(gameObject);
    }

  }
}
