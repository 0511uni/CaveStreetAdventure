using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinScreenShotController : MonoBehaviour
{
    [SerializeField]
    GameObject waterMark;

    [SerializeField]
    GameObject icons2;

    [SerializeField]
    GameObject[] winClauseUIObjects;

    //[SerializeField]
    //RectTransform icons;

    //private void Start()
    //{
    //    //icons = GetComponent<RectTransform>();
    //}

    public void WinShotButtonDown()
    {
        foreach (var winClauseUIObject in winClauseUIObjects)
        {
            winClauseUIObject.SetActive(false);
        }

        waterMark.SetActive(true);

        icons2.SetActive(true);
        //icons.localPosition = new Vector3(0, 292,0);
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


        foreach (var winClauseUIObject in winClauseUIObjects)
        {
            winClauseUIObject.SetActive(true);
        }

        waterMark.SetActive(false);

        icons2.SetActive(false);

        //icons.localPosition = new Vector3(0, 777, 0);
    }
}
