using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleObject : MonoBehaviour
{
    myVector3[] ModelSpaceVertices;
    float Scaler = 0.0f;
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
        Scaler += Time.deltaTime; //Tracks total time since function started

        //Define a new array with the correct size
        myVector3[] TransformedVertices = new myVector3[ModelSpaceVertices.Length];

        //Create our scaling matrix (sine wave, cosine wave, cosine wave)
        myMatrix4x4 scaleMatrix = new myMatrix4x4(new myVector3(1, 0, 0) * (1 + Mathf.Sin(Scaler)), new myVector3(0, 1, 0) * (1 + Mathf.Cos(Scaler)), new myVector3(0, 0, 1) * (1 + Mathf.Cos(Scaler) * Mathf.Sin(Scaler)), myVector3.Zero);

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
