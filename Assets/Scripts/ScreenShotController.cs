using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotController : MonoBehaviour
{
    [SerializeField]
    GameObject waterMark;

    [SerializeField]
    GameObject[] canvasAlls;

    [SerializeField]
    GameObject[] gameObjects;

    void Start()
    {
        waterMark.SetActive(false);
    }

    public void ShotButtonDown()
    {
        foreach (var canvasAll in canvasAlls)
        {
            canvasAll.SetActive(false);
        }
        waterMark.SetActive(true);
        // スクリーンショットをギャラリーに保存
        StartCoroutine(TakeScreenshotAndSave());
    }

    public void ShotPlusButtonDown()
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
        waterMark.SetActive(true);
        // スクリーンショットをギャラリーに保存
        StartCoroutine(TakeScreenshotAndSave());
    }

    

    // スクリーンショットをギャラリーに保存
    private IEnumerator TakeScreenshotAndSave()
    {
        yield return new WaitForEndOfFrame();

        // スクリーンショットの取得
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // スクリーンショットをギャラリーに保存
        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(
            ss, "GalleryTest", "Image.png",
            (success, path) => Debug.Log("Media save result: " + success + " " + path)
        );
        Debug.Log("Permission result: " + permission);

        // メモリリークの回避
        Destroy(ss);

        foreach (var canvasAll in canvasAlls)
        {
            canvasAll.SetActive(true);
        }

        foreach (var gameObject in gameObjects)
        {
            gameObject.SetActive(true);
        }

        waterMark.SetActive(false);
    }
}
