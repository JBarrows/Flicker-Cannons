using System.Collections;
using UnityEngine;

public class BomberBehaviour : EnemyBehaviour
{
    public float _speed = 4f;

    public GameObject missilePrefab;
    public Vector3 targetPosition;
    public float shootInterval = 1f;
    public float slowDownDistance = 1f;

    private bool isMoving = true;

    float t = 0f;
    void MoveToTarget()
    {
        t += Time.deltaTime * _speed * 0.01f;
        transform.position = Vector3.Lerp(transform.position, targetPosition, t);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isMoving = false;
            StartCoroutine(ShootMissiles());
        }
    }

    IEnumerator ShootMissiles()
    {
        while (true)
        {
            Instantiate(missilePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(shootInterval);
        }
    }

    public override void BehaveFixed()
    {
        //transform.Translate(_speed * Time.fixedDeltaTime * Vector2.down);

        if (isMoving)
        {
            MoveToTarget();
        }
    }
}
