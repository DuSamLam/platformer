using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //importing SceneManagement library

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;
    public bool hasKey = false;

    public GameObject key;

    public static PlayerController instance; //creating an object of the class to be findable

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null) //check if instance is in the scene
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        if (Input.GetKey("w"))
        {
            //player moves up
            newPosition.y += speed;
        }

        if (Input.GetKey("s"))
        {
            //player moves down
            newPosition.y -= speed;
        }

        //player moves left
        if (Input.GetKey("a"))
        {
            newPosition.x -= speed;
        }

        //player moves right
        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
        }

        transform.position = newPosition;
    }
}