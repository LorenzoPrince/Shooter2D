using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class villagerText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, TextArea(3, 10)] private string[] arrayText;        //creamos array con todos los texto que le voy a poner tambien el text sirve para que podamos poner de una el texto en la array
    [SerializeField] private UIManager uIManager; //control de ui script reference
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text pressE;
    private bool isDialogActive = false;


    private Rigidbody2D playerRb; // Referencia al Rigidbody2D del jugador

    private int index; //de la array
    private void Start()
    {
        Dectect();  // Asegurarse de que el jugador est� asignado
    }
    private void Dectect()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); // una forma para comunicarme con otro script.
        playerRb = player.GetComponent<Rigidbody2D>();// esto pa dps sacar el movimiento al player
    }
    void Update()
    {
 
        float distance = Vector2.Distance(this.gameObject.transform.position, player.transform.position);
        if (distance < 2f && !isDialogActive && enemyLife() == 0)
        {
            pressE.gameObject.SetActive(true);  // Activar el texto "Presiona E" // ver el texto
            Debug.Log("adentro del rango personaje");
            if (Input.GetKeyDown(KeyCode.E) && enemyLife() == 0)
            {
                Debug.Log("tocaste e");
                pressE.gameObject.SetActive(false);
                uIManager.activeDesactiveBoxText(true);
                Debug.Log("Caja de texto activada"); //prueba de pq no andaba
                playerRb.constraints = RigidbodyConstraints2D.FreezeAll;
                isDialogActive = true; //para que no detecte
                Activate();
            }
        }
        else if (distance >= 2f)
        {
            pressE.gameObject.SetActive(false); //renegue con esto mucho :/
        }
        if (isDialogActive && Input.GetKeyDown(KeyCode.E))
        {
            Activate();
        }


    }
    void Activate()
    {
        if (index < arrayText.Length) //recorro para ir poniendo el texto
        {
            Debug.Log($"Mostrando texto: {arrayText[index]}");  // Muestra el texto actual en el Log
            uIManager.viewText(arrayText[index]); // mostrar elemento texto del indice
            index++;
        }
        else
        {
            uIManager.activeDesactiveBoxText(false); //desativa la caja
            Debug.Log("termino dialogo");
            index = 0; //para leerlo de nuevo
            playerRb.constraints = RigidbodyConstraints2D.FreezeRotation; //frezea rotacion en y e x arreglo error de que no se frezee en z
            isDialogActive = false;
        }
    }
    private int enemyLife() //i nt si no no anda con void pq devuelve numero 
    {
        // Encontramos todos los objetos con la etiqueta
        GameObject[] enemi = GameObject.FindGameObjectsWithTag("Enemy");

        // Retornamos la cantidad de enemigos encontrados
        return enemi.Length;

    }
}