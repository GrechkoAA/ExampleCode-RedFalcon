using UnityEngine;
using Random = UnityEngine.Random;

public class Scout : Alien
{
    [SerializeField] private int _amplitude = 35;
    [SerializeField] private float _frequency = 0.75f;

    private float _snakeMovementDuration = 0;

    private void Start()
    {
        _frequency = GetRandomFrequence(_frequency);
    }

    protected override void Update()
    {
        if (State == AlienState.Active)
            MoveSnake();
        else
            base.Update();
    }

    private float GetRandomFrequence(float number) => Random.Range(0, 3) == 0 ? number : -number;

    private void MoveSnake()
    {
        _snakeMovementDuration += Time.deltaTime;

        transform.Translate(Vector3.down * (Speed) * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, (Mathf.Sin(_snakeMovementDuration * _frequency) * _amplitude));
    }
}