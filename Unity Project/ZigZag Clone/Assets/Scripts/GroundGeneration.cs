using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGeneration : MonoBehaviour
{
    public GameObject groundblockPrefab;
    public GameObject groundblockWithItemPrefab;
    public PlayerMovement player;
    public GameObject settingsMenu;
    public float drawDistance = 100;

    private GameManager gameManager;
    private Queue ground = new Queue();
    private Vector3 lastPosition;
    private float zOffset;
    private float xOffset;
    private bool generating;

    public void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        zOffset = GameObject.Find("Groundblock").GetComponent<MeshRenderer>().bounds.extents.z;
        xOffset = GameObject.Find("Groundblock").GetComponent<MeshRenderer>().bounds.extents.x * -1;
        lastPosition = GameObject.Find("Groundblock (14)").transform.position;
        generating = false;

        ground.Enqueue(GameObject.Find("Groundblock (-1)"));
        ground.Enqueue(GameObject.Find("Groundblock (0)"));
        ground.Enqueue(GameObject.Find("Groundblock"));
        ground.Enqueue(GameObject.Find("Groundblock (1)"));
        ground.Enqueue(GameObject.Find("Groundblock (2)"));
        ground.Enqueue(GameObject.Find("Groundblock (3)"));
        ground.Enqueue(GameObject.Find("Groundblock (4)"));
        ground.Enqueue(GameObject.Find("Groundblock (5)"));
        ground.Enqueue(GameObject.Find("Groundblock (6)"));
        ground.Enqueue(GameObject.Find("Groundblock (7)"));
        ground.Enqueue(GameObject.Find("Groundblock (8)"));
        ground.Enqueue(GameObject.Find("Groundblock (9)"));
        ground.Enqueue(GameObject.Find("Groundblock (10)"));
        ground.Enqueue(GameObject.Find("Groundblock (11)"));
        ground.Enqueue(GameObject.Find("Groundblock (12)"));
        ground.Enqueue(GameObject.Find("Groundblock (13)"));
        ground.Enqueue(GameObject.Find("Groundblock (14)"));
    }

    public void Update()
    {
        CheckNewGround();
        CleanupOldGround();
    }

    public void StartBuilding()
    {
        InvokeRepeating("GenerateGround", 0.2f, 0.2f / PlayerPrefs.GetFloat("Difficulty"));
        generating = true;
    }

    public void CancelGeneration()
    {
        CancelInvoke();
        generating = false;
    }

    private void CheckNewGround()
    {
        float distance = Vector3.Distance(lastPosition, player.transform.position);

        if (distance > drawDistance)
        {
            CancelGeneration();
        }
        else if (gameManager.gameStarted && !settingsMenu.activeSelf && !generating && distance < drawDistance)
        {
            StartBuilding();
        }
    }

    private void CleanupOldGround()
    {
        GameObject oldestBlock = (GameObject)ground.Peek();

        if (Vector3.Distance(oldestBlock.transform.position, player.transform.position) > drawDistance / 10)
        {
            ground.Dequeue();
            Destroy(oldestBlock);
        }
    }
    
    private void GenerateGround()
    {
        Vector3 spawnPosition = Vector3.zero;

        float chance = Random.Range(0, 100);

        if(chance < 50)
        {
            spawnPosition = new Vector3(lastPosition.x + xOffset, lastPosition.y, lastPosition.z + zOffset);
        }
        else
        {
            spawnPosition = new Vector3(lastPosition.x + xOffset, lastPosition.y, lastPosition.z - zOffset);
        }

        if(chance > 70)
        {
            GameObject g = Instantiate(groundblockWithItemPrefab, spawnPosition, Quaternion.Euler(0, 45, 0));
            ground.Enqueue(g);
            lastPosition = g.transform.position;
        }
        else
        {
            GameObject g = Instantiate(groundblockPrefab, spawnPosition, Quaternion.Euler(0, 45, 0));
            ground.Enqueue(g);
            lastPosition = g.transform.position;
        }

    }
}
