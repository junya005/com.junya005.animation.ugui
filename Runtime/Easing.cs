using UnityEngine;

namespace junya005.Animation.uGUI
{
    /// <summary>
    /// <para xml:lang="ja">イージング関数の列挙子</para>
    /// <para xml:lang="en">Enum of easing functions.</para>
    /// </summary>
    public enum EaseType
    {
        Linear,
        InQuad,
        OutQuad,
        InOutQuad,
        InCubic,
        OutCubic,
        InOutCubic,
        InSine,
        OutSine,
        InOutSine,
        InBack,
        OutBack,
    }

    /// <summary>
    /// <para xml:lang="ja">イージング関数の機能を提供するクラス</para>
    /// <para xml:lang="en">This class provide feature that easing functions.</para>
    /// </summary>
    public struct Easing
    {
        // Back系のイージング関数に使用する定数
        const float c1 = 1.70158f;
        const float c3 = c1 + 1;

        private EaseType _currentEaseType;

        public Easing(EaseType easeType = EaseType.Linear)
        {
            _currentEaseType = easeType;
        }

        /// <summary>
        /// <para xml:lang="ja">
        /// アニメーションの現在進捗からイージング関数を適用した値を評価する
        /// </para>
        /// <para xml:lang="en">
        /// Evaluate a value with an easing function applied, based on the animation's current progress.
        /// </para>
        /// </summary>
        /// <param name="t">
        /// <para xml:lang="ja">アニメーションの現在進捗（0.0 ~ 1.0の間に正規化した値）</para>
        /// <para xml:lang="en">
        /// Current animation progress (value normalized between 0.0 and 1.0)
        /// </para>
        /// </param>
        public float Evaluate(float t)
        {
            t = Mathf.Clamp01(t);
            float result = t;

            switch (_currentEaseType)
            {
                case EaseType.InQuad:
                    // https://easings.net/#easeInQuad
                    result = t * t;
                    break;
                case EaseType.OutQuad:
                    // https://easings.net/#easeOutQuad
                    result = 1 - (1 - t) * (1 - t);
                    break;
                case EaseType.InOutQuad:
                    // https://easings.net/#easeInOutQuad
                    result = t < 0.5 ? 2 * t * t : 1 - ((-2 * t + 2) * (-2 * t + 2)) / 2;
                    break;
                case EaseType.InCubic:
                    // https://easings.net/#easeInCubic
                    result = t * t * t;
                    break;
                case EaseType.OutCubic:
                    // https://easings.net/#easeOutCubic
                    result = 1 - ((1 - t) * (1 - t) * (1 - t));
                    break;
                case EaseType.InOutCubic:
                    // https://easings.net/#easeInOutCubic
                    result = t < 0.5 ? (4 * t * t * t) : (1 - ((-2 * t + 2) * (-2 * t + 2) * (-2 * t + 2)) / 2);
                    break;
                case EaseType.InSine:
                    // https://easings.net/#easeInSine
                    result = 1 - Mathf.Cos((t * Mathf.PI) / 2);
                    break;
                case EaseType.OutSine:
                    // https://easings.net/#easeOutSine
                    result = Mathf.Sin((t * Mathf.PI) / 2);
                    break;
                case EaseType.InOutSine:
                    // https://easings.net/#easeInOutSine
                    result = -(Mathf.Cos(Mathf.PI * t) - 1) / 2;
                    break;
                case EaseType.InBack:
                    // https://easings.net/#easeInBack
                    result = c3 * t * t * t - c1 * t * t;
                    break;
                case EaseType.OutBack:
                    // https://easings.net/#easeOutBack
                    result = 1 + c3 * (t - 1) * (t - 1) * (t - 1) + c1 * (t - 1) * (t - 1);
                    break;
                case EaseType.Linear:
                default:
                    // Linearの結果はtそのままのため、何も処理しない
                    break;
            }

            return result;
        }
    }
}
