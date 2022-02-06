using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [SerializeField]
    private float shakeStrenght;
    [SerializeField] float shakeSpeed;

    void Update()
    {
        float ShakeOffset = Mathf.Lerp(-shakeStrenght,shakeStrenght,Mathf.PingPong(Time.time*shakeSpeed,1));
        float yShake = Mathf.Lerp(-shakeStrenght,shakeStrenght,Mathf.PingPong(Time.time,1));

        transform.position += new Vector3(ShakeOffset,ShakeOffset,0); 
    }
}
