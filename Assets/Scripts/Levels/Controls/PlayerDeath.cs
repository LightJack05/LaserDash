using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    //int waitCounter = 10;
    //bool CheckForDeath = false;
    void FixedUpdate()
    {

        //if (CheckForDeath)
        //{
        //if (this.GetComponent<Rigidbody2D>().velocity.x <= 2f)
        //{
        //    Death();
        //}
        if (this.transform.position.y < -10)
        {
            Death();
        }
        //}
        //else
        //{
        //    //waitCounter--;
        //    //if(waitCounter <= 0)
        //    //{
        //    //    CheckForDeath = true;
        //    //}
        //}
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            foreach (ContactPoint2D hitPos in collision.contacts)
            {
                Debug.Log(hitPos.normal);
                if ((hitPos.normal.y < 0.9f))
                {
                    Death();
                    break;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
           foreach(ContactPoint2D hitPos in collision.contacts)
           {
                Debug.Log(hitPos.normal);
                if ((hitPos.normal.y < 0.9f))
                {
                    Death();
                    break;
                }
            }
        }
    }
    void Death()
    {
        Debug.Log("Death");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
