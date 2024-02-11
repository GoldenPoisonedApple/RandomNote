using UnityEngine;

/// <summary>
/// フレームとして扱うインターフェース
/// </summary>
public interface I_Flame {
    /// <summary>
    /// フレーム作成
    /// </summary>
    /// <param name="flameData">フレームに必要なデータ</param>
    /// <param name="flame_num">フレーム番号</param>
    void ReflectData(I_FlameData flameData, int flame_num);
}
