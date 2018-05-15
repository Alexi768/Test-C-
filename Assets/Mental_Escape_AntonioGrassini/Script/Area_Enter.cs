using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_Enter : MonoBehaviour
{
    public Camera_Tremor TremorePazzesco;

    void Awake()
    {
        TremorePazzesco.enabled = false;
    }
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "area_trigger" && !GameManager.Instance.noteHasBeenShown2 && GameManager.Instance.enigmi[0].isResolved)
        {
            GameManager.Instance.church_note = true;
            GameManager.Instance.Movement_Controller(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (other.tag == "trigger_ascensore" && GameManager.Instance.enigmi[3].isResolved)
        {
            TremorePazzesco.enabled = true;
            GameManager.Instance.Movement_Controller(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false; 
            GameManager.Instance.elevator_area = true;
            GameManager.Instance.lights.SetActive(false);
            GameManager.Instance.gameover.Play();

        }

    }
}
