using UnityEngine;
using System.Collections;

public class CueBallPlayer : MonoBehaviour
{
	public const float LINEAR_DRAG = 0.8f;
    
	public static CueBallPlayer instance;
	
	//forces
	public float gravity = 21.0f;
	public float jumpForce = 10.0f;
	
	//speed
	public float speed = 5.0f;
	public float maxSpeed = 10.0f;
	
	//modifiers
    public float mouseSensitivity = 20.0f;
    public float dragDistance = 300.0f;
	
	//temporary until a better method is used
    public float forceMeterWidth = 128.0f;
	
	public int boostMultiplier = 10;
	
	private float dragDist = 0.0f;
	private float meterModifier = 0.0f;
    public float mouseDir = 0.0f;

	public int lives = 3;

	private bool isGrounded = false;
	
	public GUITexture forceMeter;
	
	public Texture2D[] meterImages;

    private Vector3 relativeCam;

    void Awake()
    {
        Screen.lockCursor = true;

        instance = this;

        rigidbody.useGravity = false;
    }

    void Start()
    {
        forceMeter.transform.position = Vector3.zero;
        forceMeter.transform.localScale = Vector3.zero;

        forceMeter.enabled = false;
    }

	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.lockCursor = false;
        }
        //Screen.lockCursor = true;

        relativeCam = -(Camera.main.transform.position - transform.position);
        //keep the Y zeroed out so that axis doesn't change.  we want to stay on the ground.
        relativeCam.y = 0;
	}

    void FixedUpdate()
    {
        //movement controls
        Motor();

        //boost controls
        Boost();

        //gravity
        ApplyGravity();
    }

    void Boost()
    {
        //Note: THIS LINE WILL BE REPLACED WITH A DIFFERENT METHOD.
        forceMeter.pixelInset = new Rect((Screen.width / 2) - (forceMeterWidth / 2), 0, forceMeterWidth, 160);

        //toggle the force meter to only be enabled when the mouse button is held.
        forceMeter.enabled = Input.GetMouseButton(0);

        if (Input.GetMouseButton(0))
        {
            //add the value of the mouse Y input axis to the variable.
            mouseDir -= Input.GetAxisRaw("Boost") * mouseSensitivity;

            //create a desired drag distance
            mouseDir = Mathf.Clamp(mouseDir, 0.0f, dragDistance);
			
            //then divide the mouseDir by the dragDistance to give the resulting value.
            //by doing this division calcuation, the value will be between zero and one.
            //if mouseDir is half of what dragDistance is, the result will be 0.5.
            meterModifier = mouseDir / dragDistance;

            //display the boost meter
            forceMeter.texture = meterImages[(int)Mathf.Round(meterModifier * (meterImages.Length - 1))];
        }
		
        //when the mouse button is released, apply boost.
        if (Input.GetMouseButtonUp(0))
        {
            rigidbody.AddForce(relativeCam * (mouseDir / dragDistance), ForceMode.VelocityChange);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Screen.lockCursor = true;
            //reset the value to zero when first pressing the mouse button.
            //do this so here so when mouse button is released there is still a value to apply to the boost.
            mouseDir = 0;
        }
    }

    void Motor()
    {
        //get input.
        float forwardInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (isGrounded)
        {
            //apply drag when grounded to slow character
            rigidbody.drag = LINEAR_DRAG;

            //apply move force.
            rigidbody.AddForceAtPosition(relativeCam * forwardInput, transform.position, ForceMode.Impulse);

            //apply jump force
            if (Input.GetButtonDown("Jump"))
            {
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            //perform the quick stop
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                rigidbody.isKinematic = true;
            }
        }
        else
        {
            //when not grounded don't apply any drag so the character doesn't slow while airborn.
            rigidbody.drag = 0;
        }

        //disable the quick stop
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            rigidbody.isKinematic = false;
        }
    }

    void ApplyGravity()
    {
        rigidbody.AddForce(Vector3.down * gravity * Time.deltaTime, ForceMode.VelocityChange);
    }
	
	void OnCollisionExit()
	{
        isGrounded = false;
	}
	
	void OnCollisionStay()
	{
        isGrounded = true;
	}
}
