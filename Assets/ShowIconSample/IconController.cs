using UnityEngine;

public class IconController : MonoBehaviour
{
    [SerializeField]
    GameObject[] icon;

    int icons;

    public int Icons
    {
        get => icons;
        set
        {
            if (value < 0 || value > icon.Length)
            {
                return;
            }

            icons = value;

            for (int i = 0; i < icon.Length; i++)
            {
                icon[i].SetActive(i < value);//省略化


                
                //三項演算子
                //(i < value ? true : false)


                //展開
                //if (i < value)
                //{
                //    icon[i].SetActive(true);//(i < value ? true : false)
                //}
                //else
                //{
                //    icon[i].SetActive(false);//(i < value ? true : false)
                //}//(i < value ? true : false)
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Icons++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Icons--;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log(Icons);
        }
    }
}