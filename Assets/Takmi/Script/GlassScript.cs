using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassScript : MonoBehaviour
{//âtëÃÇÃíPà ÇÕml
    public float GlassSize = 99999f;
    [SerializeField] float MinGlassSize = 240f;
    [SerializeField] float MaxGlassSize = 590f;
    [SerializeField] float DefaultGlassSpeed = 50f;
    [SerializeField] GameObject manager;
    [SerializeField] ChangeColor ColorScript;

    float syutugenX = 0;

    GameObject childGlass;

    public float d1;
    public float d2;
    GameManagerScript managerScript;
    bool doonce;
    bool goRight=false;
    bool fromLeft = true;
    bool moving = false;
    float movingfloat = 0;
    float times=15;

    bool failed;


    public float NowGlassTaiseki = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GlassSize = Random.Range(MinGlassSize, MaxGlassSize);
        Spawned();
        manager = GameObject.FindGameObjectWithTag("manager");
       managerScript= manager.GetComponent<GameManagerScript>();

        this.transform.position = new Vector3(-30, -2f, 0);


        childGlass = this.transform.GetChild(1).gameObject;

        GameObject grandchild = childGlass.transform.GetChild(0).gameObject;

        ColorScript = grandchild.GetComponent<ChangeColor>();
        syutugenX = Random.Range(-6f, 6);    }

    // Update is called once per frame
    void Update()
    {
        NowGlassTaiseki = d1 + d2;
       // print(NowGlassTaiseki + "ml/" + GlassSize + "ml");
     //   Debug.Log(NowGlassTaiseki + "ml/" +GlassSize+"ml");
        if (NowGlassTaiseki >= GlassSize&&!doonce)
        {
            filled();
        }
        else
        {
           // print(doonce);
        }

        if (goRight||fromLeft)
        {
            if (failed)
            {
                this.transform.position += new Vector3(0, -DefaultGlassSpeed, 0) * Time.deltaTime;
            }
            else
            {
                this.transform.position += new Vector3(DefaultGlassSpeed, 0, 0) * Time.deltaTime;
            }

            float myX = this.transform.position.x;
            float myY = this.transform.position.y;

            if (myX >= 25f||myY<=-10f)
            {
                Destroy(this.gameObject);
            }
            if(myX >= syutugenX&&fromLeft)//èâä˙à íuÇ…à⁄ìÆ
            {
                fromLeft = false;
                times = 15f;
                managerScript.tastyanim.SetBool("DoAnim",false);
                print("FALSE");
            ;
            ;
            }
        }
        else if(moving)
        {
            movingfloat += Time.deltaTime*1f;
            this.transform.position = new Vector3(Mathf.Sin(movingfloat)*3f, -2f, 0);
        }

        ColorScript.t = d1 / NowGlassTaiseki;
        float scale = NowGlassTaiseki / GlassSize;
       
        childGlass.transform.localScale = new Vector3(1f, scale * 0.9f, 1f);

        times -= Time.deltaTime;
        managerScript.timer.text = times.ToString("f1");
        if (times <= 0f&&!doonce)
        {
            failed=true;
            filled();
            
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

    void filled()
    {
        float score = 0;

       

        if (!failed)
        {
             score = (d1 / (d1 + d2) * 100);
        }
        if (Mathf.Abs(score - 50) >= 25)
        {
            failed = true;
        }
        doonce = true;
        if (managerScript!=null){
            managerScript.made(this.gameObject, score);
        }
       
        goRight = true;
       
    }
}
