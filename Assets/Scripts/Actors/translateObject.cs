using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateObject : MonoBehaviour
{
    myVector3[] ModelSpaceVertices;
    myVector3 Position = new myVector3(0.0f, 7.0f, 3.0f);
    float Timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //We get a copy of all the vertices (this is NOT efficient, but for the sake of understanding we're doing it like this)
        ModelSpaceVertices = myVector3.ToMyVector3(MF.mesh.vertices);

        Position = myVector3.ToMyVector3(gameObject.transform.position);
        Position.y -= 7.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        //Define a new array with the correct zise
        myVector3[] transformedVertices = new myVector3[ModelSpaceVertices.Length];

        //Create our translation matrix
        myMatrix4x4 translationMatrix = new myMatrix4x4(
            new myVector3(1, 0, 0),
            new myVector3(0, 1, 0),
            new myVector3(0, 0, 1),
            //new myVector3(Mathf.Cos(Timer) + Position.x, -Mathf.Sin(Timer) + Position.y, -Mathf.Cos(Timer) + Position.z));
            new myVector3(Mathf.Cos(Timer), -Mathf.Sin(Timer), -Mathf.Cos(Timer)));

        //Transform each individual vertex
        for (int i = 0; i < transformedVertices.Length; i++)
        { transformedVertices[i] = (translationMatrix * ModelSpaceVertices[i]).ToMyVector3(); }

        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //Assign our new vertices
        MF.mesh.vertices = myVector3.ToUnityVector3(transformedVertices);

        //These final steps are sometimes necessary to make the mesh look correct
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
