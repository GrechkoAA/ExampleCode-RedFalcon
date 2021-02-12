using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaButton : MonoBehaviour
{
    [SerializeField] private Image _shipImage;
    [SerializeField] private TMP_Text _shipName;
    [SerializeField] private EncyclopediaPage _page;

    private Transform _pageContainer;
    private EncyclopediaData _data;

    public void Init(EncyclopediaData data,Transform pageContainer)
    {
        _pageContainer = pageContainer;
        _data = data;
        _shipImage.sprite = _data.SpriteShip;
        _shipName.text = _data.NameShip.ToString();
    }

    public void OnPageCreateClick()
    {
        EncyclopediaPage page = Instantiate(_page, _pageContainer);
        page.Init(_data);
    }
}
