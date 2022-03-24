using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpolator : MonoBehaviour
{
    myVector3 serverVector = myVector3.Zero;
    myVector3 myVector = myVector3.Zero;
    bool interpolate = false;
    float myTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        serverVector = new myVector3(this.transform.position.x, this.transform.position.y, this.transform.position.z); //Stores the object's starting position
    }

    // Update is called once per tick
    void FixedUpdate()
    {
        myVector = new myVector3(this.transform.position.x, this.transform.position.y, this.transform.position.z); //Stores the object's current position
        myVector.x -= 0.1f; //Moves the object on the x axis
        if (interpolate == false) { myVector.y += 0.025f; } //If not correcting object position, adjust objects y position to emulate client side data v server side data
        serverVector.x -= 0.1f; //Emulates what the server is tracking to be the objects real position
        this.transform.position = myVector.ToUnityVector3(); //Adjusts objects position according to its current myVector3 coordinates
        myTimer += Time.fixedDeltaTime; //Logs time per tick
        if (myTimer > 1.0f) { interpolate = true; } //If more than 1 second of ticks occur then, interpolate the objects position to make client side data match the server side's real data
        if (interpolate) //If object position need interpolating to server position then...
        {
            myVector3 positionUpdate = myMaths.VectorLerp(myVector, serverVector, Time.deltaTime); //Updates object's position towards the server position using deltaTime to ensure the transition is smooth
            this.transform.position = positionUpdate.ToUnityVector3(); //Adjusts object position according to its current myVector3 coordinates
            if (myVector <= myMaths.ScaleVector(serverVector, 1.1f) && myVector >= myMaths.ScaleVector(serverVector, 0.9f)) { interpolate = false; myTimer = 0.0f; myVector = serverVector; } //Once object position is relatively equal to the server side real position, stops interpolating the ojects position
        }
        if (myTimer > 3.0f) { interpolate = false; myTimer = 0.0f; myVector = serverVector; } //Failsafe to account for some issues in interpolation detection
    }
}