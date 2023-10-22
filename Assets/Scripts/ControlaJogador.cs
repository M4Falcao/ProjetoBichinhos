using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlaJogador : MonoBehaviour
{
    public float Speed = 5.0f; 
    public LayerMask Floor;
    public GameObject TextoGameOver;
    public int Vida = 100;
    public ControlaInterface ScriptControlaInterface;

    private Rigidbody body;
    private Animator animator;
    private Vector3 movement;


    private void Start()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Time.timeScale = 1;

    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");  // Movimento horizontal
        float vertical = Input.GetAxis("Vertical");  // Movimento vertical

       
        movement = new Vector3(horizontal, 0.0f, vertical);  // Vetor de movimento


        if(movement != Vector3.zero)
        {
            animator.SetBool("Movendo", true);
        }
        else
        {
            animator.SetBool("Movendo", false);
        }

        if (Vida<=0 && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("game");
        }
    }

    void FixedUpdate()
    {

        body.MovePosition((movement * Speed * Time.deltaTime) + body.position);

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit impact;
        Debug.DrawRay(raio.origin, raio.direction * 100);

        if (Physics.Raycast(raio, out impact, 100, Floor))
        {
            Vector3 posicaoMiraDoJogador = impact.point - body.position;
            posicaoMiraDoJogador.y = body.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraDoJogador);
            body.MoveRotation(novaRotacao);

        }

    }

    public void TomarDano(int dano)
    {
        Vida = Vida - dano;
        ScriptControlaInterface.AtualizaLifeBar();

        if(Vida <= 0)
        {
            Time.timeScale= 0.0f;
            TextoGameOver.SetActive(true);
        }
    }

}
