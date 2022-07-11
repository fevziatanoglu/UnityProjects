using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{



    private Vector3 offset =new  Vector3(1f, 4f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerPosition = playerTransform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, smoothTime);
        
    }
}
