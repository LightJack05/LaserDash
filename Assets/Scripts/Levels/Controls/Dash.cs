using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    bool dashAvailable = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && dashAvailable)
        {
            StartCoroutine(doDash());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DashTrigger")
        {
            dashAvailable = true;
        }
    }


    IEnumerator doDash()
    {
        dashAvailable = false;

        this.GetComponent<Rigidbody2D>().isKinematic = true;
        this.GetComponent<Rigidbody2D>().velocity = new(this.GetComponent<Rigidbody2D>().velocity.x, 0);
        this.GetComponent<BoxCollider2D>().enabled = false;
        Vector2 oldVelocity = this.GetComponent<Rigidbody2D>().velocity;
        this.GetComponent<Rigidbody2D>().velocity = oldVelocity * 10f;

        yield return new WaitForSeconds(0.1f);

        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<Rigidbody2D>().isKinematic = false;
        this.GetComponent<Rigidbody2D>().velocity = oldVelocity;

    }
}
