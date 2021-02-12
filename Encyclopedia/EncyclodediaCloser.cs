using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EncyclodediaCloser : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Encyclopedia _encyclopedia;

    public void OnPointerClick(PointerEventData eventData)
    {
        _encyclopedia.Close();
    }
}
