using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullPiece : Breakable
{
    [SerializeField] Sprite _brokenSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Break()
    {
        base.Break();
        _renderer.sprite = _brokenSprite;
    }
}
