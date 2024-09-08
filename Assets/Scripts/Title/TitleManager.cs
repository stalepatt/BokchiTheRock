using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public Animation LogoAnimation;
    public TextMeshProUGUI LogoText;

    public GameObject Title;

    private void Awake()
    {
        LogoAnimation.gameObject.SetActive(true);
        Title.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(LoadGameCoroutine());
    }

    private IEnumerator LoadGameCoroutine()
    {
        Logger.Log($"{GetType()}::LoadGameCoroutine");
        LogoAnimation.Play();
        yield return new WaitForSeconds(LogoAnimation.clip.length);
        
        LogoAnimation.gameObject.SetActive(false);
        Title.SetActive(true);
    }
}
