using UnityEngine;

[ExecuteAlways] // �Đ����Ă��Ȃ��Ԃ����W�Ɣ��a���ω�����悤��
public class WaterRenderer : MonoBehaviour
{
    [SerializeField] private Material material; // �X���C���p�̃}�e���A��

    private const int MaxSphereCount = 256; // ���̍ő���i�V�F�[�_�[���ƍ��킹��j
    private readonly Vector4[] _spheres = new Vector4[MaxSphereCount];
    [SerializeField] SphereCollider[] _drink1Colliders;
    //[SerializeField] SphereCollider[] _drink2colliders;

    private void Start()
    {
        // �q��SphereCollider�����ׂĎ擾
        _drink1Colliders = GetComponentsInChildren<SphereCollider>();

        // �V�F�[�_�[���� _SphereCount ���X�V
        material.SetInt("_SphereCount", _drink1Colliders.Length);
    }

    private void Update()
    {
        // �q��SphereCollider�̕������A_spheres �ɒ��S���W�Ɣ��a�����Ă���
        for (var i = 0; i < _drink1Colliders.Length; i++)
        {
            var col = _drink1Colliders[i];
            var t = col.transform;
            var center = t.position;
            var radius = t.lossyScale.x * col.radius;
            // ���S���W�Ɣ��a���i�[
            _spheres[i] = new Vector4(center.x, center.y, center.z, radius);
        }

        // �V�F�[�_�[���� _Spheres ���X�V
        material.SetVectorArray("_Spheres", _spheres);
    }
}
