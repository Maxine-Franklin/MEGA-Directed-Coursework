using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformObject : MonoBehaviour
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
        //Position.y -= 7.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        //Define a new array with the correct size
        myVector3[] transformedVertices = new myVector3[ModelSpaceVertices.Length];

        //Create our scaling matrix (0.5x, 0.5y, 0.5z)
        myMatrix4x4 scaleMatrix = new myMatrix4x4(new myVector3(1, 0, 0) * (1 + Mathf.Sin(Timer)), new myVector3(0, 1, 0) * (1 + Mathf.Cos(Timer)), new myVector3(0, 0, 1) * (1 + Mathf.Cos(Timer) * Mathf.Sin(Timer)), myVector3.Zero);

        /*Debug.Log("Scale Matrix:\n" +
            scaleMatrix.values[0, 0] + ", " + scaleMatrix.values[1, 0] + ", " + scaleMatrix.values[2, 0] + ", " + scaleMatrix.values[3, 0] + "\n" +
            scaleMatrix.values[0, 1] + ", " + scaleMatrix.values[1, 1] + ", " + scaleMatrix.values[2, 1] + ", " + scaleMatrix.values[3, 1] + "\n" +
            scaleMatrix.values[0, 2] + ", " + scaleMatrix.values[1, 2] + ", " + scaleMatrix.values[2, 2] + ", " + scaleMatrix.values[3, 2] + "\n" +
            scaleMatrix.values[0, 3] + ", " + scaleMatrix.values[1, 3] + ", " + scaleMatrix.values[2, 3] + ", " + scaleMatrix.values[3, 3]);*/

        //Create our rotation matrix (0, 0, 45)
        //Roll
        /*myMatrix4x4 rollMatrix = new myMatrix4x4(
            new myVector3(Mathf.Cos(0), Mathf.Sin(0), 0),
            new myVector3(-Mathf.Sin(0), Mathf.Cos(0), 0),
            new myVector3(0, 0, 1),
            myVector3.Zero);*/
        /*Debug.Log("Roll Matrix:\n" +
            rollMatrix.values[0, 0] + ", " + rollMatrix.values[1, 0] + ", " + rollMatrix.values[2, 0] + ", " + rollMatrix.values[3, 0] + "\n" +
            rollMatrix.values[0, 1] + ", " + rollMatrix.values[1, 1] + ", " + rollMatrix.values[2, 1] + ", " + rollMatrix.values[3, 1] + "\n" +
            rollMatrix.values[0, 2] + ", " + rollMatrix.values[1, 2] + ", " + rollMatrix.values[2, 2] + ", " + rollMatrix.values[3, 2] + "\n" +
            rollMatrix.values[0, 3] + ", " + rollMatrix.values[1, 3] + ", " + rollMatrix.values[2, 3] + ", " + rollMatrix.values[3, 3]);*/
        //Pitch
        /*myMatrix4x4 pitchMatrix = new myMatrix4x4(
            new myVector3(1, 0, 0),
            new myVector3(0, Mathf.Cos(0), Mathf.Sin(0)),
            new myVector3(0, -Mathf.Sin(0), Mathf.Cos(0)),
            myVector3.Zero);*/
        /*Debug.Log("Pitch Matrix:\n" +
            pitchMatrix.values[0, 0] + ", " + pitchMatrix.values[1, 0] + ", " + pitchMatrix.values[2, 0] + ", " + pitchMatrix.values[3, 0] + "\n" +
            pitchMatrix.values[0, 1] + ", " + pitchMatrix.values[1, 1] + ", " + pitchMatrix.values[2, 1] + ", " + pitchMatrix.values[3, 1] + "\n" +
            pitchMatrix.values[0, 2] + ", " + pitchMatrix.values[1, 2] + ", " + pitchMatrix.values[2, 2] + ", " + pitchMatrix.values[3, 2] + "\n" +
            pitchMatrix.values[0, 3] + ", " + pitchMatrix.values[1, 3] + ", " + pitchMatrix.values[2, 3] + ", " + pitchMatrix.values[3, 3]);*/
        //Yaw
        /*myMatrix4x4 yawMatrix = new myMatrix4x4(
            new myVector3(Mathf.Cos(0), 0, -Mathf.Sin(0)),
            new myVector3(0, 1, 0),
            new myVector3(Mathf.Sin(0), 0, Mathf.Cos(0)),
            myVector3.Zero);*/
        /*Debug.Log("Yaw Matrix:\n" +
            yawMatrix.values[0, 0] + ", " + yawMatrix.values[1, 0] + ", " + yawMatrix.values[2, 0] + ", " + yawMatrix.values[3, 0] + "\n" +
            yawMatrix.values[0, 1] + ", " + yawMatrix.values[1, 1] + ", " + yawMatrix.values[2, 1] + ", " + yawMatrix.values[3, 1] + "\n" +
            yawMatrix.values[0, 2] + ", " + yawMatrix.values[1, 2] + ", " + yawMatrix.values[2, 2] + ", " + yawMatrix.values[3, 2] + "\n" +
            yawMatrix.values[0, 3] + ", " + yawMatrix.values[1, 3] + ", " + yawMatrix.values[2, 3] + ", " + yawMatrix.values[3, 3]);*/

        myMatrix4x4 rollMatrix = new myMatrix4x4(
            new myVector3(Mathf.Cos(Timer), Mathf.Sin(Timer), 0),
            new myVector3(-Mathf.Sin(Timer), Mathf.Cos(Timer), 0),
            new myVector3(0, 0, 1),
            myVector3.Zero);
        //Pitch
        myMatrix4x4 pitchMatrix = new myMatrix4x4(
            new myVector3(1, 0, 0),
            new myVector3(0, Mathf.Cos(Timer), Mathf.Sin(Timer)),
            new myVector3(0, -Mathf.Sin(Timer), Mathf.Cos(Timer)),
            myVector3.Zero);
        //Yaw
        myMatrix4x4 yawMatrix = new myMatrix4x4(
            new myVector3(Mathf.Cos(Timer), 0, -Mathf.Sin(Timer)),
            new myVector3(0, 1, 0),
            new myVector3(Mathf.Sin(Timer), 0, Mathf.Cos(Timer)),
            myVector3.Zero);

        myMatrix4x4 rotationMatrix = yawMatrix * (pitchMatrix * rollMatrix); //Calculates the entire rotation in one step

        /*Debug.Log("Rotation Matrix:\n" +
            rotationMatrix.values[0, 0] + ", " + rotationMatrix.values[1, 0] + ", " + rotationMatrix.values[2, 0] + ", " + rotationMatrix.values[3, 0] + "\n" +
            rotationMatrix.values[0, 1] + ", " + rotationMatrix.values[1, 1] + ", " + rotationMatrix.values[2, 1] + ", " + rotationMatrix.values[3, 1] + "\n" +
            rotationMatrix.values[0, 2] + ", " + rotationMatrix.values[1, 2] + ", " + rotationMatrix.values[2, 2] + ", " + rotationMatrix.values[3, 2] + "\n" +
            rotationMatrix.values[0, 3] + ", " + rotationMatrix.values[1, 3] + ", " + rotationMatrix.values[2, 3] + ", " + rotationMatrix.values[3, 3]);*/

        //Create our translation matrix
        myMatrix4x4 translationMatrix = new myMatrix4x4(
            new myVector3(1, 0, 0),
            new myVector3(0, 1, 0),
            new myVector3(0, 0, 1),
            //new myVector3(Position.x, Position.y, Position.z));
            new myVector3(Mathf.Cos(Timer), -Mathf.Sin(Timer), -Mathf.Cos(Timer)));

        /*Debug.Log("Translation Matrix:\n" +
            translationMatrix.values[0, 0] + ", " + translationMatrix.values[1, 0] + ", " + translationMatrix.values[2, 0] + ", " + translationMatrix.values[3, 0] + "\n" +
            translationMatrix.values[0, 1] + ", " + translationMatrix.values[1, 1] + ", " + translationMatrix.values[2, 1] + ", " + translationMatrix.values[3, 1] + "\n" +
            translationMatrix.values[0, 2] + ", " + translationMatrix.values[1, 2] + ", " + translationMatrix.values[2, 2] + ", " + translationMatrix.values[3, 2] + "\n" +
            translationMatrix.values[0, 3] + ", " + translationMatrix.values[1, 3] + ", " + translationMatrix.values[2, 3] + ", " + translationMatrix.values[3, 3]);*/

        myMatrix4x4 transformMatrix = translationMatrix * (rotationMatrix * scaleMatrix);

        /*Debug.Log("Transform Matrix:\n" +
            transformMatrix.values[0, 0] + ", " + transformMatrix.values[1, 0] + ", " + transformMatrix.values[2, 0] + ", " + transformMatrix.values[3, 0] + "\n" +
            transformMatrix.values[0, 1] + ", " + transformMatrix.values[1, 1] + ", " + transformMatrix.values[2, 1] + ", " + transformMatrix.values[3, 1] + "\n" +
            transformMatrix.values[0, 2] + ", " + transformMatrix.values[1, 2] + ", " + transformMatrix.values[2, 2] + ", " + transformMatrix.values[3, 2] + "\n" +
            transformMatrix.values[0, 3] + ", " + transformMatrix.values[1, 3] + ", " + transformMatrix.values[2, 3] + ", " + transformMatrix.values[3, 3]);*/
        
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
