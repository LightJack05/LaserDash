using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Jump pad triggered");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 100f, 0));
        }
    }
}
