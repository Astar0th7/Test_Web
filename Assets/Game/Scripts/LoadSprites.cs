using System.Collections.Generic;
using Game.Scripts.Root;
using Game.Scripts.Root.Services;
using Game.Scripts.Root.Services.AssetsLoader;
using UnityEngine;

public class LoadSprites : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _spriteRenderer;
    
    private ILocalAssetLoader _localAssetLoader;

    private void Start()
    {
        _localAssetLoader = ServiceLocator.Instance.Resolve<ILocalAssetLoader>();
    }

    public async void Load()
    {
        IList<Sprite> sprites = await _localAssetLoader.LoadAssetsByLabel<Sprite>(AssetLabels.SPRITES);
        LoadSprite(sprites);
    }

    private void LoadSprite(IList<Sprite> sprites)
    {
        for (int i = 0; i < _spriteRenderer.Length; i++)
        {
            if (sprites.Count <= i)
                break;
            
            _spriteRenderer[i].sprite = sprites[i];
        }
    }
}