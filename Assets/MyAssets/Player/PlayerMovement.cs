using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Vars
    public GameObject camera;
    public float speed = 10;
    public float cameraSpeed = 100;

    //Lambda Methods
    private float horizontalInput => MovementValue(Input.GetAxis("Horizontal"));
    private float verticalInput => MovementValue(Input.GetAxis("Vertical"));
    private float mouseX => CameraMovement(Input.GetAxis("Mouse X"));
    private float mouseY => CameraMovement(Input.GetAxis("Mouse Y"));

    //Easing Methods
    float MovementValue(float input) => input * Time.deltaTime * speed;
    float CameraMovement(float input) => Time.deltaTime * cameraSpeed * input;
    private float cameraX, cameraY;

    [SerializeField]
    private float bobbingValue;
    private Vector3 cameraInitialPosition = new Vector3(0, 2, 0);
    private Coroutine returnCameraToOriginCoroutine;
    private readonly float width = Screen.width;
    private readonly float height = Screen.height;
    private float verticalMultiplier;
    private Rigidbody playerRb;
    
    public bool canJump = true;

    GameManagerSO gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = Resources.Load<GameManagerSO>("General/GameManager");
        Physics.gravity *= 3;
        Application.targetFrameRate = 60;
        playerRb = GetComponent<Rigidbody>();
        cameraX = camera.transform.rotation.x;
        cameraY = camera.transform.rotation.y;
        verticalMultiplier = ((width - height) / width)+1;

    }

    private void Update()
    {
        if (!gameManager.Paused)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                canJump = false;
                Vector3 direction = Vector3.up;
                if (Input.GetKey(KeyCode.LeftShift))
                    direction = new Vector3(transform.forward.x,
                                            1,
                                            transform.forward.z);


                playerRb.AddForce(direction * 20, ForceMode.Impulse);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameManager.Paused)
        {
            if (horizontalInput != 0 || verticalInput != 0)
            {
                if (returnCameraToOriginCoroutine != null)
                {
                    StopCoroutine(returnCameraToOriginCoroutine);
                    returnCameraToOriginCoroutine = null;
                }
                transform.Translate(horizontalInput, 0, verticalInput);
                Bobbing(Time.deltaTime);
            }
            else
            {
                if (bobbingValue > 0 && returnCameraToOriginCoroutine == null)
                {
                    returnCameraToOriginCoroutine = StartCoroutine(returnCameraToOrigin());
                }
            }

            if(gameManager.CanLook)
            {
                cameraX = Mathf.Clamp(cameraX + -mouseY, -45, 45);
                cameraY += mouseX;
                camera.transform.localRotation = Quaternion.Euler(cameraX * verticalMultiplier, 0, 0);
                transform.rotation = Quaternion.Euler(0, cameraY, 0);
            }
            
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Contains("ground")) canJump = true;
    }

    private void Bobbing(float value)
    {
        if (bobbingValue > Mathf.PI * 2)
        {
            bobbingValue = 0;
            return;
        }
        bobbingValue += value * 6;
        camera.transform.localPosition += new Vector3(
                (Mathf.Sin(bobbingValue)/80),
                (Mathf.Sin(bobbingValue * 2)/55),
                0
            );
    }
    private IEnumerator returnCameraToOrigin()
    {
        float currentTime = 0;
        float time = bobbingValue > 3 ? bobbingValue - 3 : bobbingValue;
        while(currentTime < time)
        {
            camera.transform.localPosition = Vector3.Lerp(
                camera.transform.localPosition,
                cameraInitialPosition,
                currentTime / time
            );

            currentTime += Time.deltaTime;
            yield return null;
        }
        bobbingValue = 0;
        StopCoroutine(returnCameraToOriginCoroutine);
        returnCameraToOriginCoroutine = null;
    }

}
