using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody rb;
    private bool playerDied;
    private CameraFollow cf;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cf = Camera.main.GetComponent<CameraFollow>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!playerDied)
        {

            if (rb.velocity.sqrMagnitude > 60)
            {

                playerDied = true;
                cf.CanFollow = false;
                
                //Gameover işlemleri yapılmalı ve sesi çalınmalı
                SoundManager.instance.GameEndSound();
                GameplayController.instance.RestartGame();

            }
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            
            //Altın kazandık ses çal
            SoundManager.instance.PickedUpCoins();
            GameplayController.instance.IncrementScore();

        }

        if (other.CompareTag("Spike"))
        {
            cf.CanFollow = false;
            gameObject.SetActive(false);

            //Gameover olduk ses çal
            SoundManager.instance.GameEndSound();
            //oyunu tekrar başlat
            GameplayController.instance.RestartGame();
        }
    } //Ontriggerenter

    private void OnCollisionEnter(Collision other)
    {

        if (other.transform.CompareTag("EndPlatform"))
        {
            
            //Oyun KAZANıldı! 
            //Ses çal
            SoundManager.instance.GameStartSound();

            //Next level
            GameplayController.instance.RestartGame();
            
        }
        
    } //oncollisionenter
} // class










































