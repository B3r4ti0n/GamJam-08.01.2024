using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class CinematicController : MonoBehaviour
{
    [SerializeField]
    private RawImage m_videoRawImage;
    [SerializeField]
    private AudioSource m_AudioSource;
    [SerializeField]
    private VideoPlayer m_VideoPlayer;
    [SerializeField]
    private GameObject m_HideVideo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisableGameObjectAfterDelay());

        m_VideoPlayer.prepareCompleted += VideoPrepared;

        m_VideoPlayer.loopPointReached += VideoEndReached;

        m_VideoPlayer.Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DisableGameObjectAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);

        m_HideVideo.SetActive(false);

        
    }


    void VideoPrepared(VideoPlayer vp)
    {
        m_AudioSource.Play();
        m_videoRawImage.texture = vp.texture;
        vp.Play();
    }

    void VideoEndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("MenuScene 1");
    }

}
