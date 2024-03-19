using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    private HUDManager Instance;
    private ShootPlayer _shootPlayer;

    [SerializeField] private TextMeshProUGUI _textAmmo;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _shootPlayer = ShootPlayer.Instance;
    }

    private void Update()
    {
        _textAmmo.text = "Ammo: " + _shootPlayer.Ammo.ToString() + "/" + _shootPlayer.MaxAmmo.ToString();
    }
}
