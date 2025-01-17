using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 3f;
    private Vector2 mov;
    Rigidbody2D rb;
    public Animator anim;
    private SpriteRenderer spritePerso;
    private int lifePlayer = 3;
    [SerializeField] Health health;
    private bool canMove = true;
    public AudioSource audioSource; //llamo para el audio



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
        if (canMove)  // verifico si esta true osea no esta muerto asi puedo moverme.
        { 
            Move();
        }

    }

    private void Move()
    {
        mov.x = Input.GetAxisRaw("Horizontal") * speed;
        mov.y = Input.GetAxisRaw("Vertical") * speed;
        rb.velocity = new Vector2(mov.x, mov.y); // el rb.velocity se encarga de mantener el movimiento independiente a los frame


        anim.SetFloat("Horizontal", mov.x);
        anim.SetFloat("Speed", mov.sqrMagnitude);
        if (mov.x != 0) // Si el jugador se mueve en el eje horizontal
        {
            spritePerso.flipX = mov.x < 0; // Si se mueve a la izquierda, se voltea (flipX)
        }
    }
    private void damageReceived()
    {
        if (lifePlayer > 0) 
        { 
            lifePlayer --; //resta
            health.heartRest(lifePlayer);
            if (lifePlayer == 0)
            {
                canMove = false; // desactiva el movimiento
                rb.constraints = RigidbodyConstraints2D.FreezeAll; //frezeo el movimiento en todos los ejes para que no empujen al personaje
                audioSource.Play();
                anim.SetTrigger("Muere");
                Invoke(nameof(Morir), 2f); // invoco para que haga la animacion y desaparezca luego de 2 segundos que es el tiempo de animacion desaparece.
                Debug.Log("muerto");
            }
        } 
    }
    private void Morir()
    {

        string sceneName = SceneManager.GetActiveScene().name; //agarro escena
        SceneManager.LoadScene(sceneName);
        //Destroy(this.gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Shot"))
        {
            damageReceived();
        }
    }
}
