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
    float MaxNeedTilt = 150;

    GameObject glass;
    GlassScript GS;
    private void Start()
    {
       resetData();


    }
    void Update()
    {
   
        movin = Input.GetAxis("Horizontal" + PlayerNum);

        this.transform.position+=new Vector3(movin*speed, 0, 0)*Time.deltaTime;

        //‚±‚±‚Ü‚ÅˆÚ“®

        float tilt = (Input.GetAxis("Tilt" + PlayerNum)+1)*0.5f;
        if (PlayerNum == 1)
        {
            tilt *= 1f;
           
        }
        Vector3 localAngle = this.transform.localEulerAngles;
        if(PlayerNum == 1)
        {
            localAngle.z = Mathf.Lerp(0, -180, tilt);
        }
        else
        {
            localAngle.z = Mathf.Lerp(0, 180, tilt);
        }
        this.transform.eulerAngles = localAngle;
        // ‚±‚±‚Ü‚Å‰ñ“]


        float nowAngle = Mathf.Abs(localAngle.z);
       
        
           // Debug.Log(NeedTilt + " DOBODOBO "+nowAngle);

            if (nowAngle >= NeedTilt)
            {
                print("YOU ARE DOBODOBO");
           
                GS.NowGlassTaiseki += 1;
            }

        
    
        //‚±‚±‚Ü‚Å‰t‘Ì‚ªo‚é‚©‚Ì”»’è


    }

    public void resetData()
    {
        NeedTilt = Random.Range(MinNeedTilt, MaxNeedTilt);
        glass = GameObject.FindGameObjectWithTag("glass");
        GS = glass.GetComponent<GlassScript>();



    }
}