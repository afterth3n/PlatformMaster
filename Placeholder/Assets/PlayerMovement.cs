using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float msense = 250f;
    public float speed = 50f;
    public float fallSpeed = 200f;
    private bool falling = false;
    private bool jumping = false;
    private bool wallJump = false;
    private bool wallJumpDelay = false;
    private Rigidbody playerBody;
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        playerBody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(0, (Input.GetAxis("Mouse X")) * Time.deltaTime * msense, 0);

        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(0, (Input.GetAxis("Mouse X")) * Time.deltaTime * msense, 0);

        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            mainCamera.transform.Rotate(-(Input.GetAxis("Mouse Y")) * Time.deltaTime * msense, 0, 0);

        }
        if (Input.GetAxis("Mouse Y") < 0)
        {
            mainCamera.transform.Rotate(-(Input.GetAxis("Mouse Y")) * Time.deltaTime * msense, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.Space) && !falling && jumping && wallJump && !wallJumpDelay)
        {
            playerBody.AddForce(transform.up * 2500);
            Debug.Log("Walljump");
            StartCoroutine(WallJumpCheck());
        }
        if (Input.GetKeyDown(KeyCode.Space) && !falling && !jumping)
        {
            playerBody.AddForce(transform.up * 2500);
            jumping = true;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
            {
                speed = 200f;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 100f;
        }



    }
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            playerBody.AddForce(transform.forward * speed);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerBody.AddForce(transform.right * speed);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerBody.AddForce(transform.right * -speed);
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            playerBody.AddForce(transform.forward * -speed);
        }
         if (playerBody.velocity.y < -0.1)
        {
            jumping = false;
            falling = true;
            playerBody.AddForce(transform.up * -fallSpeed);
            fallSpeed += 6;
        }
        else
        {
            falling = false;
            fallSpeed = 200f;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            wallJump = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            wallJump = false;
        }
    }
    
    IEnumerator WallJumpCheck()
    {
        wallJumpDelay = true;
        yield return new WaitForSeconds(.35f);
        wallJumpDelay = false;
    }
}
