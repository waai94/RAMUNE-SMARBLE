using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Material drink1_material;
    [SerializeField] private Material drink2_material;

 public float t = 1f;

    Color _color;

    void Start()
    {
        //オブジェクトの色をRGBA値を用いて変更する
        _color = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
        GetComponent<Renderer>().material.color = Color.Lerp(drink1_material.color, drink2_material.color, t);
    }
}
