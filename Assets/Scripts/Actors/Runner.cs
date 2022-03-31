using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    float speed = 1.0f;
    myVector3 Fowards = new myVector3(0, 0, 0);
    myVector3 Backwards = new myVector3(0, 0, 0);
    myVector3 Right = new myVector3(0, 0, 0);
    myVector3 Left = new myVector3(0, 0, 0);
    myVector3 Up = new myVector3(0, 0, 0);
    myVector3 Down = new myVector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        myVector3 Fowards = new myVector3(speed, 0, 0);
        myVector3 Backwards = new myVector3(-speed, 0, 0);
        myVector3 Right = new myVector3(0, speed, 0);
        myVector3 Left = new myVector3(0, -speed, 0);
        myVector3 Up = new myVector3(0, 0, speed);
        myVector3 Down = new myVector3(0, 0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        myVector3 Pos = new myVector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        myVector3 EulerAngle = new myVector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        myVector3 ForwardDirection = myMaths.EulerToVector(EulerAngle);
        if (Input.GetKeyDown("w")) 
        {
            this.transform.position = myVector3.ToUnityVector3(myMaths.AddVector(Pos, ForwardDirection));
        }
        //if (Input.GetKeyDown("w")) { this.transform.position = myVector3.AddVector(Pos, Fowards).ToUnityVector3; }
        //if (Input.GetKeyDown("s")) { this.transform.position = myVector3.AddVector(Pos, Backwards).ToUnityVector3; }
        //if (Input.GetKeyDown("a")) { this.transform.position = myVector3.AddVector(Pos, Left).ToUnityVector3; }
        //if (Input.GetKeyDown("d")) { this.transform.position = myVector3.AddVector(Pos, Right).ToUnityVector3; }
        //if (Input.GetKeyDown("e")) { this.transform.position = myVector3.AddVector(Pos, Up).ToUnityVector3; }
        //if (Input.GetKeyDown("q")) { this.transform.position = myVector3.AddVector(Pos, Down).ToUnityVector3; }
    }
}