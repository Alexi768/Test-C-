using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Sequence : MonoBehaviour
{
    public Enigma_Sequenza padreContatore;
    public int ID;
    public Color newCol = Color.green;
    public GameObject enigma1;
    public Cube_Movement player;

    Button bottone;
    // Use this for initialization
    void Start()
    {
        bottone = GetComponent<Button>();
        padreContatore = GetComponentInParent<Enigma_Sequenza>();
        ColorBlock cb = bottone.colors;
        cb.normalColor = Color.red;
        cb.highlightedColor = Color.red;
        bottone.colors = cb;
    }

    // Update is called once per frame
    public void Change()
    {
        if (padreContatore.cont == ID)
        {
            padreContatore.cont += 1;
            if (padreContatore.cont == 6)
            {
                enigma1.SetActive(false);
                GameManager.Instance.Movement_Controller(true);
                GameManager.Instance.sequenza = true;

            }
            else
            {
                padreContatore.cont = 0;
            }
        }
    }


}
