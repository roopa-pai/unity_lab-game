using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text oopsText;
    public Text bumpText;
    public Text keyText;
    public Text winText;
    private Rigidbody rb;
    private int count;
    private int bump;
    private Vector3 offset;
    public int gotkey;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        bump = 0;
        bumpText.text = "";
        oopsText.text = "";
        keyText.text = "";
        winText.text = "";
        SetCountText();
        SetBumpText();

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        movement = transform.InverseTransformDirection(movement);
        movement.y = 0.0f;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Furniture"))
        {
            bumpText.text = "Bump!";
            bump = bump + 1;
            SetBumpText();
        }
    }

    void OnCollisionExit(Collision other)
    {
        bumpText.text = "";
        oopsText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            keyText.text = "Got key from Xenia!";
            keyText.CrossFadeAlpha(0.0f, 5f, false);
            gotkey = 1;
        }
        if (other.gameObject.CompareTag("Brain"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 10)
        {
            winText.text = "You won!";
        }
    }
    void SetBumpText()
    {
        if (bump >= 12 && bump % 4 == 0)
        {
            oopsText.text = "You're working too hard! Go home.";
        }
    }
}