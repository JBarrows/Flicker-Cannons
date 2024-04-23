using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : Breakable
{
    [SerializeField] List<HullPiece> _pieces;

    public override void Break()
    {
        foreach (var piece in _pieces)
        {
            if (piece.Broken)
                continue;

            piece.Break();
            return;
        }

        // TODO: Game Over
        base.Break();
        foreach (var gun in FindObjectsByType<Cannon>(FindObjectsSortMode.None))
        {
            if (!gun.Broken)
                gun.Break();

            busted.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_pieces.Count == 0)
        {
            _pieces.AddRange(GetComponentsInChildren<HullPiece>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
