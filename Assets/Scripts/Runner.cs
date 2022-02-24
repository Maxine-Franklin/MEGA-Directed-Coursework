using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    float speed = 1.0f;
    MyVector3 Fowards = new MyVector3(0, 0, 0);
    MyVector3 Backwards = new MyVector3(0, 0, 0);
    MyVector3 Right = new MyVector3(0, 0, 0);
    MyVector3 Left = new MyVector3(0, 0, 0);
    MyVector3 Up = new MyVector3(0, 0, 0);
    MyVector3 Down = new MyVector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        MyVector3 Fowards = new MyVector3(speed, 0, 0);
        MyVector3 Backwards = new MyVector3(-speed, 0, 0);
        MyVector3 Right = new MyVector3(0, speed, 0);
        MyVector3 Left = new MyVector3(0, -speed, 0);
        MyVector3 Up = new MyVector3(0, 0, speed);
        MyVector3 Down = new MyVector3(0, 0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        MyVector3 Pos = new MyVector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        //if (Input.GetKeyDown("w")) { this.transform.position = MyVector3.AddVector(Pos, Fowards).ToUnityVector3; }
        //if (Input.GetKeyDown("s")) { this.transform.position = MyVector3.AddVector(Pos, Backwards).ToUnityVector3; }
        //if (Input.GetKeyDown("a")) { this.transform.position = MyVector3.AddVector(Pos, Left).ToUnityVector3; }
        //if (Input.GetKeyDown("d")) { this.transform.position = MyVector3.AddVector(Pos, Right).ToUnityVector3; }
        //if (Input.GetKeyDown("e")) { this.transform.position = MyVector3.AddVector(Pos, Up).ToUnityVector3; }
        //if (Input.GetKeyDown("q")) { this.transform.position = MyVector3.AddVector(Pos, Down).ToUnityVector3; }
    }
}
