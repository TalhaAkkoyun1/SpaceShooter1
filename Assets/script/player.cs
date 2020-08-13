using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float tilt;
    public boundry boundry;
    public GameObject bolt;
    public Transform shotSpawn;
    public float fireRate;
    float nextFire;
    private AudioSource playerShoot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerShoot = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButton("Jump") && Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
            Instantiate(bolt, shotSpawn.position, shotSpawn.rotation);
            playerShoot.Play();
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundry.minX, boundry.maxX), rb.position.y, Mathf.Clamp(rb.position.z, boundry.minZ, boundry.maxZ));

        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -tilt);
    }

}
[System.Serializable]
public class boundry
{
    public float minX, maxX, minZ, maxZ;
}