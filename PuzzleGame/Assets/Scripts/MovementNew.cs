using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNew : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", false);
        anim.SetBool("isWalking", false);
        anim.SetBool("hasAxe", false);
        
    }


    // Update is called once per frame
    void Update()
    {
       
        bool horDown = Input.GetButtonDown("Horizontal");
        bool horHeld = Input.GetButton("Horizontal");
        bool horUp = Input.GetButtonUp("Horizontal");
        bool verDown = Input.GetButtonDown("Vertical");
        bool verHeld = Input.GetButton("Vertical");
        bool verUp = Input.GetButtonUp("Vertical");
        bool jumDown = Input.GetButtonDown("Jump");
        bool jumHeld = Input.GetButton("Jump");
        bool jumUp = Input.GetButtonUp("Jump");
        bool sprDown = Input.GetButtonDown("Sprint");
        bool sprHeld = Input.GetButton("Sprint");
        bool sprUp = Input.GetButtonUp("Sprint");
        

        float movementTime = Time.deltaTime * 2;

        if (sprDown)
        {
            movementTime = movementTime * 3;
            anim.SetBool("isRunning", true);
        }
        if (sprHeld)
        {
            movementTime = movementTime * 3;
            anim.SetBool("isRunning", true);
        }
        if (sprUp)
        {
            anim.SetBool("isRunning", false);
        }

       


        if (horDown && Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            //transform.Rotate(0, 180, 0, Space.World);
            transform.Translate(Vector3.forward * movementTime);
            anim.SetBool("isWalking", true);
            
        }
        if (horHeld && Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.Translate(Vector3.forward * movementTime);
            anim.SetBool("isWalking", true);
            
        }
        if (horDown && Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            // transform.Rotate(0, 0, 0, Space.World);
            transform.Translate(Vector3.forward * movementTime);
            anim.SetBool("isWalking", true);
            
        }
        if (horHeld && Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.Translate(Vector3.forward * movementTime);
            anim.SetBool("isWalking", true);
            
        }

        if (horUp)
        {
            anim.SetBool("isWalking", false);
        }

        if (verDown && Input.GetAxisRaw("Vertical") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //transform.Rotate(0, 90, 0, Space.World);
            transform.Translate(Vector3.forward * movementTime);
            anim.SetBool("isWalking", true);
            
        }
        if (verHeld && Input.GetAxisRaw("Vertical") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.forward * movementTime);
            anim.SetBool("isWalking", true);
            
        }
        if (verDown && Input.GetAxisRaw("Vertical") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //   transform.Rotate(0, -90, 0, Space.World);
            transform.Translate(Vector3.forward * movementTime);
            anim.SetBool("isWalking", true);
            
        }
        if (verHeld && Input.GetAxisRaw("Vertical") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.forward * movementTime);
            anim.SetBool("isWalking", true);
            
        }
        if (verUp)
        {
            anim.SetBool("isWalking", false);
            
        }
       



    }
}
