using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraZumbi : MonoBehaviour
{
    public GameObject Zumbi;
    public float TempoDeZumbi = 1;

    public float gameTimer;
    public float timer;
    void Start()
    {
        gameTimer = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameTimer < 500) gameTimer = gameTimer + Time.deltaTime;
        timer = timer + Time.deltaTime;
        float tempo = (600 - gameTimer) / 600;
        if(timer >= (TempoDeZumbi * tempo))
        {
            Instantiate(Zumbi, transform.position, transform.rotation);
            timer = 0;
        }
        
    }
}
