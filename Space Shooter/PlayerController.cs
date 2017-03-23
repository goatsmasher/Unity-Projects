using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    Rigidbody mything;
    AudioSource aSource;
    public float speed;
    public float tilt;
    public float fireRate;
    private float nextFire = 0.0f;
    public Boundary boundary;
    void Start()
    {
        mything = GetComponent<Rigidbody>();
        aSource = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            aSource.PlayOneShot(aSource.clip);
        }
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = (new Vector3(moveHorizontal, 0.0f, moveVertical));
        mything.velocity = movement * speed;

        mything.position = new Vector3
        (
            Mathf.Clamp(mything.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(mything.position.z, boundary.zMin, boundary.zMax)
        );

        mything.rotation = Quaternion.Euler(0.0f, 0.0f, mything.velocity.x * -tilt);

    }
}
