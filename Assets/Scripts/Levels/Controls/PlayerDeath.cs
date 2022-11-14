using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    int waitCounter = 10;
    bool CheckForDeath = false;
    void FixedUpdate()
    {
        
        if (CheckForDeath)
        {
            if (this.GetComponent<Rigidbody2D>().velocity.x <= 2f)
            {
                Death();
            }
            if(this.transform.position.y < -10)
            {
                Death();
            }
        }
        else
        {
            waitCounter--;
            if(waitCounter <= 0)
            {
                CheckForDeath = true;
            }
        }
    }
    void Death()
    {
        Debug.Log("Death");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
