using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField]
    private float moweSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float rayLength;

    private Vector3 sourcePosition;
    private Quaternion sourceRotation;

    private void Awake()
    {
        instance=this;
        sourcePosition=transform.position;
        sourceRotation=transform.rotation;
        enabled=false;
    }
    void Update()
    {
    if(Input.GetKey(KeyCode.W))
        {
            Mowe(transform.forward);
            AudioManager.instance.PlayWalk();
        }
    if(Input.GetKey(KeyCode.S))
        {
            Mowe(-transform.forward);
            AudioManager.instance.PlayWalk();
        }
     if(Input.GetKey(KeyCode.A))
        {
            Mowe(-transform.right);
            AudioManager.instance.PlayWalk();
        }
     if(Input.GetKey(KeyCode.D))
        {
            Mowe(transform.right);
            AudioManager.instance.PlayWalk();
        }
     if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0f,-rotationSpeed*Time.deltaTime,0f),Space.World);
        }
     if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0f,rotationSpeed*Time.deltaTime,0f),Space.World);
        }
        transform.position=new Vector3(transform.position.x,sourcePosition.y,transform.position.z);
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
    public void PlayerReset()
    {
        transform.position=sourcePosition;
        transform.rotation=sourceRotation;
        enabled=true;
    }
}
