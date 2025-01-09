using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SpawnPoint : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public Material GetMaterial()
    {
        return _renderer.material;
    }

    public Quaternion GetRandomRotation()
    {
        float maxRotationDegree = 360f;
        float randomRotation = Random.Range(0, maxRotationDegree);

        return Quaternion.Euler(0, randomRotation, 0);
    }
}
