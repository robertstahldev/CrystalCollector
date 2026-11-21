using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text victoryText;
    [SerializeField] private TMP_Text resetText;

    //Subscribe after GameManager initializes; refresh UI.
    private void Start()
    {
        GameManager.Instance.OnScoreChanged += UpdateScore;
        GameManager.Instance.OnGameStateChanged += UpdateGameState;
        UpdateScore(GameManager.Instance.CollectedCount, 5);
        UpdateGameState(GameManager.Instance.CurrentState);
    }

    //Display current score.
    private void UpdateScore(int collected, int total)
    {
        scoreText.text = $"Crystals: {collected} / {total}";
    }

    //Show win and restart messages after victory.
    private void UpdateGameState(GameManager.GameState state)
    {
        victoryText.gameObject.SetActive(
            state == GameManager.GameState.Won
        );
        resetText.gameObject.SetActive(
            state == GameManager.GameState.Won
        );
    }

    //Unsubscribe when disabled.
    private void OnDisable()
    {
        if (GameManager.Instance == null)
            return;

        GameManager.Instance.OnScoreChanged -= UpdateScore;
        GameManager.Instance.OnGameStateChanged -= UpdateGameState;
    }
}