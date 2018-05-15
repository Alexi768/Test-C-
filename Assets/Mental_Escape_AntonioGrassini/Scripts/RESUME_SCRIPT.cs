using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RESUME_SCRIPT : MonoBehaviour
{
    public GameObject PauseCanvas;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Resume()
    {
        GameManager.Instance.Movement_Controller(true);
        PauseCanvas.SetActive(false);
    }
}
