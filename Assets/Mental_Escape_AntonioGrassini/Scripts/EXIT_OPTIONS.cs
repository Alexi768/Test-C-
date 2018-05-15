using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EXIT_OPTIONS : MonoBehaviour
{
    public GameObject story;
    public AudioSource paper_sound;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void quitGame()
    {
        SceneManager.LoadScene("menu_principale");
    }

    public void quitMenu()
    {
        Application.Quit();
        //if (Application.isEditor)
        //{
        //    EditorApplication.isPlaying = false;
        //}
    }

    public void quitNote()
    {
        story.SetActive(false);
        paper_sound.Play();
        GameManager.Instance.Movement_Controller(true);
        GameManager.Instance.noteisOn = false;
    }
}
