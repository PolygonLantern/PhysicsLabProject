using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GoalsManager _goalsManager;
    public TMP_Text scoreText;
    public TMP_Text messageText;

    private void Start()
    {
        _goalsManager = GoalsManager.GM;
    }

    private void Update()
    {
        scoreText.text = $"Score: " + ScoreManager.Score;
        messageText.text = _goalsManager.message;
    }
}
