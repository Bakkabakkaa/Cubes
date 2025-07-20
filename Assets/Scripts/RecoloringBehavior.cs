using UnityEngine;

public class RecoloringBehavior : MonoBehaviour
{
    [SerializeField] 
    private float _recoloringDuration;

    [SerializeField]
    private float _delayBeforeColorChange;

    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;

    private float _recoloringTime;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }

    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0f, 1f);
    }

    private void Update()
    {
        _recoloringTime += Time.deltaTime;

        var progress = _recoloringTime / _recoloringDuration;
        var currentColor = Color.Lerp(_startColor, _nextColor, progress);
        _renderer.material.color = currentColor;

        if (_recoloringTime >= _recoloringDuration)
        {
            _recoloringTime = -_delayBeforeColorChange;
            GenerateNextColor();
        }
    }
}
