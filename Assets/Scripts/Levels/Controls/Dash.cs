using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool Dashing = false;
    bool dashAvailable = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && dashAvailable)
        {
            Debug.Log("Dash");
            Dashing = true;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Dash available.");
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

        Dashing = false;
    }
}
