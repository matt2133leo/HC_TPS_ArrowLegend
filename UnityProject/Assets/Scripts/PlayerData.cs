﻿using UnityEngine;

[CreateAssetMenu(fileName ="玩家資料",menuName ="OppositaMan/玩家資料")]
public class PlayerData : ScriptableObject
{
    [Header("血量")]
    public float hp = 200;
}
