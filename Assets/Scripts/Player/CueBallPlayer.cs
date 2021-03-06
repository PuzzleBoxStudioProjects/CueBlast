using UnityEngine;
using System.Collections;

public class CueBallPlayer : MonoBehaviour
{
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
	public float linearDrag = 0.8f;
	
	//temporary until a better method is used
    public float forceMeterWidth = 128.0f;
	
	private float meterModifier = 0.0f;
    private float mouseDir = 0.0f;

	public int lives = 3;
	public int boostForce = 10;
	
	public bool isGrounded = false;
	
	public GUITexture forceMeter;
	
	public Texture2D[] meterImages;

    private Vector3 relativeCamForward;
	
	private Camera cam;
	
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
		
		cam = Camera.main;
    }

	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.lockCursor = false;
        }
        relativeCamForward = -(cam.transform.position - transform.position);
		relativeCamForward.y = 0;
	}

    void FixedUpdate()
    {
		ApplyQuickStop();
		
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
			//limit velocity
			float currentSpeed = rigidbody.velocity.magnitude;
			
			if (currentSpeed > maxSpeed)
			{
				rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
			}
			
            rigidbody.AddForce(meterModifier * boostForce * relativeCamForward, ForceMode.VelocityChange);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Screen.lockCursor = true;
            //reset the value to zero when first pressing the mouse button.
            mouseDir = 0;
        }
    }

    void Motor()
    {
        //get input.
        float vInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float hInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		
		Vector3 relativeCamRight = (new Vector3(cam.transform.right.x, 0, 0));
		
		relativeCamRight = cam.transform.TransformDirection(relativeCamRight);
		
		if (isGrounded)
        {
            //apply drag when grounded to slow character
            rigidbody.drag = linearDrag;
			
//			if (rigidbody.velocity.magnitude < speed)
//			{
		        //apply move force.
		        rigidbody.AddForceAtPosition(relativeCamForward.normalized * vInput, transform.position, ForceMode.Impulse);
				rigidbody.AddForceAtPosition(relativeCamRight.normalized * hInput, transform.position, ForceMode.Impulse);
//			}
            //apply jump force
            if (Input.GetButtonDown("Jump"))
            {
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        else
        {
            //when not grounded don't apply any drag so the character doesn't slow while airborne.
            rigidbody.drag = 0;
        }
    }
	
	void ApplyQuickStop()
	{
		//perform the quick stop
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
			rigidbody.velocity = Vector3.zero;
			rigidbody.freezeRotation = true;
        }
	    //disable the quick stop
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            rigidbody.freezeRotation = false;
        }
	}
	
	public void SetSpeedBoost(float speed, Vector3 direction)
	{
		rigidbody.velocity = Vector3.zero;
		rigidbody.AddForce(direction * speed);
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
	
	void OnCollisionEnter(Collision col)
	{
		if (col.transform.tag == "OtherBalls")
		{
			GameMaster.instance.curHitCount++;
		}
	}
}