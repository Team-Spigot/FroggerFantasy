using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class GameManager : MonoBehaviour
    {
        void Awake()
        {
            if (FindObjectsOfType(GetType()).Length > 1)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(this);
        }
    }
}