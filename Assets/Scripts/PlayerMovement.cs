using UnityEngine;
using System.Collections;

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

    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        if (FindObjectOfType<Tiled2Unity.TiledMap>() != null)
        {
            SizeOfTiles = FindObjectOfType<Tiled2Unity.TiledMap>().TileWidth * FindObjectOfType<Tiled2Unity.TiledMap>().ExportScale;
            halfSizeOfTiles = SizeOfTiles / 2;
        }

        if (GameObject.FindGameObjectsWithTag("Spawn").Length == 1 && GameObject.FindGameObjectWithTag("Spawn") != null)
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length == 1 && GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("Spawn").transform.position + new Vector3(halfSizeOfTiles, halfSizeOfTiles, 0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHitDown = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, SizeOfTiles, CollisionLayer);
        RaycastHitLeft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, SizeOfTiles, CollisionLayer);
        RaycastHitUp = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.up, SizeOfTiles, CollisionLayer);
        RaycastHitRight = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, SizeOfTiles, CollisionLayer);

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            // Set Animation to Idle.
            playerAnimator.SetBool("Moving", false);

        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Vertical") > 0 && canMove == true)
            {
                if (!RaycastHitUp)
                {
                    canMove = false;
                    StartCoroutine(MoveInGrid(transform.position.x, transform.position.y + SizeOfTiles));
                }
            }
            else if (Input.GetAxis("Vertical") < 0 && canMove == true)
            {
                if (!RaycastHitDown)
                {
                    canMove = false;
                    StartCoroutine(MoveInGrid(transform.position.x, transform.position.y - SizeOfTiles));
                }
            }
            if (Input.GetAxis("Horizontal") > 0 && canMove == true)
            {
                if (!RaycastHitRight)
                {
                    canMove = false;
                    StartCoroutine(MoveInGrid(transform.position.x + SizeOfTiles, transform.position.y));
                }
            }
            if (Input.GetAxis("Horizontal") < 0 && canMove == true)
            {
                if (!RaycastHitLeft)
                {
                    canMove = false;
                    StartCoroutine(MoveInGrid(transform.position.x - SizeOfTiles, transform.position.y));
                }
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
                // Set Animation Moving Right
                playerAnimator.SetInteger("Direction", 2);
                playerAnimator.SetBool("Moving", true);
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
                // Set Animation Moving Left
                playerAnimator.SetInteger("Direction", 4);
                playerAnimator.SetBool("Moving", true);
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
                // Set Animation Moving Up
                playerAnimator.SetInteger("Direction", 1);
                playerAnimator.SetBool("Moving", true);
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
                // Set Animation Moving Down
                playerAnimator.SetInteger("Direction", 3);
                playerAnimator.SetBool("Moving", true);
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
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y, -2), new Vector3(transform.position.x, transform.position.y - SizeOfTiles, -2));
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y, -2), new Vector3(transform.position.x, transform.position.y + SizeOfTiles, -2));
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y, -2), new Vector3(transform.position.x - SizeOfTiles, transform.position.y, -2));
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y, -2), new Vector3(transform.position.x + SizeOfTiles, transform.position.y, -2));
    }
}