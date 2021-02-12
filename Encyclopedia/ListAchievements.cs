using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListAchievements : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _layoutGroup;
    [SerializeField] private AchievementsPage _achievementTemplate;
    [SerializeField] private List<AchievementData> _achievementData;
    [SerializeField] private Transform _content;
    [SerializeField] private int _paddingTop;

    private void Awake()
    {
        CreateList();
    }

    private void CreateList()
    {
        AchievementsPage newElementAchievement = null;

        for (int i = 0; i < _achievementData.Count; i++)
        {
            newElementAchievement = Instantiate(_achievementTemplate, _content);

            newElementAchievement.transform.position += GetPosition(i);
            newElementAchievement.Init(_achievementData[i]);               
        }

        SetPaddingTop((int)newElementAchievement.GetComponent<RectTransform>().anchoredPosition.y);
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3(0, -_paddingTop * i, 0);
    }

    private void SetPaddingTop(int position)
    {   
        _layoutGroup.padding.top = -position + _paddingTop;
    }
}