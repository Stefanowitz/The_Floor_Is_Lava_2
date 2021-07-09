using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Script : MonoBehaviour
{
    public int livesRemaning = 3;

    public Text livesLeftDisplay;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask lavaMask;

    bool inLava;

    public GameObject startPoint;

    // Start is called before the first frame update
    void Start()
    {
        livesLeftDisplay.text = livesRemaning.ToString() + " Lives Remaining";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 spawnPoint = startPoint.transform.position;
        // Creates af Sphere around the Groundcheck to see if it is touching Lava    
        inLava = Physics.CheckSphere(groundCheck.position, groundDistance, lavaMask);

        if (inLava)
        {
            livesRemaning--;
            livesLeftDisplay.text = livesRemaning.ToString() + " Lives Remaining";
            transform.position = spawnPoint;

        }

    }
}
