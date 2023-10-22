using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorZumbis : MonoBehaviour
{

    private float pontuacao = 0;
    public TMP_Text placar;
    // Start is called before the first frame update
    void Start()
    {
        placar.text = "0";
    }

    public void Pontuar()
    {
        pontuacao++;
        placar.text = pontuacao.ToString();

    }
}
