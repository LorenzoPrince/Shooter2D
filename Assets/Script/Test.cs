using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]//funcion que hace que el componente se ponga automaticamente en el objeto, ya que lo requiere y tampoco se podra eliminar en otro script o etc.
public class Test : MonoBehaviour
{
    [SerializeField] float speed = 3f; //mantiene la variable privada pero podes verla en el inspecto
    private float playerMov;

    private int strongJump = 5;
    private bool Jumping = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Movimiento()
    {
        playerMov = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3 (playerMov * speed * Time.deltaTime, 0f, 0f); //el transform punto position pide vector 3
        if (Input.GetKeyDown(KeyCode.Space) && Jumping == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, strongJump);
            Jumping = true;
        }     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Jumping = false;
        }
    }
}
