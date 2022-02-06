using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshNoise : MonoBehaviour
{
    [SerializeField]
    private ComputeShader shader;

    private ComputeBuffer in_buffer,out_buffer,noiseBuffer;
    private int kernelHandle;

    private Vector3[] out_verticesArray;
    private Mesh mesh;
    private int verticesCnt;
    private int size;

    [SerializeField]
    private float noiseStrength;
    [SerializeField]
    private float timeMultiplier;
    private void Awake()
    {
        shader = Instantiate(shader);
        mesh = GetComponent<MeshFilter>().mesh;
        verticesCnt = mesh.vertices.Length;
        size = (int)Mathf.Sqrt(verticesCnt);

        out_verticesArray =new Vector3[verticesCnt];

        in_buffer = new ComputeBuffer(verticesCnt,12);
        out_buffer = new ComputeBuffer(verticesCnt,12);
        noiseBuffer = new ComputeBuffer(verticesCnt,12);

        in_buffer.SetData(mesh.vertices);
        noiseBuffer.SetData(generateNoise(verticesCnt,noiseStrength));

        kernelHandle = shader.FindKernel("CSMain");
        shader.SetBuffer(kernelHandle,"in_vertices",in_buffer);
        shader.SetBuffer(kernelHandle,"out_vertices",out_buffer);
        shader.SetBuffer(kernelHandle,"in_noise",noiseBuffer);
        shader.SetInt("size",size);
    }

    private void Update()
    {
        shader.SetFloat("costime",Mathf.Cos(Time.time*timeMultiplier));
        shader.Dispatch(kernelHandle,verticesCnt,1,1);
        out_buffer.GetData(out_verticesArray);
        mesh.vertices=out_verticesArray;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }

    private void OnDestroy()
    {
        in_buffer.Release();
        out_buffer.Release();
        noiseBuffer.Release();
    }

    private Vector3[] generateNoise(int arrayLen,float strength)
    {
        Vector3[] noise = new Vector3[arrayLen];
        for(int i=0;i<arrayLen;i++)
        {
            noise[i]=new Vector3(Random.Range(-strength,strength),Random.Range(-strength,strength),Random.Range(-strength,strength));
        }
        return noise;
    }
}
