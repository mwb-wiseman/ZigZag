using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public ButtonBehaviourInGame buttonBehaviour;
    public GameObject gameOverCanvas;
    public GameObject settingsMenu;
    public Transform rayStart;

    public float speed = 1f;
    public bool cutLoose = false;

    private GameManager gameManager;
    private Rigidbody myRigidbody;
    private Animator animator;
    private AudioManager audioManager;
    private bool walkingRight = true;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
        myRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        speed = speed * PlayerPrefs.GetFloat("Difficulty");
    }

    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)
            return;
        else
            animator.SetBool("startRunning", true);

        if(!GameObject.FindGameObjectWithTag("SubMenu"))
            transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }

    private void Update()
    {
        DetectGround();

        // Check for player input   
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);

            if (gameManager.gameStarted && !settingsMenu.activeSelf && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                ChangeDirection();
            }
        }
    }

    private void ChangeDirection()
    {
        if (!cutLoose && !settingsMenu.activeSelf)
            Switch();
    }

    private void DetectGround()
    {
        RaycastHit hit;

        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            animator.SetTrigger("NoPlatform");
            gameOverCanvas.SetActive(true);
            if (!cutLoose)
            {
                audioManager.StopMusic();
                audioManager.PlaySound(audioManager.gameOver);
                myRigidbody.AddTorque(0f, 0, -0.1f);
                speed = speed / 2;
                cutLoose = true;
            }
        }
    }

    private void Switch()
    {
        switch (walkingRight)
        {
            // If currently walking right, turn left 90 degrees
            case true:
                myRigidbody.transform.rotation = Quaternion.Euler(0, -135, 0);
                break;
            // If currently walking left, turn right 90 degrees
            case false:
                myRigidbody.transform.rotation = Quaternion.Euler(0, -45, 0);
                break;
        }

        walkingRight = !walkingRight;
    }
}
