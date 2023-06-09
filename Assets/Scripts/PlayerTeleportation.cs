using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the throwing of TeleBalls and manages their inventory.
/// </summary>
public class PlayerTeleportation : MonoBehaviour
{

    [SerializeField] GameObject[] ballTypeArray;
    int curBallType;

    [SerializeField] float throwForce;
    [SerializeField] Transform throwArrow;

    AudioSource audioSrc;
    [SerializeField] AudioClip throwAudio;
    [SerializeField] AudioClip teleportAudio;

    Animator animator;
    [SerializeField] AnimationClip teleportAnim;
    [HideInInspector] public float teleportTime;

    GameObject activeBall;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        teleportTime = teleportAnim.length;

        activeBall = null;
        curBallType = 0;
    }

    void Update()
    {
        if (PauseScreen.gamePaused) { return; }

        // Restart when pressing R
        if(Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Only allow player to throw a ball if one isn't being thrown
        if(activeBall == null && LevelController.getNumLeft(curBallType) > 0) {
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
            if (Input.GetMouseButton(0)) 
            {
                throwArrow.gameObject.SetActive(true);
            }
            // Throw ball when left mouse button let go
            if (Input.GetMouseButtonUp(0)) 
            {
                ThrowBall();
                LevelController.decrementBall(curBallType);
                throwArrow.gameObject.SetActive(false);
            }
        }

        // Switch ball type with right click
        if (Input.GetMouseButtonDown(1)) {
            curBallType++;
            if (curBallType == ballTypeArray.Length) {
                curBallType = 0;
            }
            UIManagement.refresh(curBallType);
        }
    }

    void ThrowBall() 
    {
        if(activeBall == null) {
            // Getting mouse position in world
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;

            Vector3 direction = Vector3.Normalize(worldPos - transform.position);

            activeBall = Instantiate(ballTypeArray[curBallType], transform.position, Quaternion.identity);
            activeBall.GetComponent<Rigidbody2D>().AddForce(direction * throwForce);
            activeBall.GetComponent<TeleBall>().player = transform;
            audioSrc.clip = throwAudio;
            audioSrc.Play();
        }
    }

    public void TeleportAudioVisuals() {
        audioSrc.clip = teleportAudio;
        audioSrc.Play();
        animator.Play(teleportAnim.name);
    }
}
