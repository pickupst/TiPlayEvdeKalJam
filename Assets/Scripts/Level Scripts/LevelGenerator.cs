using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] players;
    public AudioClip[] sounds;
    
    public GameObject DieSound;
    
    [SerializeField]
    private GameObject startPlatform;
    [SerializeField]
    private GameObject endPlatform;
    [SerializeField]
    private GameObject simplePlatform;

    private float blockWidth = 0.5f;
    private float blockHeight = 0.2f;

    [SerializeField]
    private int amountToSpawn = 100;
    private int beginAmount = 0;

    private Vector3 lastPos;

    private List<GameObject> spawnedPlatforms = new List<GameObject>();

    [SerializeField]
    private GameObject playerPrefab;

    private float timer = 0;
    private int index = 0;
    
    void Awake()
    {
        switchPlayer();
        
        InstantiateLevel();
    } // awake

    void InstantiateLevel()
    {
        for (int i = beginAmount; i < amountToSpawn; i++)
        {
            GameObject newPlatform;

            if (i == 0)
            {
                
                newPlatform = Instantiate(startPlatform);
                
            } else if (i == amountToSpawn - 1)
            {
                newPlatform = Instantiate(endPlatform);
                newPlatform.tag = "EndPlatform";
                
            } else
            {
                newPlatform = Instantiate(simplePlatform);
            }

            newPlatform.transform.parent = transform;
              
            spawnedPlatforms.Add(newPlatform);

            if (i == 0)
            {
                
                lastPos = newPlatform.transform.position;
                
                // create the player on this position
                Vector3 temp = lastPos;
                temp.y += 0.1f;
                Instantiate(playerPrefab, temp, Quaternion.identity);
                
                continue;
            }

            int left = Random.Range(0, 2);

            if (left == 0)
            {
                
                newPlatform.transform.position = new Vector3(lastPos.x - blockWidth, lastPos.y 
                                                                                     + blockHeight, lastPos.z);
                
            } else
            {
                
                newPlatform.transform.position = new Vector3(lastPos.x, lastPos.y 
                                                                                     + blockHeight, lastPos.z + blockWidth);
                
            }

            lastPos = newPlatform.transform.position;
            
            //platformlara hareket ver (tatlı bir animasyon)
            if (i < amountToSpawn)
            {
                float endPos = newPlatform.transform.position.y;
                
                newPlatform.transform.position = 
                    new Vector3(newPlatform.transform.position.x, 
                        newPlatform.transform.position.y - blockHeight * 3f,
                           newPlatform.transform.position.z);

                newPlatform.transform.DOLocalMoveY(endPos, 0.3f).SetDelay(i * 0.1f);

                
                
            }

        } // for loop
        
    } // instantiateLevel

    private void Update()
    {
        timer += Time.deltaTime;

        if ((index == 0 && timer >= 3) || (index > 0 && timer >= 0.35f))
        {
            timer = 0;
            
            if (spawnedPlatforms[index].GetComponent<Rigidbody>() == null)
            {
                spawnedPlatforms[index].gameObject.AddComponent<Rigidbody>();
            }
            
            index++;
        }
    }

    private void setPlayer(GameObject player)
    {
        playerPrefab = player;
    }
    
    void switchPlayer()
    {
        int index = Random.Range(0, players.Length);
        
        setPlayer(players[index]);
        DieSound.GetComponent<AudioSource>().clip = sounds[index];

    }
} // class


















