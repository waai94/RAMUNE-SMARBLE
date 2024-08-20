using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] Text kosuu;
    public Text timer;
    public GameObject glass;

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
    }

    // Update is called once per frame
    void Update()
    {
        //  Debug.Log(result.Length);
        kosuu.text = scoreNum + 1 + "/" + result.Length;
    }

    public void made(GameObject g, float score)
    {
        
        if (scoreNum < result.Length)  // ”z—ñ‚Ì”ÍˆÍ“à‚Å‚ ‚é‚±‚Æ‚ðŠm”F
        {
            result[scoreNum] = score;
            lastscore = score;
            //print("added");
            scoreNum++;
        }
        else
        {
            // Debug.LogWarning("Result array is full. Cannot add more scores.");
         
        }

       // Destroy(g);
        Instantiate(glass);
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
