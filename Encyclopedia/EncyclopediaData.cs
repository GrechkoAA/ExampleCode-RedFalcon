using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "New EncyclopediaData", menuName = "Encyclopedia Data", order = 51)]
public class EncyclopediaData : ScriptableObject
{
    [SerializeField] private Sprite _spriteShip;
    [SerializeField] private string _shipName;
    [SerializeField] private string _shipDiscription;

    public Sprite SpriteShip => _spriteShip;
    public string NameShip => _shipName;
    public string ShipDiscription => _shipDiscription;
}
