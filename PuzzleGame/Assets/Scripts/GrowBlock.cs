using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowBlock : MonoBehaviour
{

    public GameObject player;
    private bool isGrowing = false;
    private Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(+0.002f, +0.002f, +0.002f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrowing == true && player.transform.localScale.y <= 1.0f)
        {
            player.transform.localScale += scaleChange;
        }
        else
        {
            isGrowing = false;
        }
    }

    public void Grow()
    {
        isGrowing = true;
        Debug.Log("yes");
    }
}
