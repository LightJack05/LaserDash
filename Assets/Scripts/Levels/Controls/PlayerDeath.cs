using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerDeath : MonoBehaviour
{
    //int waitCounter = 10;
    //bool CheckForDeath = false;
    public GameObject PlayerDeathEffect;

    void FixedUpdate()
    {
        if (this.transform.position.y < -10)
        {
            Death();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            foreach (ContactPoint2D hitPos in collision.contacts)
            {
                
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
                
                if ((hitPos.normal.y < 0.9f))
                {
                    Death();
                    break;
                }
            }
        }

        if(collision.gameObject.tag == "Enemy")
        {
            Death();
        }
    }
    public void Death()
    {
        Debug.Log("Player died.");
        StartCoroutine("DeathAnimation");
    }

    public IEnumerator DeathAnimation()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
        this.gameObject.GetComponent<Light2D>().enabled = false;
        PlayerDeathEffect.SetActive(true);
        Camera.main.gameObject.GetComponent<Camerafollow>().enabled = false;

        yield return new WaitForSeconds(1);

        Restart();
        yield return null;
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
