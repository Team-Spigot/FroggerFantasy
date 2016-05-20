using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private DropOff _do;
        private EnemyBattleManager _ebm;

        public float Speed;
        public float SizeOfTiles;

        public LayerMask CollisionLayer;
        public LayerMask TriggerLayer;

        public bool Locked;
        public bool Paused;

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

        private Vector3 TargetPosition;
        private bool canMove = true;

        private Animator playerAnimator;

        private float halfSizeOfTiles;

        private RaycastHit2D RaycastHitDown, RaycastHitLeft, RaycastHitUp, RaycastHitRight;
        private RaycastHit2D TRaycastHitDown, TRaycastHitLeft, TRaycastHitUp, TRaycastHitRight;

        private Vector2 playerCenter;

        private Vector3 lastPosition;

        void Awake()
        {
            _ebm = EnemyBattleManager.instance;
            _do = DropOff.instance;
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
                transform.position = GameObject.FindGameObjectWithTag("Spawn").transform.position; //+ new Vector3(SizeOfTiles, SizeOfTiles, 0f);
            }
        }

        // Update is called once per frame
        void Update()
        {
            RaycastHitDown = Physics2D.Raycast(PlayerCenter, Vector2.down, halfSizeOfTiles, CollisionLayer);
            RaycastHitLeft = Physics2D.Raycast(PlayerCenter, Vector2.left, halfSizeOfTiles, CollisionLayer);
            RaycastHitUp = Physics2D.Raycast(PlayerCenter, Vector2.up, halfSizeOfTiles, CollisionLayer);
            RaycastHitRight = Physics2D.Raycast(PlayerCenter, Vector2.right, halfSizeOfTiles, CollisionLayer);

            TRaycastHitDown = Physics2D.Raycast(PlayerCenter, Vector2.down, halfSizeOfTiles, TriggerLayer);
            TRaycastHitLeft = Physics2D.Raycast(PlayerCenter, Vector2.left, halfSizeOfTiles, TriggerLayer);
            TRaycastHitUp = Physics2D.Raycast(PlayerCenter, Vector2.up, halfSizeOfTiles, TriggerLayer);
            TRaycastHitRight = Physics2D.Raycast(PlayerCenter, Vector2.right, halfSizeOfTiles, TriggerLayer);

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                if (Input.GetAxis("Vertical") > 0 && canMove && !Paused) // Move up
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
                else if (Input.GetAxis("Horizontal") < 0 && canMove && !Paused) // Move Left
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
                else if (Input.GetAxis("Vertical") < 0 && canMove && !Paused) // Move Down
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
                else if (Input.GetAxis("Horizontal") > 0 && canMove && !Paused) // Move Right
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

            if (!Locked)
            {
                if (TCheckAllRaycasts("Enemy"))
                {
                    _ebm.currentEnemy = TRaycastHitUp.collider.gameObject;
                }
                else
                {
                    _ebm.currentEnemy = null;
                }

                if (TCheckAllRaycasts("DropOffPoint"))
                {
                    _do.currentDropOffPoint = TRaycastHitUp.collider.gameObject.GetComponent<DropOffPoint>();
                }
                else
                {
                    _do.currentDropOffPoint = null;
                }
            }
        }

        void LateUpdate()
        {
            PlayerCenter = transform.position;
            if (!Locked)
            {
                lastPosition = transform.position;
            }
        }

        public void ResetPlayer()
        {
            Locked = false;
            Paused = false;
            transform.position = new Vector3(Mathf.Round(lastPosition.x / SizeOfTiles) * SizeOfTiles,
                                            Mathf.Round(lastPosition.y / SizeOfTiles) * SizeOfTiles, 0);
        }

        IEnumerator MoveInGrid(float x, float y)
        {
            while ((transform.position.x != x || transform.position.y != y) && !Paused)
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

        private bool CheckAllRaycasts(string tag)
        {
            if ((RaycastHitUp && RaycastHitUp.collider.tag == tag) && (RaycastHitLeft && RaycastHitLeft.collider.tag == tag) && (RaycastHitDown && RaycastHitDown.collider.tag == tag) && (RaycastHitRight && RaycastHitRight.collider.tag == tag))
            {
                return true;
            }

            return false;
        }

        private bool TCheckAllRaycasts(string tag)
        {
            if ((TRaycastHitUp && TRaycastHitUp.collider.tag == tag) && (TRaycastHitLeft && TRaycastHitLeft.collider.tag == tag) && (TRaycastHitDown && TRaycastHitDown.collider.tag == tag) && (TRaycastHitRight && TRaycastHitRight.collider.tag == tag))
            {
                return true;
            }

            return false;
        }
    }
}