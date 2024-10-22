using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _clickMouse;

    [SerializeField] private TextMeshProUGUI _redEnemy;
    [SerializeField] private TextMeshProUGUI _greenEnemy;
    [SerializeField] private TextMeshProUGUI _blueEnemy;


    public void SetClickMouse(int countClick)
    {
        _clickMouse.text = countClick.ToString();
    }

    public void SetCountColorEnemy(int redEnemy, int greenEnemy, int blueEnemy)
    {
        _redEnemy.text = redEnemy.ToString();
        _greenEnemy.text = greenEnemy.ToString();
        _blueEnemy.text = blueEnemy.ToString();
    }
}