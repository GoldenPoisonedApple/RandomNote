using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour {

    [SerializeField]
    private Transform[] stars;      //星


    public int value = 0;               //評価


    //星の色
    private Color star_color = new Color(0xff, 0xd0, 0x00);
    //星の色
    private Color star_color_default = new Color(0xff, 0xff, 0xff);

    void Start()
    {
        //リスナー設定
        for (int i=0; i<stars.Length; i++) {
            int tmp = i;
            stars[i].GetComponent<Button>().onClick.AddListener(() => { set_value(tmp); });
        }
    }

    /// <summary>
    /// 評価変更
    /// </summary>
    /// <param name="star_num">評価の数</param>
    private void set_value (int star_num) {
        int i = 0;
        //評価の数だけやる
        for ( ; i<star_num+1; i++) {
            stars[i].GetComponent<Image>().color = star_color;
        }
        //評価設定
        value = i;
        //残りを白にする
        for ( ; i < stars.Length; i++) {
            stars[i].GetComponent<Image>().color = star_color_default;
        }
    }
    
}
