using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneNoise : MonoBehaviour
{
    Mesh mesh;
    Vector3[] noise;
    Vector3[] SourceVertices;
    [SerializeField]
    float might;
    [SerializeField]
    float mightRandomizer;
    void Start()
    {
        mesh=GetComponent<MeshFilter>().mesh;
        SourceVertices=mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        float _might=might+Random.Range(-mightRandomizer,mightRandomizer);
        Vector3[] vertices = mesh.vertices;
        for(int i=0;i<vertices.Length;i++)
        {
            vertices[i]= SourceVertices[i] + new Vector3(Random.Range(-_might,_might),Random.Range(-_might,_might),Random.Range(-_might,_might));
        }
        mesh.vertices=vertices;
       /* mesh.RecalculateBounds();
        mesh.RecalculateNormals();*/
    }

    [ContextMenu("SetNewMesh")]
    public void SetNewMesh()
    {
        mesh=GetComponent<MeshFilter>().mesh;
        mesh.vertices=VecticesGenerator(1000,1000);
        mesh.triangles=TrianglesGenerator(1000,1000);
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh=mesh;
        GetComponent<MeshCollider>().sharedMesh=mesh;
    }
    Vector3[] VecticesGenerator(int width=100, int height=100)
    {
        Vector3[] _vertices = new Vector3[width*height];
        int counter = 0;
        for(int i=0;i<width;i++)
        {
            for(int y=0;y<height;y++)
            {
                _vertices[counter]=new Vector3(i,0,y);
                counter++;
            }
        }
        return _vertices;
    }
    int[] TrianglesGenerator(int width= 100,int height = 100)
    {
        //int[] _triangles = new int[(width)*(height)*6];
        int[] _triangles = new int[3];
        _triangles[0]=0;
        _triangles[1]=1;
        _triangles[2]=width;

       /* _triangles[3]=width;
        _triangles[4]=1;
        _triangles[5]=width+1;*/
        
        /* int counter = 0;
         for(int i=0;i<width-1;i++)
         {
             for(int y = 0; y<height-1; y++)
                 {
                 Debug.Log("itters");
                 _triangles[counter]=y+i*width;
                 _triangles[counter+1]=y+1+i*width;
                 _triangles[counter+2]=y+i*width+width;
                 counter+=2;
                 }
         }*/
        return _triangles;
    }
  /*  private void OnDrawGizmos()
    {
        foreach(Vector3 vert in mesh.vertices)
        {
            Gizmos.DrawSphere(vert,0.1f);
        }
    }*/

    [ContextMenu("GenerateMesh")]
    private void Generate()
    {
        GetComponent<MeshFilter>().mesh=mesh=new Mesh();
        mesh.name="Procedural Grid";
        int xSize = 9;
        int ySize = 9;

        Vector3[] vertices=new Vector3[(xSize+1)*(ySize+1)];
        for(int i = 0, y = 0; y<=ySize; y++)
        {
            for(int x = 0; x<=xSize; x++, i++)
            {
                vertices[i]=new Vector3(x,0,y);
            }
        }
        mesh.vertices=vertices;

        int[] triangles = new int[xSize*ySize*6];
        for(int ti = 0, vi = 0, y = 0; y<ySize; y++, vi++)
        {
            for(int x = 0; x<xSize; x++, ti+=6, vi++)
            {
                triangles[ti]=vi;
                triangles[ti+3]=triangles[ti+2]=vi+1;
                triangles[ti+4]=triangles[ti+1]=vi+xSize+1;
                triangles[ti+5]=vi+xSize+2;
            }
        }
        Vector2[] uv = new Vector2[vertices.Length];
        Vector4[] tangents = new Vector4[vertices.Length];
        Vector4 tangent = new Vector4(1f,0f,0f,-1f);
        for(int i = 0, y = 0; y<=ySize; y++)
        {
            for(int x = 0; x<=xSize; x++, i++)
            {
                vertices[i]=new Vector3(x,y);
                uv[i]=new Vector2((float)x/xSize,(float)y/ySize);
                tangents[i]=tangent;
            }
        }
        mesh.triangles=triangles;
        mesh.uv=uv;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        GetComponent<MeshCollider>().sharedMesh=mesh;
    }
}