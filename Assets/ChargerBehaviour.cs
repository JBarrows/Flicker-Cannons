using UnityEngine;

public class ChargerBehaviour : EnemyBehaviour
{
    public float _speed = 4f;

    public override void BehaveFixed()
    {
        transform.Translate(_speed * Time.fixedDeltaTime * Vector2.down);
    }
}
