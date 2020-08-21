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
    private Quaternion calibrationQuaternion;
    public SimpleTouchPad touchPad;
    public SimpleTouchAreaButton areaButton;    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerShoot = GetComponent<AudioSource>();
        CalibrateAccelerometer();
    }

    private void Update()
    {
        if (areaButton.CanFire() && Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
            Instantiate(bolt, shotSpawn.position, shotSpawn.rotation);
            playerShoot.Play();
        }


    }
    void CalibrateAccelerometer()
    {
        Vector3 acclerationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), acclerationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

    
    Vector3 FixAccleration(Vector3 acceleration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
        return fixedAcceleration;
    }
        
        
    // Update is called once per frame
    private void FixedUpdate()
    {
        // float moveHorizontal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        //Vector3 accelerationRaw = Input.acceleration;
        //Vector3 acceleration = FixAccleration(accelerationRaw);
        // Vector3 movement = new Vector3(acceleration.x, 0.0f, acceleration.y);

        Vector2 direction = touchPad.GetDirection();
        Vector3 movement = new Vector3(direction.x, 0.0f, direction.y);

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