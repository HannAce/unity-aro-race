using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
    
{
    public int score = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Flag")
        {
            score = score + 20;
            Destroy(other.gameObject);
        }
        else if(other.tag == "End")
        {
            Destroy(other.gameObject);
            GameObject.FindWithTag("Fly").transform.position += transform.up * score * Time.deltaTime;
        }
    }
}
