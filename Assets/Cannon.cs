using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Breakable
{
    [SerializeField] GameObject _barrel;
    [SerializeField] SpriteRenderer _barrelRenderer;
    [SerializeField] SpriteMask _cooldownMask;
    [SerializeField] SpriteRenderer _cooldownOverlay;
    [SerializeField] float _cooldownLength = 2f;

    public Color _color;
    public Color _baseColor;

    [SerializeField] Bullet _templateBullet;
    
    float _cooldown = 0;

    public bool CanFire => !Broken && _cooldown <= 0;

    // Start is called before the first frame update
    void Start()
    {
        if (_cooldownOverlay)
        {
            _cooldownOverlay.color = Color.Lerp(_color, Color.gray, 0.7f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_cooldown > 0)
        {
            _cooldown -= Time.deltaTime;
            CoolDown();
        }
    }

    private void CoolDown()
    {
        // Fade barrel color
        if (_barrelRenderer)
        {
            if (_cooldown <= 0)
            {
                // Snap to active color
                _barrelRenderer.color = Color.white;
            }
            else
            {
                // Only go to 80% of the active color
                _barrelRenderer.color = Color.Lerp(
                    _color,
                    Color.white,
                    0.8f * (1 - (_cooldown / _cooldownLength))
                );
            }
        }

        // Progress the mosk/meter
        if (_cooldownMask)
        {
            if (_cooldown <= 0)
            {
                // Snap: Mask is hidden, base color is reset
                _cooldownMask.transform.localScale = new(1f, 0f, 1f);
                if (_renderer)
                {
                    _renderer.color = _baseColor;
                }
            }
            else
            {
                var t = _cooldown / _cooldownLength;
                _cooldownMask.transform.localScale = new(1f, 1 - t, 1f);
            }
        }
    }

    public void Highlight()
    {
        _barrelRenderer.color = _color;
    }

    public void ResetColor()
    {
        _barrelRenderer.color = Color.white;
    }

    internal void Shoot(Vector2 vector)
    {
        // Set barrel direction
        _barrel.transform.up = vector;

        var bullet = Instantiate(_templateBullet, transform.position, _barrel.transform.rotation, transform.parent);
        bullet.SetColor(_color);

        _cooldown = _cooldownLength;
        
        if (_renderer)
        {
            _renderer.color = Color.gray;
        }
    }

    public override void Break()
    {
        base.Break();
        Destroy(GetComponent<Collider2D>());
        Destroy(_renderer.gameObject);
        Destroy(_barrel);
    }
}
