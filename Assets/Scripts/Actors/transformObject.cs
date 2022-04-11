using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformObject : MonoBehaviour
{
    myVector3[] ModelSpaceVertices;
    myVector3 Position = new myVector3(0.0f, 7.0f, 3.0f);
    //float Timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //We get a copy of all the vertices (this is NOT efficient, but for the sake of understanding we're doing it like this)
        ModelSpaceVertices = myVector3.ToMyVector3(MF.mesh.vertices);

        Position = myVector3.ToMyVector3(gameObject.transform.position);
        //Position.y -= 7.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Define a new array with the correct size
        myVector3[] transformedVertices = new myVector3[ModelSpaceVertices.Length];

        //Create our scaling matrix (0.5x, 0.5y, 0.5z)
        myMatrix4x4 scaleMatrix = new myMatrix4x4(new myVector3(1, 0, 0) * 2.0f, new myVector3(0, 1, 0), new myVector3(0, 0, 1), myVector3.Zero);

        //Create our rotation matrix (0, 0, 45)
        //Roll
        myMatrix4x4 rollMatrix = new myMatrix4x4(
            new myVector3(Mathf.Cos(45), Mathf.Sin(45), 0),
            new myVector3(-Mathf.Sin(45), Mathf.Cos(45), 0),
            new myVector3(0, 0, 1),
            myVector3.Zero);
        //Pitch
        myMatrix4x4 pitchMatrix = new myMatrix4x4(
            new myVector3(1, 0, 0),
            new myVector3(0, Mathf.Cos(0), Mathf.Sin(0)),
            new myVector3(0, -Mathf.Sin(0), Mathf.Cos(0)),
            myVector3.Zero);
        //Yaw
        myMatrix4x4 yawMatrix = new myMatrix4x4(
            new myVector3(Mathf.Cos(0), 0, -Mathf.Sin(0)),
            new myVector3(0, 1, 0),
            new myVector3(Mathf.Sin(0), 0, Mathf.Cos(0)),
            myVector3.Zero);

        myMatrix4x4 rotationMatrix = yawMatrix * (pitchMatrix * rollMatrix); //Calculates the entire rotation in one step

        //Create our translation matrix
        myMatrix4x4 translationMatrix = new myMatrix4x4(
            new myVector3(1, 0, 0),
            new myVector3(0, 1, 0),
            new myVector3(0, 0, 1),
            //new myVector3(Position.x, Position.y, Position.z));
            new myVector3(2, 0, 0));

        myMatrix4x4 transformMatrix = translationMatrix * (rotationMatrix * scaleMatrix);

        //Transform each individual vertex
        for (int i = 0; i < transformedVertices.Length; i++)
        { transformedVertices[i] = (transformMatrix * ModelSpaceVertices[i]).ToMyVector3(); }

        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //Assign our new vertices
        MF.mesh.vertices = myVector3.ToUnityVector3(transformedVertices);

        //These final steps are sometimes necessary to make the mesh look correct
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
