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
    [SerializeField] GameObject milkanim;
    [SerializeField] GameObject coffeeanim;
    [SerializeField] GameObject OkaneText;

    public Animator tastyanim;

    public float[] result;
    public float[] okane = new float[10];
    public int scoreNum = 0;
    float lastscore = 0;

    float lastokane = 0;

    bool failed;
    // Start is called before the first frame update
    void Start()
    {
        result = new float[10];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = 0f;
        }

        tastyanim = tastyanimObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //  Debug.Log(result.Length);
        kosuu.text = scoreNum + 1 + "/" + result.Length;
        OkaneText.GetComponent<Text>().text = "+" + lastokane.ToString() + "yen";
    }

    public void made(GameObject g, float score)
    {
        print("made");

        coffeePercent.text = score.ToString("f1") + "%";
        MilkPercent.text = (100 - score).ToString("f1") + "%";

        // tastyanim.SetBool("DoAnim", true);

        tastyanim.Play("TastyAnim", 0, 0);
        milkanim.GetComponent<Animator>().Play("milkanim");
        coffeeanim.GetComponent<Animator>().Play("CoffeeAnim");
        OkaneText.GetComponent<Animator>().Play("okaneAnim");


        failed = false;
        if (Mathf.Abs(score - 50) <= 5)
        {
            tastytext.text = "Tasty!";
        }
        else if (Mathf.Abs(score - 50) <= 25)
        {
            tastytext.text = "Hummm,nice.";
        }
        else
        {
            tastytext.text = " やりなおし！！";
            failed = true;
        }


        float kasegi = 200 + ((100 - (Mathf.Abs(score - 50f)) * 2) * 2);
        if (failed || g.GetComponent<GlassScript>().failed)
        {
            kasegi = 0;
        }
        kasegi = Mathf.Floor(kasegi);
        lastscore = score;
        lastokane = kasegi;
        if (scoreNum < result.Length - 1)  // 配列の範囲内であることを確認
        {
            result[scoreNum] = score;



            okane[scoreNum] = kasegi;

            //print("added");
            scoreNum++;



            Instantiate(glass);

        }
        else
        {
            // Debug.LogWarning("Result array is full. Cannot add more scores.");
            finished.SetActive(true);
            finished.GetComponent<Animator>().Play("TastyAnim");

        }

        // Destroy(g);

    }

    public string makestring()
    {
        string scoremozi = "";
        foreach (float i in result)
        {
            scoremozi = scoremozi + i.ToString("f1") + "%  ";
        }


        return (lastscore + "%   " + (100 - lastscore) + "%");


    }
}
