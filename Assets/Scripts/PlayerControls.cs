using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private const float GRAVITY = 9.80665f;
    public float speed;
    public float jumpHeight;
    public float sensitivityX = 4f;
    public float sensitivityY = 4f;
    public float minY = -40f;
    public float maxY = 40f;
    public float sprintSpeedMultiplier = 1.5f;
    public float crouchSpeedMultiplier = 0.5f;

    private float rotationX = 0f;
    private Transform cam;
    private float yVelocity;
    private bool isGrounded;
    private float lastJumped;
    private bool isCrouching;
    private bool isSprinting;
    private float currentSpeedMultiplier;
    private Vector3 input;

    void Awake()
    {
        cam = Camera.main.transform;
        lastJumped = -50;
    }   

    void Update()
    {
        isCrouching =false;
        isSprinting = false;
        if(Input.GetKey(KeyCode.LeftShift)){
            isCrouching=true;
            isSprinting=false;
        }
        if(Input.GetKey(KeyCode.LeftControl)){
            isSprinting=true;
            isCrouching=false;
        }
        currentSpeedMultiplier=1;
        if(isCrouching){
            currentSpeedMultiplier = crouchSpeedMultiplier;
        }
        else if(isSprinting){
            currentSpeedMultiplier = sprintSpeedMultiplier;
        }

        if (Physics.Raycast(transform.position - Vector3.up * (transform.localScale.y / 2f), Vector3.down, 0.2f))
        {
            if(Time.time-lastJumped>0.5f){
                isGrounded = true;
            }
            else{
                isGrounded=false;
            }
        }
        else
        {
            isGrounded = false;
        }


        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;
        transform.Rotate(Vector3.up * mouseX);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY);
        cam.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

         
        if(isGrounded){ 
            yVelocity=0;
            if(Input.GetKeyDown(KeyCode.Space)){
                yVelocity = Mathf.Sqrt(2 * GRAVITY * jumpHeight);
                lastJumped=Time.time;
            }   
        }
        else{
            yVelocity -= Time.deltaTime * GRAVITY;
        }
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed*currentSpeedMultiplier;
    }

    void FixedUpdate()
    {        
        input.y = yVelocity;
        transform.Translate(input*Time.fixedDeltaTime);  
    }
}
