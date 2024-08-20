using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]

public class Mesh : MonoBehaviour
{
    [SerializeField] Transform right_up;
    [SerializeField] Transform right_down;
    [SerializeField] Transform left_up;
    [SerializeField] Transform left_down;

    private MeshFilter meshFilter;
    private Mesh myMesh;
    private Vector3[] myVertices = new Vector3[4];
    private int[] myTriangles = new int[6];

    /*
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]

    void Start()
    {
        Vector3[] myVertices = new Vector3[4];

        myVertices[0] = left_down.localPosition;
        myVertices[1] = right_down.localPosition;
        myVertices[2] = left_up.localPosition;
        myVertices[3] = right_up.localPosition;


        // メッシュの作成  
        var mesh = new Mesh();

        // 頂点座標配列をメッシュにセット  
        mesh.SetVertices(new Vector3[] {
            new Vector3 (0, 1f),
            new Vector3 (1f, -1f),
            new Vector3 (-1f, -1f),
        });

        // インデックス配列をメッシュにセット  
        mesh.SetTriangles(new int[] {
            0, 1, 2
        }, 0);

        // MeshFilterを通してメッシュをMeshRendererにセット  
        var filter = GetComponent<MeshFilter>();
        filter.sharedMesh = mesh;
   
    }
     */
}