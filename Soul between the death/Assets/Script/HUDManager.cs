using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    private HUDManager Instance;
    private ShootPlayer _shootPlayer;
    private LifePlayer _lifePlayer;
    private LevelTrigger _levelTrigger;

    [SerializeField] private TextMeshProUGUI _textAmmo;
    [SerializeField] private TextMeshProUGUI _textLife;
    [SerializeField] private TextMeshProUGUI _textScore;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _shootPlayer = ShootPlayer.Instance;
        _lifePlayer = LifePlayer.Instance;
        _levelTrigger = LevelTrigger.Instance;
    }

    private void Update()
    {
        _textAmmo.text = "Bullet " + _shootPlayer.Ammo.ToString() + "/" + _shootPlayer.MaxAmmo.ToString();
        _textLife.text = "Health " + _lifePlayer._health;
        _textScore.text = "Score " + _levelTrigger._level * 5;
    }
}
