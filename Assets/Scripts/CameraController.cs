using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    float distance;
    Vector3 playerPrevPos, playerMoveDir;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;

        distance = offset.magnitude;
        playerPrevPos = player.transform.position;
    }

    void LateUpdate()
    {
        playerMoveDir = player.transform.position - playerPrevPos;
        if (playerMoveDir != Vector3.zero)
        {
            playerMoveDir.Normalize();
            transform.position = player.transform.position - playerMoveDir * distance;

            //transform.position.y += 5f; // required height
            transform.position += new Vector3(0, 4f, 0);
            //transform.rotation += new Vector3(-10f, 0, 0);

            transform.LookAt(player.transform.position);

            playerPrevPos = player.transform.position;
        }
    }
}
