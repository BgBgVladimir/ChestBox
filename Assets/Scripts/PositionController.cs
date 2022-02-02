using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    private Mesh mesh;

    private int randomVertex;

    [SerializeField]
    private Vector3 offset;

    void Start()
    {
        mesh=target.GetComponent<MeshFilter>().mesh;
        randomVertex=Random.Range(0,mesh.vertices.Length);
        transform.position=mesh.vertices[randomVertex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(transform.position.x,mesh.vertices[randomVertex].y+offset.y,mesh.vertices[randomVertex].z);
    }
}
