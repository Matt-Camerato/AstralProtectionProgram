using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerCountdown : MonoBehaviour
{
    public static event Action<float> Move = delegate { };

    [Header("Countdown Settings")]
    [SerializeField, Tooltip("The length of the countdown (in seconds)")] private float _countdownLength = 1f;
    [SerializeField, Tooltip("The player's color when the countdown starts")] private Color _startColor;
    [SerializeField, Tooltip("The player's color when the countdown ends")] private Color _endColor;
    [SerializeField, Tooltip("The player's color when the countdown starts")] private Vector2 _startScale;
    [SerializeField, Tooltip("The player's color when the countdown ends")] private Vector2 _endScale;
    public float Count;

    private SpriteRenderer _playerSprite;

    private void Start()
    {
        _playerSprite = GetComponent<SpriteRenderer>();

        Count = _countdownLength; //initialize count
    }

    private void Update()
    {
        if (GameplayManager.Instance.gameIsOver) return; //dont move if game is over

        //update player and scale color based on count
        _playerSprite.color = Color.Lerp(_endColor, _startColor, Count);
        _playerSprite.transform.localScale = Vector2.Lerp(_endScale, _startScale, Count);

        Count -= Time.deltaTime; //decrement count

        if (Count > 0) return; //check if countdown is over

        Move(Count); //call the delegate
        Count = _countdownLength; //reset count
    }
}
