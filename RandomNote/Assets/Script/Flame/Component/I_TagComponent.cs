

public interface I_TagComponent
{
	/// <summary>
	/// タグデータを反映する
	/// </summary>
	/// <param name="data">タグデータ</param>
	/// <param name="flame">フレームデータへの参照</param>
	public void ReflectData(TagData data, I_FlameData flameData);
}