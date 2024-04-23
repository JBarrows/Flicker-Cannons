using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingBehaviour : EnemyBehaviour
{
    readonly Color subtraction = new(0,0,0,1);

    // Start is called before the first frame update
    void Start()
    {
        // Queue this object to be destroyed
        Destroy(gameObject, 0.5f);
        Destroy(GetComponent<Collider2D>());

        //StartCoroutine(Die());

        sprite.sortingOrder -= 1;
    }

    IEnumerator Die()
    {
        sprite.color = new Color(1, 1, 1, 0.5f);

        int flashes = 3;
        float t = 0.1f;
        for (int i = 0; i < 2 * flashes; i++)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(t);
        }

        yield return new WaitForSeconds(t);
        Destroy(this.gameObject);
    }

    public override void BehaveFixed()
    {
        sprite.color -= Time.fixedDeltaTime * subtraction;
    }
}
