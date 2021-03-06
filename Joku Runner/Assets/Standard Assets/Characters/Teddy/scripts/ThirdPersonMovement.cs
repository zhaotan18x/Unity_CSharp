using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class ThirdPersonMovement : MonoBehaviour
{
    const float locomationAnimationSmoothTime = .1f;
    
    public Transform cam; 
    public CharacterController controller;

    public float walkspeed = 2f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
   
     public float jumpSpeed = 8.0F;
     private Vector3 moveDirection = Vector3.zero;
     public float gravity = 20.0F;

    void Start(){
      
    }


    // Update is called once per frame
    void Update()
    {
        //input kysely
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime );
            transform.rotation = Quaternion.Euler(0f, angle,0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * walkspeed * Time.deltaTime);      

        }
        //hyppy
       if (controller.isGrounded && Input.GetButton("Jump")) {
         moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
}
