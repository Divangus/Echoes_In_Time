using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlCompleted : MonoBehaviour
{
    public bool[] lvlCompleted;

    bool fadeIn = false;
    bool fadeOut = false;
    public float fadeTime = 1.0f;
    CanvasGroup canv;

    string sceneToChange;
    bool destroyEverything;

    float alpha = 0.0f;
    public AudioClip _lvlComplete;
    AudioSource source;

    bool getCanvas = false;

    void Awake()
    {
        if (CompareTag("Untagged")) Debug.Log("OBJECT NEEDS A TAG");

        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        //Don't reset Slider when reloading the scene
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();

        GetCanvas();
        //canv.alpha = 1.0f;
    }

    private void Update()
    {
        if (getCanvas)
        {
            GetCanvas();
            getCanvas = false;
        }

        if (fadeIn)
        {
            alpha -= Time.deltaTime / fadeTime;
            canv.alpha = alpha;

            if(alpha <= 0.0f)
            {
                fadeIn = false;
            }
        }

        if (fadeOut)
        {
            alpha += Time.deltaTime / fadeTime;
            canv.alpha = alpha;

            if (alpha >= 1.0f)
            {
                fadeOut = false;
                fadeIn = true;
                RealChangeScene();
                getCanvas = true;
            }
        }
    }

    public void ChangeScene(string sceneName = "", bool destroy = false)
    {
        destroyEverything = destroy;
        fadeOut = true;

        if (sceneName == "") return;
        sceneToChange = sceneName;
    }

    void GetCanvas()
    {
        canv = GameObject.Find("transition").GetComponent<CanvasGroup>();
        if (canv == null) Debug.Log("Can't find 'transition' object");
        Debug.Log("canvas found!");
    }

    void RealChangeScene()
    {
        LevelBlackBoard bb = FindObjectOfType<LevelBlackBoard>();
        if (bb != null)
        {
            bb.ResetValues();
            if(destroyEverything) bb.DestroyEverything();
        }

        SceneManager.LoadScene(sceneToChange);
    }

    public void PlayAudio(AudioClip ac)
    {
        source.PlayOneShot(ac);
    }
}

