using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jugador : MonoBehaviour
{
  Rigidbody rb;
  
      public float speed = 5f;
      public float rotationSpeed = 50f;
      public float jump = 0.5f;  
      public float jumpForce = 5.0f;
      bool isJump = false;
      bool floordetected = false;

     void Start() 
     {
        rb = GetComponent<Rigidbody>();
     }

    void Update()
    {
        movement();
        jumpsquare();
    }

    void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
       Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
       movementDirection.Normalize(); 

       transform.position = transform.position + movementDirection * speed * Time.deltaTime;

      if(movementDirection != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), rotationSpeed * Time.deltaTime);
    }

    void jumpsquare()
    {
        Vector3 floor = transform.TransformDirection(Vector3.down);

      if (Physics.Raycast(transform.position, floor, 1.0f))
      {
         floordetected = true;
      }
      else
      {
        floordetected = false;
      }

      isJump = Input.GetButtonDown("Jump"); 

      if(isJump && floordetected)
      {
        rb.AddForce(new Vector3 (0, jumpForce, 0 ), ForceMode.Impulse);
      }
    }

     private void OnCollisionEnter(Collision collision)
    {  
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("Has perdido");
        }
        if (collision.gameObject.CompareTag("sueloinvisible"))
        {
          Destroy(gameObject);
          Debug.Log("Has perdido");
        }
    } 
}
