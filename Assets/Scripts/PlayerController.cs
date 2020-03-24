using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
	public float move_speed = 10f;
	public float jump_speed = 8f;
	private float movement = 0f;
	private Rigidbody2D rigidBody; 

	/* Ground check jumping */
	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	private bool isTouchingGround;

    private bool isAlive = true;
    public Text deadMsg;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isAlive);

        if(isAlive)
        {

            movement = Input.GetAxis("Horizontal");   // gets how much u press on left or right shiii

            isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

            if(movement > 0f)
            {
            	rigidBody.velocity = new Vector2(movement*move_speed, rigidBody.velocity.y);  // (x , y ) for moving stuff
            }
            else if(movement < 0f)
            {
                rigidBody.velocity = new Vector2(movement*move_speed, rigidBody.velocity.y);  // (x , y ) for moving stuff
            }

            if(Input.GetButtonDown("Jump") && isTouchingGround)
            {
            	rigidBody.velocity = new Vector2(rigidBody.velocity.x, jump_speed);
            }
        }

        else
        {
            StartCoroutine("dead");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "spike" && isAlive == true)
        {   
            isAlive = false;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jump_speed);
            // collider.isTrigger == true;

        }
    }

    IEnumerator dead()
    {
        deadMsg.text = "Better Luck Next Time !!";

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene("Menu");

    }
    
}
