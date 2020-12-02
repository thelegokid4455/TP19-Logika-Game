using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;

    public GameObject animObj;
    public AudioClip shootSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bo = GameObject.Instantiate<GameObject>(bulletPrefab);
            //bo.transform.position = this.transform.position;
            

            BulletController bullet = bo.GetComponent<BulletController>();

            bo.transform.position = bulletSpawn.transform.position;
            bo.transform.rotation = bulletSpawn.transform.rotation;

            animObj.GetComponent<Animation>().Stop();
            animObj.GetComponent<Animation>().Play("Fire");
            GetComponent<AudioSource>().PlayOneShot(shootSound);
        }
    }
}
