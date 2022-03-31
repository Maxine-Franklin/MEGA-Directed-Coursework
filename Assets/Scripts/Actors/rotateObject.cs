using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour
{
    myVector3[] ModelSpaceVertices;
    float Angle = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //We get a copy of all the vertices (this is NOT efficient, but for the sake of understanding we're doing it like this)
        ModelSpaceVertices = myVector3.ToMyVector3(MF.mesh.vertices);
    }

    // Update is called once per frame
    void Update()
    {
        //Add to our Yaw Angle
        Angle += Time.deltaTime;

        //Define a new array with the correct zise
        myVector3[] TransformedVertices = new myVector3[ModelSpaceVertices.Length];

        //Create our rotation matrix

        //Roll
        myMatrix4x4 rollMatrix = new myMatrix4x4(
            new myVector3(Mathf.Cos(Angle), Mathf.Sin(Angle), 0),
            new myVector3(-Mathf.Sin(Angle), Mathf.Cos(Angle), 0),
            new myVector3(0, 0, 1),
            myVector3.Zero);
        //Pitch
        myMatrix4x4 pitchMatrix = new myMatrix4x4(
            new myVector3(1, 0, 0),
            new myVector3(0, Mathf.Cos(Angle), Mathf.Sin(Angle)),
            new myVector3(0, -Mathf.Sin(Angle), Mathf.Cos(Angle)),
            myVector3.Zero);
        //Yaw
        myMatrix4x4 yawMatrix = new myMatrix4x4(
            new myVector3(Mathf.Cos(Angle), 0, -Mathf.Sin(Angle)),
            new myVector3(0, 1, 0),
            new myVector3(Mathf.Sin(Angle), 0, Mathf.Cos(Angle)),
            myVector3.Zero);

        myMatrix4x4 rotationMatrix = yawMatrix * (pitchMatrix * rollMatrix); //Calculates the entire rotation in one step

        //Transform each individual vertex
        for (int i = 0; i < TransformedVertices.Length; i++)
        {
            TransformedVertices[i] = (rotationMatrix * ModelSpaceVertices[i]).ToMyVector3();
        }

        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //Assign our new vertices
        MF.mesh.vertices = myVector3.ToUnityVector3(TransformedVertices);

        //These final steps are sometimes necessary to make the mesh look correct
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
