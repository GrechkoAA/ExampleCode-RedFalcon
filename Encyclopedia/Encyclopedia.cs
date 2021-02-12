using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Encyclopedia : MonoBehaviour
{
    public const string OpenState = "IsOpen";
    public const string UScene = "Encyclopedia";

    [SerializeField] private List<EncyclopediaData> _encyclopediaData;
    [SerializeField] private Transform _content;
    [SerializeField] private EncyclopediaButton _button;
    [SerializeField] private Transform _pageContainer;
    [SerializeField] private float _destroyTime;

    public Animator EncyclopediaAnimator;

    private void Awake()
    {
        ShownData();
    }

    public void Close()
    {
        EncyclopediaAnimator.SetBool(OpenState, !EncyclopediaAnimator.GetBool(OpenState));
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_destroyTime);
        SceneManager.UnloadSceneAsync(UnloadScene);
    }

    private void ShownData()
    {
        for (int i = 0; i < _encyclopediaData.Count - 1; i++)
        {
            if (PlayerPrefs.HasKey(_encyclopediaData[i].name))
            {
                EncyclopediaButton button = Instantiate(_button, _content);
                button.Init(_encyclopediaData[i], _pageContainer);
            }
        }
    }
}
