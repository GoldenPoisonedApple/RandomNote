using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainScreen : MonoBehaviour
{
	[SerializeField]
	private Transform frameViewer;      //フレームビュワー
	[SerializeField]
	private Transform wordFrame;        //ワードフレーム


	//定数
	const int FRAME_SPACE = 50;         //フレーム間隔

	/*
	void Start() {
			//データ読み込み
			WordDataWrapper wordDataWrapper = WordDataManager.Load();
			//フレーム作成
			createFrame(wordDataWrapper);
	}

	/// <summary>
	/// 単語フレーム作成、配置
	/// </summary>
	private void createFrame (WordDataWrapper wordDataWrapper) {
			//フレームビュワー位置設定
			frameViewer.position = new Vector2(0f, 0f);
			//フレームビュワー高さ設定
			float frame_viewer_height = 0;

			//データの数だけ繰り返し
			for (int i = 0; i < wordDataWrapper.WordDataList.Count; i++)
			{

					//フレームインスタンス生成
					GameObject frame_instance = Instantiate(wordFrame.gameObject, frameViewer.position, Quaternion.identity);
					//フレーム高さ取得
					float frame_height = frame_instance.GetComponent<RectTransform>().sizeDelta.y;
					frame_viewer_height += frame_height + FRAME_SPACE;
					//位置設定
					frame_instance.transform.position = new Vector2(frameViewer.position.x, -((frame_height + FRAME_SPACE) * i + FRAME_SPACE));
					//親子関係構築    第二引数:相対的な大きさにスケールを変更するか
					frame_instance.transform.SetParent(frameViewer, false);
			}

			//フレームビュワー高さ変更
			frameViewer.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, frame_viewer_height + FRAME_SPACE);
	}
	*/

}
