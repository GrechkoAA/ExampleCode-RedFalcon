using UnityEngine;

public class OverheatedGun : Gun
{
    [SerializeField] private byte _maxShotsCount = 10;
    [SerializeField] private float _gunCoolingTime = 3;
    [SerializeField] private float _gunCoolingTimeBetweenShots = 1;

    private byte _currentNumberShots = 0;
    private bool _isGunOverheating = false;
    private float _timeLastShot;

    public event System.Action WeaponOverheated;
    public event System.Action<float> OverheatConditionChanged;

    public byte MaxShotsCount => _maxShotsCount;
    public bool IsGunOverheating => _isGunOverheating;

    private void Update()
    {
        if (_isGunOverheating == true)
            CoolGun();
        else if (_currentNumberShots > 0)
            CheckDelayLastShot(_gunCoolingTimeBetweenShots);
    }

    public override void PlayerShipShoot()
    {
        if (CanShoot())
        {
            base.PlayerShipShoot();

            _currentNumberShots++;
            _timeLastShot = 0;

            OverheatConditionChanged?.Invoke(_currentNumberShots);

            if (IsCold())
            {
                _isGunOverheating = true;
                WeaponOverheated?.Invoke();
            }
        }
    }

    private void CoolGun()
    {
        if (_currentNumberShots > 0)
            CheckDelayLastShot(_gunCoolingTime / _maxShotsCount);
        else
            _isGunOverheating = false;
    }

    private void CheckDelayLastShot(float coolingTime)
    {
        _timeLastShot += Time.deltaTime;

        OverheatConditionChanged?.Invoke(_currentNumberShots - (_timeLastShot / coolingTime));

        if (_timeLastShot >= coolingTime)
        {
            _timeLastShot = 0;
            _currentNumberShots--;
        }
    }

    private bool IsCold()
    {
        return _currentNumberShots == _maxShotsCount;
    }

    private bool CanShoot()
    {
        return _isGunOverheating == false;
    }
}