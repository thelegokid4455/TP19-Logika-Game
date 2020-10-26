using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSide : MonoBehaviour
{
    public float jumpSpeed;
    public float moveSpeed;

    public bool isGravityMode;

    // Start is called before the first frame update
    void Start()
    {
        if (Physics.gravity.y > 0)
            Physics.gravity *= -1;
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
            if (isGravityMode)
            {
                Physics.gravity *= -1;
            }
            else
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, 1 * jumpSpeed, 0);
            }
            
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
