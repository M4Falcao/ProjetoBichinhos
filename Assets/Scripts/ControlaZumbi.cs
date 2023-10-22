using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ControlaZumbi : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocidade = 5;
    public GameObject Placar;

    private Rigidbody body;
    private Animator animator;

    private void Start()
    {
        Jogador = GameObject.FindWithTag("Player");
        Placar = GameObject.FindWithTag("Placar");
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        int indexTipoDeZumbi = UnityEngine.Random.Range(1, 28);
        transform.GetChild(indexTipoDeZumbi).gameObject.SetActive(true);
        

    }

    void FixedUpdate()
    {
        Vector3 direcao = Jogador.transform.position - transform.position;
        body.MoveRotation(Quaternion.LookRotation(direcao));

        if (direcao.magnitude > 2.5) 
        {
            body.MovePosition(body.position + direcao.normalized * Velocidade * Time.deltaTime);
            animator.SetBool("Atacando", false);

        } 
        else
        {
            animator.SetBool("Atacando", true);
        }
        
        
    }
    void AtacaJogador()
    {
        int dano = UnityEngine.Random.Range(20,30);
        Jogador.GetComponent<ControlaJogador>().TomarDano(dano);
        
    }
    private void OnDestroy()
    {
        Placar.GetComponent<ContadorZumbis>().Pontuar();
        
    }
    public void Morre()
    {
    }
}
