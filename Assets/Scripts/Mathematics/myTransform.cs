using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myTransform : MonoBehaviour
{
    public myVector3 Position = myVector3.Zero; //myMatrix4x4.Identity;
    //public Position position = new Position(myVector3.Zero);
    public myVector3 Rotation = myVector3.Zero;
    public myVector3 Scale = new myVector3(1f, 1f, 1f);

    myVector3[] ModelSpaceVertices;

    // Start is called before the first frame update
    void Start()
    {
        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //We get a copy of all the vertices (this is NOT efficient, but for the sake of understanding we're doing it like this)
        ModelSpaceVertices = myVector3.ToMyVector3(MF.mesh.vertices);

        //Position = myVector3.ToMyVector3(gameObject.transform.position);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ModelSpaceVertices != null)
        {
            //Define a new array with the correct size
            myVector3[] transformedVertices = new myVector3[ModelSpaceVertices.Length];

            //Create our scaling matrix
            myMatrix4x4 scaleMatrix = new myMatrix4x4(new myVector3(1, 0, 0) * Scale.x, new myVector3(0, 1, 0) * Scale.y, new myVector3(0, 0, 1) * Scale.z, myVector3.Zero);

            //Create our rotation matrix (0, 0, 45)
            //Roll
            myMatrix4x4 rollMatrix = new myMatrix4x4(
                new myVector3(Mathf.Cos(Rotation.x), Mathf.Sin(Rotation.x), 0),
                new myVector3(-Mathf.Sin(Rotation.x), Mathf.Cos(Rotation.x), 0),
                new myVector3(0, 0, 1),
                myVector3.Zero);
            //Pitch
            myMatrix4x4 pitchMatrix = new myMatrix4x4(
                new myVector3(1, 0, 0),
                new myVector3(0, Mathf.Cos(Rotation.y), Mathf.Sin(Rotation.y)),
                new myVector3(0, -Mathf.Sin(Rotation.y), Mathf.Cos(Rotation.y)),
                myVector3.Zero);
            //Yaw
            myMatrix4x4 yawMatrix = new myMatrix4x4(
                new myVector3(Mathf.Cos(Rotation.z), 0, -Mathf.Sin(Rotation.z)),
                new myVector3(0, 1, 0),
                new myVector3(Mathf.Sin(Rotation.z), 0, Mathf.Cos(Rotation.z)),
                myVector3.Zero);

            myMatrix4x4 rotationMatrix = yawMatrix * (pitchMatrix * rollMatrix); //Calculates the entire rotation in one step

            //Create our translation matrix
            myMatrix4x4 translationMatrix = new myMatrix4x4(
                new myVector3(1, 0, 0),
                new myVector3(0, 1, 0),
                new myVector3(0, 0, 1),
                new myVector3(Position.x, Position.y, Position.z));

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
            Camera pCam = gameObject.GetComponentInChildren<Camera>();
            if (pCam != null)
            {
                pCam.transform.localPosition = Position.ToUnityVector3();
            }
        }
    }

    /*private myVector3[] getMesh()
    {
        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();
        position = new Position(myVector3.ToMyVector3(gameObject.transform.position));

        //We get a copy of all the vertices (this is NOT efficient, but for the sake of understanding we're doing it like this)
        return myVector3.ToMyVector3(MF.mesh.vertices);
    }

    public void gMesh()
    {
        MeshFilter MF = GetComponent<MeshFilter>();
        ModelSpaceVertices = myVector3.ToMyVector3(MF.mesh.vertices);
        return;
    }*/

    /*struct Pos
    {
        private myVector3 _pos;
        public Pos(myVector3 a)
        { _pos = a; }
        public static Pos operator +(Pos a, myVector3 b)
        { 

            return a;
        }
    }*/

    /*
    internal class Pos : MonoBehaviour
    {
        private myVector3 _position = myVector3.Zero;
        GameObject b;
        public Pos(GameObject a)
        {
            b = a;
        }
        private void Jerry()
        {
            GameObject g = gameObject;
        }
        public static Pos operator +(Pos a, myVector3 b)
        {
            //myVector3 _position = myVector3.ToMyVector3();

            return a;
        }
    }*/
}

/*public class Position
{
    private myVector3 _position; //= new myVector3(0, 0, 0);
    public Position(myVector3 a) { _position = a; } //The Position constructor

    /*public static Position operator +(Position a, myVector3 b)
    {
        return 
    }/
}*/