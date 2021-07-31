using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform player;
    private Vector3 camPos;
    [SerializeField] float minX = 0f;
    [SerializeField] float maxX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        camPos = transform.position;
        camPos.x = player.position.x;
        if(camPos.x < minX)
        {
            camPos.x = minX;
        }
        if(camPos.x > maxX)
        {
            camPos.x = maxX;
        }
        transform.position = camPos;

    }
}
