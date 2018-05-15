using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CONTROLS_SCRIPT : MonoBehaviour
{
    public GameObject CanvasMenu;
    public GameObject ControlsMenu;

    // Use this for initialization
    void Start()
    {
        CanvasMenu.SetActive(true);
        ControlsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ControlsImm()
    {
        ControlsMenu.SetActive(true);
        CanvasMenu.SetActive(false);
    }
    public void ExitFromControls()
    {
        CanvasMenu.SetActive(true);
        ControlsMenu.SetActive(false);
    }
}
