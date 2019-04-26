using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCamera : MonoBehaviour
{
    public float rollSpeed;
    public float planeSpeed;
    public float planeAcc;
    public float sensX;
    public float sensY;
    public float speedMax;
    public float speedMin;

    private float mouseX;
    private float mouseY;
    private float horizontal;
    private Vector3 lookRot;
    // Start is called before the first frame update
    void Start()
    {
        horizontal = Input.GetAxis("Horizontal");
        rollSpeed = 70f;
        planeSpeed = 15f;
        sensX = 70f;
        sensY = 70f;
        speedMax = 50f;
        speedMin = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        planeAcc = Input.GetAxis("Vertical");
        planeSpeed += planeAcc;

        if (planeSpeed>speedMax)
        {
            planeSpeed = speedMax;
        }
        else if (planeSpeed<speedMin)
        {
            planeSpeed = speedMin;
        }

        horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * planeSpeed * Time.deltaTime);
        mouseX = Input.GetAxis("Mouse X")*sensX*Time.smoothDeltaTime;
        mouseY = Input.GetAxis("Mouse Y")*sensY*Time.smoothDeltaTime;
        lookRot = new Vector3(-mouseY,mouseX, 0);
        transform.Rotate(lookRot); 
        transform.eulerAngles += new Vector3(0, 0, -horizontal * rollSpeed * Time.deltaTime);
    }
}
