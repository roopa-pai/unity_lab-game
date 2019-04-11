using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour {

    public GameObject player;
    private static int gotkey;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        PlayerController playerScript = player.GetComponent<PlayerController>();
        gotkey = playerScript.gotkey;

        if (gotkey == 1)
        {
            transform.position = player.transform.position;
            transform.position += new Vector3(0,4f,0);
        }
    }
}