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
    private myTransform pTransform; //Player transform
    private AABB pCollisions; //Player collision detection
    private myVector3 pRotation = myVector3.Zero; //Player rotation
    private Camera pView; //Player view

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        pRigidBody = gameObject.GetComponent<myRigidBody>(); //Stores a reference to the player's myRigidBody component
        pTransform = GetComponent<myTransform>(); //Stores a reference to the player's myTransform component
        pCollisions = GetComponent<AABB>(); //Stores a reference to the player's collider (AABB) component
        pView = gameObject.GetComponentInChildren<Camera>(); //Obtains player camera
    }

    // Update is called once per frame
    void Update()
    {
        if (pRigidBody.Velocity.y > -1f && pRigidBody.Velocity.y <= 1f) { isFalling = false; } //If player has a downwards velocity of less than one, they are not classified as falling

        if (Input.GetButtonDown("Jump") && !isFalling) //If the jump key is pressed and the player is not falling then...
        { pRigidBody.Velocity.y += Mathf.Sqrt(jumpHeight * -20.0f * pRigidBody.Gravity); isFalling = true; } //Gives the player an upwards velocity to simulating jumping and marks the player as falling

        if (Input.GetKeyDown("r")) //If r key is pressed, the player vertical position is reset to 4 on the y-axis, this is to bring the player back to the map if they fall through the world
        { pCollisions.Position(new myVector3(0, 4.0f - pTransform.Position.y, 0)); pTransform.Position.y = 4.0f; pRigidBody.Velocity.y = 0f; } //Resets player/collider position removes vertical velocity

        //Mouse movement
        if (Input.GetAxis("Mouse X") != 0) { pRotation.y += Input.GetAxis("Mouse X") * pCameraSensitivity.x; } //Rotates x axis
        if (Input.GetAxis("Mouse Y") != 0 && pRotation.x < 60 && pRotation.x > -60) { pRotation.x -= Input.GetAxis("Mouse Y") * pCameraSensitivity.y; } //Rotates y axis
        if (pRotation.x > 60 && pRotation.x > -60) { pRotation.x = 59.9f; } //Gimbles locks the y-axis to prevent camera flipping
        if (pRotation.x < 60 && pRotation.x < -60) { pRotation.x = -59.9f; } //Gimbles locks the y-axis to prevent camera flipping
        pView.transform.rotation = Quaternion.Euler(pRotation.ToUnityVector3()); //Rotates the camera using Unity's tranform component as the camera doesn't have a mesh

        //Directional keys
        if (Input.GetAxis("Vertical") != 0) {pTransform.Position.z += Mathf.Sign(Input.GetAxis("Vertical")) * pSpeed * Time.deltaTime; //Forwards/Backwards (Mesh)
            pCollisions.Position(new myVector3(0, 0, Mathf.Sign(Input.GetAxis("Vertical")) * pSpeed * Time.deltaTime)); } //Forwards/Backwards (Collider)
        if (Input.GetAxis("Horizontal") != 0) { pTransform.Position.x += Mathf.Sign(Input.GetAxis("Horizontal")) * pSpeed * Time.deltaTime; //Left/Right (Mesh)
            pCollisions.Position(new myVector3(Mathf.Sign(Input.GetAxis("Vertical")) * pSpeed * Time.deltaTime, 0, 0)); } //Left/Right (Collider)
        //myVector3 pPosition = myVector3.Zero; //Needed to account for player rotation of direction
        //if (Input.GetAxis("Vertical") != 0) { pPosition.z += Mathf.Sign(Input.GetAxis("Vertical")) * pSpeed * Time.deltaTime; } //Forwards/Backwards
        //if (Input.GetAxis("Horizontal") != 0) { pPosition.x += Mathf.Sign(Input.GetAxis("Horizontal")) * pSpeed * Time.deltaTime; } //Left/Right
        //pTransform.Position += new myVector3((pPosition.z * Mathf.Cos(pRotation.y)) + (pPosition.x * -Mathf.Sin(pPosition.y)), 0, (pPosition.z * Mathf.Sin(pRotation.y)) + (pPosition.x * Mathf.Cos(pRotation.y)));
        //pPosition = myVector3.Zero;

    }
}