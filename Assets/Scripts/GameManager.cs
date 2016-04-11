using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Spawn").Length == 1 && GameObject.FindGameObjectWithTag("Spawn") != null)
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length == 1 && GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("Spawn").transform.position + new Vector3(0, 1, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {

    }
}
