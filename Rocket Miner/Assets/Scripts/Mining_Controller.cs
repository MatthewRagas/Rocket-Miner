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

<<<<<<< Updated upstream
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
=======
            endpos = pos + _direction;
            Debug.DrawLine(pos, endpos, Color.red);
        }       

        _hit = Physics2D.Raycast(pos, endpos);
        if (_hit.collider != null && _hit.collider.gameObject.name != "Player")
        {
            
            GameObject Block = GameObject.Find(_hit.collider.gameObject.name);
            Block_Mining_Behavior MiningBehavior = (Block_Mining_Behavior) Block.GetComponent(typeof(Block_Mining_Behavior));

            if (diggingTimer != MiningBehavior.blockMineTimer && isMining == true)
            {
                diggingTimer = MiningBehavior.blockMineTimer;
            }
            Debug.Log(_hit.collider.gameObject.name);
            Debug.Log(diggingTimer);
            isMining = true;
            diggingTimer = diggingTimer - Time.deltaTime;
            if(diggingTimer <= 0)
            {
                Debug.Log("destroyed");
            }

        }
        else
        {
            isMining = false;
            Debug.Log("stop");

>>>>>>> Stashed changes
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
            rigidbodies.velocity = new Vector2(0.0f,0.0f);
            controlSpeed = 3.0f;
            rigidbodies.gravityScale = 0.0f;
            rigidbodies.mass = 0.0f;
            yOffset = verticalMove * Time.deltaTime * controlSpeed * 10;
            newYPos = transform.position.y + yOffset;
            
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            rigidbodies.gravityScale = 1.0f;
            rigidbodies.mass = 0.64f;
            //for(float _gravityScale = 0; _gravityScale <= 1.01f; _gravityScale += Time.deltaTime)
            //{
            //    rigidbodies.gravityScale = _gravityScale;
            //}
            controlSpeed = controlSpeedTemp;
        }










        transform.position = new Vector2(newXPos, newYPos);
        
        if (rigidbodies.velocity.y < -50)
        {
            rigidbodies.velocity = new Vector2(rigidbodies.velocity.x, -50.0f);
        }

    }
}
