using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController controller;
    public float walkSpeed;


    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    bool canMove;
    float timer;
    public GameObject CanvasFinale;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        CanvasFinale.SetActive(false);
        canMove = true;
    }
    void Update()
    {
        // MovePlayer();
        if (canMove)
        {

            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;

            }

            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            timer += Time.deltaTime;
            if(timer>7)
            {
                Application.Quit();
                Debug.Log("STACCA STACCAAA");
            }

        }
    }

    void MovePlayer()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 moveDirSide = transform.right * horiz * walkSpeed;
        Vector3 moveDirForward = transform.forward * vert * walkSpeed;

        controller.SimpleMove(moveDirSide);
        controller.SimpleMove(moveDirForward);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            canMove = false;
            CanvasFinale.SetActive(true);
        }
    }
}
