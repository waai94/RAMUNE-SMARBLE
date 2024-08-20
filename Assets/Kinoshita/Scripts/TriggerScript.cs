using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class TriggerScript : MonoBehaviour
{
    ParticleSystem ps;

    public int count = 0;

    // �����̃��X�g�́A�e�t���[���Ńg���K�[�̏�����
    // ��v����p�[�e�B�N�����i�[���܂�
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {
        // ���̃t���[���̃g���K�[�̏����Ɉ�v����p�[�e�B�N�����擾���܂�
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        // �g���K�[�ɐN�������p�[�e�B�N���𑖍����A�Ԃɂ��܂�
        for (int i = 0; i < numEnter; i++)
        {
            count++;
        }

        Debug.Log(count);
    }
}