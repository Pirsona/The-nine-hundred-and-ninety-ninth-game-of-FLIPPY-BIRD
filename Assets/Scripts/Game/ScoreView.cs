using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private Score _score;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    
    private void OnEnable()
    {
        _score.ScoreChanged += UpdateView;
    }

    private void OnDisable()
    {
        _score.ScoreChanged -= UpdateView;
    }

    private void UpdateView(int score)
    {
        _text.text = score.ToString();
    }
}