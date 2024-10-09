using System.Collections;
using Game.Scripts.Root.Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private float _duration;
    
    private LoadSprites _loadSprites;
    private Coroutine _animation;
    private float _nextAlpha;
    private float _leftTime;

    private void Start()
    {
        _loadSprites = ServiceLocator.Instance.Resolve<LoadSprites>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_animation == null)
        {
            _loadSprites.Load();
            _animation = StartCoroutine(AlphaBlinking());
        }
    }

    private IEnumerator AlphaBlinking()
    {
        Color imageColor = _image.color;
        _nextAlpha = Mathf.Approximately(imageColor.a, 1) ?  0 : 1;
        _leftTime = _duration;
        
        while (true)
        {
            _leftTime -= Time.deltaTime;
            imageColor.a = Mathf.Abs(_nextAlpha - _leftTime / _duration);
            _image.color = imageColor;
            
            if (_leftTime <= 0)
            {
                imageColor.a = _nextAlpha;
                _nextAlpha = Mathf.Approximately(imageColor.a, 1) ?  0 : 1;
                _leftTime = _duration;
            }
            
            yield return null;
        }
    }    
}