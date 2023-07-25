using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanvasFade : MonoBehaviour
{
		enum eFadeType
		{
			fade_in,
			fade_out
		};

		private float _alpha = 1.0f;

		private bool _isFading = false;

		[SerializeField]
		private eFadeType fadeType = eFadeType.fade_in;
		[SerializeField]
		private float fadingDuration = 1.0f;    //Time for fading
		private float fadeSpeed = 1.0f;

		[SerializeField]
		private bool _startFadeOnAwake = false;

		[SerializeField]
		private UnityEvent onCompleteEvent;

		private CanvasGroup _canvasGroup;

		void Awake()
		{
			if (fadeType == eFadeType.fade_in)
				_alpha = 0;
			else if (fadeType == eFadeType.fade_out)
				_alpha = 1.0f;

			_canvasGroup = GetComponent<CanvasGroup>();
			if (_canvasGroup == null)
				Debug.LogError("[warning] CanvasFadeScript: please add a Canvas Group to the Canvas");

			if (fadingDuration > 0)
				fadeSpeed = 1 / fadingDuration;

			if (_startFadeOnAwake)
				StartFading();
		}



		public void StartFading()
		{
			setCanvasAlpha();
			_isFading = true;
		}

		void setCanvasAlpha()
		{
			if (_canvasGroup != null) _canvasGroup.alpha = _alpha;
		}


		void Update()
		{
			if (_isFading)
			{
				if (fadeType == eFadeType.fade_in)
				{
					_alpha += Time.deltaTime * fadeSpeed;
					if (_alpha > 0.95f)
						onFadeCompleted();
				}
				else if (fadeType == eFadeType.fade_out)
				{
					_alpha -= Time.deltaTime * fadeSpeed;
					if (_alpha < 0.05f)
						onFadeCompleted();
				}

				setCanvasAlpha();
			}
		}

		public void onFadeCompleted()
		{
			_isFading = false;

			//Call On Complete Here
			if (onCompleteEvent != null)
				onCompleteEvent.Invoke();
		}
}
