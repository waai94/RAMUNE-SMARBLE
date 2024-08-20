using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] Text kosuu;
    public Text timer;
    public GameObject glass;
    [SerializeField] Text coffeePercent;
    [SerializeField] Text MilkPercent;
    [SerializeField] GameObject tastyanimObject;
    [SerializeField] GameObject finished;
    [SerializeField] Text tastytext;

    public Animator tastyanim;

    float[] result;
    int scoreNum = 0;
    float lastscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        result = new float[10];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = 0f;
        }

        tastyanim=tastyanimObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //  Debug.Log(result.Length);
        kosuu.text = scoreNum + 1 + "/" + result.Length;
    }

    public void made(GameObject g, float score)
    {
        print("made");
        if (scoreNum < result.Length-1)  // 配列の範囲内であることを確認
        {
            result[scoreNum] = score;
            lastscore = score;
            //print("added");
            scoreNum++;
         
            coffeePercent.text = score.ToString("f1")+"%";
            MilkPercent.text = (100-score).ToString("f1") + "%";

            tastyanim.SetBool("DoAnim", true);

            if (Mathf.Abs(score - 50) <= 5)
            {
                tastytext.text = "Tasty!";
            }else if(Mathf.Abs(score - 50) <= 25)
            {
                tastytext.text = "Hummm,nice.";
            }
            else
            {
                tastytext.text = " TERRIBLE";
            }



            Instantiate(glass);

        }
        else
        {
            // Debug.LogWarning("Result array is full. Cannot add more scores.");
            finished.SetActive(true);
         
        }

       // Destroy(g);
       
    }

   public  string makestring()
    {
        string scoremozi="";
        foreach(float i in result)
        {
            scoremozi = scoremozi + i.ToString("f1")+"%  ";
        }

        
        return (lastscore+"%   "+(100-lastscore)+"%");

      
    }
}
