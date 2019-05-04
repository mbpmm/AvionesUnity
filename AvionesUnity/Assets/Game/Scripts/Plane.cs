using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float rollSpeed;
    public float planeSpeed;
    public float planeAcc;
    public float sensX;
    public float sensY;
    public float speedMax;
    public float speedMin;
    public GameObject bulletEmitter;
    public GameObject bullet;
    public float bulletForce;
    public float playerHP;

    private float mouseX;
    private float mouseY;
    private float horizontal;
    private Vector3 lookRot;
    private float bulletTimer;
    // Start is called before the first frame update
    void Start()
    {
        horizontal = Input.GetAxis("Horizontal");
        rollSpeed = 70f;
        planeSpeed = 15f;
        sensX = 70f;
        sensY = 70f;
        speedMax = 40f;
        speedMin = 10f;
        bulletForce = 300000 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        //camera movement
        planeSpeed += planeAcc;
        planeAcc = Input.GetAxis("Vertical");
        
        if (planeSpeed > speedMax)
        {
            planeSpeed = speedMax;
        }
        else if (planeSpeed < speedMin)
        {
            planeSpeed = speedMin;
        }
        
        horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * planeSpeed * Time.deltaTime);
        mouseX = Input.GetAxis("Mouse X") * sensX * Time.smoothDeltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensY * Time.smoothDeltaTime;
        lookRot = new Vector3(-mouseY, mouseX, 0);
        transform.Rotate(lookRot);
        transform.eulerAngles += new Vector3(0, 0, -horizontal * rollSpeed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            bulletTimer += Time.deltaTime;
            if (bulletTimer>0.15f)
            {
                GameObject auxBullet;
                auxBullet = Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation);
                Rigidbody rig;
                rig = auxBullet.GetComponent<Rigidbody>();
                rig.AddForce(transform.forward * bulletForce);
                bulletTimer = 0;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BulletEnemy(Clone)")
        {
            playerHP = playerHP - 10;
            Debug.Log("colision de bala: " + playerHP);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerHP = 0;
    }

}
