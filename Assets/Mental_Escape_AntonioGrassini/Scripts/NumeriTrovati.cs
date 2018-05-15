using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class NumeriTrovati : Enigma_Base
{
    public ChangeValueButton uno;
    public ChangeValueButton due;
    public ChangeValueButton tre;
    public ChangeValueButton quattro;
    public GameObject ui;
    public GameObject Ascensore;
    bool unaSolaVolta;
   
       
    
    // Use this for initialization
    void Start () {
        unaSolaVolta = true;
        //isEnabled = true;
        isResolved = false;
        isVisible = false;
    }

    public override void setVisible(bool isVisible)
    {
        this.isVisible = isVisible;
        ui.SetActive(isVisible);
        GameManager.Instance.Movement_Controller(!isVisible);
        GameManager.Instance.enigma_on = isVisible;
    }

    // Update is called once per frame
    void Update () {
	     if (uno.trovato&&due.trovato&&tre.trovato&&quattro.trovato)
        {

            if (unaSolaVolta)
            {
                Debug.Log("Apri ascensore");
                Ascensore.GetComponent<Animation>().Play("Open");
                unaSolaVolta = false;
            }
            setVisible(false);
            isResolved = true;
            isEnabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            setVisible(false);
        }
    }
}




