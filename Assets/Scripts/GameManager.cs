using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton reference.
    public static GameManager Instance { get; private set; }
    [SerializeField] private CollectibleFactory collectibleFactory;

    public enum GameState
    {
        Playing,
        Won
    }

    public GameState CurrentState { get; private set; }

    public int CollectedCount { get; private set; }

    [SerializeField] private int totalCollectibles = 5;

    //Observer events for score and state changes.
    public event Action<int, int> OnScoreChanged;
    public event Action<GameState> OnGameStateChanged;

    //Prevent duplicate GameManagers.
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    //Initialize score and game state.
    private void Start()
    {
        CollectedCount = 0;
        CurrentState = GameState.Playing;
    }

    //Handle a collected crystal.
    public void CollectCrystal()
    {
        //Ignore collections after winning.
        if (CurrentState != GameState.Playing)
            return;

        CollectedCount++;

        //Notify score subscribers.
        OnScoreChanged?.Invoke(
            CollectedCount, totalCollectibles);

        //Check win condition.
        if (CollectedCount >= totalCollectibles)
        {
            CurrentState = GameState.Won;
            OnGameStateChanged?.Invoke(CurrentState);
        }
    }

    //Listen for collection events.
    private void OnEnable()
    {
        Collectible.OnCollected += CollectCrystal;
    }

    //Stop listening when disabled.
    private void OnDisable()
    {
        Collectible.OnCollected -= CollectCrystal;
    }

    //Reset score, state, and collectibles.
    public void ResetGame()
    {
        CollectedCount = 0;
        CurrentState = GameState.Playing;

        collectibleFactory.ResetCollectibles();

        OnScoreChanged?.Invoke(
            CollectedCount, totalCollectibles);

        OnGameStateChanged?.Invoke(CurrentState);
    }

    //Clear Singleton reference on destruction.
    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}