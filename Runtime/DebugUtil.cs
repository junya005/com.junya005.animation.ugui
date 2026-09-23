using UnityEngine;

namespace junya005.Animation.uGUI
{
    /// <summary>
    /// <para xml:lang="ja">
    /// パッケージ内部のDebug用Utility
    /// パッケージの利用者は使用しないでください
    /// </para>
    /// <para xml:lang="en">
    /// Utility of for debug that inside the package
    /// If you are package user, don't use.
    /// </para>
    /// </summary>
    public static class DebugUtil
    {
        private static bool _enableLogs = true;

        public static void Log(string content)
        {
#if UNITY_EDITOR
            if (_enableLogs)
            {
                Debug.Log($"[uGUI Animation] {content}");
            }
#endif
        }

        public static void LogWarning(string content)
        {
#if UNITY_EDITOR
            if (_enableLogs)
            {
                Debug.LogWarning($"[uGUI Animation] {content}");
            }
#endif
        }

        public static void LogError(string content)
        {
#if UNITY_EDITOR
            if (_enableLogs)
            {
                Debug.LogError($"[uGUI Animation] {content}");
            }
#endif
        }
    }
}
