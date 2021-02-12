using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(OverheatedGun))]
public class WeaponOverheatingBar : MonoBehaviour
{
    [SerializeField] private OverheatedGun _overheatedGun;
    [SerializeField] private Slider _overheatingBar;

    public void RefreshBar(float currentCount)
    {
        if (_overheatedGun.IsGunOverheating == true)
            SmoothlyRefreshBar(currentCount);
        else
            RefreshBarIncrements(currentCount);
    }

    private void SmoothlyRefreshBar(float currentCount) =>
        _overheatingBar.value = GetNormalizedValueBar(currentCount);

    private void RefreshBarIncrements(float currentCount) =>
        _overheatingBar.value = GetNormalizedValueBar(Mathf.Ceil(currentCount));

    private float GetNormalizedValueBar(float value) =>
     _overheatingBar.maxValue / _overheatedGun.MaxShotsCount* value;


    private void OnEnable()
    {
        _overheatedGun.OverheatConditionChanged += RefreshBar;
    }

    private void OnDisable()
    {
        _overheatedGun.OverheatConditionChanged -= RefreshBar;
    }
}