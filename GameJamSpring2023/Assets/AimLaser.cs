using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLaser : MonoBehaviour
{

    [SerializeField] GameObject laser;

    [SerializeField] LayerMask layerMask;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public GameObject startVFX;
    public GameObject endVFX;


    private Quaternion rotation;
    private List<ParticleSystem> particles = new List<ParticleSystem>();

    private GameObject ratKing;
    private Vector3 rk;
    private float time = 0f;
    private bool spawned;

    // Start is called before the first frame update
    void Start()
    {
        fillLists();
        ratKing = GameObject.FindWithTag("Boss");
        if (ratKing != null)
        {
            spawned = true;
        }
        else
        {
            spawned = false;
        }
        enableLaser();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ratKing == null)
        {
            disableLaser();
            return;
        }
        else if (spawned == false)
        {
            spawned = true;
            ratKing = GameObject.FindWithTag("Boss");

        }

        time += Time.deltaTime;
        updateLaser();
        /*if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("happened");
            enableLaser();
        }

        if (Input.GetButton("Fire1"))
        {
            updateLaser();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            disableLaser();
        }*/

        rotateToRK();
    }

    public void setFirePoint(Transform t)
    {
        firePoint = t;
    }

    void enableLaser()
    {
        lineRenderer.enabled = true;

        for (int i = 0; i < particles.Count; i++)
        {
            particles[i].Play();
        }
    }

    void updateLaser()
    {

        rk = ratKing.transform.position;

        Vector3 difference = rk - gameObject.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        lineRenderer.SetPosition(0, (Vector2)firePoint.position); //first position

        startVFX.transform.position = (Vector2)firePoint.position;

        lineRenderer.SetPosition(1, rk); //second position/point

        Vector2 direction = (Vector2)rk - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude, layerMask);

        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
            if (time > 1f)
            {
                ratKing.GetComponent<EnemyHealth>().hit();
                ratKing.GetComponent<EnemyHealth>().hit();
                ratKing.GetComponent<EnemyHealth>().hit();
                ratKing.GetComponent<EnemyHealth>().hit();
                ratKing.GetComponent<EnemyHealth>().hit();
                time = 0;
            }
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

    void rotateToRK()
    {
        Vector2 direction = (Vector2)rk - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0, 0, angle);
        //transform.rotation = rotation;
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
