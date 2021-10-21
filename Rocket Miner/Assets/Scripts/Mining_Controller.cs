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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
}
