using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TweetButton : MonoBehaviour
{
    //[SerializeField]
    //GameObject scoreObject = null; // Textオブジェクト

    public Text scoreText;

    public Text highscoreText;

    [SerializeField]
    GameStatus datSave;


    //「つぶやく」ボタンを押したときの処理
    public void OnClickTweetButton()
    {
        scoreText.text = datSave.Score.ToString();
        highscoreText.text = PlayerPrefs.GetInt(datSave.key).ToString();

        var text = "今回の記録は『"
        + scoreText.text
        + "』点でした! \n"
        + "High Scoreは、『" + highscoreText.text + "』点でした! \n"
        + "挑戦者求む!!\n"
        + "https://www.google.com/‎\n";

        
        string[] hashtags = { "tag1", "tag2" };

        Application.OpenURL($"https://twitter.com/intent/tweet?text={UnityWebRequest.EscapeURL(text)}&hashtags={UnityWebRequest.EscapeURL(string.Join(",", hashtags))}");
    }
}

