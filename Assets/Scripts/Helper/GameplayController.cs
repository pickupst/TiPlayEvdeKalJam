using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{

    public static GameplayController instance;

    [SerializeField]
    private Text scoreText;

    private int score;
    
    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        
    } // awake

    public void IncrementScore()
    {
        score++;
        scoreText.text = "x" + score;
    }

    public void RestartGame()
    {
        Invoke("ReloadGame", 3f);
    }
    
    void ReloadGame()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");

    }


} //class
