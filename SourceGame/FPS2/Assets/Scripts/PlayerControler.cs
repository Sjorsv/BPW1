using UnityEngine;

[RequireComponent(typeof(PlayerMotor))
    ]

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private float NormalSpeed = 5f;
    private float IceSpeed = 10f;
    [SerializeField]
    private float lookSensitivity = 3f;

    public Rigidbody rb;
    public bool isGrounded;
    public bool CanJump;
    public bool onIce;
    public float JumpHeight = 4.0f;
    public float Gravity = 20.0f;
    public float forwardAndBackSpeed = 8.0f;
    public float StrafeSpeed = 5.0f;

    public bool msgPanel = false;
    public GameObject MessagePanel;
    public GameObject shroom;
    public GameObject InfoPanel;
    
    private PlayerMotor motor;

    private ScoreManager scoreManager;

    public AudioSource audioS;


    private void Awake()
    {
        scoreManager = ScoreManager.Instance;
    }

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //Calculate movment velocity as a 3d vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _yMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _yMov;

        // Final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        // Apply movement
        motor.Move(_velocity);


        //Calculate rotation as a 3D Vector (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D Vector (turning around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

        //Apply camera rotation
        motor.RotateCamera(_cameraRotation);

        //Pick up shroom
        if (shroom != null && Input.GetKeyDown(KeyCode.F))
        {
            CloseMessagePanel();
            PickUpShroom();
        }

        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.Mouse0))) {
            CloseInfoPanel();
        }

    }

    private void FixedUpdate()
    {
        // calculate how fast it should be moving
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal") * StrafeSpeed, 0, Input.GetAxis("Vertical") * forwardAndBackSpeed);
        targetVelocity = transform.TransformDirection(targetVelocity);

        // apply a force that attempts to reach our target velocity
        Vector3 velocity = rb.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.y = 0;
        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        // jump
        if (CanJump && isGrounded && Input.GetButton("Jump"))
        {
            rb.velocity = new Vector3(velocity.x, Mathf.Sqrt(2 * JumpHeight * Gravity), velocity.z);
            isGrounded = false;
        }

        // apply Gravity
        rb.AddForce(new Vector3(0, -Gravity * rb.mass, 0));

        // footsteps
        PlayFootSteps();
    }

    private void OnCollisionEnter(Collision other) // store collission object in other
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
            onIce = false;
        }

        if(other.gameObject.tag == "Pushable")
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (other.gameObject.tag == "Pushable")
        {
            isGrounded = true;
        }

        if (other.gameObject.tag == "ice")
        {
            onIce = true;
            speed = IceSpeed;
            isGrounded = true;

        }
     
        else {
            speed = NormalSpeed;
        }

        // 2 floats wanneer grond = speed en ice = speed x2

        if (other.gameObject.tag == "shroom")
        {
            OpenMessagePanel(); // press F to pickup
            shroom = other.gameObject;
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "shroom")
        {
        CloseMessagePanel(); // press F to pickup weg
            shroom = null; // shroom heeft geen gameobject   
         
        }
    }

    public void OpenMessagePanel()
    {
        
        MessagePanel.SetActive(true);

      }

    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);
       
    }

    public void CloseInfoPanel()
    {
        InfoPanel.SetActive(false);

    }

    public void PickUpShroom()
    {
        if (shroom != null)
        {
            shroom.SetActive(false);
            scoreManager.MushroomCount++;
        }
    }

    public void PlayFootSteps()
    {
        if (forwardAndBackSpeed > 0.1f && forwardAndBackSpeed < speed + 0.1f)
        {
            audioS.enabled = true;
            audioS.loop = true; 
        }

        if (forwardAndBackSpeed < 0.1f)
        {
            audioS.enabled = false;
            audioS.loop = false;
        }


    }


}


