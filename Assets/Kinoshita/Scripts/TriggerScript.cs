using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class TriggerScript : MonoBehaviour
{
    ParticleSystem ps;

    public int count = 0;

    // これらのリストは、各フレームでトリガーの条件に
    // 一致するパーティクルを格納します
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {
        // このフレームのトリガーの条件に一致するパーティクルを取得します
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        // トリガーに侵入したパーティクルを走査し、赤にします
        for (int i = 0; i < numEnter; i++)
        {
            count++;
        }

        Debug.Log(count);
    }
}