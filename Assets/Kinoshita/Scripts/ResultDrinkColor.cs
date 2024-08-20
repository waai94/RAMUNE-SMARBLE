using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDrinkColor : MonoBehaviour
{
    [SerializeField] GameObject[] fluids;

    [SerializeField] Material drink1_material;
    [SerializeField] Material drink2_material;

    [SerializeField] GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < fluids.Length; i++)
        {
            fluids[i].GetComponent<Renderer>().material.color = Color.Lerp(drink1_material.color, drink2_material.color, gameManager.result[i] / 100f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        for (int i = 0; i < fluids.Length; i++)
        {
            var rand = Random.Range(0f, 1f);
            fluids[i].GetComponent<Renderer>().material.color = Color.Lerp(drink1_material.color, drink2_material.color, gameManager.result[i]);
        }
        */
    }
}
