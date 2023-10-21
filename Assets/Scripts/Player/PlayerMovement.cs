using UnityEngine;

namespace PlayerController{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;
        public Transform groundCheck;
        public LayerMask groundMask;

        public float speed = 12f;
        public float gravity = -9.81f;
        public float groundDistance = 0.4f;
        public float jumpHeight = 3f;
        public float sprintSpeed = 8.0f;
        public float sprintDuration = 3.0f; // How long can the player sprint
        public float sprintCooldown = 5.0f; // How long it takes for sprint to fully regenerate
        public float currentSprintTime = 6.0f;
        private bool isSprinting = false;
    
        Vector3 velocity;
        bool isGrounded;

        void Update()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f; 
            }

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * y;

            if (Input.GetKey(KeyCode.LeftShift) && !isSprinting && currentSprintTime > 0)
            {
                isSprinting = true;
            }
            else if (!Input.GetKey(KeyCode.LeftShift) && isSprinting)
            {
                isSprinting = false;
            }
            if (isSprinting)
            {
                currentSprintTime -= Time.fixedDeltaTime;
                controller.Move(move * Time.fixedDeltaTime * sprintSpeed);
                if (currentSprintTime <= 0)
                {
                    isSprinting = false;
                }
            }
            else
            {
                if (currentSprintTime < sprintDuration)
                {
                    currentSprintTime += Time.fixedDeltaTime / sprintCooldown;
                }
                controller.Move(move * Time.fixedDeltaTime * speed);
            }

            if(Input.GetButtonDown("Jump") && isGrounded){
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}