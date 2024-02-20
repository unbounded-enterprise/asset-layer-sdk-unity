using UnityEngine;

namespace AssetLayer.Unity { 

    public class CameraController : MonoBehaviour
    {
        public GameObject player;
        public float rotationSpeed = 1;
        public float zoomSpeed = 2f;
        public float minZoom = 3f;
        public float maxZoom = 3f;
        private float currentZoom;
        public float groundLevel = 0.0f; // Set this to your ground level
        public float heightOffset = 2f; // Height above the player

        float mouseX, mouseY;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            currentZoom = minZoom + ((maxZoom + minZoom) / 15.0f);

            // Set the camera to look towards the player from behind and rotate it 180 degrees
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y + 180, 0);

            InventoryUIManagerUnityUI.OnInventoryToggled += InventoryToggled;
        }



        public void InventoryToggled(bool showing)
        {
            
            if (showing)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            } else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
        }

        void Update()
        {
            // If the player object is not assigned, try to find it
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    mouseX += touch.deltaPosition.x * rotationSpeed;
                    mouseY -= touch.deltaPosition.y * rotationSpeed;
                    mouseY = Mathf.Clamp(mouseY, -35, 60);
                }
            }

            // Mobile pinch to zoom
            if (Input.touchCount == 2)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
                Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

                float prevMagnitude = (touch1PrevPos - touch2PrevPos).magnitude;
                float currentMagnitude = (touch1.position - touch2.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                currentZoom -= difference * zoomSpeed * Time.deltaTime;
                currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
            }

            if (player != null)
            {
                Vector3 directionToLook = player.transform.position - transform.position;
                directionToLook.x = 0; // Ignore the x-component of the direction
                transform.rotation = Quaternion.LookRotation(directionToLook);
            }

        }


        void LateUpdate()
        {
            if (player != null)
            {
                // Zooming with Mouse Wheel
                currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
                currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

                // Set the camera's position to be a fixed distance behind the player on the x-axis and at a certain height
                Vector3 cameraPosition = player.transform.position + Vector3.left * currentZoom + Vector3.up * heightOffset;

                // Ensure the camera is above ground level
                if (cameraPosition.y < groundLevel + heightOffset)
                {
                    cameraPosition.y = groundLevel + heightOffset;
                }

                transform.position = cameraPosition;

                // Have the camera look at the player
                transform.LookAt(player.transform.position);
            }
        }




    }
}