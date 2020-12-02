using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    public Transform target;
    public float distance = 3.0f;
    public float height = 3.0f;
    public float damping = 5.0f;
    public bool smoothRotation = true;
    public float rotationDamping = 10.0f;

    public bool lookAt;

    // Start is called before the first frame update
    void Start()
    {
        if (!target)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            if(!lookAt)
            {
                var wantedPosition = target.TransformPoint(0, height, -distance);
                transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);


                if (smoothRotation)
                {
                    var wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
                }
                else transform.LookAt(target, target.up);
            }
            else
            {
                transform.LookAt(target);
            }
            
        }
    }
}
