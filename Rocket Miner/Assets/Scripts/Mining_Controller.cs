using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining_Controller : MonoBehaviour
{
    //Ray _ray;
    RaycastHit2D _hit;
    Vector3 _direction;
    Vector3 endpos;

    float distance = 1.0f;

    public float controlSpeed;
    float controlSpeedTemp;

    public GameObject gameObject;

    Rigidbody2D rigidbodies;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodies = gameObject.GetComponentInChildren<Rigidbody2D>();
        controlSpeedTemp = controlSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        DirectionalMiningDetection();
        Movement();
    }

    //Casts a ray in the direciton the player moves in, to detect blocks for mining.
    void DirectionalMiningDetection()
    {
        if (Input.GetKey(KeyCode.S))
        {
            _hit = Physics2D.Raycast(transform.position, Vector2.down, distance);

            _direction.x = Input.GetAxis("Horizontal");
            _direction.y = Input.GetAxis("Vertical");

            endpos = transform.position + _direction;
            Debug.DrawLine(transform.position, endpos, Color.red);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _hit = Physics2D.Raycast(transform.position, Vector2.right, distance);

            _direction.x = Input.GetAxis("Horizontal");
            _direction.y = Input.GetAxis("Vertical");

            endpos = transform.position + _direction;
            Debug.DrawLine(transform.position, endpos, Color.red);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _hit = Physics2D.Raycast(transform.position, Vector2.left, distance);

            _direction.x = Input.GetAxis("Horizontal");
            _direction.y = Input.GetAxis("Vertical");

            endpos = transform.position + _direction;
            Debug.DrawLine(transform.position, endpos, Color.red);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            _hit = Physics2D.Raycast(transform.position, Vector2.up, distance);

            _direction.x = Input.GetAxis("Horizontal");
            _direction.y = Input.GetAxis("Vertical");

            endpos = transform.position + _direction;
            Debug.DrawLine(transform.position, endpos, Color.red);
        }
    }

    void Movement()
    {
        //Grabs the value of the horizontal and vertical axis
        float horizontalMove = Input.GetAxis("Horizontal");
        Debug.Log(horizontalMove);
        float verticalMove = Input.GetAxis("Vertical");
        Debug.Log(verticalMove);

        //controls direciton of player movement on X axis
        float xOffset = horizontalMove * Time.deltaTime * controlSpeed;
        float newXPos = transform.position.x + xOffset;

        //controls direciton of player movement on Y axis
        float yOffset = verticalMove * Time.deltaTime * controlSpeed;
        float newYPos = transform.position.y + yOffset;

        if(Input.GetKey(KeyCode.W))
        {
            controlSpeed = 3.0f;
            rigidbodies.gravityScale = 0.0f;
            yOffset = verticalMove * Time.deltaTime * controlSpeed * 10;
            newYPos = transform.position.y + yOffset;
            
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            for(float _gravityScale = 0; _gravityScale <= 1.01f; _gravityScale += 0.01f)
            {
                rigidbodies.gravityScale = _gravityScale;
            }
            controlSpeed = controlSpeedTemp;
        }










        transform.position = new Vector2(newXPos, newYPos);
        
    }
}
