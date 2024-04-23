using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _renderer;

    public bool Broken { get; protected set; } = false;

    public UnityEvent busted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _renderer.color += 2f * Time.deltaTime * Color.white;
    }

    public virtual void Break()
    {
        Broken = true;
    }
}
