using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampadarioScript : MonoBehaviour {
    float tempo;
    Animation anm;
	// Use this for initialization
	void Start () {
        anm = GetComponent<Animation>();
        tempo = Random.Range(0, 2);
	}

    // Update is called once per frame
    void Update()
    {

        if (Time.time > tempo)
        {
            if(!anm.isPlaying)
            {
                anm.Play("CINEMA_4D_Principale");
            }
        }

    }
}
