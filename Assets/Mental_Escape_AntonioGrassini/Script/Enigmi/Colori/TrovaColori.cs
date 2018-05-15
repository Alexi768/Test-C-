using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using System.Collections.Generic;

public class TrovaColori : Enigma_Base
{
    public GameObject portone;
    public AudioSource sacrifice;
    public ChangeColor uno;
    public ChangeColor due;
    public ChangeColor tre;
    public ChangeColor quattro;
    public GameObject ui;
    // Use this for initialization
    void Start()
    {
        isEnabled = true;
        isResolved = false;
        isVisible = false;
    }

    public override void setVisible(bool isVisible)
    {
        this.isVisible = isVisible;
        ui.SetActive(isVisible);
        //GameManager.Instance.Movement_Controller(!isVisible);
        GameManager.Instance.enigma_on = isVisible;
    }

    // Update is called once per frame
    void Update()
    {
        if (uno.trovato && due.trovato && tre.trovato && quattro.trovato)
        {
            setVisible(false);
            isResolved = true;
            GameManager.Instance.EnigmaSolved();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            sacrifice.Play();
            portone.GetComponent<Animation>().Play("Open");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            setVisible(false);
        }
    }
}




