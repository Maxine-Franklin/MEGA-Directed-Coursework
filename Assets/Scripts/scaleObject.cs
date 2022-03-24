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

        //Vector3[] TempMSV = MF.mesh.vertices;

        //ModelSpaceVertices = new myVector3[MF.mesh.vertices.Length];
        //We get a copy of all the vertices (this is NOT efficient, but for the sake of understanding we're doing it like this)
        //for (int i = 0; i < MF.mesh.vertices.Length; i++)
        //{
        //    ModelSpaceVertices[i] = new myVector3(TempMSV[i].x, TempMSV[i].y, TempMSV[i].z);
        //}
        //ModelSpaceVertices = MF.mesh.vertices;

        //We get a copy of all the vertices (this is NOT efficient, but for the sake of understanding we're doing it like this)
        ModelSpaceVertices = myVector3.ToMyVector3(MF.mesh.vertices);

       // ModelSpaceVertices = TempMSV;
    }

    // Update is called once per frame
    void Update()
    {
        //Define a new array with the correct size
        myVector3[] TransformedVertices = new myVector3[ModelSpaceVertices.Length];

        //Transform each individual vertex
        myMatrix4x4 scaleMatrix = new myMatrix4x4(new myVector3(1, 0, 0) * 2.0f, new myVector3(0, 1, 0), new myVector3(0, 0, 1), myVector3.Zero);

        //Transofrm each indiviudal vertex
        for (int i = 0; i < TransformedVertices.Length; i++)
        { TransformedVertices[i] = (scaleMatrix * ModelSpaceVertices[i]).ToMyVector3(); }

        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //Assign our new vertices
        for (int i = 0; i < MF.mesh.vertices.Length; i++)
        { MF.mesh.vertices[i] = TransformedVertices[i].ToUnityVector3(); }

        //These final steps are sometimes necessary to make the mesh look correct
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
