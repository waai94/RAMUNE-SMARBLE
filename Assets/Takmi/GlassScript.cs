using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassScript : MonoBehaviour
{//‰t‘Ì‚Ì’PˆÊ‚Íml
    public float GlassSize = 99999f;
    [SerializeField] float MinGlassSize = 240f;
    [SerializeField] float MaxGlassSize = 590f;
    [SerializeField] GameObject manager;
    public float d1;
    public float d2;
    GameManagerScript managerScript;
    bool doonce;


    public float NowGlassTaiseki = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GlassSize = Random.Range(MinGlassSize, MaxGlassSize);
        Spawned();
        manager = GameObject.FindGameObjectWithTag("manager");
       managerScript= manager.GetComponent<GameManagerScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        NowGlassTaiseki = d1 + d2;
     //   Debug.Log(NowGlassTaiseki + "ml/" +GlassSize+"ml");
        if (NowGlassTaiseki >= GlassSize&&!doonce)
        {
            float score = (d1 / (d1 + d2) * 100);
            doonce = true;
            managerScript.made(this.gameObject,score);
        }


    }

    public void Spawned()
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject i in Players)
        {
            CurrentInputTest o = i.GetComponent<CurrentInputTest>();
            o.resetData(this.gameObject);
        }
    }
}
