using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{

    [SerializeField] float lifeTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,lifeTime);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //saque vida
            Debug.Log("Le pego al jugador");
            Destroy(gameObject);
        }
        else
        {
            // También puedes verificar las colisiones con otros objetos si es necesario
            Debug.Log("La bala colisionó con otro objeto: " + collision.gameObject.name);
        }
    }
}
