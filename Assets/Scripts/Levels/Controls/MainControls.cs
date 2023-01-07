using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControls : MonoBehaviour
{
    int jumpPoints = 2;
    private void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new(24f, 0), ForceMode2D.Impulse);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpPoints > 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new(this.GetComponent<Rigidbody2D>().velocity.x, 0);

                this.GetComponent<Rigidbody2D>().AddForce(new(0, 75f), ForceMode2D.Impulse);
                jumpPoints--;
            }
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            foreach (ContactPoint2D hitPos in collision.contacts)
            {
                
                if ((hitPos.normal.y > 0.9f))
                {
                    jumpPoints = 2;
                    break;
                }
            }
        }
    }

}