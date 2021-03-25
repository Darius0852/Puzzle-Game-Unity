using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBlock : MonoBehaviour
{

    public GameObject player;
    public Vector3 jump;
    public float jumpHeight = 2.0f;
    public float jumpForce = 2.0f;
    private bool isJumping = false;
    private bool isGrounded = true;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpHeight, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        else
        {
            isJumping = false;
        }

    }

    public void Jump()
    {
         isJumping = true;
         Debug.Log("jump");
    }
}
