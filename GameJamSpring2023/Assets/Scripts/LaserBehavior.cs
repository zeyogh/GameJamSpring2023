using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public GameObject startVFX;
    public GameObject endVFX;

    private Quaternion rotation;
    private List<ParticleSystem> particles = new List<ParticleSystem>();

    // Start is called before the first frame update
    void Start()
    {
        fillLists();
        disableLaser();

        Physics2D.IgnoreLayerCollision(6, 6);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            enableLaser();
        }

        if (Input.GetButton("Fire1"))
        {
            updateLaser();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            disableLaser();
        }

        rotateToMouse();
    }

    void enableLaser()
    {
        lineRenderer.enabled = true;

        for(int i = 0; i < particles.Count; i++)
        {
            particles[i].Play();
        }
    }

    void updateLaser()
    {
        var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

        lineRenderer.SetPosition(0, (Vector2)firePoint.position); //first position

        startVFX.transform.position = (Vector2)firePoint.position;

        lineRenderer.SetPosition(1, mousePos); //second position/point

        Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude, layerMask);
    
        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
        }

        endVFX.transform.position = (Vector2)lineRenderer.GetPosition(1);

    }

    void disableLaser()
    {
        lineRenderer.enabled = false;

        for (int i = 0; i < particles.Count; i++)
        {
            particles[i].Stop();
        }
    }

    void rotateToMouse()
    {
        Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0, 0, angle);
        //transform.rotation = rotation;
        firePoint.transform.rotation = rotation;
        startVFX.transform.rotation = rotation;
        endVFX.transform.rotation = rotation;
    }

    void fillLists()
    {
        for (int i = 0; i < startVFX.transform.childCount; i++)
        {
            var ps = startVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
            {
                particles.Add(ps);
            }
        }

        for (int i = 0; i < startVFX.transform.childCount; i++)
        {
            var ps = endVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
            {
                particles.Add(ps);
            }
        }
    }
}
