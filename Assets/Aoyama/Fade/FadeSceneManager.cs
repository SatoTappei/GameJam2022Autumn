using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeSceneManager : MonoBehaviour
{
    [SerializeField]
    private bool _isStartFade = false;
    [SerializeField]
    private float _fadeTime = 1f;
    [SerializeField]
    private string _sceneName = "Title";
    [Header("é©å»éQè∆")]
    [SerializeField]
    Animator _fadeAnimator;
    

    private void Awake()
    {
        if(_isStartFade )
        {
            _fadeAnimator!.Play("FadeOut");
        }
    }

    public void SceneChange()
    {
        StartCoroutine(SceneChangeCor());
    }

    IEnumerator SceneChangeCor()
    {
        _fadeAnimator!.Play("FadeIn");
        yield return new WaitForSeconds(_fadeTime);
        SceneManager.LoadScene(_sceneName);
    }
}
