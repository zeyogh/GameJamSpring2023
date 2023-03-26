using UnityEngine;

// Ensure the component is present on the gameobject the script is attached to
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // Local rigidbody variable to hold a reference to the attached Rigidbody2D component
    new Rigidbody2D rigidbody2D;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    public float bulletSpeed = 20.0f;
    public int health = 5;

    public float movementSpeed = 1000.0f;
    private float angle;
    private Vector2 targetVelocity;

    void Awake()
    {
        // Setup Rigidbody for frictionless top down movement and dynamic collision
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.isKinematic = false;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void FixedUpdate()
    {
        // Handle user input
        targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (targetVelocity != Vector2.zero)
        {
            angle = Mathf.Atan2(targetVelocity.y, targetVelocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        Move(targetVelocity);
    }

    void Move(Vector2 targetVelocity)
    {
        // Set rigidbody velocity
        rigidbody2D.velocity = (targetVelocity * movementSpeed * Time.deltaTime) ; // Multiply the target by deltaTime to make movement speed consistent across different framerates
    }

    public void Fire()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.SetPositionAndRotation(bulletStart.transform.position, Quaternion.Euler(0.0f, 0.0f, rigidbody2D.rotation));
        if (targetVelocity != Vector2.zero)
        {
            b.GetComponent<Rigidbody2D>().velocity = targetVelocity * bulletSpeed;
        }  else
        {
            float z = transform.rotation.eulerAngles.z;
            Debug.Log(z);
            Vector2 vel;

            if (z == 0)
            {
                vel = Vector2.right;
            } else if (z == 90)
            {
                vel = Vector2.up;
            }  else if (z == 180)
            {
                vel = Vector2.left;
            } else if (z == 270)
            {
                vel = Vector2.down;
            } else if (z == 135)
            {
                vel = new Vector2(-1f, 1f);
            }
            else if (z == 315)
            {
                vel = new Vector2(1f, -1f);
            }
            else
            {
                vel = (Vector2.one * angle).normalized;
            }
 
            b.GetComponent<Rigidbody2D>().velocity = vel * bulletSpeed;
        }
        
    }

    public void hit()
    {
        health--;
        if (health <=0)
        {
            Debug.Log("u died :(");
        }
    }
}