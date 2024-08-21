using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{

    [SerializeField] Transform tareru;
    [SerializeField] bool isRight;
    ParticleSystem.EmissionModule mEmObj;

    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem ParticleObj = GetComponent<ParticleSystem>();
        mEmObj = ParticleObj.emission;
    }

    // Update is called once per frame
    void Update()
    {

        var scale = tareru.localScale;
        var spr = scale.x - 0.4f;
        spr = spr * 0.7f;

        var val = 0f;
        if (isRight)
        {
            val = RightTrigger.val;
        }
        else
        {
            val = LeftTrigger.val;
        }


        spr *= (val - 0.2f);

        var num = Mathf.Max(val - 0.53f, 0);
        if (num > 0) { num += 0.4f; }

        mEmObj.rate = new ParticleSystem.MinMaxCurve(num * 30);





        if (spr > 1) { spr = 0.8f; }
        if (spr < 0.1) { spr = 0.1f; }
        this.transform.localScale = new Vector3(spr, spr, spr);
    }
}
