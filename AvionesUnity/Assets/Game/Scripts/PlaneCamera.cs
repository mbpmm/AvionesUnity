using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCamera : MonoBehaviour
{
    /*
     Primero vos le estas seteando 
transform.rotation = Quaternion.Euler(new Vector4(-1f * (mouseY * 180f), mouseX * 360f, transform.rotation.z));

Ahi estas mezclando Eulers con Quaternions. Ese "transform.rotation.z" del final está tomando la data del quaternion, no de los euler. Recordá que Quaternion y 
Euler funcionan completamente diferente.

Ahora, si vos transformás ese "transform.rotation.z" en "transform.rotation.eulerAngles.z" vas a ver que cuado haces un Yaw se empieza a romper todo el control de tu avión. 
Fijate que pasa con las rotaciones en el Inspector de Unity.

Tratá de observar un poco las rotaciones del ejercicio que vimos en clase. Pensar un poco lo que vimos en clase sobre los pinos tambien, el concepto de una vez que roto mi 
transform que pasa con la siguiente rotación que hago.

Probá agregar rotación a la rotación que ya tenes y NO setearla en base a tu input. Porque de momento estás usando la posición del mouse en pantalla para definir la rotación de tu nave. 
Recordá que tenés Input.GetAxis("Mouse Y") tambien:
https://docs.unity3d.com/ScriptReference/Input.GetAxis.html 


Por otro lado:
transform.eulerAngles += new Vector3(0,  horizontal * yawSpeed * Time.deltaTime, 0);
supongo que vendría a ser:
transform.eulerAngles += new Vector3(0, 0, horizontal * yawSpeed * Time.deltaTime);
no?
     */


    public float rollSpeed;
    public float planeSpeed;
    public float planeAcc;
    public float sensX;
    public float sensY;

    private float mouseX;
    private float mouseY;
    private float horizontal;
    private Vector3 lookRot;
    // Start is called before the first frame update
    void Start()
    {
        horizontal = Input.GetAxis("Horizontal");
        rollSpeed = 20f;
        planeSpeed = 10f;
        sensX = 70f;
        sensY = 70f;
    }

    // Update is called once per frame
    void Update()
    {
        planeAcc = Input.GetAxis("Vertical");
        planeSpeed += planeAcc;
        horizontal = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.forward * planeSpeed * Time.deltaTime);
        mouseX = Input.GetAxis("Mouse X")*sensX*Time.smoothDeltaTime;
        mouseY = Input.GetAxis("Mouse Y")*sensY*Time.smoothDeltaTime;
        lookRot = new Vector3(-mouseY,mouseX, 0);
        transform.Rotate(lookRot); 
        transform.eulerAngles += new Vector3(0, 0, -horizontal * rollSpeed * Time.deltaTime);
    }
}
