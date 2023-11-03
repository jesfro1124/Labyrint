using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gubbe : MonoBehaviour
{
    public float movementSpeed = 2.5f;
    public float cameraSpeed = 2f;

    private Transform cameraTransform;
    public Transform cameraTransform1;
    public Transform cameraTransform2;
    public Rigidbody body;
    public Transform arm1;
    public Transform arm2;

    private float armRotX = 120f;

    void Start() {
        cameraTransform = cameraTransform1;
        cameraTransform1.gameObject.SetActive(cameraTransform == cameraTransform1);
        cameraTransform2.gameObject.SetActive(cameraTransform == cameraTransform2);
    }


    void Update()
    {
        float rotationGubbe = Input.GetAxis("Mouse X");
        transform.localEulerAngles += new Vector3(0, rotationGubbe, 0) * cameraSpeed * Time.deltaTime;

        float rotationCamera = Input.GetAxis("Mouse Y");
        Vector3 cameraAngles = cameraTransform.localEulerAngles;
        cameraAngles.x = cameraAngles.x - rotationCamera * cameraSpeed * Time.deltaTime;
        // Begränsa siktvinkeln till mellan -70 och 70 grader
        while (cameraAngles.x > 180)
            cameraAngles.x -= 360;
        if (cameraAngles.x < -70f)
            cameraAngles.x = -70f;
        if (cameraAngles.x > 70f)
            cameraAngles.x = 70f;
        cameraTransform.localEulerAngles = cameraAngles;

        if (Input.GetKeyDown(KeyCode.C)){
           if (cameraTransform == cameraTransform1){
               cameraTransform = cameraTransform2;
           } 
           else
               cameraTransform = cameraTransform1;
            cameraTransform1.gameObject.SetActive(cameraTransform == cameraTransform1);
            cameraTransform2.gameObject.SetActive(cameraTransform == cameraTransform2);
        }

        float movement = Input.GetAxis("Vertical");
        if (movement != 0) {
            Vector3 armAngles = arm1.localEulerAngles;
            while (armAngles.x > 180)
                armAngles.x -= 360;
            if (armAngles.x > 30 || armAngles.x < -30)
                armRotX = -armRotX;
            arm1.localEulerAngles = armAngles + new Vector3(armRotX * Time.deltaTime, 0, 0);
            arm2.localEulerAngles = new Vector3(-arm1.localEulerAngles.x, arm1.localEulerAngles.y, arm1.localEulerAngles.z);
        }
    }
    void FixedUpdate()
    {
        float movement = Input.GetAxis("Vertical");
        if (movement != 0) {
            body.MovePosition(transform.position + transform.forward * movement * movementSpeed * Time.fixedDeltaTime);
        }
    }
}
