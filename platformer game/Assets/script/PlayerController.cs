using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //importing SceneManagement library

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;
    SpriteRenderer sprite;
    public float jumpForce; //the force that will be added to the verical component of player's velocity
    Rigidbody2D rb; //create reference for rigidbody bc jump requires physics

    //Ground check Variables
    public LayerMask groundLayer;
    public Transform groundCheck;
    public bool isGrounded;
    

    public static PlayerController instance; //creating an object of the class to be findable

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.2DOverlapCircle(groundCheck.transform, .5f, groundLayer);
        Vector3 newPosition = transform.position;
        Vector3 newScale = transform.localScale;
        float currentScale = Mathf.Abs(transform.localScale.x);

        //player moves left
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x -= speed;
            newScale.x = -currentScale;
        }

        //player moves right
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += speed;
            newScale.x = currentScale;
        }

        if (Input.GetKey("w") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        transform.position = newPosition;
        transform.localScale = newScale;
    }
}