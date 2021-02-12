using UnityEngine;

[RequireComponent(typeof(OverheatedGun))]
public class WeaponOverheatingText : MonoBehaviour
{
    [SerializeField] private OverheatedGun _overheatedGun;
    [SerializeField] private GameObject _weaponOverheating;
    [SerializeField, Range(0.1f, 0.5f)] private float _flickerFrequencySeconds = 0.25f;
    [SerializeField] private byte _amountFlicker = 3;

    private byte _currentNumberFingerings = 0;
    private bool _isFlickering = false;
    private float _flickerTimer = 0;

    private void Update()
    {
        if (_isFlickering)
        {
            StartFlickering();
        }
    }

    private void ShowText()
    {
        _isFlickering = true;
    }

    private void StartFlickering()
    {
        _flickerTimer += Time.deltaTime;

        if (_flickerTimer >= _flickerFrequencySeconds)
        {
            _weaponOverheating.SetActive(!_weaponOverheating.activeSelf);

            _flickerTimer = 0;
            _currentNumberFingerings++;
        }

        if (IsCompleteFlicker())
        {
            _flickerTimer = 0;
            _currentNumberFingerings = 0;
            _isFlickering = false;
        }
    }

    private bool IsCompleteFlicker() =>
         (_currentNumberFingerings / 2) == _amountFlicker;

    private void OnEnable() =>
        _overheatedGun.WeaponOverheated += ShowText;

    private void OnDisable() =>
        _overheatedGun.WeaponOverheated -= ShowText;
}