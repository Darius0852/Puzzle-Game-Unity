using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    private float speedUp;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        speedUp = 2.0F;
    }


    // Update is called once per frame
    void Update()
    {

        playerMovement();

    }

    void playerMovement() {

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(ver, 0f, -hor) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

    }

    public void SpeedUp()
    {
        speedUp = 3.0F;
    }

    public void SlowDown()
    {
        speedUp = 1.0F;
    }
}
