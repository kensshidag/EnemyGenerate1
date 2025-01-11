using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public Vector3 GetDirection()
    {
        return _direction;
    }

    public Material GetMaterial()
    {
        return _renderer.material;
    }
}
