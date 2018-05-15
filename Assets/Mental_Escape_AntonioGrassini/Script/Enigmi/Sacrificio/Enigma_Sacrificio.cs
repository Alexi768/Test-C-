using UnityEngine;
using System.Collections;

public class Enigma_Sacrificio : Enigma_Base {

    // Use this for initialization
    public Trigger_Piedistallo uno;
    public Trigger_Piedistallo due;
    public Trigger_Piedistallo tre;
    public GameObject Tomba;
    bool unaSolaVolta;
	void Start () {
        unaSolaVolta = true;

    }
	
	// Update is called once per frame
	void Update () {
        if (uno.oggettoPosizionato && due.oggettoPosizionato && tre.oggettoPosizionato)
        {
            if(unaSolaVolta)
            {
                Debug.Log("Apri tomba");
                Tomba.GetComponent<Animation>().Play("Open");
                unaSolaVolta = false;
            }
            //GameManager.Instance.EnigmaSolved();
            setVisible(false);
            isResolved = true;
            GameManager.Instance.enigmi[2].isResolved = true;
            GameManager.Instance.enigmi[2].isEnabled = false;
            //GameManager.Instance.enigmi[3].isEnabled = true;
            GameManager.Instance.eid = 3;
        }
    }
}
