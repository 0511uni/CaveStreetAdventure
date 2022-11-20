using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ランキングページのスクリーンショット制御
/// </summary>
public class RankingScreenShot : MonoBehaviour
{
    [SerializeField]
    GameObject waterMark;

    [SerializeField]
    GameObject[] gameObjects;

    void Start() => waterMark.SetActive(false);

    /// <summary>
    /// ScreenShotのボタンを押したとき
    /// </summary>
    public void ShotButtonDown()
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }

        waterMark.SetActive(true);

        // スクリーンショットをギャラリーに保存
        StartCoroutine(TakeScreenshotAndSave());
    }

    /// <summary>
    /// スクリーンショットをギャラリーに保存
    /// </summary>
    /// <returns></returns>
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

        foreach (var gameObject in gameObjects)
        {
            gameObject.SetActive(true);
        }

        waterMark.SetActive(false);
    }
}
