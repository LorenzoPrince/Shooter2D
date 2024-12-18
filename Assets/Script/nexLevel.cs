using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nexLevel : MonoBehaviour
{
    // Start is called before the first frame update

    private int totalsEnemy;


    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player") )
        {
            totalsEnemy = CountEnemy();
            Debug.Log("adentro total enemigos vivos: " + totalsEnemy);
            if (totalsEnemy == 0)
            {
                Debug.Log("cambio escena");
                UnityEngine.SceneManagement.SceneManager.LoadScene("Scene2"); // uso esta forma pq el scene solo no va 
            }
        }
    }
    private int CountEnemy()
    {
        // Encontramos todos los objetos con la etiqueta
        GameObject[] enemi = GameObject.FindGameObjectsWithTag("Enemy");

        // Retornamos la cantidad de enemigos encontrados
        return enemi.Length;
    }
}
