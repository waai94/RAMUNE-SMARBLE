using UnityEngine;

[ExecuteAlways] // 再生していない間も座標と半径が変化するように
public class WaterRenderer : MonoBehaviour
{
    [SerializeField] private Material material; // スライム用のマテリアル

    private const int MaxSphereCount = 256; // 球の最大個数（シェーダー側と合わせる）
    private readonly Vector4[] _spheres = new Vector4[MaxSphereCount];
    [SerializeField] SphereCollider[] _drink1Colliders;
    //[SerializeField] SphereCollider[] _drink2colliders;

    private void Start()
    {
        // 子のSphereColliderをすべて取得
        _drink1Colliders = GetComponentsInChildren<SphereCollider>();

        // シェーダー側の _SphereCount を更新
        material.SetInt("_SphereCount", _drink1Colliders.Length);
    }

    private void Update()
    {
        // 子のSphereColliderの分だけ、_spheres に中心座標と半径を入れていく
        for (var i = 0; i < _drink1Colliders.Length; i++)
        {
            var col = _drink1Colliders[i];
            var t = col.transform;
            var center = t.position;
            var radius = t.lossyScale.x * col.radius;
            // 中心座標と半径を格納
            _spheres[i] = new Vector4(center.x, center.y, center.z, radius);
        }

        // シェーダー側の _Spheres を更新
        material.SetVectorArray("_Spheres", _spheres);
    }
}
