using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetController : MonoBehaviour
{
    public static event Action PlanetDied;

    [Header("Planet Settings")]
    public Color primaryColor, secondaryColor;
    [SerializeField] private List<Sprite> _overlaySprites;
    [SerializeField] private SpriteRenderer _primarySR, _secondarySR;
    [SerializeField] private ParticleSystem _explosionParticles;

    [Header("Health Settings")]
    [SerializeField] private int _totalHealth = 100;
    [SerializeField] private Color _healthStartColor, _healthEndColor;
    [SerializeField] private Image _planetHealthBar;

    public int health;

    private void Awake()
    {
        //set initial planet colors
        float hue = UnityEngine.Random.Range(0f, 1f);
        primaryColor = Color.HSVToRGB(hue, 1f, 1f);
        secondaryColor = Color.HSVToRGB(hue, 0.5f, 1f);

        //set planet overlay sprite
        int i = UnityEngine.Random.Range(0, _overlaySprites.Count);
        _secondarySR.sprite = _overlaySprites[i];
    }

    private void Start()
    {
        //set colors of planet
        _primarySR.color = primaryColor;
        _secondarySR.color = secondaryColor;

        ParticleSystem.MainModule particles = _explosionParticles.main;
        particles.startColor = primaryColor;

        health = _totalHealth;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        _planetHealthBar.fillAmount = (float) health / _totalHealth;
        _planetHealthBar.color = Color.Lerp(_healthEndColor, _healthStartColor, (float) health / _totalHealth);
        if (health <= 0) StartCoroutine(DeathAnimation());
    }

    private IEnumerator DeathAnimation()
    {
        _primarySR.enabled = false;
        _secondarySR.enabled = false;
        _explosionParticles.Play();
        while (_explosionParticles.particleCount > 0) yield return null;
        PlanetDied.Invoke();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            health -= 10;
            UpdateHealthBar();
            Destroy(collision.gameObject);
        }
    }
}
