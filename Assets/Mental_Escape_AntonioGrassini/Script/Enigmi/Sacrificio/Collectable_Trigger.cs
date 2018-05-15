using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Collectable_Trigger : MonoBehaviour
{
    public GameObject interact;
    public bool isActive;
    public GameObject item;
    // Use this for initialization
    void Start()
    {
        interact.SetActive(false);
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Player" && isActive)
    //    {
    //        Pickup_Object pickup = other.GetComponent<Pickup_Object>();
    //        if (pickup.current_pickup == null)
    //        {
    //        interact.SetActive(true);
    //            if (Input.GetKey(KeyCode.F))
    //            {
    //                interact.SetActive(false);
    //                pickup.current_pickup = item.gameObject;
    //                item.transform.position = pickup.pos.position;
    //                item.transform.parent = pickup.pos;

    //            }
    //            if(Input.GetKeyUp(KeyCode.F))
    //            {
    //                item.transform.parent = null;       
    //            }

    //        }
    //    }

    //}

    //void OnTriggerExit(Collider other)
    //{
    //    interact.SetActive(false);


    //}
}