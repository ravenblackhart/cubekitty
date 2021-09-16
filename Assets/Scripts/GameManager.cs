using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]


    [SerializeField] private GameObject uiManager;
    [SerializeField] private GameObject player;

    [SerializeField] public Material[] Skybox;
    
    
    
    void Awake()
    {
        GameObject[] mgm = GameObject.FindGameObjectsWithTag("GameController");
        if (mgm.Length > 1) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        
        #region UIManager

        if (FindObjectOfType<EventSystem>() == null)
        {
            var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            GameObject[] mui = GameObject.FindGameObjectsWithTag("UIController");
            if (mui.Length > 1)
            {
                for (int i = 1; i < mui.Length; i++)
                {
                    Destroy(mui[i]);
                }
            }
        
            else if (mui.Length < 1)
            {
                Instantiate(uiManager);
            }
        }
       
        #endregion

        #region PlayerController

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            GameObject[] mpc = GameObject.FindGameObjectsWithTag("Player");
            if (mpc.Length > 1)
            {
                for (int i = 1; i < mpc.Length; i++)
                {
                    Destroy(mpc[i]);
                }
            }
            else if (mpc.Length < 1)
            {
                Instantiate(player);
            }
        }
        #endregion

        #region LevelManager

        GameObject[] lm = GameObject.FindGameObjectsWithTag("LevelManager");
        if (lm.Length > 1)
        {
            for (int i = 1; i < lm.Length; i++)
            {
                Destroy(lm[i]);
            }
        }

        #endregion

    }

}
