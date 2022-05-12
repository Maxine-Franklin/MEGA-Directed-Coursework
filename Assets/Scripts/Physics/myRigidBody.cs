using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myRigidBody : MonoBehaviour
{
    public float Mass = 1f;
    public float force_x;
    public bool enableGravity = true;
    public float Gravity = -9.8f;
    public myVector3 Force = myVector3.Zero;
    myVector3 Acceleration = myVector3.Zero;
    public myVector3 Velocity = myVector3.Zero;

    //public myVector3 getVelocity { get { return Velocity; } }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { Force += new myVector3(0, 1, 0); }

        if (enableGravity)
        { Force += new myVector3(0, Gravity, 0); }

        //Calculate acceleration
        Acceleration = Force / Mass;

        //Apply acceleration to the velocity over time
        Velocity += Acceleration * Time.deltaTime;

        //Debug.Log("Velocity: " + Velocity.x + ", " + Velocity.y + ", " + Velocity.z);

        GetComponent<myTransform>().Position += Velocity * Time.deltaTime;
        GetComponent<AABB>().Position(Velocity * Time.deltaTime);
        //transform.position += new Vector3(0, 0.1f, 0);
        //GetComponentInChildren<myTransform>().Position += new myVector3(0, 1, 0);
    }
}
