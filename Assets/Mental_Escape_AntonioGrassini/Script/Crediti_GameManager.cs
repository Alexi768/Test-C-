using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Crediti_GameManager : MonoBehaviour
{
    public GameObject pause;

    public static GameManager Instance
    {
        get
        {
            return FindObjectOfType<GameManager>();
        }
    }
    // Use this for initialization
    void Start()
    {
        pause.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause.activeInHierarchy == false)
            {
                pause.SetActive(true);
            }
            else if (pause.activeInHierarchy == true)
            {
                pause.SetActive(false);
            }
        }
    }
}
