
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardforce = 2000f;
    public float sidewaysforce = 500f;
   
   
    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysforce*Time.deltaTime,0,0);
        }
         if(Input.GetKey("d"))
        {
            rb.AddForce(sidewaysforce*Time.deltaTime,0,0);
        }


         if(Input.GetKey("w"))
        {
            rb.AddForce(0,0,forwardforce * Time.deltaTime);
        }

         if(Input.GetKey("s"))
        {
            rb.AddForce(0,0,-forwardforce * Time.deltaTime);
        }




    }
}
