using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LinkScene : MonoBehaviour {
    public string SceneName = "";
    public bool Async = true;
    public bool AsyncAutoMove = false;
    public Slider loadSlider = null;
    private Slider _loadSlider { get{ return loadSlider; } }
    private float _Progress = 0.0f;
    public float Progress { get { return _Progress; } }
    public bool ProgressHide = false;
    public GameObject hint = null;
    private AsyncOperation async;
    public GameObject DontDestory = null;

    private void GameLoad()
    {
        SceneManager.LoadScene(SceneName);
    }

    private IEnumerator GameSceneLoad()
    {
        async = SceneManager.LoadSceneAsync(SceneName);
        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
        {
            _Progress = async.progress + 0.1f;
            if(_loadSlider != null)
            {
                _loadSlider.value = _Progress;
            }
            yield return new WaitForEndOfFrame();
        }
        if (_loadSlider != null)
        {
            _loadSlider.value = 1f;
            ProgressEnded();
        }
        if (AsyncAutoMove)
        {
            async.allowSceneActivation = true;
        }
    }

    private void ProgressEnded()
    {

        if (ProgressHide)
        {
            if (_loadSlider != null)
            {
                _loadSlider.gameObject.SetActive(false);
            }
            if (hint != null)
            {
                hint.SetActive(true);
            }
        }
    }

    public void Move()
    {
        if (DontDestory != null)
        {
            DontDestroyOnLoad(DontDestory);
        }
        async.allowSceneActivation = true;
    }

    private void Start()
    {
        if (Async)
        {
            StartCoroutine(GameSceneLoad() );
        }
        else
        {
            GameLoad();
        }
    }

}
