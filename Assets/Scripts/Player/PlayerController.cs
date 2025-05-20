using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject fireRotation;
    private Rigidbody2D playerRigidbody;
    

    
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");

        bool playerMoving = inputH != 0 || inputV != 0;
        if (playerMoving)
        {
            FireRotate(inputH, inputV);
            playerRigidbody.velocity = new Vector3(inputH, inputV, 0) * moveSpeed;

        }
        else
        {
            playerRigidbody.velocity = Vector2.zero;
        }
        
    }

    private void FireRotate(float inputH, float inputV)
    {
        if (inputH > 0)
        {
            fireRotation.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (inputH < 0)
        {
            fireRotation.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (inputV > 0)
        {
            fireRotation.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (inputV < 0)
        {
            fireRotation.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }
}
