using System;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public static event EventHandler OnLevelDone;

    [SerializeField] private TextMeshProUGUI _remainingText;

    private int _brickCount = 0;

    private void Awake()
    {
        GridSystem.OnLevelStart += GridSystem_OnLevelStart;
        Ball.OnBreakBrick += Ball_OnBreakBrick;
    }

    private void OnDestroy()
    {
        GridSystem.OnLevelStart -= GridSystem_OnLevelStart;
        Ball.OnBreakBrick -= Ball_OnBreakBrick;
    }

    private void UpdateRemainingText()
    {
        if (_remainingText == null) return;

        _remainingText.text = "Remaining Brick: " + _brickCount;
    }

    private void GridSystem_OnLevelStart(object sender, GridSystem.OnLevelStartEventArgs e)
    {
        _brickCount = e.brickCount;
        UpdateRemainingText();
    }

    private void Ball_OnBreakBrick(object sender, System.EventArgs e)
    {
        _brickCount -= 1;
        UpdateRemainingText();
        if (_brickCount == 0)
        {
            OnLevelDone?.Invoke(this, EventArgs.Empty);
        }

    }
}
