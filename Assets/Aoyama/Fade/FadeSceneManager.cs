using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeSceneManager : SingletonMonoBehaviour<FadeSceneManager>
{
    [SerializeField]
    private bool _isStartFade = true;
    [SerializeField]
    private float _fadeTime = 1.5f;
    [Header("自己参照")]
    [SerializeField]
    Animator _fadeAnimator;
    

    private void Start()
    {
        if(_isStartFade )
        {
            _fadeAnimator!.Play("FadeOut");
        }
    }

    /// <summary>
    /// FadeしながらSceneChangeできる関数
    /// </summary>
    /// <param name="sceneName">移動するシーン</param>
    /// <param name="isStartFade">移動した先でFadeOutするかどうか</param>
    public void SceneChange(string sceneName)
    {
        StartCoroutine(SceneChangeCor(sceneName));
    }

    IEnumerator SceneChangeCor(string sceneName, bool isStartFade = false)
    {
        _isStartFade = isStartFade;
        _fadeAnimator!.Play("FadeIn");
        yield return new WaitForSeconds(_fadeTime);
        SceneManager.LoadScene(sceneName);
    }
}
