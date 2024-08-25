using UnityEngine;
using UnityEngine.InputSystem;
public class CurrentInputTest : MonoBehaviour
{

    float movin = 0;
    [SerializeField] int PlayerNum = 1;
    [SerializeField] float speed = 2;
    [SerializeField] float Ikioi = 1f;
    float NeedTilt = 0;
    float MinNeedTilt = 90;
    float MaxNeedTilt = 90;
    float MaxSosogi = 120f;
    public float sosogi;
    BoxCollider child;

    public bool isHitToGlass;
    bool cap = true;

    GameObject glass;
    GlassScript GS;

    public Transform[] childTransforms;
    private void Start()
    {
        child = GetComponentInChildren<BoxCollider>();


    }
    void Update()
    {
        var leftMove = LeftMove.axis; // 右スティック入力(Vector2)
        var rightMove = RightMove.axis; // 左スティック入力(Vector2)
        var rightTrigger = RightTrigger.val; // 右トリガー入力(float) 0～1
        var leftTrigger = LeftTrigger.val; // 左トリガー入力(float) 0～1

        if (PlayerNum == 1)
        {
            movin = leftMove.x;
        }
        else
        {
            movin = rightMove.x;
        }


        this.transform.position += new Vector3(movin * speed, 0, 0) * Time.deltaTime;

        //ここまで移動

        float tilt = 0;
        //  print(leftTrigger.x);
        if (PlayerNum == 2)
        {
            tilt = leftTrigger;

        }
        else
        {
            tilt = rightTrigger;
        }

        Vector3 localAngle = this.transform.localEulerAngles;
        if (PlayerNum == 1)
        {
            localAngle.z = Mathf.Lerp(0, -180, tilt);
            //print(localAngle.z+"Angle.z "+tilt+"Tilt");
        }
        else
        {
            localAngle.z = Mathf.Lerp(0, 180, tilt);
        }
        this.transform.eulerAngles = localAngle;
        // ここまで回転


        float nowAngle = Mathf.Abs(localAngle.z);


        // Debug.Log(NeedTilt + " DOBODOBO "+nowAngle);

        if (nowAngle >= NeedTilt && isHitToGlass && !cap)
        {

            sosogi = MaxSosogi * Ikioi * ((nowAngle - NeedTilt) / 90) * Time.deltaTime;
            // Debug.Log(sosogi+"ml注いでおります。");
            if (PlayerNum == 1)
            {
                GS.d1 += sosogi;
            }
            else
            {
                GS.d2 += sosogi;
            }

        }
        else
        {
            cap = false;
        }



        //ここまで液体が出るかの判定


    }

    public void resetData(GameObject g)
    {
        //新しいグラスが出るたびに変数をリセットする
        NeedTilt = Random.Range(MinNeedTilt, MaxNeedTilt);
        glass = g;
        GS = glass.GetComponent<GlassScript>();

        Ikioi = Random.Range(0.5f, 4.5f);
        float yokoscale = Ikioi * 0.5f;
        this.transform.localScale = (new Vector3(yokoscale, 1.0f, yokoscale));
        cap = true;
        isHitToGlass = false;



    }
}