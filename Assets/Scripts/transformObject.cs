using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformObject : MonoBehaviour
{
    myVector3[] ModelSpaceVertices;

    void start()
    {
        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //We get a copy of all the vertices (this is NOT efficient, but for the sake of understanding we're doing it like this)
        //ModelSpaceVertices = MF.mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
