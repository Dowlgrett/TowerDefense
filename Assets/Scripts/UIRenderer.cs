using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIRenderer : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI _playerHealth;
    [SerializeField]
    public TextMeshProUGUI _playerGold;
    [SerializeField]
    public Player _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        _playerHealth.text = "Health: " + _player.Health;
        _playerGold.text = "Gold: " + _player.Gold;
    }

}
