using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed;
    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] TrailRenderer _trail;
    [SerializeField] Gradient _gradient;
    [SerializeField] float _lifespan = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifespan);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Time.fixedDeltaTime * _speed * Vector2.up, Space.Self);
    }

    public void SetColor(Color color)
    {
        _sprite.color = color;
        _gradient.colorKeys = new GradientColorKey[] { new GradientColorKey(color, 0) };
        _trail.colorGradient = _gradient;
    }
}
