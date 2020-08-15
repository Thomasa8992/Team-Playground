using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float movementSpeed = 6;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        anim = GameObject.Find("GFX").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //normalizing this vector will insure that a consistent speed is used when the character is moving in all directions
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f) {
            anim.SetBool("walking", true);

            //calculate the turn direction based on camera direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //smooths the angles for character turning to keep from having hard snap turning
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDirection.normalized * movementSpeed * Time.deltaTime);
        } else {
            anim.SetBool("walking", false);
        }
    }
}
