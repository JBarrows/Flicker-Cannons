using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float _delay = 1;
    public float _waveDuration = 2;
    public float _waveMagnitude = 0.01f;
    public float _minDelay = 0.2f;
    float _waveTime = 0;

    [SerializeField] Transform _leftBound;
    [SerializeField] Transform _rightBound;

    [SerializeField] List<GameObject> _templateEnemies;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(coSpawnEnemy());
    }

    IEnumerator coSpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);

            Vector2 pos = new (
                Random.Range(_leftBound.position.x, _rightBound.position.x),
                transform.position.y
            );
            var template = _templateEnemies[Random.Range(0, _templateEnemies.Count)];
            Instantiate(template, pos, Quaternion.identity, transform);
        }
    }

    private void Update()
    {
        _waveTime += Time.deltaTime;
        if (_waveTime > _waveDuration)
        {
            _waveTime = 0;
            _delay = Mathf.Max(_minDelay, _delay - _waveMagnitude);
        }
    }
}
