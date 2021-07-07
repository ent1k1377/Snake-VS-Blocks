using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int _destroyPriceRange;
    [SerializeField] private int _destroyPrice;
    [SerializeField] private Color[] _colors;

    private SpriteRenderer _spriteRenderer;
    private int _filling;

    public int LeftToFill => _destroyPrice - _filling;

    public event UnityAction<int> FillingUpdated;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetColor(_colors[Random.Range(0, _colors.Length - 1)]);

        _destroyPrice = Random.Range(_destroyPriceRange.x, _destroyPriceRange.y);
        FillingUpdated?.Invoke(LeftToFill);
    }

    public void Fill()
    {
        _filling++;
        FillingUpdated?.Invoke(LeftToFill);

        if (_filling == _destroyPrice)
            Destroy(gameObject);
    }

    private void SetColor(Color color)
    {
        _spriteRenderer.material.color = color;
    }
}
