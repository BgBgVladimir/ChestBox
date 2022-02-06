using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] targets;

    [SerializeField]
    private Vector3 randomDistanceInTargetSpace;

    public void RePlace()
    {
        int randomTarget = Random.Range(0,targets.Length);
        Transform target = targets[randomTarget].transform;

        transform.position=new Vector3(target.position.x,0,target.position.z);
        transform.Translate(target.right*Random.Range(-randomDistanceInTargetSpace.x,randomDistanceInTargetSpace.x),Space.World);
        transform.Translate(target.up*Random.Range(-randomDistanceInTargetSpace.y,randomDistanceInTargetSpace.y),Space.World);
        transform.Translate(target.forward*Random.Range(-randomDistanceInTargetSpace.z,randomDistanceInTargetSpace.z),Space.World);
        transform.rotation=Quaternion.LookRotation(target.up);  
    }
}
