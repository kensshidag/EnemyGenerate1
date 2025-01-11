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

    private void Start()
    {
        ResetVelocity();
    }

    private void Update()
    {
        MoveStraight();
    }

    public void Initialize(Vector3 position, Material material, Quaternion rotation)
    {
        SetPosition(position);
        _renderer.material = material;
        gameObject.transform.rotation = rotation;
    }

    private void SetPosition(Vector3 position)
    {
        position.y += transform.localScale.y;
        transform.position = position;
    }

    private void ResetVelocity()
    {
        if (_rigidbody.velocity != Vector3.zero)
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void MoveStraight()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }
}
