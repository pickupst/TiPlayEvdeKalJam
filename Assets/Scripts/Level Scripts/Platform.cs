using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  DG.Tweening;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour
{

    [SerializeField] 
    private Transform[] spikes;

    [SerializeField]
    private GameObject coin;
    
    private bool fallDown;

    [SerializeField]
    private float sprikeMinPos = 0.75f;
    
    [SerializeField]
    private Vector3 coinOffSet = new Vector3(0, 5, 0);
    
    // Start is called before the first frame update
    void Start()
    {

        ActivitePlatform();

    }

    private void ActivitePlatform()
    {

        int chance = Random.Range(0, 100);

        if (chance > 70)
        {
            int type = Random.Range(0, 8);

            if (type == 0)
            {
                ActiviteSpike();
            } else if (type == 1)
            {
                AddCoin();
            }else if (type == 2)
            {
                fallDown = true;
            }else if (type == 3)
            {
                fallDown = true;
            }else if (type == 4)
            {
                AddCoin();
            }else if (type == 5)
            {
                fallDown = true;
            }else if (type == 6)
            {
                fallDown = true;
            }else if (type == 7)
            {
                AddCoin();
            }
            
        }

    } // activite platforms

    private void ActiviteSpike()
    {
        int index = Random.Range(0, spikes.Length);
        
        spikes[index].gameObject.SetActive(true);

        spikes[index].transform.position = new Vector3(spikes[index].transform.position.x, spikes[index].transform.position.y - sprikeMinPos, spikes[index].transform.position.z);
        spikes[index].DOLocalMoveY(7f, 1.3f).SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(1f, 3f));

    } // ActiviteSpike

    void AddCoin()
    {

        GameObject c = Instantiate(coin);
        c.transform.position = transform.position;
        c.transform.SetParent(transform);
        c.transform.DOLocalMoveY(5f, 0f);

    } // Add caoin

    public void InvokeFalling()
    {
        gameObject.AddComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        
        if (other.transform.CompareTag("Player"))
        {

            if (fallDown)
            {
                fallDown = false;
                Invoke("InvokeFalling", 0.5f);
            }
            
        }
        
    }
} // class




































