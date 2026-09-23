using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace junya005.Animation.uGUI
{
    /// <summary>
    /// <para xml:lang="ja">浮遊アニメーション機能を提供するコンポーネント</para>
    /// <para xml:lang="en">Component of provide feature that float animation</para>
    /// </summary>
    public class FloatAnimation : MonoBehaviour
    {
        private const float ONE_CYCLE_OF_PI = 2f;

        [SerializeField, Tooltip("実行時に再生するか")]
        private bool _playOnAwake = true;

        [SerializeField, Tooltip("揺れの大きさ")]
        private Vector3 _animScale = Vector3.up;

        [SerializeField, Tooltip("アニメーション周期の速さ")]
        private float _animFrequency = 1.0f;

        [SerializeField, Tooltip("ループするか")]
        private bool _isLooping = true;

        [SerializeField, Tooltip("ループしない場合の再生回数")]
        private int _periodCount = 1;

        private float _time = 0.0f;
        private Vector3 _initialLocalPos = Vector3.zero;
        private bool _isPlaying = false;

        #region Public Methods

        /// <summary>
        /// <para xml:lang="ja">アニメーションを再生する</para>
        /// <para xml:lang="en">Play animation.</para>
        /// </summary>
        public void Play()
        {
            _isPlaying = true;
            DebugUtil.Log($"Playing FloatAnimation. : {this.name}");
        }

        /// <summary>
        /// <para xml:lang="ja">アニメーションを一時停止する</para>
        /// <para xml:lang="en">Pause animation.</para>
        /// </summary>
        public void Pause()
        {
            _isPlaying = false;
            DebugUtil.Log($"Pause FloatAnimation. : {this.name}");
        }

        /// <summary>
        /// <para xml:lang="ja">アニメーションを停止する</para>
        /// <para xml:lang="en">Stop animation.</para>
        /// </summary>
        public void Stop()
        {
            _isPlaying = false;
            _time = 0.0f;
            DebugUtil.Log($"Stop FloatAnimation. : {this.name}");
        }

        /// <summary>
        /// <para xml:lang="ja">ループ状態を設定する</para>
        /// <para xml:lang="en">Set loop state.</para>
        /// </summary>
        /// <param name="value">
        /// <para xml:lang="ja">設定値(boolean)</para>
        /// <para xml:lang="en">Set value.(boolean)</para>
        /// </param>
        public void SetLoop(bool value)
        {
            _isLooping = value;
            DebugUtil.Log($"LoopState Setted {_isLooping}. : {this.name}");
        }

        #endregion

        #region Unity Events

        private void Start()
        {
            _initialLocalPos = this.transform.localPosition;

            if (_playOnAwake)
            {
                Play();
            }
        }

        private void Update()
        {
            if (!_isPlaying) { return; }

            _time += Time.deltaTime;

            // 指定された周期数で止めるために、PI*を計算
            if (!_isLooping &&
                (_time * _animFrequency) >= CalculatePeriodValue(_periodCount))
            {
                // オーバーシュートを防ぎ、完全に初期座標で止まるように_animFrequencyでクランプ
                // _time = 0;は、座標が飛んでしまうバグが発生する可能性があるため採用していない
                _time = CalculatePeriodValue(_periodCount) / _animFrequency;
                Pause();
            }

            SinAnimation(_time);
        }

        #endregion

        private float CalculatePeriodValue(int count)
        {
            return Mathf.PI * (ONE_CYCLE_OF_PI * _periodCount);
        }

        private void SinAnimation(float t)
        {
            Vector3 vec = _animScale * Mathf.Sin(t * _animFrequency);
            this.transform.localPosition = _initialLocalPos + vec;
        }
    }
}
