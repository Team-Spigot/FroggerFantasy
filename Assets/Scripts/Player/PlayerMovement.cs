﻿using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerMovement : MonoBehaviour
    {
        public float Speed;
        public float SizeOfTiles;
        public LayerMask CollisionLayer;

        [HideInInspector]
        public Vector3 TargetPosition;
        private bool canMove = true;

        private Animator playerAnimator;

        private float halfSizeOfTiles;

        private RaycastHit2D RaycastHitDown, RaycastHitLeft, RaycastHitUp, RaycastHitRight;

        private Vector2 playerCenter;

        public Vector2 PlayerCenter
        {
            get
            {
                return playerCenter;
            }
            set
            {
                playerCenter = new Vector2(value.x + halfSizeOfTiles, value.y + halfSizeOfTiles);
            }
        }

        void Start()
        {
            playerAnimator = GetComponentInChildren<Animator>();

            if (FindObjectOfType<Tiled2Unity.TiledMap>() != null)
            {
                SizeOfTiles = FindObjectOfType<Tiled2Unity.TiledMap>().TileWidth * FindObjectOfType<Tiled2Unity.TiledMap>().ExportScale;
                halfSizeOfTiles = SizeOfTiles / 2;
            }

            if (GameObject.FindGameObjectsWithTag("Spawn") != null && GameObject.FindGameObjectsWithTag("Spawn").Length == 1)
            {
                Debug.Log("Found one object with the tag \"Spawn\"");
                Debug.Log("The object with the tag \"Spawn\" has a position of: " + GameObject.FindGameObjectWithTag("Spawn").transform.position);
                transform.position = GameObject.FindGameObjectWithTag("Spawn").transform.position; //+ new Vector3(SizeOfTiles, SizeOfTiles, 0f);
                Debug.Log("Moved Object with tag \"Player\" to object with tag \"Spawn\"");
            }
        }

        // Update is called once per frame
        void Update()
        {
            RaycastHitDown = Physics2D.Raycast(PlayerCenter, Vector2.down, halfSizeOfTiles, CollisionLayer);
            RaycastHitLeft = Physics2D.Raycast(PlayerCenter, Vector2.left, halfSizeOfTiles, CollisionLayer);
            RaycastHitUp = Physics2D.Raycast(PlayerCenter, Vector2.up, halfSizeOfTiles, CollisionLayer);
            RaycastHitRight = Physics2D.Raycast(PlayerCenter, Vector2.right, halfSizeOfTiles, CollisionLayer);

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                if (Input.GetAxis("Vertical") > 0 && canMove == true) // Move up
                {
                    // Set Animation Moving Up
                    playerAnimator.SetInteger("Direction", 0);
                    playerAnimator.SetBool("Moving", true);

                    if (!RaycastHitUp)
                    {
                        canMove = false;
                        StartCoroutine(MoveInGrid(transform.position.x, transform.position.y + SizeOfTiles));
                    }
                    else
                    {
                        playerAnimator.SetInteger("Direction", 0);
                        playerAnimator.SetBool("Moving", false);
                    }
                }
                else if (Input.GetAxis("Horizontal") < 0 && canMove == true) // Move Left
                {
                    // Set Animation Moving Left
                    playerAnimator.SetInteger("Direction", 1);
                    playerAnimator.SetBool("Moving", true);

                    if (!RaycastHitLeft)
                    {
                        canMove = false;
                        StartCoroutine(MoveInGrid(transform.position.x - SizeOfTiles, transform.position.y));
                    }
                    else
                    {
                        playerAnimator.SetInteger("Direction", 1);
                        playerAnimator.SetBool("Moving", false);
                    }
                }
                else if (Input.GetAxis("Vertical") < 0 && canMove == true) // Move Down
                {
                    // Set Animation Moving Down
                    playerAnimator.SetInteger("Direction", 2);
                    playerAnimator.SetBool("Moving", true);

                    if (!RaycastHitDown)
                    {
                        canMove = false;
                        StartCoroutine(MoveInGrid(transform.position.x, transform.position.y - SizeOfTiles));
                    }
                    else
                    {
                        playerAnimator.SetInteger("Direction", 2);
                        playerAnimator.SetBool("Moving", false);
                    }
                }
                else if (Input.GetAxis("Horizontal") > 0 && canMove == true) // Move Right
                {
                    // Set Animation Moving Right
                    playerAnimator.SetInteger("Direction", 3);
                    playerAnimator.SetBool("Moving", true);

                    if (!RaycastHitRight)
                    {
                        canMove = false;
                        StartCoroutine(MoveInGrid(transform.position.x + SizeOfTiles, transform.position.y));
                    }
                    else
                    {
                        playerAnimator.SetInteger("Direction", 3);
                        playerAnimator.SetBool("Moving", false);
                    }
                }
            }

            if ((RaycastHitUp && RaycastHitUp.collider.tag == "Enemy") || (RaycastHitLeft && RaycastHitLeft.collider.tag == "Enemy") || (RaycastHitDown && RaycastHitDown.collider.tag == "Enemy") || (RaycastHitRight && RaycastHitRight.collider.tag == "Enemy"))
            {
                FindObjectOfType<BattleTransition>().BeginBattle(false);
            }
        }

        void LateUpdate()
        {
            PlayerCenter = transform.position;
        }

        IEnumerator MoveInGrid(float x, float y)
        {
            while (transform.position.x != x || transform.position.y != y)
            {
                //moving x forward
                if (transform.position.x < x)
                {
                    //moving the point by speed 
                    TargetPosition.x = Speed * Time.deltaTime;
                    //check if the point goes more than it should go and if yes clamp it back
                    if (TargetPosition.x + transform.position.x > x)
                    {
                        TargetPosition.x = x - transform.position.x;
                    }
                }
                //moving x backward
                else if (transform.position.x > x)
                {
                    //moving the point by speed 
                    TargetPosition.x = -Speed * Time.deltaTime;
                    //check if the point goes more than it should go and if yes clamp it back
                    if (TargetPosition.x + transform.position.x < x)
                    {
                        TargetPosition.x = -(transform.position.x - x);
                    }
                }
                else //x is unchanged so should be 0 in translate function
                {
                    TargetPosition.x = 0;
                }
                //moving y forward
                if (transform.position.y < y)
                {
                    //moving the point by speed 
                    TargetPosition.y = Speed * Time.deltaTime;
                    //check if the point goes more than it should go and if yes clamp it back
                    if (TargetPosition.y + transform.position.y > y)
                    {
                        TargetPosition.y = y - transform.position.y;
                    }
                }
                //moving y backward
                else if (transform.position.y > y)
                {
                    //moving the point by speed 
                    TargetPosition.y = -Speed * Time.deltaTime;
                    //check if the point goes more than it should go and if yes clamp it back
                    if (TargetPosition.y + transform.position.y < y)
                    {
                        TargetPosition.y = -(transform.position.y - y);
                    }
                }
                else //y is unchanged so it should be zero
                {
                    TargetPosition.y = 0;
                }

                TargetPosition.z = 0;

                transform.Translate(TargetPosition);
                yield return 0;
            }
            //the work is ended now congratulation
            canMove = true;
            TargetPosition = Vector2.zero;
            playerAnimator.SetBool("Moving", false);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector3(PlayerCenter.x, PlayerCenter.y, -2), new Vector3(PlayerCenter.x, PlayerCenter.y - halfSizeOfTiles, -2));
            Gizmos.DrawLine(new Vector3(PlayerCenter.x, PlayerCenter.y, -2), new Vector3(PlayerCenter.x, PlayerCenter.y + halfSizeOfTiles, -2));
            Gizmos.DrawLine(new Vector3(PlayerCenter.x, PlayerCenter.y, -2), new Vector3(PlayerCenter.x - halfSizeOfTiles, PlayerCenter.y, -2));
            Gizmos.DrawLine(new Vector3(PlayerCenter.x, PlayerCenter.y, -2), new Vector3(PlayerCenter.x + halfSizeOfTiles, PlayerCenter.y, -2));
        }
    }
}