using System.Collections.Generic;
using UnityEngine;

public class GunArray : MonoBehaviour
{
    public List<Cannon> _cannons;
    
    [SerializeField] GUIManager _guiManager;
    
    Cannon _closestCannon;
    Vector2 _clickStart;
    Vector2 _clickEnd;
    // Start is called before the first frame update
    void Start()
    {
        if (!_guiManager)
            _guiManager = FindAnyObjectByType<GUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_guiManager && _guiManager.Paused)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            BeginFlick(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ConcludeFlick(Input.mousePosition);
        }

        //foreach (var touch in Input.touches)
        //{
        //    switch (touch.phase)
        //    {
        //        case TouchPhase.Began:
        //            cannon = getClosestCannon(touch.position);
        //            cannon.GetComponentInChildren<SpriteRenderer>().color = cannon._color;
        //            break;
        //        case TouchPhase.Moved:
        //        case TouchPhase.Stationary:
        //            break;
        //        case TouchPhase.Ended:
        //        case TouchPhase.Canceled:
        //            cannon = getClosestCannon(touch.position);
        //            cannon.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }

    private void BeginFlick(Vector2 mousePosition)
    {
        _clickStart = Camera.main.ScreenToWorldPoint(mousePosition);
        Cannon cannon = GetClosestCannon(_clickStart);
        if (cannon)
        {
            _closestCannon = cannon;
            _closestCannon.Highlight();
        }
        else
        {
            _closestCannon = null;
        }
    }

    private void ConcludeFlick(Vector2 mousePosition)
    {
        _clickEnd = Camera.main.ScreenToWorldPoint(mousePosition);
        if (_clickEnd.y < _clickStart.y)
        {
            if (_closestCannon)
            {
                _closestCannon.ResetColor();
            }
            return;
        }

        var cannon = GetClosestCannon(_clickStart);
        if (!cannon)
        {
            return;
        }

        Vector2 shotVector;
        //shotVector = clickEnd - clickStart;
        shotVector = _clickEnd - (Vector2)cannon.transform.position;

        Debug.DrawLine(_clickStart, _clickEnd, Color.white, 1f, false);
        Debug.DrawLine(
            cannon.transform.position,
            _clickEnd,
            cannon._color,
            1f,
            false
        );

        // Shoot
        if (cannon)
            cannon.Shoot(shotVector);
    }

    private Cannon GetClosestCannon(Vector2 position)
    {
        float closestDist = float.PositiveInfinity;
        Cannon closestGun = null;

        foreach (var cannon in _cannons)
        {
            if (!cannon.CanFire)
                continue; // Skip

            var dist = Mathf.Abs(position.x - cannon.transform.position.x);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestGun = cannon;
            }
        }

        return closestGun;
    }
}
