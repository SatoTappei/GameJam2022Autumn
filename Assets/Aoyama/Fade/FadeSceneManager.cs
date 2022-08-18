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
    [Header("é©å»éQè∆")]
    [SerializeField]
    Animator _fadeAnimator;
    

    private void Start()
    {
        if(_isStartFade )
        {
            _fadeAnimator!.Play("FadeOut");
        }
    }

    public void SceneChange(string sceneName)
    {
        StartCoroutine(SceneChangeCor(sceneName));
    }

    IEnumerator SceneChangeCor(string sceneName)
    {
        _fadeAnimator!.Play("FadeIn");
        yield return new WaitForSeconds(_fadeTime);
        SceneManager.LoadScene(sceneName);
    }
}
