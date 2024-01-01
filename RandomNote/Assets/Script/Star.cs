using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour {

    [SerializeField]
    private Transform[] stars;      //¯


    public int value = 0;               //•]‰¿


    //¯‚ÌF
    private Color star_color = new Color(0xff, 0xd0, 0x00);
    //¯‚ÌF
    private Color star_color_default = new Color(0xff, 0xff, 0xff);

    void Start()
    {
        //ƒŠƒXƒi[İ’è
        for (int i=0; i<stars.Length; i++) {
            int tmp = i;
            stars[i].GetComponent<Button>().onClick.AddListener(() => { set_value(tmp); });
        }
    }

    /// <summary>
    /// •]‰¿•ÏX
    /// </summary>
    /// <param name="star_num">•]‰¿‚Ì”</param>
    private void set_value (int star_num) {
        int i = 0;
        //•]‰¿‚Ì”‚¾‚¯‚â‚é
        for ( ; i<star_num+1; i++) {
            stars[i].GetComponent<Image>().color = star_color;
        }
        //•]‰¿İ’è
        value = i;
        //c‚è‚ğ”’‚É‚·‚é
        for ( ; i < stars.Length; i++) {
            stars[i].GetComponent<Image>().color = star_color_default;
        }
    }
    
}
