using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    void Awake()
    {
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        if (!player.GetComponent<PlayerMovement>().cutLoose)
            transform.position = player.transform.position + offset;
        else
            transform.position = transform.position;
    }
}
