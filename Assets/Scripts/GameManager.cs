using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Paddle playerPaddle;
    [SerializeField] private Paddle computerPaddle;
    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text computerScoreText;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Image blackOverlay;
    private int playerScore;
    private int computerScore;
    private bool isPaused;

    private void Start()
    {
        NewGame();
        // Ensure the UI is hidden at the start
        resumeButton.gameObject.SetActive(false);
        blackOverlay.gameObject.SetActive(false);
        isPaused = false;
        // Add click listener to the Resume button
        resumeButton.onClick.AddListener(ResumeGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NewGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void NewGame()
    {
        SetPlayerScore(0);
        SetComputerScore(0);
        NewRound();
    }

    public void NewRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();

        CancelInvoke();
        Invoke(nameof(StartRound), 1f);
    }

    private void StartRound()
    {
        ball.AddStartingForce();
    }

    public void OnPlayerScored()
    {
        SetPlayerScore(playerScore + 1);
        NewRound();
    }

    public void OnComputerScored()
    {
        SetComputerScore(computerScore + 1);
        NewRound();
    }

    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
    }

    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }

    private void TogglePauseMenu()
    {
        isPaused = !isPaused;

        resumeButton.gameObject.SetActive(isPaused);
        blackOverlay.gameObject.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void ResumeGame()
    {
        isPaused = false;

        // Hide UI elements
        resumeButton.gameObject.SetActive(false);
        blackOverlay.gameObject.SetActive(false);

        // Resume game
        Time.timeScale = 1f;
    }

}