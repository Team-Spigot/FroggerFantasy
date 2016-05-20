using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Linq;

namespace TeamSpigot
{
    public class EnemyMovement : MonoBehaviour
    {
        public enum Direction
        {
            up,
            down,
            left,
            right
        }

        public int Speed;
        public float SizeOfTiles;
        public LayerMask CollisionLayer;

        public Direction direction;
        [HideInInspector]
        public Vector3 TargetPosition;

        private bool canMove = true;

        private Animator enemyAnimator;

        private float halfSizeOfTiles;

        private RaycastHit2D RaycastHitDown, RaycastHitLeft, RaycastHitUp, RaycastHitRight;

        public Vector2 EnemyCenter
        {
            get
            {
                return new Vector2(transform.position.x + halfSizeOfTiles, transform.position.y + halfSizeOfTiles);
            }
        }

        // Use this for initialization
        void Start()
        {
            Sprite[] EnemySprites = new Sprite[4];

            enemyAnimator = GetComponentInChildren<Animator>();

            if (FindObjectOfType<Tiled2Unity.TiledMap>() != null)
            {
                SizeOfTiles = FindObjectOfType<Tiled2Unity.TiledMap>().TileWidth * FindObjectOfType<Tiled2Unity.TiledMap>().ExportScale;
                halfSizeOfTiles = SizeOfTiles / 2;
            }

            EnemySprites = AssetDatabase.LoadAllAssetsAtPath("Assets/Sprites/Enemy/CarOverworldSpriteSheet.png").OfType<Sprite>().ToArray();
            GetComponentInChildren<SpriteRenderer>().sprite = EnemySprites[Random.Range(0, 4)];
        }

        // Update is called once per frame
        void Update()
        {

            if (direction == Direction.up && canMove == true)
            {
                RaycastHitUp = Physics2D.Raycast(EnemyCenter, Vector2.up, halfSizeOfTiles, CollisionLayer);

                enemyAnimator.SetInteger("Direction", 0);
                enemyAnimator.SetBool("Moving", true);

                if (!RaycastHitUp)
                {
                    canMove = false;
                    StartCoroutine(MoveInGrid(transform.position.x, transform.position.y + SizeOfTiles));
                }
                if (RaycastHitUp && RaycastHitUp.collider.gameObject.layer == LayerMask.NameToLayer("EnemyResetSpot"))
                {
                    transform.localPosition = new Vector3(0, -SizeOfTiles, 0);
                }
            }
            else if (direction == Direction.left && canMove == true)
            {
                RaycastHitLeft = Physics2D.Raycast(EnemyCenter, Vector2.left, halfSizeOfTiles, CollisionLayer);

                enemyAnimator.SetInteger("Direction", 1);
                enemyAnimator.SetBool("Moving", true);

                if (!RaycastHitLeft)
                {
                    canMove = false;
                    StartCoroutine(MoveInGrid(transform.position.x - SizeOfTiles, transform.position.y));
                }
                if (RaycastHitLeft && RaycastHitLeft.collider.gameObject.layer == LayerMask.NameToLayer("EnemyResetSpot"))
                {
                    transform.localPosition = new Vector3(0, -SizeOfTiles, 0);
                }
            }
            else if (direction == Direction.down && canMove == true)
            {
                RaycastHitDown = Physics2D.Raycast(EnemyCenter, Vector2.down, halfSizeOfTiles, CollisionLayer);

                enemyAnimator.SetInteger("Direction", 2);
                enemyAnimator.SetBool("Moving", true);

                if (!RaycastHitDown)
                {
                    canMove = false;
                    StartCoroutine(MoveInGrid(transform.position.x, transform.position.y - SizeOfTiles));
                }
                if (RaycastHitDown && RaycastHitDown.collider.gameObject.layer == LayerMask.NameToLayer("EnemyResetSpot"))
                {
                    transform.localPosition = new Vector3(0, -SizeOfTiles, 0);
                }
            }
            else if (direction == Direction.right && canMove == true)
            {
                RaycastHitRight = Physics2D.Raycast(EnemyCenter, Vector2.right, halfSizeOfTiles, CollisionLayer);

                enemyAnimator.SetInteger("Direction", 3);
                enemyAnimator.SetBool("Moving", true);

                if (!RaycastHitRight)
                {
                    canMove = false;
                    StartCoroutine(MoveInGrid(transform.position.x + SizeOfTiles, transform.position.y));
                }
                if (RaycastHitRight && RaycastHitRight.collider.gameObject.layer == LayerMask.NameToLayer("EnemyResetSpot"))
                {
                    transform.localPosition = new Vector3(0, -SizeOfTiles, 0);
                }
            }
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
            enemyAnimator.SetBool("Moving", false);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector3(EnemyCenter.x, EnemyCenter.y, -2), new Vector3(EnemyCenter.x, EnemyCenter.y - halfSizeOfTiles, -2));
            Gizmos.DrawLine(new Vector3(EnemyCenter.x, EnemyCenter.y, -2), new Vector3(EnemyCenter.x, EnemyCenter.y + halfSizeOfTiles, -2));
            Gizmos.DrawLine(new Vector3(EnemyCenter.x, EnemyCenter.y, -2), new Vector3(EnemyCenter.x - halfSizeOfTiles, EnemyCenter.y, -2));
            Gizmos.DrawLine(new Vector3(EnemyCenter.x, EnemyCenter.y, -2), new Vector3(EnemyCenter.x + halfSizeOfTiles, EnemyCenter.y, -2));
        }
    }
}