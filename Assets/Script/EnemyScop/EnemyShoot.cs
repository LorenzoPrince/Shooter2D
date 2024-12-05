using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 2f;
    [SerializeField] float intervalTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    private IEnumerator Shoot() //currutina
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalTime);//intervalo de tiempo

            Vector2 direction = (player.transform.position - transform.position).normalized;  // vector para saber donde esta el jugador
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); //instancia la bala
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity =  direction * bulletSpeed;
        
        }
    }
}
