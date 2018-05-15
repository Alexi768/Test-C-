using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ChangeValueButton : MonoBehaviour
{
    public int count;
    Text valore;
    public string value;
    public bool trovato = false;
    public AudioSource button_sound;
    // Use this for initialization
    void Start()
    {
        valore = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        valore.text = count.ToString();
        if (valore.text == value)
        {
            trovato = true;
        }
        else
        {
            trovato = false;
        }
    }

    public void ChangeDown()
    {
        button_sound.Play();
        if (count > 0)
            count--;

    }
    public void ChangeUp()
    {
        button_sound.Play();
        if (count < 9)
            count++;
    }
//    public void Reset()
//    {
//        count = 0;
//    }
}
