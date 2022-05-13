using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myRigidBody : MonoBehaviour
{
    public float Mass = 1f; //The mass of the object
    public bool enableGravity = true;
    public float Gravity = -9.8f; //Will move to a physics class later that dictates either the scene or an area, but keeping it on rigidBody for testing
    public myVector3 Force = myVector3.Zero;
    public myVector3 Velocity = myVector3.Zero;
    myVector3 Acceleration = myVector3.Zero;
    //private myVector3 minVelocity = new myVector3(0.005f, 0.0001f, 0.005f);

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (minVelocity.x >= Velocity.x && -minVelocity.x <= Velocity.x) { Velocity.x = 0; }
        //if (minVelocity.y >= Velocity.y && -minVelocity.y <= Velocity.y) { Velocity.y = 0; }
        //if (minVelocity.z >= Velocity.z && -minVelocity.z <= Velocity.z) { Velocity.y = 0; }

        //if (enableGravity)
        //{ Force += new myVector3(0, Gravity, 0); }

        //Calculate acceleration
        Acceleration = Force / Mass;

        if (enableGravity)
        { Acceleration += new myVector3(0, Gravity * Mass, 0); }

        //Apply acceleration to the velocity over time
        Velocity += Acceleration * Time.deltaTime;

        //Debug.Log("Velocity: " + Velocity.x + ", " + Velocity.y + ", " + Velocity.z);

        //Updates position
        GetComponent<myTransform>().Position += Velocity * Time.deltaTime; //Updates mesh position
        GetComponent<AABB>().Position(Velocity * Time.deltaTime); //Updates collider position
    }
}
