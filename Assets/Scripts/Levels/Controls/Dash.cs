using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    bool isDashCooldownActive = false;
    GameObject level;

    private void Start()
    {
        level = GameObject.FindGameObjectWithTag("floor");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isDashCooldownActive)
        {
            StartCoroutine(DoDash());
        }
    }

    IEnumerator DoDash()
    {
        isDashCooldownActive = true;

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

        //Won't work.
        //if (level.GetComponent<CompositeCollider2D>().bounds.Contains(this.transform.position))
        //{
        //    this.GetComponent<PlayerDeath>().Death();
        //}

        yield return new WaitForSeconds(4f);

        isDashCooldownActive = false;
    }
}
