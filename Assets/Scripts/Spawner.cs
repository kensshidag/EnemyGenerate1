using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(_enemy),
            actionOnGet: (enemy) => InitializeEnemy(enemy),
            actionOnRelease: (null),
            actionOnDestroy: (enemy) => Destroy(enemy),
            collectionCheck: true,
            defaultCapacity: 5,
            maxSize: 20);
    }

    private void Start()
    {
        StartCoroutine(TwoSecondTimer());
    }

    private void InitializeEnemy(Enemy enemy)
    {
        int randomSpawnPoint = Random.Range(0, _spawnPoints.Length);
        SpawnPoint spawnPoint = _spawnPoints[randomSpawnPoint];

        enemy.gameObject.SetActive(true);
        enemy.ResetVelocity();
        enemy.SetPosition(spawnPoint.transform.position);
        enemy.SetMaterial(spawnPoint.GetMaterial());
        enemy.SetRotation(spawnPoint.GetRandomRotation());
    }

    private IEnumerator TwoSecondTimer()
    {
        WaitForSeconds waitForSeconds = new(2f);

        while (true)
        {
            yield return waitForSeconds;
            _pool.Get();
        }
    }
}
