using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_look : MonoBehaviour
{
    // Settings the Mouse sensetivty to 100
    public float mouseSens = 100f;

    // Makeing a Link to the Player body
    public Transform playerBody;

    
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Locking the Cursor in place 
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Getting the data from where the mouse is on the X axis
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        
        // Getting the data from where the mouse is on the Y axis
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        // Decraseing X rotation based on Mouse Y
        xRotation -= mouseY;
        // limiting the player so they can look bebind them
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


    }
}
