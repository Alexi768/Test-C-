using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Enigma_Sequenza : Enigma_Base
{

    public int cont;
    public int max;
    public GameObject ui;
    public AudioSource button_sound;
    public List<Button> bottoni;
    public float timer;
    public GameObject Luci;


    // Use this for initialization
    void Start()
    {
        Luci.SetActive(false);
        isEnabled = true;
        isResolved = false;
        isVisible = false;
        cont = 0;
        max = bottoni.Count;
        for (int i = 0; i < bottoni.Count; i++)
        {

            ColorBlock cb = bottoni[i].colors;
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.white;
            bottoni[i].colors = cb;
        }
    }

    public override void setVisible(bool isVisible)
    {
        if (isVisible == false)
        {
            cont = 0;
        }
        this.isVisible = isVisible;
        ui.SetActive(isVisible);
        GameManager.Instance.enigma_on = isVisible;
    }

    //public void SetNotVisible()
    //{
    //    setVisible(false);
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            setVisible(false);
            GameManager.Instance.enigma_on = false;
        }
    }

    public void AddChar(int id)
    {
        button_sound.Play();
        if (id == cont)
        {
            cont++;
            if (cont == max)
            {
                Luci.SetActive(true);
                setVisible(false);
                GameManager.Instance.EnigmaSolved();
                GameManager.Instance.enigmi[1].isEnabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }
        }
        else
        {
            cont = 0;
        }

    }
}
