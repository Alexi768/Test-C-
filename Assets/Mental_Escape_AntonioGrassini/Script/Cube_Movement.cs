using UnityEngine;
using System.Collections;

public class Cube_Movement : MonoBehaviour
{
    // Use this for initialization
    [Header("Movimento")]
    public float cspeed;
    public float speed;
    private float rotation_speed;
    public float jump;
    public bool a_terra;
    //public string terreno_tag = "terreno";
    [Header("Stamina")]
    //public float stamina;
    //public float max_stamina = 100;
    //public float notmoving;
    //public float stamina_delay = 1;
    private float time;
    public bool can_move;
    private Rigidbody rb;
    public Transform piedi;
    public float distGround;
    void Start()
    {
       // distGround = GetComponent<Collider>().bounds.extents.y;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(piedi.transform.position,Vector3.down);
        Debug.DrawRay(piedi.transform.position,Vector3.down, Color.yellow);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 0.3f))
        {
            //Debug.DrawRay(piedi.transform.position, transform.TransformDirection(Vector3.down) * distGround);
           // Debug.Log("Did Hit:" +hit.collider.name);
            a_terra = true;
        }

        cspeed = speed;
        //if (stamina == 0)
        //{
        //    cspeed = speed * 0.5f;
        //}
        time = Time.deltaTime;
        //notmoving += +time;
        //if (notmoving > stamina_delay && stamina < 100)
        //{
        //    stamina += 0.1f;
        //}
        if (can_move)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    cspeed = speed * 1.5f;
                    //stamina -= 0.1f;
                }
                transform.Translate(Vector3.forward * cspeed * time);
                //stamina -= 0.1f;
                //notmoving = 0;

            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * cspeed * time);
                //stamina -= 0.1f;
                //notmoving = 0;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * cspeed * time);
                //stamina -= 0.1f;
                //notmoving = 0;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * cspeed * time);
                //stamina -= 0.1f;
                //notmoving = 0;
            }
            if ((Input.GetKeyDown(KeyCode.Space)) && (a_terra))
            {
                a_terra = false;
                rb.velocity = new Vector3(rb.velocity.x, jump*Time.deltaTime, rb.velocity.z);
                //rb.AddForce(transform.up * jump);
                //stamina -= 0.5f;
                //notmoving = 0;
            }
        }
        //stamina = Mathf.Clamp(stamina, 0, max_stamina);




    }
//    void OnCollisionEnter(Collision collision)
//    {
//        if (collision.collider.tag == terreno_tag)
//        {
//            a_terra = true;
//        }
//    }
//    void OnCollisionExit(Collision collision)
//    {
//        if (collision.collider.tag == terreno_tag)
//        {
//            a_terra = false;
//        }
//    }
}