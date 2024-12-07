using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Le peg� al enemigo");
            Destroy(collision.gameObject); // Destruye al enemigo
        }
        else
        {
            Debug.Log("La bala colision� con: " + collision.gameObject.name);
        }

        Destroy(gameObject); // Destruye la bala despu�s de cualquier colisi�n
    }
}
