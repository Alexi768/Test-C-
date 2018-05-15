using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Trigger : MonoBehaviour
{
    //public GameObject interact;
    public Enigma_Base enigma;
    public Cube_Movement player;

    // Use this for initialization
    void Start()
    {
        //interact.SetActive(false);
        enigma.setVisible(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && player.can_move && enigma.isEnabled)
        {
            //interact.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                //interact.SetActive(false);
                enigma.setVisible(true);
                GameManager.Instance.Movement_Controller(false);
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        //interact.SetActive(false);


    }
}
