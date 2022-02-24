using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    bool Safe = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && Safe)
        {
            Safe = false;
            Move();
        }
        if (Input.GetKeyUp("space"))
        {
            Safe = true;
        }
    }

    void Move()
    {
        Vector3 Obj2 = GameObject.Find("Obj2").transform.position;
        MyVector3 Obj2Vector = new MyVector3(Obj2.x, Obj2.y, Obj2.z);
        MyVector3 Obj1Vector = new MyVector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        MyVector3 Movement = MyVector3.SubVector(Obj2Vector, Obj1Vector);
        Obj1Vector = MyVector3.AddVector(Obj1Vector, Movement);
        this.transform.position = Obj1Vector.ToUnityVector3();
        return;
    }
}