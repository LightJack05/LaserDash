using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Camera.main.transform.position = new(Player.transform.position.x + 4, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }
}
