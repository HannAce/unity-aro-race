using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public int Score = 0;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Flag")
        {
            Score++;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
