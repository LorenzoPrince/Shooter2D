using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    public enum EnemyStateMachine
    {
        Idle,
        Perseguir,
        Atacar,
        Morir
    }
    private EnemyStateMachine currentState;
    public Transform jugador;
    public float rangoAtaque = 2f;
    public float rangoDeteccion = 5f;
    public float velocidad = 3f;
    private bool isDead = false;
    void Start()
    {
        currentState = EnemyStateMachine.Idle;

    }
    void Update()
    {
        switch (currentState)
        {
            case EnemyStateMachine.Idle:
                Idle();
                break;
            case EnemyStateMachine.Perseguir:
                Perseguir();
                break;
            case EnemyStateMachine.Atacar: //Para el ejemplo no hacer nada, solo da un mensaje
                Atacar();
                break;
            case EnemyStateMachine.Morir: //Para el ejemplo no hace nada, se deberia implementar algo y que corte la ejecución
                Morir();
                break;
        }
    }
    void Idle()
    {
        Debug.Log("Enemigo en estado Idle");
        if (Vector3.Distance(transform.position, jugador.position) < rangoDeteccion && !isDead)
        {
            currentState = EnemyStateMachine.Perseguir;
        }
    }
    void Perseguir()
    {
        Debug.Log("Enemigo persiguiendo al jugador");
        transform.position = Vector3.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);
        if (Vector3.Distance(transform.position, jugador.position) < rangoAtaque)
        {
            currentState = EnemyStateMachine.Atacar;
        }
        if (Vector3.Distance(transform.position, jugador.position) > rangoDeteccion)
        {
            currentState = EnemyStateMachine.Idle;
        }
    }
    void Atacar()
    {

        Debug.Log("Enemigo atacando...");
        currentState = EnemyStateMachine.Idle;
    }
    void Morir()
    {
        Debug.Log("Logica de enemigo murio ");
    }
}