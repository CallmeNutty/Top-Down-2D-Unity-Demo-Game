using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour
{
    
    public class Enemy
    {
        public Enemy (int HP, int SPD)
        {
            health = HP;
            speed = SPD;
        }

        public int health;
        public int speed;
    }
}
