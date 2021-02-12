using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EncyclopediaPage : MonoBehaviour
{
    [SerializeField] private Image _imageShip;
    [SerializeField] private TMP_Text _headline;
    [SerializeField] private TMP_Text _description;

    public void Init(EncyclopediaData encyclopediaData)
    {
        _imageShip.sprite = encyclopediaData.SpriteShip;
        _headline.text = encyclopediaData.NameShip.ToString();
        _description.text = encyclopediaData.ShipDiscription.ToString();
    }

    public void OnCloseClick()
    {
        Destroy(gameObject);
    }
}
