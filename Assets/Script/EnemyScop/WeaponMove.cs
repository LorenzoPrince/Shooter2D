using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponMove : MonoBehaviour
{
    public GameObject referencia; // La referencia que queremos usar (en este caso, el enemigo o personaje)
    public float offsetRight = 2f; // Distancia a mover el arma cuando está a la derecha
    private Vector3 initialPosition; // Guardamos la posición inicial del arma
    private SpriteRenderer spritePerso; // Para voltear el sprite del arma
    private SpriteRenderer referenciaSprite; // Para acceder al SpriteRenderer de la referencia

    // Start is called before the first frame update
    void Start()
    {
        spritePerso = GetComponentInChildren<SpriteRenderer>(); // Obtener el SpriteRenderer del arma
        initialPosition = transform.position; // Guardamos la posición inicial del arma

        // Verificar si el componente SpriteRenderer está presente en la referencia
        if (referencia != null)
        {
            referenciaSprite = referencia.GetComponent<SpriteRenderer>();
            if (referenciaSprite == null)
            {
                Debug.LogError("El GameObject de referencia no tiene un SpriteRenderer.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (referencia == null || referenciaSprite == null)
            return; // Si no hay referencia o no se encuentra el SpriteRenderer, no hacer nada

        // Comprobar si la referencia está mirando hacia la izquierda (flipX)
        if (referenciaSprite.flipX)
        {
            // El arma debe estar a la izquierda del personaje
            spritePerso.flipX = true; // Voltea el sprite del arma
            transform.position = initialPosition; // Mantén el arma en su posición inicial
        }
        else
        {
            // El arma debe estar a la derecha del personaje
            spritePerso.flipX = false; // Voltea el sprite del arma
            transform.position = new Vector3(initialPosition.x + offsetRight, initialPosition.y, initialPosition.z); // Mueve el arma a la derecha
        }
    }
}