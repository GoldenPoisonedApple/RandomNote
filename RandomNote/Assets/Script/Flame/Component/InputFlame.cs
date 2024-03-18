using UnityEngine;

public class InputFlame : MonoBehaviour
{
	[SerializeField]
	private GameObject flameParent;     //プレハブ配置場所

	public void SetFlame(int flame_num, I_FlameData flameData, I_TagControl tagControl, GameObject flamePrehub)
	{
		// プレハブ配置場所の子オブジェクトを全て削除
		foreach (Transform child in flameParent.transform){ Destroy(child.gameObject); }
		// flamePrehubをインスタンスして配置
		GameObject instance = Instantiate(flamePrehub);
		//親設定
		instance.transform.SetParent(flameParent.transform, false);

		//データ反映
		instance.GetComponent<I_Flame>().Reflect(flame_num, flameData, tagControl);
	}
}