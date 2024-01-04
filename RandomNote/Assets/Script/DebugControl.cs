using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebugControl {

    /// <summary>
    /// ���O�\���p
    /// </summary>
    public static void Log (string message)
    {
        Debug.Log(message);
    }

    /// <summary>
    /// �G���[�\���p
    /// </summary>
    public static void Error (System.Exception message) {
        Debug.Log(message);
    }
    public static void Error(string message) {
        Debug.Log(message);
    }
}
