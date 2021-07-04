using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float xOffset; //расстояние от игрока до камеры по оси x настраивается в инспекторе
    [SerializeField] private float yOffset; //расстояние от игрока до камеры по оси y настраивается в инспекторе
    [SerializeField] private float zOffset; //расстояние от игрока до камеры по оси z настраивается в инспекторе

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x+xOffset,_player.transform.position.y+yOffset,_player.transform.position.z+zOffset);
        // перемеаем позицию нашей камеры к позиции игрока + растояние 
    }
}
