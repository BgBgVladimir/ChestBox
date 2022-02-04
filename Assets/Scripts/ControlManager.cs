using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    [SerializeField]
    private float moweSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float rayLength;

    private float sourceY;

    private void Start()
    {
        sourceY=transform.position.y;
    }

    void Update()
    {
    if(Input.GetKey(KeyCode.W))
        {
            Mowe(transform.forward);
        }
    if(Input.GetKey(KeyCode.S))
        {
            Mowe(-transform.forward);
        }
     if(Input.GetKey(KeyCode.A))
        {
            Mowe(-transform.right);
        }
     if(Input.GetKey(KeyCode.D))
        {
            Mowe(transform.right);
        }
     if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0f,-rotationSpeed*Time.deltaTime,0f),Space.World);
        }
     if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0f,rotationSpeed*Time.deltaTime,0f),Space.World);
        }
        transform.position=new Vector3(transform.position.x,sourceY,transform.position.z);
    }

    void Mowe(Vector3 direction)
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,direction,out hit,rayLength))
        {
            return;
        }
        transform.Translate((direction)*moweSpeed*Time.deltaTime,Space.World);
    }
}
