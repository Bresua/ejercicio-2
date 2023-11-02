using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioEnemigo : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
    if (other.CompareTag("Enemigo"))
    {
        Destroy(gameObject);
        Debug.Log("Has perdido");
    }
   }
}
