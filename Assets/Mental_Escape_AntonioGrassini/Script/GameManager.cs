using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource paper_sound;
    public bool combinazione_colori;
    public bool sequenza;
    public GameObject player;
    public GameObject story;
    public GameObject note1;
    public GameObject note2;
    public GameObject note3;
    public GameObject note4;
    public GameObject note5;
    public GameObject lights;
    private Cube_Movement movement;
    private MouseLook mouse;
    public List<Enigma_Base> enigmi;
    public int eid;
    public GameObject pause;
    public bool enigma_on;
    public bool intro;
    public bool noteisOn;
    public float timer_intro;
    public float timer1;
    public bool noteHasBeenShown;
    public bool noteHasBeenShown2;
    public bool noteHasBeenShown3;
    public bool noteHasBeenShown4;
    public bool church_note;
    public bool elevator_area;
    public float endGameDelay;
    public AudioSource gameover;


    public static GameManager Instance
    {
        get
        {
            return FindObjectOfType<GameManager>();
        }
    }
    // Use this for initialization
    void Start()
    {
        pause.SetActive(false);
        movement = player.GetComponent<Cube_Movement>();
        mouse = player.GetComponent<MouseLook>();

        note1.SetActive(false);
        note2.SetActive(false);
        note3.SetActive(false);
        note4.SetActive(false);
        note5.SetActive(false);
        story.SetActive(false);
        noteHasBeenShown = false;
        noteHasBeenShown2 = false;
        noteHasBeenShown3 = false;
        church_note = false;
        elevator_area = false;
        enigmi[0].isEnabled = true;
        enigmi[0].isResolved = false;
        enigmi[0].setVisible(false);
        intro = true;
        for (int i = 1; i < enigmi.Count; i++)
        {
            enigmi[i].isEnabled = false;
            enigmi[i].isResolved = false;
            enigmi[i].setVisible(false);
        }

    }
    public void Movement_Controller(bool canmove)
    {
        if (canmove)
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        movement.can_move = canmove;
        mouse.can_look = canmove;

    }
    public void EnigmaSolved()
    {

        enigmi[eid].isEnabled = false;
        enigmi[eid].isResolved = true;
        if (eid < enigmi.Count - 1)
        {
            eid++;
            enigmi[eid].isEnabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (timer_intro == 0)
        {
            Movement_Controller(false);
            noteisOn = true;
        }
        if (timer_intro > 1.5f && intro)
        {
            Movement_Controller(false);
            intro = false;
            story.SetActive(true);
            paper_sound.Play();

        }
        if (intro)
        {
            timer_intro += Time.deltaTime;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !enigma_on && !noteisOn)
        {
            if (pause.activeInHierarchy == false)
            {
                pause.SetActive(true);
                Movement_Controller(false);
            }
            else if (pause.activeInHierarchy == true)
            {
                pause.SetActive(false);
                Movement_Controller(true);
            }
        }
        if (enigmi[0].isResolved && timer1 < 1.5f && !noteHasBeenShown)
        {
            noteisOn = true;
            timer1 += Time.deltaTime;
        }
        if (enigmi[0].isResolved && timer1 >= 1.5f && !noteHasBeenShown)
        {
            paper_sound.Play();
            note1.SetActive(true);
            noteHasBeenShown = true;
            timer1 = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (church_note && timer1 < 1.5f && !noteHasBeenShown2)
        {
            timer1 += Time.deltaTime;
            noteisOn = true;
        }
        if (church_note && timer1 >= 1.5f && !noteHasBeenShown2)
        {
            paper_sound.Play();
            note2.SetActive(true);
            timer1 = 0;
            Movement_Controller(false);
            noteHasBeenShown2 = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            enigmi[1].isEnabled = true;
        }

        if (enigmi[1].isResolved && timer1 < 1.5f && !noteHasBeenShown3)
        {
            timer1 += Time.deltaTime;
            noteisOn = true;
        }
        if (enigmi[1].isResolved && timer1 >= 1.5f && !noteHasBeenShown3)
        {
            paper_sound.Play();
            note3.SetActive(true);
            timer1 = 0;
            noteisOn = true;
            //Movement_Controller(false);
            noteHasBeenShown3 = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (enigmi[2].isResolved && timer1 < 2.5f && !noteHasBeenShown4)
        {
            timer1 += Time.deltaTime;
            noteisOn = true;
        }
        if (enigmi[2].isResolved && timer1 >= 2.5f && !noteHasBeenShown4)
        {
            Movement_Controller(false);
            paper_sound.Play();
            note4.SetActive(true);
            note4.SetActive(true);
            timer1 = 0;
            noteHasBeenShown4 = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            enigmi[3].isEnabled = true;
        }
        if (elevator_area && timer1 < endGameDelay)
        {
            timer1 += Time.deltaTime;
        }

        if(elevator_area && timer1 >= endGameDelay)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("Crediti");
        }
    }
}
