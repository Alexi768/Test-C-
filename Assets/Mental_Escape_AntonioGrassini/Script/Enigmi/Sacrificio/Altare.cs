using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altare : MonoBehaviour {
    public bool isPlaying;
    public AudioSource creepy_song;

    // Use this for initialization
    void Start () {
        isPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.enigmi[0].isResolved && !isPlaying)
        {
            creepy_song.Play();
            isPlaying = true;

        }
	}
}
