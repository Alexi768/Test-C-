using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class ChangeColor : MonoBehaviour
{
    public int solution;
    public bool trovato = false;
    public int Color_ID;
    public List<Color> listColor;
    public int cid;

    Button bottone;
    // Use this for initialization
    void Start()
    {
        bottone = GetComponent<Button>();
        ColorBlock cb = bottone.colors;
        cb.normalColor = listColor[0];
        cb.highlightedColor = listColor[0];
        bottone.colors = cb;

    }

    // Update is called once per frame
    public void Change()
    {

        cid++;
        if (cid>7)
        {
            cid = 0;
        }
        ColorBlock cb = bottone.colors;
        cb.normalColor = listColor[cid];
        cb.highlightedColor = listColor[cid];


        bottone.colors = cb;

       
        if (cid == solution)
        {
            trovato = true;
        }
        else
        {
            trovato = false;
        }
    }
}