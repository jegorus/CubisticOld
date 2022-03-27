using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform directionPos;
    public Text jumpCountText;
    public GameManagerScript levelManager;

    public Vector3 distance = new Vector3(0, 0, 0);
    public float vectorLength = 10f;
    public float jumpForce = 10f;
    public int jumpCount = 7;
    public int jumpIncYellow = 1;
    public int jumpIncGreen = 3;
    bool isGrounded = false;
    bool AirJump = true;
    float jumpTime = 0f;
    public float jumpDelay = 0.1f;
    float x;
    float y;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        x = Input.GetAxis("Mouse X") * PlayerPrefs.GetFloat("MouseSensitivity", 0.4f);
        y = Input.GetAxis("Mouse Y") * PlayerPrefs.GetFloat("MouseSensitivity", 0.4f);


        if (Input.GetKeyDown(KeyCode.R))
        {
            levelManager.Die();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (AirJump)
            {
                AirJump = false;
                jumpCountText.color = Color.gray;
            }
            else
            {
                AirJump = true;
                jumpCountText.color = Color.white;
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            levelManager.LoadMenu();
        }


        distance += new Vector3(x, y, 0);
        if (distance.magnitude > vectorLength)
        {
            distance /= distance.magnitude;
            distance *= vectorLength;
        }
        directionPos.position = distance + transform.position;

        jumpCountText.text = "Jumps: " + jumpCount.ToString();


        //Move
        jumpTime -= Time.deltaTime;
        if (jumpTime < 0) jumpTime = 0;
        if (jumpTime <= 0)
        {
            if (jumpCount > 0 | (jumpCount == 0 & isGrounded))
            {
                if ((Input.GetMouseButton(0) & AirJump == false & isGrounded) | (Input.GetMouseButtonDown(0) & AirJump == true))
                {
                    FindObjectOfType<AudioManagerScript>().Play("Jump");
                    rb.velocity = -distance * jumpForce;
                    float torque = 0.05f * Vector3.Angle(distance, new Vector3(1f, 0, 0));
                    //Torque
                    if (distance.x > 0)
                    {
                        rb.AddTorque(torque);
                    }
                    else
                    {
                        rb.AddTorque(-torque);
                    }

                    if (!isGrounded)
                    {
                        jumpCount--;
                    }
                    isGrounded = false;
                    jumpTime = jumpDelay;
                }
            }
        }


        if (transform.position.y < -10)
        {
            levelManager.Die();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            levelManager.Die();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
             isGrounded = true;
        }
    }

    public void IncreaseJumpsYellow()
    {
        jumpCount += jumpIncYellow;
    }
    public void IncreaseJumpsGreen()
    {
        jumpCount += jumpIncGreen;
    }
}
