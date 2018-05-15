using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ApplicationManager : MonoBehaviour {

    public string scene = "menu";
    public string scene1 = "game";

    public void LoadGame()
    {
        SceneManager.LoadScene(scene1);
       
    }
    public void Quit()
    {
        Application.Quit();
        //if (Application.isEditor)
        //{
        //    EditorApplication.isPlaying = false;
        //}
    }
}
