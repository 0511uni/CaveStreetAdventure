using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// MenuScene全体を制御する
/// </summary>
public class MainManager : MonoBehaviour
{
    /// <summary>
    /// Menuに遷移する
    /// </summary>
    public void GameMenuStart() => SceneManager.LoadScene("TitleMenuScene");

    /// <summary>
    /// 定数定義：壁方向
    /// </summary>
    public const int WALL_FRONT = 1;  // 前
    public const int WALL_RIGHT = 2;  // 右
    public const int WALL_BACK = 3;   // 後
    public const int WALL_LEFT = 4;   // 左

    public GameObject panelWalls;     // 壁全体

    private int wallNo;               // 現在向いている位置


    void Start()
    {
        Screen.SetResolution(400, 710, false, 60);
        wallNo = WALL_FRONT;// スタート時点では「前」を向く
    }

    /// <summary>
    /// ゲーム終了ボタンを押したら実行する
    /// </summary>
    public void GameEnd()
    {
        print("z");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL("http://www.yahoo.co.jp/");
#else
        Application.Quit();
#endif
    }

    /// <summary>
    /// 右(>)ボタンを押した
    /// </summary>
    public void PushButtonRight()
    {
        wallNo++;   // 方向を一つ右に
        // 「左」の1つ右は「前」
        if (wallNo > WALL_LEFT)
        {
            wallNo = WALL_FRONT;
        }
        DisplayWall(); // 壁表示更新
    }

    /// <summary>
    /// 左(>)ボタンを押した
    /// </summary>
    public void PushButtonLeft()
    {
        wallNo--; // 方向を一つ左に
        // 「前」の1つ右は「左」
        if (wallNo < WALL_FRONT)
        {
            wallNo = WALL_LEFT;
        }
        DisplayWall(); // 壁表示更新
    }

    /// <summary>
    /// 壁の動き
    /// </summary>
    void DisplayWall()
    {
        switch (wallNo)
        {
            case WALL_FRONT:
                panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case WALL_RIGHT:
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
                break;
            case WALL_BACK:
                panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                break;
            case WALL_LEFT:
                panelWalls.transform.localPosition = new Vector3(-3000.0f, 0.0f, 0.0f);
                break;
        }

    }
}

