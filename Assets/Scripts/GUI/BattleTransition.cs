using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TeamSpigot
{
    public class BattleTransition : MonoBehaviour
    {
        private Animator UIAnimator;

        // Use this for initialization
        void Start()
        {
            UIAnimator = GetComponent<Animator>();
        }

        public void BeginBattle()
        {
            UIAnimator.SetTrigger("Leave");
        }

        public void BeginBattle(bool testing)
        {
            if (testing)
            {
                UIAnimator.SetBool("Testing", true);
            }
            
            UIAnimator.SetTrigger("Leave");
        }

        private void EnterBattle()
		{
			UIAnimator = GetComponent<Animator>();
            UIAnimator.SetTrigger("Enter");
        }

        private void ChangeLevel()
        {
            SceneManager.LoadScene(2);
        }

        public void ResetBattle()
        {
            EnterBattle();
        }

        void OnLevelWasLoaded(int level)
        {
            if (level == 2)
            {
                ResetBattle();
            }
        }

        void ResetVariables()
        {
            UIAnimator.ResetTrigger("Leave");
            UIAnimator.ResetTrigger("Enter");
        }
    }
}