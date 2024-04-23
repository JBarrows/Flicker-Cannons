using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    private int _score = 0;

    [SerializeField] TMPro.TMP_Text text;

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            text.text = string.Format("{0:D4}", _score);
        }
    }

    private void Start()
    {
        if (!text)
        {
            text = GetComponent<TMPro.TMP_Text>();
        }
    }

    public void Reset()
    {
        Score = 0;
    }
}
