using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myRigidBody : MonoBehaviour
{
    public myVector3 Force;
    myVector3 Acceleration;
    myVector3 Velocity;
    public float Mass = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate acceleration
        //Acceleration = Force / Mass;

        //Apply acceleration to velocity over time
        Velocity += Acceleration * Time.deltaTime;

        //Update position
        transform.position += myVector3.ToUnityVector3(Velocity * Time.deltaTime);

    }
}
