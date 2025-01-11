using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private Vector3 _direction;

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

    public void Init(Vector3 spawnPosition, Material material, Vector3 direction)
    {
        SetPosition(spawnPosition);
        _renderer.material = material;
        _direction = direction;
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
        transform.position = Vector3.MoveTowards(transform.position, _direction, _speed * Time.deltaTime);
        transform.LookAt(_direction);
    }
}
