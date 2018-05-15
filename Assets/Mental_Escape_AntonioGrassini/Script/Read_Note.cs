using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Read_Note : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "note_trigger" && GameManager.Instance.enigmi[3].isEnabled)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameManager.Instance.noteisOn = true;
                GameManager.Instance.note5.SetActive(true);
                GameManager.Instance.Movement_Controller(false);
                GameManager.Instance.paper_sound.Play();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
