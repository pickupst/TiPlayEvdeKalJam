using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    [SerializeField] 
    private AudioSource gameStart, gameEnd, coinSound, jumpSound;
    
    
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        
    } // awake

    public void GameStartSound()
    {
        gameStart.Play();
    }
    
    public void GameEndSound()
    {
        gameStart.Play();
    }
    
    public void PickedUpCoins()
    {
        coinSound.Play();
    }
    
    public void JumpSound()
    {
        jumpSound.Play();
    }
    
} // class










































































