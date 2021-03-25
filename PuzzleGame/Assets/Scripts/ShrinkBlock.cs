using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkBlock : MonoBehaviour
{

    public GameObject player;
    private bool isShrinking = false;
    private Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(-0.002f, -0.002f, -0.002f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isShrinking == true && player.transform.localScale.y >= 0.5f)
        {
            player.transform.localScale += scaleChange;
        }
        else
        {
            isShrinking = false;
        }
    }

    public void Shrink()
    {
        isShrinking = true;
        Debug.Log("yes");
    }
}
