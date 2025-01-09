using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private Rigidbody _rigidbody;
    private Renderer _renderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        MoveStraight();
    }

    public void ResetVelocity()
    {
        if (_rigidbody.velocity != Vector3.zero)
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    public void SetPosition(Vector3 position)
    {
        position.y += transform.localScale.y;
        transform.position = position;
    }

    public void SetMaterial(Material material)
    {
        _renderer.material = material;
    }

    public void SetRotation(Quaternion rotation)
    {
        gameObject.transform.rotation = rotation;
    }

    private void MoveStraight()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }
}
