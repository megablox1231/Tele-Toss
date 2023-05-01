using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the throwing of TeleBalls and manages their inventory.
/// </summary>
public class PlayerTeleportation : MonoBehaviour
{

    [SerializeField] GameObject[] ballTypeArray;
    int[] ballTypeInventory;
    int curBallType;

    [SerializeField] float throwForce;
    [SerializeField] Transform throwArrow;

    GameObject activeBall;

    void Start()
    {
        activeBall = null;
        ballTypeInventory = new int[] {4, 4, 4};
    }

    void Update()
    {
        // Only allow player to throw a ball if one isn't being thrown
        if(activeBall == null) {
            // Setting direction of throw arrow
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Input.mousePosition;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                worldPos.z = 0;

                Vector3 rotatedDir = Quaternion.Euler(0, 0, 90) * Vector3.Normalize(worldPos - transform.position);
                throwArrow.rotation = Quaternion.LookRotation(Vector3.forward, rotatedDir);
            }
            // Throw arrow active while left mouse button held down
            if (Input.GetMouseButtonDown(0)) 
            {
                throwArrow.gameObject.SetActive(true);
            }
            // Throw ball when left mouse button let go
            if (Input.GetMouseButtonUp(0)) 
            {
                ThrowBall();
                throwArrow.gameObject.SetActive(false);
            }
        }

        // Switch ball type with right click
        if (Input.GetMouseButtonDown(1)) {
            curBallType++;
            if (curBallType == ballTypeArray.Length) {
                curBallType = 0;
            }
        }
    }

    void ThrowBall() 
    {
        if(activeBall == null) {
            Destroy(activeBall);
            // Getting mouse position in world
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;

            Vector3 direction = Vector3.Normalize(worldPos - transform.position);

            activeBall = Instantiate(ballTypeArray[curBallType], transform.position, Quaternion.identity);
            activeBall.GetComponent<Rigidbody2D>().AddForce(direction * throwForce);
            activeBall.GetComponent<TeleBall>().player = transform;
        }
    }
}
