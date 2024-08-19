using UnityEngine;
using UnityEngine.InputSystem;
public class CurrentInputTest : MonoBehaviour
{

    float movin = 0;
    [SerializeField] int PlayerNum = 1;
    [SerializeField] float speed = 2;
    void Update()
    {
        print(Input.GetAxis("Horizontal" + PlayerNum));
        movin = Input.GetAxis("Horizontal" + PlayerNum);

        this.transform.position+=new Vector3(movin*speed, 0, 0)*Time.deltaTime;

        float tilt = (Input.GetAxis("Tilt" + PlayerNum)+1)*0.5f;
        if (PlayerNum == 1)
        {
            tilt *= -1;
        }
        Vector3 localAngle = this.transform.localEulerAngles;
        localAngle.z = Mathf.Lerp(0, 180, tilt);
        this.transform.eulerAngles = localAngle;


    }
}