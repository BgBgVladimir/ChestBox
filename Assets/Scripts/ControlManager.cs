using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    [SerializeField]
    private float moweSpeed;
    [SerializeField]
    private float rotationSpeed;
    private float sourceY;
    private void Start()
    {
        sourceY=transform.position.y;
    }
    void Update()
    {
    if(Input.GetKey(KeyCode.W))
        {
            transform.Translate((transform.forward)*moweSpeed*Time.deltaTime,Space.World);
        }
    if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward*moweSpeed*Time.deltaTime,Space.World);
        }
     if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-transform.right*moweSpeed*Time.deltaTime,Space.World);
        }
     if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right*moweSpeed*Time.deltaTime,Space.World);
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
}
