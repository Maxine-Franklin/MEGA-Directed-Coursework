using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleObject : MonoBehaviour
{
    myVector3[] ModelSpaceVertices;
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
        //Define a new array with the correct size
        myVector3[] TransformedVertices = new myVector3[ModelSpaceVertices.Length];

        //Create our scaling matrix (2x, y, z)
        myMatrix4x4 scaleMatrix = new myMatrix4x4(new myVector3(1, 0, 0) * 2.0f, new myVector3(0, 1, 0), new myVector3(0, 0, 1), myVector3.Zero);

        //Transform each individual vertex
        for (int i = 0; i < TransformedVertices.Length; i++)
        { TransformedVertices[i] = (scaleMatrix * ModelSpaceVertices[i]).ToMyVector3(); }

        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //Assign our new vertices
        MF.mesh.vertices = myVector3.ToUnityVector3(TransformedVertices);

        //These final steps are sometimes necessary to make the mesh look correct
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
