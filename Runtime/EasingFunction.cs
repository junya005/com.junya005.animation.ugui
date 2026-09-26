using UnityEngine;

namespace junya005.Animation.uGUI
{
    /// <summary>
    /// <para xml:lang="ja">イージング関数を提供するクラス</para>
    /// <para xml:lang="en">This class provide easing functions.</para>
    /// </summary>
    public static class EasingFunction
    {
        // Back系のイージング関数に使用する定数
        const float c1 = 1.70158f;
        const float c3 = c1 + 1;

        public static float InQuad(float t)
        {
            // https://easings.net/#easeInQuad
            return t * t;
        }

        public static float OutQuad(float t)
        {
            // https://easings.net/#easeOutQuad
            return 1 - (1 - t) * (1 - t);
        }

        public static float InOutQuad(float t)
        {
            // https://easings.net/#easeInOutQuad
            return t < 0.5 ? 2 * t * t : 1 - ((-2 * t + 2) * (-2 * t + 2)) / 2;
        }

        public static float InCubic(float t)
        {
            // https://easings.net/#easeInCubic
            return t * t * t;
        }

        public static float OutCubic(float t)
        {
            // https://easings.net/#easeOutCubic
            return 1 - ((1 - t) * (1 - t) * (1 - t));
        }

        public static float InOutCubic(float t)
        {
            // https://easings.net/#easeInOutCubic
            return t < 0.5 ? (4 * t * t * t) : (1 - ((-2 * t + 2) * (-2 * t + 2) * (-2 * t + 2)) / 2);
        }

        public static float InSine(float t)
        {
            // https://easings.net/#easeInSine
            return 1 - Mathf.Cos((t * Mathf.PI) / 2);
        }
        public static float OutSine(float t)
        {
            // https://easings.net/#easeOutSine
            return Mathf.Sin((t * Mathf.PI) / 2);
        }
        public static float InOutSine(float t)
        {
            // https://easings.net/#easeInOutSine
            return -(Mathf.Cos(Mathf.PI * t) - 1) / 2;
        }
        public static float InBack(float t)
        {
            // https://easings.net/#easeInBack
            return c3 * t * t * t - c1 * t * t;
        }
        public static float OutBack(float t)
        {
            // https://easings.net/#easeOutBack
            return 1 + c3 * (t - 1) * (t - 1) * (t - 1) + c1 * (t - 1) * (t - 1);
        }
    }
}
