using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myRigidBody : MonoBehaviour
{
    public float Mass = 1f;
    public myVector3 Force = myVector3.Zero;
    myVector3 Acceleration = myVector3.Zero;
    myVector3 Velocity = myVector3.Zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetKeyDown("a"))
        //{
        //   Force += new myVector3(0, 1, 0);
        //}

        //Calculate acceleration
        Acceleration = Force / Mass;
        Debug.Log(Time.deltaTime);

        //Apply acceleration to the velocity over time
        Velocity += Acceleration * Time.deltaTime;

        GetComponent<myTransform>().Position += new myVector3(0, 0.1f, 0);//Velocity * Time.deltaTime;
        //transform.position += new Vector3(0, 0.1f, 0);
        //GetComponentInChildren<myTransform>().Position += new myVector3(0, 1, 0);
    }
}
