using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadBehaviour : MonoBehaviour
{
    public float JumpForce = 150f;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.GetComponent<Rigidbody2D>().velocity = new(Player.GetComponent<Rigidbody2D>().velocity.x, 0);
            Player.GetComponent<Rigidbody2D>().AddForce(new(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
