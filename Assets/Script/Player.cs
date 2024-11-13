using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 3f;
    private float movX, movY;
    Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal") * speed;
        movY = Input.GetAxisRaw("Vertical") * speed;
        rb.velocity = new Vector2(movX, movY);
    }
}
