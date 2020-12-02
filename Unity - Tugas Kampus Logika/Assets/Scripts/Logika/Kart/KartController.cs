using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour
{
    public float moveSpeed;
    public float rotSpeed;
    public float pitchModifier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
        {
            this.GetComponent<Rigidbody>().velocity = this.transform.forward * moveSpeed;
        }
        if (Input.GetKey("s"))
        {
            this.GetComponent<Rigidbody>().velocity = this.transform.forward * -moveSpeed;
        }

        if (Input.GetKey("a"))
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, -rotSpeed);
        }
        if (Input.GetKey("d"))
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, rotSpeed);
        }

        GetComponent<AudioSource>().pitch = GetComponent<Rigidbody>().velocity.magnitude * pitchModifier;
    }
}
