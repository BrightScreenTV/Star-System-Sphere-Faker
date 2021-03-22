using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**

    This software is Copyright BrightScreenTV Limited 2020.
    You are free to use this code and the associated project. Please credit where possible.
    THIS IS PROVIDED AS-IS. NO GUARENTEE IS MADE AS TO IT'S FUNCTIONING.
    
*/

public class PlayerOneScript : MonoBehaviour
{
    public float turnSpeed = 40.0f; //doesn't matter what you set here - it's always zero to begin with in the inspector

    public bool wrapXPosition;
    public float xBoundary;
    private float _XBoundary;

    public bool wrapYPosition;
    public float yBoundary;
    private float _YBoundary;

    // ---- Starfield
    public rot_scrpt starField;
    Rigidbody starsRB;

    // ---- This object references
    public GameObject playerSprite;
    Rigidbody2D thisRB;


    // ---- Ship speed factors

    float dragCoeff = 4f; // how quickly we decelerate, def = 4
    float velocityDenom = 4f; // how much force is applied to move forward, def=4

    // ---- 

    private Camera mainCam;

    void Start()
    {
        _YBoundary = Mathf.Max(2f, yBoundary);
        _XBoundary = Mathf.Max(2f, xBoundary);

        mainCam = Camera.main;

        thisRB = GetComponent<Rigidbody2D>();
        starsRB = starField.GetComponent<Rigidbody>();

        thisRB.drag = dragCoeff;
        starsRB.angularDrag = dragCoeff;
    }

    void Update()
    {

        float upDown = Input.GetAxis("Vertical");
        float leftRight = Input.GetAxis("Horizontal");

        Vector3 negRotationVector = Vector3.forward * -turnSpeed * Time.deltaTime * leftRight;
        Vector3 posRotationVector = Vector3.forward * turnSpeed * Time.deltaTime * leftRight;

        playerSprite.transform.Rotate(negRotationVector, Space.Self);

        if (Input.GetKey("s"))
        {
            starsRB.angularVelocity = Vector3.zero;
            thisRB.velocity = Vector3.zero;
        }

        if (Input.GetKey("h")) {
            // Hyperspace!
            Vector3 newPosition = new Vector3(Random.Range(-xBoundary, xBoundary), Random.Range(-yBoundary, yBoundary), 0.0f);
            hyperSpace(newPosition);
        }

        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (wrapXPosition) {
            pos.x = Mathf.Repeat(pos.x + _XBoundary, _XBoundary * 2) - _XBoundary;
        }
        if (wrapYPosition) {
            pos.y = Mathf.Repeat(pos.y + _YBoundary, _YBoundary * 2) - _YBoundary;
        }

        if (pos != transform.position) {
            // mimic hyperspace to show we've wrapped
            hyperSpace(pos);
        }

        Vector3 movementForce = playerSprite.transform.up * (upDown / velocityDenom);

        thisRB.AddForce(movementForce, ForceMode2D.Impulse);

        starsRB.AddTorque(playerSprite.transform.right * (-upDown / (velocityDenom * 2)), ForceMode.Impulse);
    }

    void hyperSpace(Vector3 newPos) {
        Vector3 difference = (newPos - transform.position).normalized;
        transform.position = newPos;
        starsRB.AddTorque((Quaternion.Euler(0, 0, -270) * difference) * 500f, ForceMode.Impulse);
    }
}