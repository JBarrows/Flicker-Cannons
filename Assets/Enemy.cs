using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyBehaviour _behaviour;
    public SpriteRenderer _sprite;

    // Start is called before the first frame update
    void Start()
    {
        if (!_behaviour)
            _behaviour = GetComponent<EnemyBehaviour>();

        if (!_sprite)
            _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_behaviour)
            _behaviour.BehaveFixed();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            Die();
            FindAnyObjectByType<Scoreboard>().Score++;
            return;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            var breakable = collision.GetComponent<Breakable>();
            if (breakable && !breakable.Broken)
            {
                breakable.Break();
                Die();
                return;
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //        Debug.Log("COLLISION " + collision.gameObject.name);
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
    //    {
    //        var breakable = collision.gameObject.GetComponent<Breakable>();
    //        if (breakable && !breakable.Broken)
    //        {
    //            breakable.Break();
    //            Die();
    //            return;
    //        }
    //    }
    //}

    void Die()
    {
        if (_sprite)
            _sprite.color = new Color(0.8f, 0.8f, 0.8f, 0.5f);

        if (!_behaviour || !_behaviour.enabled)
        {
            Destroy(gameObject);
            return;
        }

        // Activate dying behaviour
         Destroy(_behaviour);
        _behaviour = gameObject.AddComponent<DyingBehaviour>();
        _behaviour.sprite = _sprite;
    }
}
