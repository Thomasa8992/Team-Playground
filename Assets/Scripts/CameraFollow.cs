using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float cameraMoveSpeed = 120.0f;
    public GameObject cameraFollowObject;
    Vector3 followPosition;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;
    public GameObject cameraObject;
    public GameObject playerObject;
    public float cameraDistanceXToPlayer;
    public float cameraDistanceYToPlayer;
    public float cameraDistanceZToPlayer;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    public float rotationX = 0.0f;
    public float rotationY = 0.0f;


    // Start is called before the first frame update
    void Start() {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotationX = rot.x;
        rotationY = rot.y;

        //locks the cursor in place in the game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //setup the rotation of the sticks
        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputZ = Input.GetAxis("RightStickVertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        rotationY += finalInputX * inputSensitivity * Time.deltaTime;
        rotationX += finalInputZ * inputSensitivity * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
        transform.rotation = localRotation;
    }

    void LateUpdate() {
        CameraUpdater();
    }

    void CameraUpdater() {
        Transform target = cameraFollowObject.transform;

        float step = cameraMoveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

}
