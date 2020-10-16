using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float jumpSpeed;
    public Text counter;
    public int coins;
    public int maxCoins;
    public GameObject winText;
    public GameObject winObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = "Coins: " + coins;
        
        if(coins >= maxCoins)
        {
            winText.SetActive(true);
            winObject.SetActive(true);
        }
        else
        {
            winText.SetActive(false);
            winObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpSpeed, 0));
            }
        rb.AddForce(movement * speed);
    }
}
