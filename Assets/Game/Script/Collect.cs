using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public int counter = 0;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Flag")
        {
            counter++;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
