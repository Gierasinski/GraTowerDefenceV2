using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bomb : MonoBehaviour
{
    new private Camera camera;

    private float offset = 10f;
    private float positionY = 10f;

    

    public GameObject spherePrefab;
    public GameObject impactEffect;
    public float explosionRadious = 10f;
    public int damge = 50;
    public static int cost = 20;


    GameObject spheretGO;
    new Transform transform;
    Plane plane = new Plane(Vector3.up, 0);
    Vector3 cursorPos;

    private bool falling = false;

    void Awake()
    {
        transform = GetComponent<Transform>();
    }
    void Start()
    {
        if (camera == null)
        {
            camera = Camera.main;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            falling = true;
        }
        if(transform.position.y <= -20)
        {
            Destroy(gameObject);
        }

        /*Vector3 pos = Input.mousePosition;
        pos.z = offset;
        Vector3 cursorPos = camera.ScreenToWorldPoint(pos);
        Debug.Log(cursorPos);
        //cursorPos.y = positionY;*/
        if (!falling) 
        {
            float distance;

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(plane.Raycast(ray, out distance))
            {
                cursorPos = ray.GetPoint(distance);
            }
            cursorPos.y = 10f;
            transform.position = cursorPos;

            cursorPos.y = 0;
            if (spheretGO == null)
            {
                spheretGO = (GameObject)Instantiate(spherePrefab, cursorPos, transform.rotation);
            }else
            {
                spheretGO.transform.position = cursorPos;
            }
            
            
        }
        else
        {
            Destroy(spheretGO);
        }


    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject effectInst = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(effectInst, 2f);
        Destroy(gameObject);
        Debug.Log("BUM!!!");
        Explode();
        Destroy(spheretGO);

    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadious);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }


    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamge(damge);
        }

    }
}
