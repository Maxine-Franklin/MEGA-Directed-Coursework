using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleObject : MonoBehaviour
{
    myVector3[] ModelSpaceVertices;
    // Start is called before the first frame update
    void start()
    {
        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //We get a copy of all the vertices (this is NOT efficient, but for the sake of understanding we're doing it like this)
        for (int i = 0; i < MF.mesh.vertices.Length; i++)
        {
            ModelSpaceVertices[i] = new myVector3(MF.mesh.vertices[i].x, MF.mesh.vertices[i].y, MF.mesh.vertices[i].z);
        }
        //ModelSpaceVertices = MF.mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        myVector3[] TransformedVertices = new myVector3[ModelSpaceVertices.Length];

        myMatrix4x4 scaleMatrix = new myMatrix4x4(new myVector3(1, 0, 0) * 2.0f, new myVector3(0, 1, 0), new myVector3(0, 0, 1), myVector3.Zero);

        //Transofrm each indiviudal vertex
        for (int i = 0; i < TransformedVertices.Length; i++)
        { TransformedVertices[i] = scaleMatrix * ModelSpaceVertices[i]; }

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
