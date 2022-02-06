using UnityEngine;

public class OnMouseOverLighting : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;

    private void Start()
    {
        OffLighting();  
    }
    private void OnMouseEnter()
    {
        OnLighting();
    }
    private void OnMouseExit()
    {
        OffLighting();
    }
    private void OnLighting()
    {
        foreach(Material mat in materials)
        {
            mat.SetFloat("_GlowStrength",0.25f);
        }
    }
    private void OffLighting()
    {
        foreach(Material mat in materials)
        {
            mat.SetFloat("_GlowStrength",0f);
        }
    }
}
