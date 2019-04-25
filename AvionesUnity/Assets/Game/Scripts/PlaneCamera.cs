using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCamera : MonoBehaviour
{

    public float yawSpeed;
    public float planeSpeed;
    public float planeAcc;

    private float mouseX;
    private float mouseY;
    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        horizontal = Input.GetAxis("Horizontal");
        yawSpeed = 3000f;
        planeSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        planeAcc = Input.GetAxis("Vertical");
        planeSpeed += planeAcc;
        horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * planeSpeed * Time.deltaTime);
        mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
        mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
        transform.rotation = Quaternion.Euler(new Vector4(-1f * (mouseY * 180f), mouseX * 360f, transform.rotation.z));
        transform.eulerAngles += new Vector3(0,horizontal * yawSpeed * Time.deltaTime, 0);
        
    }
}
