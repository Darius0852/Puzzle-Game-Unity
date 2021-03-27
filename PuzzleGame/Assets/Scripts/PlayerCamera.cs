using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCamera : MonoBehaviour
{

    public float RotationSpeed = 50;
    public Transform centrePoint, Player;
    float mouseX, mouseY;

    public Transform Obstruction;
    float zoomSpeed = 2f;


    public GameObject objectToFollow;
    public float xrotation = 1.0F;
    public float speed = 2.0F;
    public float ydist = 4.0F;
    private Vector3 rotateValue;
    private Vector3 moveValue;
    private float offset;
    public bool isInverted = false;

    void Start()
    {
        Obstruction = centrePoint;
        isInverted = objectToFollow.GetComponent<GravityBlock>().getIsInverted();
        
    }

    void LateUpdate()
    {

        CamControl();
        ViewObstructed();
        isInverted = objectToFollow.GetComponent<GravityBlock>().getIsInverted();
        float interpolation = speed * Time.deltaTime;


        Debug.Log(isInverted);

        if (isInverted == true)
        {
            rotateValue = new Vector3(-30, -90, 0);
            transform.eulerAngles = rotateValue;
            //ydist = -4.0F;
            //offset = (transform.position.y - 0.02f);
            //moveValue = new Vector3(transform.position.x, offset, transform.position.z);
            //transform.position = moveValue;
        }
        else if (isInverted == false)
        {
            CamControl();
        }

    }

    void CamControl()
    {

        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(centrePoint);

        centrePoint.rotation = Quaternion.Euler(0, mouseX, mouseY);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);

        if (isInverted == true)
        {
            mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35, 60);

            transform.LookAt(centrePoint);

            centrePoint.rotation = Quaternion.Euler(0, -mouseX, -mouseY);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
       

    }

    void ViewObstructed()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, centrePoint.position - transform.position, out hit, 4.5f))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                Obstruction = hit.transform;
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                if(Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, centrePoint.position) >= 1.5f)
                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }
            }
            else {

                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if(Vector3.Distance(transform.position, centrePoint.position) < 4.5f)
                {
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }

            }


        }


    }

}