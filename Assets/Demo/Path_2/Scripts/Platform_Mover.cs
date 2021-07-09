using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Mover : MonoBehaviour
{
    public Transform[] points;

    public float moveSpeed = 1f;

    private Transform target;
    private int wayPointIndex = 0;

    public GameObject player;

    void Start()
    {
        target = points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextPoint();
        }
        
    }

    void GetNextPoint()
    {
        if (wayPointIndex == 1)
        {
            wayPointIndex--;
        }
        else
        {
            wayPointIndex++;
        }
        target = points[wayPointIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //player.transform.parent = transform;
            player.transform.SetParent(transform);
           
            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            //player.transform.parent = null;
            player.transform.SetParent(null);
            Debug.Log("Exit");
        }
    }
}
