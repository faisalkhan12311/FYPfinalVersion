using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float walkingSpeed = 5.37f;
    public float runningSpeed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject walkingSound;

    public bool isGrounded;

    public AudioSource footsteps1;
    public AudioSource jump;

    public Inventory inventory;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runningSpeed;
        }
        else
        {
            speed = walkingSpeed;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
       
        if(x != 0 || z != 0)
        {
            walkingSound.SetActive(true);
        }
        
        else if(x == 0 || z == 0)
        {
            walkingSound.SetActive(false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            print("colliding");
            inventory.itemPickedup = other.gameObject;
            inventory.AddItem(inventory.itemPickedup);
            //Destroy(other.gameObject);
        }
    }
}
