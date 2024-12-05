using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Items : MonoBehaviour
{
    // Start is called before the first frame update
    public int collectedItems;
    public int totalItems;
    public TMPro.TextMeshProUGUI scoreText;
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame

    private void UpdateScore()
    {
        // Update score in screen
        scoreText.text = collectedItems + " " ;
    }
    private void collectionItem(Collider2D contraLoQueChoque)
    {
        Destroy(contraLoQueChoque.gameObject);
        collectedItems++;
        UpdateScore();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("tocando el objeto" + other.gameObject.name);

        if (other.CompareTag("Point"))
        {
            collectionItem(other);

        }


    }
}