using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 3f;
    private Vector2 mov;
    Rigidbody2D rb;
    public Animator anim;
    private SpriteRenderer spritePerso;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>(); // ya que no esta en objeto padre si no en el hijo.
        spritePerso = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mov.x = Input.GetAxisRaw("Horizontal") * speed;
        mov.y = Input.GetAxisRaw("Vertical") * speed;
        rb.velocity = new Vector2(mov.x, mov.y); // el rb.velocity se encarga de mantener el movimiento independiente a los frame
        anim.SetFloat("Caminar", Mathf.Abs(rb.velocity.magnitude)); // nos devuelve un numero absoluto y revisa la velocidad

        anim.SetFloat("Horizontal", mov.x);
        anim.SetFloat("Speed", mov.sqrMagnitude);
    }



}
