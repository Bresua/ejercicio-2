using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class zombie : MonoBehaviour
{
    public float rangodeAlerta;
    public LayerMask capaDelJugador;
    bool estarAlerta;
    public Transform jugador;
    public float velocidad;

    void Start()
    {

    }
    
    
    void Update()
    {
      estarAlerta = Physics.CheckSphere(transform.position, rangodeAlerta, capaDelJugador);

      if(estarAlerta == true)
      {
         transform.LookAt(new Vector3(jugador.position.x, transform.position.y, jugador.position.z));
         transform.position = Vector3.MoveTowards(transform.position, new Vector3(jugador.position.x, transform.position.y, jugador.position.z), velocidad * Time.deltaTime);
      }
    }
    
     
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangodeAlerta);
    } 
}
