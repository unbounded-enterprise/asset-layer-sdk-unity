using UnityEngine;

namespace AssetLayer.Unity
{

    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5.0f;
        public float deceleration = 0.9f;
        public float jumpForce = 2.0f;
        public float gravityScale = 1.5f;
        public float rotationSpeed = 5.0f;
        public Transform groundCheck; // Position marking where to check if the player is grounded.
        public float groundCheckRadius; // Radius of the ground check sphere.
        public LayerMask groundLayer; // Layer(s) to consider as ground.
        public AudioSource jumpSound; // AudioSource to play jump sound.
        public float respawnHeight = -10f;

        private bool isGrounded; // Whether or not the player is currently grounded.

        private Rigidbody rb;
        private CapsuleCollider playerCollider;
        private Bounds combinedBounds;
        private Bounds previousBounds;

        private Camera mainCamera;

        private Vector2 touchStartPos; // To store the start position of touch
        private bool isDragging = false; // To check if the user is dragging the touch

        public Vector3 lastPlayerDirection;
        private Vector3 initialForward;
        private Quaternion initialRotation;

        private Animator animator;

        private float timeSinceLastAnimatorCheck = 0f;
        private float totalAnimatorCheckTime = 0f;
        private float animatorCheckInterval = 0.3f;

        private bool wasInAir = false;

        private Vector3 currentDirection = Vector3.forward;




        void Start()
        {
            rb = GetComponent<Rigidbody>();
            mainCamera = Camera.main;
            initialForward = transform.forward;
            playerCollider = GetComponent<CapsuleCollider>();
            initialRotation = transform.rotation;
            currentDirection = transform.forward;
        }

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        bool ParameterExists(Animator animator, string paramName)
        {
            foreach (AnimatorControllerParameter param in animator.parameters)
            {
                if (param.name == paramName)
                    return true;
            }
            return false;
        }

        private void CheckModelComponents()
        {
            // If time elapsed is greater than the check interval
            if (timeSinceLastAnimatorCheck >= animatorCheckInterval)
            {
                if (animator == null)
                {
                    animator = GetComponentInChildren<Animator>();
                }
                timeSinceLastAnimatorCheck = 0f;

                // Animation logic
                if (animator != null && ParameterExists(animator, "IsIdle") && animator.GetBool("IsIdle"))
                {
                    animator.SetBool("IsIdle", false); // Replace with appropriate logic
                    if (ParameterExists(animator, "IsCrouching"))
                    {
                        animator.SetBool("IsCrouching", true);
                    }
                    

                }

             
            }

            

        }
        private bool IsBoundsUpdateNeeded()
        {
            return combinedBounds != previousBounds;
        }


        private void UpdateCombinedBounds()
        {
            previousBounds = combinedBounds; // Store the previous bounds

            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            if (renderers.Length > 0)
            {
                combinedBounds = renderers[0].bounds;
                foreach (Renderer renderer in renderers)
                {
                    combinedBounds.Encapsulate(renderer.bounds);
                }
            }
        }

        private void AdjustColliderToCombinedBounds()
        {
            if (combinedBounds.size != Vector3.zero)
            {
                playerCollider.height = combinedBounds.size.y;
                playerCollider.radius = Mathf.Max(combinedBounds.size.x, combinedBounds.size.z) / 2f;
                playerCollider.center = new Vector3(0, combinedBounds.extents.y, 0);
            }
        }

        private void JumpUp()
        {
            // Set rotation to initial rotation
            transform.rotation = initialRotation;

            if (animator != null)
            {
                animator.SetTrigger("JumpTrigger");
            }
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            if (jumpSound != null)
            {
                jumpSound.Play(); // Play jump sound.
            }
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        void Update()
        {
            // Find main camera if it's null
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }

            // Periodically check for Animator component
            timeSinceLastAnimatorCheck += Time.deltaTime;
            totalAnimatorCheckTime += Time.deltaTime;

            // Adjust check interval after 10 seconds
            if (totalAnimatorCheckTime > 10f && animatorCheckInterval != 2f)
            {
                animatorCheckInterval = 2f;
            }
            CheckModelComponents();

            // Find groundCheck if it's null
            if (groundCheck == null)
            {
                GameObject groundCheckGameObject = GameObject.Find("GroundCheck");
                if (groundCheckGameObject != null)
                {
                    groundCheck = groundCheckGameObject.transform;
                }

            }

            if (wasInAir && IsGrounded())
            {
                if (animator != null)
                {
                    animator.SetTrigger("LandingTrigger");
                }
                wasInAir = false;
            }

            if (!wasInAir && !IsGrounded())
            {
                wasInAir = true;
            }

            // Find jumpSound if it's null
            if (jumpSound == null)
            {
                jumpSound = GetComponentInChildren<AudioSource>();
            }

            if (transform.position.y < respawnHeight)
            {
                // Reset the player's position
                transform.position = new Vector3(0, 1, 0);
                // Reset the player's velocity
                rb.velocity = Vector3.zero;
                // Reset the player's angular velocity
                rb.angularVelocity = Vector3.zero;
                // Reset the player's rotation
                transform.rotation = initialRotation;
                currentDirection = transform.forward;
            }
            // Jumping
            if (Input.GetButtonDown("Jump"))
            {
                JumpUp();
            }

            // Mobile Jumping
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Start touch
                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPos = touch.position;
                }
                // End touch
                else if (touch.phase == TouchPhase.Ended && isDragging)
                {
                    isDragging = false;
                    JumpUp();
                }
                // Drag touch
                else if (touch.phase == TouchPhase.Moved)
                {
                    isDragging = true;
                }
            }
        }

        void FixedUpdate()
        {
            // Ensure the main camera is available
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
                if (mainCamera == null) return;
            }

            float rotateHorizontal = Input.GetAxis("Horizontal");
            float moveForward = Input.GetAxis("Vertical");

            // Apply direct left/right forces for quicker navigation
            Vector3 lateralForce = Vector3.Cross(Vector3.up, currentDirection) * rotateHorizontal * rotationSpeed;
            rb.AddForce(lateralForce, ForceMode.VelocityChange);

            // Apply continuous forward or backward force to maintain rolling
            Vector3 moveDirection = currentDirection.normalized * moveSpeed * moveForward;
            if (moveForward != 0 || rotateHorizontal != 0)
            {
                rb.AddForce(moveDirection, ForceMode.VelocityChange);
            }

            // Control roll direction using torque
            rb.AddTorque(new Vector3(0, 0, -rotateHorizontal * rotationSpeed));

            // Additional gravity
            rb.AddForce(new Vector3(0, -gravityScale * rb.mass * Physics.gravity.y, 0));

            // Apply deceleration
            if (Mathf.Abs(moveForward) < 0.01f && Mathf.Abs(rotateHorizontal) < 0.01f)
            {
                rb.velocity = rb.velocity * deceleration;
            }

            // Mobile Controls
            if (isDragging)
            {
                Vector2 touchDelta = (Vector2)Input.GetTouch(0).position - touchStartPos;

                float horizontalRotation = touchDelta.x / (Screen.width / 2f);
                float verticalMovement = touchDelta.y / (Screen.height / 2f);

                // Update current direction based on horizontal touch movement
                if (horizontalRotation != 0)
                {
                    // Rotate around the Y axis
                    currentDirection = Quaternion.Euler(0, horizontalRotation * rotationSpeed * Time.deltaTime, 0) * currentDirection;
                }

                // Apply forward movement
                rb.AddForce(currentDirection.normalized * moveSpeed * verticalMovement * 10);
            }

            if (!wasInAir && IsGrounded())
            {
                rb.constraints = RigidbodyConstraints.None; // Unfreeze rotation after landing
            }
        }


        private bool IsGrounded()
        {
            if (playerCollider == null) return false;

            float colliderRadius = playerCollider.radius;
            Vector3 position = transform.position;
            float extraHeight = 0.000001f; // Add extra height to the check

            bool isGrounded = Physics.CheckSphere(position, colliderRadius, groundLayer);
            return isGrounded;
        }

        private void RotateAroundZAxis(Vector3 movement)
        {
            // Calculate the rotational speed around the Z-axis
            float rotationAmount = movement.magnitude * rotationSpeed;

            // Apply the rotation
            rb.AddTorque(new Vector3(0, 0, -rotationAmount));
        }

    }
}