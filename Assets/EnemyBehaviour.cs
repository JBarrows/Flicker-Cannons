using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    public SpriteRenderer sprite { get; set; }

    public abstract void BehaveFixed();
}
