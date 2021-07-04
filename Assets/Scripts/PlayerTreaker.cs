using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTreaker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private float zOffset;

    private void Update()
    {
        transform.position=new Vector3(_player.transform.position.x,_player.transform.position.y+yOffset,_player.transform.position.z+zOffset);
    }
}
