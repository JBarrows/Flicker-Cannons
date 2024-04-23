using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] List<SpriteRenderer> _panels;
    [SerializeField] float _speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        if (!_camera)
            _camera = Camera.main;

        if (_panels.Count == 0)
            _panels.AddRange(GetComponentsInChildren<SpriteRenderer>());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var pnl in _panels)
        {
            if (pnl.transform.position.y < _camera.ViewportToWorldPoint(Vector3.zero).y)
            {
                pnl.transform.Translate(((pnl.size.y * 3) - 0.1f - (_speed * Time.deltaTime)) * Vector3.up);
            }
            else
            {
                pnl.transform.Translate(_speed * Time.deltaTime * Vector3.down);
            }

        }
    }
}
