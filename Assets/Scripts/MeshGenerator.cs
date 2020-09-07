﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    private Mesh mesh;
    
    private Vector3[] vertices;

    private int[] triangles;
    [SerializeField] private int xSize = 200;
    [SerializeField] private int zSize = 200;
    
    MeshCollider meshCollider;
    
    
    void Start()
    {
        mesh = new  Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
       
        
        CreateShape();
        UpdateMesh();

     
    }

    private void CreateShape()
    {
        
        vertices = new Vector3[(xSize +1)*(zSize +1 )];
        for (int i = 0,z = 0; z <= zSize ; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {

                float y = Mathf.PerlinNoise(x *.3f,  z *.3f) * 2f;
                vertices[i] = new   Vector3(x,y,z);
             i++;
            }
        }
        triangles = new int[xSize * zSize * 6];   
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {     
            for (int x = 0; x < xSize; x++)
            {
                
                triangles[tris] = vert;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1 ;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;
                vert++;
                tris+=6;
                
                
            }

            vert++;
        }
        
       


        //Bu alanda tek mesh yaratmak için örnek 
        // vertices = new Vector3[]
        // {
        //     new Vector3(0,0,0), 
        //     new Vector3(0,0,1), 
        //     new Vector3(1,0,0), 
        //     new Vector3(1,0,1) 
        // };
        //
        // triangles = new int[]
        // {
        //     0,1,2,1,3,2
        // };
    }

    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

    }

    // ekranda detayları görmek için her kordinata bir daire koyuyor.
    // private void OnDrawGizmos()
    // {
    //     if (vertices == null )
    //     {
    //         return;
    //     }
    //
    //     for (int i = 0; i < vertices.Length; i++)
    //     {
    //         Gizmos.DrawSphere(vertices[i], .1f);
    //     }
    // }
}