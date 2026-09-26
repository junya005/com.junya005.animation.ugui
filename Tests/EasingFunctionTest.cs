using NUnit.Framework;

namespace junya005.Animation.uGUI.Tests
{
    /// <summary>
    /// イージング関数のテスト用のクラス
    /// </summary>
    public class EasingFunctionTest
    {
        private const float Tolerance = 0.00001f;

        [Test]
        [TestCase(0.0f, 0.0f)]
        [TestCase(1.0f, 1.0f)]
        public void EaseQuadBoundariesTest(float t, float expected)
        {
            // Quad系の境界値テスト
            Assert.That(EasingFunction.InQuad(t), Is.EqualTo(expected).Within(Tolerance));
            Assert.That(EasingFunction.OutQuad(t), Is.EqualTo(expected).Within(Tolerance));
            Assert.That(EasingFunction.InOutQuad(t), Is.EqualTo(expected).Within(Tolerance));
        }

        [Test]
        public void EaseQuadMidPointTest()
        {
            // InQuadの代表値テスト
            // 0.5 * 0.5 = 0.25
            const float expectedInQuadMidPoint = 0.25f;
            float actual = EasingFunction.InQuad(0.5f);
            Assert.That(actual, Is.EqualTo(expectedInQuadMidPoint).Within(Tolerance));

            // OutQuadの代表値テスト
            // 1 - (1 - 0.5) * (1 - 0.5) = 1 - 0.5 * 0.5 = 0.75
            const float expectedOutQuadMidPoint = 0.75f;
            actual = EasingFunction.OutQuad(0.5f);
            Assert.That(actual, Is.EqualTo(expectedOutQuadMidPoint).Within(Tolerance));

            // InOutQuadの代表値テスト
            // 1 - ((-2 * 0.5 + 2) * (-2 * 0.5 + 2)) / 2 = 1 - (1 * 1) / 2 = 0.5
            const float expectedInOutQuadMidPoint = 0.5f;
            actual = EasingFunction.InOutQuad(0.5f);
            Assert.That(actual, Is.EqualTo(expectedInOutQuadMidPoint).Within(Tolerance));
        }

        [Test]
        [TestCase(0.0f, 0.0f)]
        [TestCase(1.0f, 1.0f)]
        public void EaseCubicBoundariesTest(float t, float expected)
        {
            // Cubic系の代表値テスト
            Assert.That(EasingFunction.InCubic(t), Is.EqualTo(expected).Within(Tolerance));
            Assert.That(EasingFunction.OutCubic(t), Is.EqualTo(expected).Within(Tolerance));
            Assert.That(EasingFunction.InOutCubic(t), Is.EqualTo(expected).Within(Tolerance));
        }

        [Test]
        public void EaseCubicMidPointTest()
        {
            // InCubicの代表値テスト
            // 0.5 * 0.5 * 0.5 = 0.125
            const float expectedInCubicMidPoint = 0.125f;
            float actual = EasingFunction.InCubic(0.5f);
            Assert.That(actual, Is.EqualTo(expectedInCubicMidPoint).Within(Tolerance));

            // OutCubicの代表値テスト
            // 1 - ((1 - 0.5) * (1 - 0.5) * (1 - 0.5)) = 1 - (0.5 * 0.5 * 0.5) = 1 - 0.125 = 0.875
            const float expectedOutCubicMidPoint = 0.875f;
            actual = EasingFunction.OutCubic(0.5f);
            Assert.That(actual, Is.EqualTo(expectedOutCubicMidPoint).Within(Tolerance));

            // InOutCubicの代表値テスト
            // 1 - ((-2 * t + 2) * (-2 * t + 2) * (-2 * t + 2)) / 2 =
            // 1 - (1 * 1 * 1) / 2 =
            // 0.5
            const float expectedInOutCubicMidPoint = 0.5f;
            actual = EasingFunction.InOutCubic(0.5f);
            Assert.That(actual, Is.EqualTo(expectedInOutCubicMidPoint).Within(Tolerance));
        }

        [Test]
        [TestCase(0.0f, 0.0f)]
        [TestCase(1.0f, 1.0f)]
        public void EaseSineBoundariesTest(float t, float expected)
        {
            // Sine系の代表値テスト
            Assert.That(EasingFunction.InSine(t), Is.EqualTo(expected).Within(Tolerance));
            Assert.That(EasingFunction.OutSine(t), Is.EqualTo(expected).Within(Tolerance));
            Assert.That(EasingFunction.InOutSine(t), Is.EqualTo(expected).Within(Tolerance));
        }

        [Test]
        [TestCase(0.0f, 0.0f)]
        [TestCase(1.0f, 1.0f)]
        public void EaseBackBoundariesTest(float t, float expected)
        {
            // Back系の代表値テスト
            Assert.That(EasingFunction.InBack(t), Is.EqualTo(expected).Within(Tolerance));
            Assert.That(EasingFunction.OutBack(t), Is.EqualTo(expected).Within(Tolerance));
        }
    }
}
