using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField] private Animation scoreAnimation;
    [SerializeField] private ParticleSystem psScore;
    [SerializeField] private ParticleSystem psDeath;
    [SerializeField] private ParticleSystem psDeathFloor;

    private void Start()
    {
        Player.playerDied.AddListener(StartParticles);
        Player.scoreChanged.AddListener(StartScoreEffect);
    }

    private void StartParticles(Player player, string message)
    {
        // check which particle system has to be applied depending on the player's position
        var playerScreenPos = Camera.main.WorldToScreenPoint(player.transform.position);
        var ps = playerScreenPos.y < 0 ? psDeathFloor : psDeath;

        ps.transform.position = player.transform.position;
        ps.Play();
    }

    private void StartScoreEffect(int newScore)
    {
        scoreAnimation.Play();
        psScore.Play();
    }
}
