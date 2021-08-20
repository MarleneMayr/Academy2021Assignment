using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private EndScreen endScreen;

    private void Start()
    {
        Player.playerDied.AddListener(ShowEndScreen);
        Player.scoreChanged.AddListener(UpdateScore);
    }

    private void UpdateScore(int score)
    {
        scoreText.SetText(score.ToString());
    }

    private void ShowEndScreen(Player player, string message)
    {
        endScreen.gameObject.SetActive(true);
        endScreen.SetMessage(message);
    }
}
