using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity;
    public Transform positionGrab;
    float xAxisClamp = 0.0f;
    public bool oggettoPreso;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 2)&& Input.GetKeyDown(KeyCode.F) && oggettoPreso==false && hit.transform.tag =="Obj")
        {
            Debug.DrawLine(ray.origin, hit.point);
            Debug.Log("ho colpito: " + hit.transform.gameObject.name);
            hit.transform.parent = positionGrab.transform.parent;
            hit.transform.GetComponent<Rigidbody>().useGravity = false;
            hit.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            oggettoPreso = true;
        }else if (Physics.Raycast(ray, out hit, 2) && Input.GetKeyDown(KeyCode.F) && oggettoPreso == true&& hit.transform.tag == "Obj")
        {
            Debug.DrawLine(ray.origin, hit.point);
            Debug.Log("ho colpito: " + hit.transform.gameObject.name);
            hit.transform.parent = null;
            hit.transform.GetComponent<Rigidbody>().useGravity = true;
            hit.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            oggettoPreso = false;
        }

        RotateCamera();
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        xAxisClamp -= rotAmountY;

        Vector3 targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;
        targetRotCam.z = 0;
        targetRotBody.y += rotAmountX;

        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }

        //  print(mouseY);



        transform.rotation = Quaternion.Euler(targetRotCam);
        playerBody.rotation = Quaternion.Euler(targetRotBody);


    }



}
