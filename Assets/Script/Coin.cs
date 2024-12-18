using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    public int collectedItems;
    public int totalItems;
    public TMPro.TextMeshProUGUI scoreText;
    private int pointsToAdd;

    public AudioSource audioSource; //lamo para el audio
    void Start()
    {
        //   audioSource = GetComponent<AudioSource>(); // busco el audio
        if (SceneManager.GetActiveScene().name == "Scene1") //esto para que ccuando arranque de nuevo no tenga los puntos viejos
        {
            collectedItems = 0;
            PlayerPrefs.SetInt("CollectedCoins", collectedItems);  // Reiniciar el valor en PlayerPrefs
            PlayerPrefs.Save();  // Guardar los cambios
        }
        else
        {

            collectedItems = PlayerPrefs.GetInt("CollectedCoins", 0); //guarda datos persistentes osea guarda hasta el final las money
        }
        UpdateScore();
    }

    

    // Update is called once per frame

    private void UpdateScore()
    {
        // Update score in screen
        scoreText.text = collectedItems + " ";
    }


    private void CollectItem(string tag)
    {

        switch (tag)
        {
            case "Point1":
                pointsToAdd = 1;
                break;
            case "Point2":
                pointsToAdd = 3;
                break;
            case "Point3":
                pointsToAdd = 5;
                break;
        }
        collectedItems += pointsToAdd;
        PlayerPrefs.SetInt("CollectedCoins", collectedItems);  // Guardar el número de monedas en PlayerPrefs
        PlayerPrefs.Save();  // Guardar los cambios
        UpdateScore();


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Tocando el objeto: " + other.gameObject.name);

        //verificacion de etiqueta
        if (other.CompareTag("Point1") || other.CompareTag("Point2") || other.CompareTag("Point3"))
        {
            CollectItem(other.tag);  //lamamo funcion con el objeto y su etiqueta
            if (audioSource != null)
            {
                // Reproduce el sonido solo si el AudioSource anda prueba pq no me andaba. arreglado.
                audioSource.Play();
                Debug.Log("Reproduciendo sonido");
            }
            else
            {
                Debug.LogError("AudioSource no está asignado correctamente.");
            }

            Destroy(other.gameObject);  
        }

    }
}