using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class myPlayerController : MonoBehaviour
{
    public float jumpHeight = 4.0f;
    public float pSpeed = 2.0f; //Player speed
    public Vector2 pCameraSensitivity = new Vector2(1.0f, 1.0f); //Used a Vector2 and not myVector2 so that the variable would appear in the editor
    private bool isFalling = false; //Is the player character falling
    private myRigidBody pRigidBody; //Player Rigid Body
    private myTransform pTransform;
    private AABB pCollisions;
    private myVector3 pRotation = myVector3.Zero;
    private Camera pView;

    // Start is called before the first frame update
    void Start()
    {
        pRigidBody = gameObject.GetComponent<myRigidBody>(); //Stores a reference to the player's myRigidBody component
        pTransform = GetComponent<myTransform>(); //Stores a reference to the player's myTransform component
        pCollisions = GetComponent<AABB>(); //Stores a reference to the player's collider (AABB) component
        pView = gameObject.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pRigidBody.Velocity.y > -1f) { isFalling = false; } //If player has a downwards velocity of less than one, they are not classified as falling

        if (Input.GetButtonDown("Jump") && !isFalling) //If the jump key is pressed and the player is not falling then...
        { pRigidBody.Velocity.y += Mathf.Sqrt(jumpHeight * -20.0f * pRigidBody.Gravity); isFalling = true; } //Gives the player an upwards velocity to simulating jumping and marks the player as falling
        
        //Mouse movement
        if (Input.GetAxis("Mouse X") != 0) { pRotation.y += Input.GetAxis("Mouse X") * pCameraSensitivity.x; } //Rotates x axis
        if (Input.GetAxis("Mouse Y") != 0 && pRotation.x < 60 && pRotation.x > -60) { pRotation.x -= Input.GetAxis("Mouse Y") * pCameraSensitivity.y; } //Rotates y axis
        if (pRotation.x > 60 && pRotation.x > -60) { pRotation.x = 59.9f; } //Gimbles locks the y-axis to prevent camera flipping
        if (pRotation.x < 60 && pRotation.x < -60) { pRotation.x = -59.9f; }
        pView.transform.rotation = Quaternion.Euler(pRotation.ToUnityVector3()); //Rotates the camera using Unity's tranform component as the camera doesn't have a mesh

        //Directional keys
        myVector3 pPosition = myVector3.Zero;
        if (Input.GetAxis("Vertical") != 0) { pTransform.Position.z += Mathf.Sign(Input.GetAxis("Vertical")) * pSpeed * Time.deltaTime;} //Forwards/Backwards
        if (Input.GetAxis("Horizontal") != 0) { pTransform.Position.x += Mathf.Sign(Input.GetAxis("Horizontal")) * pSpeed * Time.deltaTime; } //Left/Right
        //if (Input.GetAxis("Vertical") != 0) { pPosition.z += Mathf.Sign(Input.GetAxis("Vertical")) * pSpeed * Time.deltaTime; } //Forwards/Backwards
        //if (Input.GetAxis("Horizontal") != 0) { pPosition.x += Mathf.Sign(Input.GetAxis("Horizontal")) * pSpeed * Time.deltaTime; } //Left/Right
        //pTransform.Position += new myVector3((pPosition.z * Mathf.Cos(pRotation.y)) + (pPosition.x * -Mathf.Sin(pPosition.y)), 0, (pPosition.z * Mathf.Sin(pRotation.y)) + (pPosition.x * Mathf.Cos(pRotation.y)));
        pPosition = myVector3.Zero;

    }
}