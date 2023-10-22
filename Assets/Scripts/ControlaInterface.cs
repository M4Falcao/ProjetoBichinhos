using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaInterface : MonoBehaviour
{
    private ControlaJogador controlaJogador;
    public Slider LifeBar;
    void Start()
    {
        controlaJogador = GameObject.FindWithTag("Player").GetComponent<ControlaJogador>();
        LifeBar.maxValue = controlaJogador.Vida;
        LifeBar.value = controlaJogador.Vida;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtualizaLifeBar()
    {
        LifeBar.value = controlaJogador.Vida;
    }
}
