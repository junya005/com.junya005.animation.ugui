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
                    result = EasingFunction.InQuad(t);
                    break;
                case EaseType.OutQuad:
                    result = EasingFunction.OutQuad(t);
                    break;
                case EaseType.InOutQuad:
                    result = EasingFunction.InOutQuad(t);
                    break;
                case EaseType.InCubic:
                    result = EasingFunction.InCubic(t);
                    break;
                case EaseType.OutCubic:
                    result = EasingFunction.OutCubic(t);
                    break;
                case EaseType.InOutCubic:
                    result = EasingFunction.InOutCubic(t);
                    break;
                case EaseType.InSine:
                    result = EasingFunction.InSine(t);
                    break;
                case EaseType.OutSine:
                    result = EasingFunction.OutSine(t);
                    break;
                case EaseType.InOutSine:
                    result = EasingFunction.InOutSine(t);
                    break;
                case EaseType.InBack:
                    result = EasingFunction.InBack(t);
                    break;
                case EaseType.OutBack:
                    result = EasingFunction.OutBack(t);
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
