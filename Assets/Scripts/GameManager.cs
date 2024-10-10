using UnityEngine.UI;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject PlayButton;
    public GameObject gameOver;
  private int score;

  AudioManager audioManager;
  private void Awake()
  {
    Application.targetFrameRate = 144;
    Pause ();

    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
  }
  public void Play()
  {
    score = 0;
    scoreText.text = score.ToString();

    PlayButton.SetActive(false);
    gameOver.SetActive(false);

    Time.timeScale = 1f;
    player.enabled = true;

    Pipes[] pipes = FindObjectsOfType<Pipes>();
    for (int i = 0; i < pipes.Length; i++){
        Destroy(pipes[i].gameObject);
    }
  }
  public void Pause()
  {
    Time.timeScale = 0f;
    player.enabled = false;
  }
  public void GameOver()
  {
    gameOver.SetActive(true);
    PlayButton.SetActive(true);
    Pause();

  }
  public void IncreaseScore()
  {
    score++;
    scoreText.text = score.ToString();
  }
}
