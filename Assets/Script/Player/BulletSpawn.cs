using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private float bulletForce; //es para que sea privado pero se siga viendo en el inspector y editarlo, pero no podes editarlo en otro script. 
    [SerializeField] private GameObject objectPrefab;
    public Vector2 spawnPosition;
    GameObject bulletClone;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bulletClone = Instantiate(objectPrefab, transform.position, transform.rotation); // el quaternion. identity es para que sea en la misma posicion que el vector . y el vector que esta el spawn

            Rigidbody2D bulletRigidBody = bulletClone.GetComponent<Rigidbody2D>(); //rigid body de la nueva bala

            Vector2 direction = transform.right; //apunta a la direccion del eje x asi mira a donde esta viendo el personaje
            bulletRigidBody.velocity = direction * bulletForce; // impulso de la bala multiplicado por el bulletforce

            Destroy(bulletClone, 2f);
        }

    }

}