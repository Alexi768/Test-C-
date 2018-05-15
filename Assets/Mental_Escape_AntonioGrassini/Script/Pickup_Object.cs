using UnityEngine;
using System.Collections;

public class Pickup_Object : MonoBehaviour
{
    public Transform grabPosition;
    public GameObject current_pickup;
    //public GameObject interact;
    public Collectable_Trigger collectableTrigger;
    public bool possoPrendere;
    public bool canCarry;
    // Use this for initialization
    void Start()
    {
        canCarry = true;
        // interact.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && possoPrendere && canCarry && collectableTrigger.isActive && GameManager.Instance.enigmi[2].isEnabled)
        {
            collectableTrigger.isActive = false;
            current_pickup.transform.position = grabPosition.transform.position;
            current_pickup.transform.parent = grabPosition.transform;
            current_pickup.transform.rotation = grabPosition.transform.rotation;
            current_pickup.GetComponent<Rigidbody>().useGravity = false;
            canCarry = false;


        }
        else if (Input.GetKeyDown(KeyCode.F) && !canCarry)
        {
            if (current_pickup != null)
            {
                collectableTrigger.isActive = true;
                current_pickup.transform.parent = null;
                current_pickup.GetComponent<Rigidbody>().useGravity = true;
                collectableTrigger = null;
                current_pickup = null;
                canCarry = true;
                possoPrendere = false;
            }
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "pickup" &&possoPrendere==false && canCarry==true && GameManager.Instance.enigmi[2].isEnabled)
        {
            //interact.SetActive(true);
            collectableTrigger = other.GetComponent<Collectable_Trigger>();
            current_pickup = collectableTrigger.item.gameObject;
            
            possoPrendere = true;
        }
        //if (other.tag == "pickup")
        //{
        //    Debug.Log("Sono nel trigger");
        //    collectableTrigger = other.GetComponent<Collectable_Trigger>();
        //    if (current_pickup == null)
        //    {
        //        
        //        if (Input.GetKeyDown(KeyCode.F) && collectableTrigger.isActive)
        //        {
        //            interact.SetActive(false);
        //            current_pickup = collectableTrigger.item.gameObject;
        //            collectableTrigger.item.transform.position = pos.position;
        //            collectableTrigger.isActive = false;

        //            collectableTrigger.item.transform.parent = pos;

        //        }
        //    }
        //    if (Input.GetKeyDown(KeyCode.G))
        //    {
        //        Debug.Log("sss");
        //        collectableTrigger.isActive = true;
        //        collectableTrigger.item.transform.parent = null;
        //    }
        //}

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "pickup" &&possoPrendere)
        {
            possoPrendere = false;
            //interact.SetActive(false);
        }
    }
}