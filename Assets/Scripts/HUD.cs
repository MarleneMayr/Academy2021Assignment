using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private EndScreen endScreen;

    private void Start()
    {
        Player.playerDied.AddListener(ShowEndScreen);
    }

    private void UpdateScore(int score)
    {
        scoreText.SetText(score.ToString());
    }

    public void ShowEndScreen(Player player, string message)
    {
        endScreen.gameObject.SetActive(true);
        endScreen.SetMessage(message);
    }
}
