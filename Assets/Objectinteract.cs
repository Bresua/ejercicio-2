using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objectinteract : MonoBehaviour
{
     public inventario inventario;
     public float velocidadrotacion = 100f;
     private int Monedarecogida = 0;
     public int totalMonedas = 8;
     public ParticleSystem particulasMoneda;
    //private bool mostrarMensaje = true;


    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<inventario>();
    }

   private void OnTriggerEnter(Collider other)
   {

     Monedarecogida++; 
        inventario.cantidad++;
        Destroy(gameObject);
        Debug.Log("1 moneda recogida");
        Debug.Log("Monedas totales recogidas: " + inventario.cantidad);
      if (other.CompareTag("Player"))
        {
            particulasMoneda.gameObject.SetActive(true);
            particulasMoneda.transform.position = other.transform.position;
            particulasMoneda.Play();

        }
       if (inventario.cantidad == totalMonedas)
        {
        // Todas las monedas se han recogido, termina el juego
        Debug.Log("¡Has recogido todas las monedas!");
        EndGame();
        }
   }
       
    

     void OnCollisionEnter(Collision collision)
   {
    if (collision.gameObject.CompareTag("Moneda"))
    {
        Debug.Log("Moneda");
        Monedarecogida ++;
        Debug.Log("Moneda.total: " + Monedarecogida);
    }
    
   }


   void Update()
   {
    transform.Rotate(Vector3.up * velocidadrotacion * Time.deltaTime);
   }
   

   void EndGame()
    {
        // Carga una escena de finalización del juego o realiza otra acción de finalización
        SceneManager.LoadScene("EscenaDeFinalizacion"); // Reemplaza "EscenaDeFinalizacion" con el nombre de tu escena final
    }
  
}