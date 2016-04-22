using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace TeamSpigot
{
    public class SwitchScene : MonoBehaviour
    {
        public void SceneSwitch()
        {
            FindObjectOfType<Fade>().FadeToLevel(1);
        }
    }
}
