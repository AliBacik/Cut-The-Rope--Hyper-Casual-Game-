using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevrilecekObje : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Top"))
        {
            gameObject.GetComponent<AudioSource>().Play();
        }

        if (collision.gameObject.CompareTag("HedefObje"))
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
