using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassScript : MonoBehaviour
{//液体の単位はml
    public float GlassSize = 99999f;
    [SerializeField] float MinGlassSize = 240f;
    [SerializeField] float MaxGlassSize = 590f;
    [SerializeField] float DefaultGlassSpeed = 50f;
    [SerializeField] GameObject manager;
    [SerializeField] ChangeColor ColorScript;
    AudioSource AudioSource;
    [SerializeField] AudioClip GlassFailed;
    [SerializeField] AudioClip GlassSuccess;
    [SerializeField] AudioClip GlassSlide;

    float syutugenX = 0;

    GameObject childGlass;

    public float d1;
    public float d2;
    GameManagerScript managerScript;
    bool doonce;
    bool goRight=false;
    bool fromLeft = true;
    bool moving = false;

    bool failedsoundplayed;
    float movingfloat = 0;
    float times=10;

  public  bool failed;


    public float NowGlassTaiseki = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GlassSize = Random.Range(MinGlassSize, MaxGlassSize);
        Spawned();
        manager = GameObject.FindGameObjectWithTag("manager");
       managerScript= manager.GetComponent<GameManagerScript>();

        this.transform.position = new Vector3(-20, -4f, 0);


        childGlass = this.transform.GetChild(1).gameObject;

        GameObject grandchild = childGlass.transform.GetChild(0).gameObject;

        ColorScript = grandchild.GetComponent<ChangeColor>();
        syutugenX = Random.Range(-6f, 6);

        moving = managerScript.scoreNum > 7;

        AudioSource = this.GetComponent<AudioSource>();

        AudioSource.PlayOneShot(GlassSlide);
    
    }

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
        if (!goRight && !fromLeft)
        {
           
            
                times -= Time.deltaTime;
           
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
                if (failed&&!failedsoundplayed)
                {
                    AudioSource.PlayOneShot(GlassFailed);
                    failedsoundplayed = true;
                }
                Destroy(this.gameObject,1f);
            }
            if(myX >= syutugenX&&fromLeft)//初期位置に移動
            {
                fromLeft = false;
              
               // managerScript.tastyanim.SetBool("DoAnim",false);
            
            ;
            ;
            }
        }
        
        else if(moving)
        {
            movingfloat += Time.deltaTime*1f;
            this.transform.position = new Vector3(Mathf.Sin(movingfloat)*3f+syutugenX, -4f, 0);
        }

        ColorScript.t = d1 / NowGlassTaiseki;
        float scale = NowGlassTaiseki / GlassSize;
       
        childGlass.transform.localScale = new Vector3(1f, scale * 0.9f, 1f);

      
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

        if (!failed)
        {
            AudioSource.PlayOneShot(GlassSuccess);
        }
        doonce = true;
        if (managerScript!=null){
            managerScript.made(this.gameObject, score);
        }
       
        goRight = true;
       
    }
}
