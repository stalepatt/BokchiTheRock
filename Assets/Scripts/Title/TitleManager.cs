using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public Animation LogoAnimation;
    public TextMeshProUGUI LogoText;

    public GameObject Title;
    public Slider LoadingSlider;
    public TextMeshProUGUI LoadingProgressText;

    private AsyncOperation m_AsyncOperation;

    private void Awake()
    {
        LogoAnimation.gameObject.SetActive(true);
        Title.SetActive(false);
    }

    private void Start()
    {
        UserDataManager.Instance.LoadUserData();
        if (UserDataManager.Instance.ExistsSaveData == false)
        {
            UserDataManager.Instance.SetDefaultUserData();
            UserDataManager.Instance.SaveUserData();
        }

        StartCoroutine(LoadGameCoroutine());
    }

    private IEnumerator LoadGameCoroutine()
    {
        Logger.Log($"{GetType()}::LoadGameCoroutine");

        LogoAnimation.Play();
        yield return new WaitForSeconds(LogoAnimation.clip.length);

        LogoAnimation.gameObject.SetActive(false);
        Title.SetActive(true);

        m_AsyncOperation = SceneLoader.Instance.LoadSceneAsync(SceneType.Lobby);
        if (m_AsyncOperation == null)
        {
            Logger.Log("Lobby async loading error");
            yield break;
        }

        m_AsyncOperation.allowSceneActivation = false;

        LoadingSlider.value = 0.5f;
        LoadingProgressText.text = $"{(int)(LoadingSlider.value * 100)}%";
        yield return new WaitForSeconds(0.5f);

        while (!m_AsyncOperation.isDone)
        {
            LoadingSlider.value = m_AsyncOperation.progress < 0.5f ? 0.5f : m_AsyncOperation.progress;
            LoadingProgressText.text = ((int)(LoadingSlider.value * 100)).ToString();
            if (m_AsyncOperation.progress >= 0.9f)
            {
                m_AsyncOperation.allowSceneActivation = true;
                yield break;
            }

            yield return null;
        }
    }
}