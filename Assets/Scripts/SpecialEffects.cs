using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SpecialEffects : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] private Animation scoreAnimation;

    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem psScore;
    [SerializeField] private ParticleSystem psDeath;
    [SerializeField] private ParticleSystem psDeathFloor;

    [Header("Sounds")]
    [SerializeField] private AudioClip sfxScore;
    [SerializeField] private AudioClip sfxDeath;
    [SerializeField] private AudioClip sfxColorSwitch;

    private AudioSource audioSource;

    private void Start()
    {
        Player.playerDied.AddListener(StartDeathParticles);
        Player.scoreChanged.AddListener(StartScoreEffects);
        Player.colorChanged.AddListener(StartColorChanged);
        audioSource = GetComponent<AudioSource>();
    }

    private void StartDeathParticles(Player player, string message)
    {
        // check which particle system has to be applied depending on the player's position
        var playerScreenPos = Camera.main.WorldToScreenPoint(player.transform.position);
        var ps = playerScreenPos.y < 0 ? psDeathFloor : psDeath;

        ps.transform.position = player.transform.position;
        ps.Play();

        audioSource.clip = sfxDeath;
        audioSource.Play();
    }

    private void StartScoreEffects(int newScore)
    {
        scoreAnimation.Play();
        psScore.Play();

        audioSource.clip = sfxScore;
        audioSource.Play();
    }

    private void StartColorChanged(int newColorIndex)
    {
        audioSource.clip = sfxColorSwitch;
        audioSource.Play();
    }
}
