using UnityEngine;

public class SnakerBehaviour : EnemyBehaviour
{
    public float _speed = 3f;
    public float _xFactor = 0.4f;
    public float _wavelength = 0.5f;
    float _t = 0;

    [SerializeField] float _x = 0f;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x * 0.7f, transform.position.y, transform.position.z);
        _t = UnityEngine.Random.value * _wavelength * Mathf.PI * 2;
    }

    public override void BehaveFixed()
    {
        _t += Time.fixedDeltaTime;
        _x = _xFactor * Mathf.Sin(_t / _wavelength);
        var v = new Vector2(_x, -_speed * Time.fixedDeltaTime);
        transform.Translate(v);
    }
}
