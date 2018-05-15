using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Trigger_Piedistallo : MonoBehaviour
{
    public GameObject interact;
    public Transform positionObject;
    public GameObject obj;
    public bool oggettoPosizionato;
    public Pickup_Object player;
    // Use this for initialization
    void Start()
    {
        oggettoPosizionato = false;
        interact.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //    if (obj != null)
        //    {
        //        obj.transform.position = positionObject.transform.position;
        //        obj = null;
        //        // blocca movimento
        //    }
    }

    void OnTriggerStay(Collider other)
    {
        if (oggettoPosizionato == false)
        {
            if (other.tag == "sacrificio")
            {
                if (player.canCarry == true)
                {
                    if (Input.GetKey(KeyCode.F))
                    {
                        obj = other.gameObject;
                        obj.transform.position = positionObject.transform.position;
                        obj.transform.rotation = positionObject.transform.rotation;
                        //Destroy(obj.GetComponent<Rigidbody>());
                        //obj.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
                        oggettoPosizionato = true;
                    }
                }
            }
        }


    }
}