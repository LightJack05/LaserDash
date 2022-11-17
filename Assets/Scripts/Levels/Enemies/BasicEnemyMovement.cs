using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
    public float LeftBoundaryX;
    public float RightBoundaryX;
    public float speed;

    private void FixedUpdate()
    {
        if (this.transform.position.x > RightBoundaryX && speed > 0  )
        {
            speed = -speed;
        }
        else if(this.transform.position.x < LeftBoundaryX && speed < 0)
        {
            speed = -speed;
        }

        this.GetComponent<Rigidbody2D>().MovePosition(this.transform.position + new Vector3(speed, 0, 0));

        
    }
}
