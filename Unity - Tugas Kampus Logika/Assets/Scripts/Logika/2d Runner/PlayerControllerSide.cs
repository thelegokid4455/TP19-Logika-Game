using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSide : MonoBehaviour
{
    public float jumpSpeed;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //rb.AddForce(movement);
        this.GetComponent<Rigidbody>().velocity = new Vector3(
            moveSpeed * Time.deltaTime,
            this.GetComponent<Rigidbody>().velocity.y,
            this.GetComponent<Rigidbody>().velocity.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 1* jumpSpeed, 0);
            print("Jump");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if(other.gameObject.tag == "Obstacle")
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
