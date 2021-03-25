using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBlock : MonoBehaviour
{

    public Transform centrePoint;
    public float passThroughRange = 0.5f;
    private bool canPassPink = false;
    GameObject[] gos;
    // Start is called before the first frame update
    void Start()
    {
        gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
    }

    // Update is called once per frame
    void Update()
    {
        if (canPassPink == true)
        {
            foreach (GameObject go in gos)
            {
                if (go.CompareTag("Yellow"))
                {
                    go.GetComponent<MeshRenderer>().enabled = true;
                    go.GetComponent<MeshCollider>().enabled = true;
                }
                else if (go.CompareTag("Pink"))
                {
                    go.GetComponent<MeshRenderer>().enabled = false;
                    go.GetComponent<MeshCollider>().enabled = false;
                }
            }
        }
        canPassPink = false;

    }

    public void PassThroughPinkWall()
    {
        canPassPink = true;
    }
}
