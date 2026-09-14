using UnityEngine;

[System.Serializable]
public class Upgrade
{
    // 기획자가 채우는 속성
    private string _name;
    private float _defaultValue;
    private float _increaseValue;
    private float _defaultCost;
    private float _increaseCost;

    // 실행중에 동적으로 바뀌 속성
    private int _level;
    private float _currentValue;
    private float _nextValue;
    private int _cost;

    public Upgrade(int level, string name, float defaultValue, float increaseValue, float increaseCost)
    {
        _level = level;
        _name = name;
        _defaultValue = defaultValue;
        _increaseValue = increaseValue;
        _increaseCost = increaseCost;

        Calculate();
    }
    

    public void LevelUp()
    {
        _level += 1;

        Calculate();
    }

    private void Calculate()
    {
        // Todo: 공식에 따라 변화
        // Value : 기본 밸류 + 레벨 * 증가량 밸류
        // Cost  : 기본 점수 * 증가량 점수 ^ 레벨

        _currentValue = _defaultValue + _level * _increaseValue;
        _nextValue = _defaultValue + (_level + 1) * _increaseValue;
        _cost = (int)(_defaultCost + Mathf.Pow(_increaseCost, _level));
    }
}