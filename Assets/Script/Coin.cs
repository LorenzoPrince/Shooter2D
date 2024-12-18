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
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame

    private void UpdateScore()
    {
        // Update score in screen
        scoreText.text = collectedItems + " ";
    }
    private void collectionItem(Collider2D contraLoQueChoque)
    {
        Destroy(contraLoQueChoque.gameObject);
        collectedItems++;
        UpdateScore();

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
        UpdateScore();


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Tocando el objeto: " + other.gameObject.name);

        //verificacion de etiqueta
        if (other.CompareTag("Point1") || other.CompareTag("Point2") || other.CompareTag("Point3"))
        {
            CollectItem(other.tag);  //lamamo funcion con el objeto y su etiqueta
            Destroy(other.gameObject);  
        }

    }
}