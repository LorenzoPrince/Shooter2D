using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Camera cam;


    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        // Obtenemos la posición del ratón en el mundo.
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));

        // Calculamos la dirección del ratón con respecto al objeto.
        Vector3 direction = mousePos - transform.position;

        // Calculamos el ángulo de rotación en radianes, y lo convertimos a grados.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplicamos la rotación. Aseguramos que el objeto mire hacia el ratón.
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

    }
}