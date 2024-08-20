using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassScript : MonoBehaviour
{//‰t‘Ì‚Ì’PˆÊ‚Íml
    public float GlassSize = 99999f;
    [SerializeField] float MinGlassSize = 240f;
    [SerializeField] float MaxGlassSize = 590f;
    [SerializeField] float DefaultGlassSpeed = 50f;
    [SerializeField] GameObject manager;
    [SerializeField] ChangeColor ColorScript;

    GameObject childGlass;

    public float d1;
    public float d2;
    GameManagerScript managerScript;
    bool doonce;
    bool goRight=false;
    bool fromLeft = true;


    public float NowGlassTaiseki = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GlassSize = Random.Range(MinGlassSize, MaxGlassSize);
        Spawned();
        manager = GameObject.FindGameObjectWithTag("manager");
       managerScript= manager.GetComponent<GameManagerScript>();

        this.transform.position = new Vector3(-30, 0, 0);

        childGlass = this.transform.GetChild(2).gameObject;

        ColorScript = childGlass.GetComponent<ChangeColor>();
        
    }

    // Update is called once per frame
    void Update()
    {
        NowGlassTaiseki = d1 + d2;
        print(NowGlassTaiseki + "ml/" + GlassSize + "ml");
     //   Debug.Log(NowGlassTaiseki + "ml/" +GlassSize+"ml");
        if (NowGlassTaiseki >= GlassSize&&!doonce)
        {
            filled();
        }

        if (goRight||fromLeft)
        {
            this.transform.position += new Vector3(DefaultGlassSpeed, 0, 0) * Time.deltaTime;
            float myX = this.transform.position.x;

            if (myX >= 25f)
            {
                Destroy(this.gameObject);
            }
            if(myX >= 0)
            {
                fromLeft = false;
            }
        }

        ColorScript.t = d1 / NowGlassTaiseki;

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

    void filled()
    {
        float score = (d1 / (d1 + d2) * 100);
        doonce = true;
        managerScript.made(this.gameObject, score);
        goRight = true;
    }
}
