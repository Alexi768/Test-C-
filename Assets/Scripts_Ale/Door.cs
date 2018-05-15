using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Door : MonoBehaviour
{
    float distance;
    Cube_Movement character;
    Animation anm;
    public bool aperta;
    public bool chiusaAChive;
    AudioSource portaSound;
    public AudioClip locked;
    public AudioClip open;
    

    // Use this for initialization
    void Start()
    {
        portaSound = GetComponent<AudioSource>();
        aperta = false;
        anm = GetComponent<Animation>();
        character = FindObjectOfType<Cube_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, character.transform.position);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        var myColliders = GetComponentsInChildren<Collider>(); //

        if (Physics.Raycast(ray, out hit, 5) && hit.transform.tag == "Door" && myColliders.ToList().Contains(hit.collider))
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (chiusaAChive && aperta == false)
                {
                    if (!portaSound.isPlaying)
                    {
                        portaSound.clip = locked;
                        portaSound.Play();

                    }
                }
                else
                {
                    if (!aperta && !anm.IsPlaying("Close"))
                    {
                        anm.Play("Open");
                        aperta = true;
                        portaSound.clip = open;
                        portaSound.Play();

                    }

                    if (aperta && !anm.IsPlaying("Open"))
                    {
                        anm.Play("Close");
                        aperta = false;
                        portaSound.clip = open;
                        portaSound.Play();

                    }
                }
            }

        }
    }
}

