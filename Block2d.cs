using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Tetris
{
    public class Block2d : MonoBehaviour
    {

        float lastFall = 0;
        public float Fallspeed = 1;
        Score score;
        public bool allowRotation = true;
        public bool limitRotation = false;

        void Update()
        {
            CheckUserInput();
        }

        void CheckUserInput()
        {
            // Move Left
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Modify position
                transform.position += new Vector3(-1, 0, 0);
                if (IsValidBorder2dPos())
                {
                    FindObjectOfType<Border2d>().UpdateBorder2d(this);
                }
                else
                {
                    // Modify position
                    transform.position += new Vector3(1, 0, 0);
                }
            }

            //move right
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Modify position
                transform.position += new Vector3(1, 0, 0);
                if (IsValidBorder2dPos())
                {
                    FindObjectOfType<Border2d>().UpdateBorder2d(this);
                }
                else
                {
                    // Modify position
                    transform.position += new Vector3(-1, 0, 0);
                }
            }
            //rotatate in space
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (allowRotation)
                {
                    if (limitRotation)
                    {
                        if (transform.rotation.eulerAngles.z >= 90)
                        {
                            transform.Rotate(0, 0, -90);
                        }
                        else
                        {
                            transform.Rotate(0, 0, 90);
                        }
                    }
                    else
                    {

                        transform.Rotate(0, 0, -90);
                    }

                    if (IsValidBorder2dPos())
                    {
                        FindObjectOfType<Border2d>().UpdateBorder2d(this);
                    }
                    else
                    {
                        if (limitRotation)
                        {
                            if (transform.rotation.eulerAngles.z <= -90)
                            {
                                transform.Rotate(0, 0, 90);
                            }
                            else
                            {
                                transform.Rotate(0, 0, -90);
                            }
                        }
                        else
                        {
                            transform.Rotate(0, 0, 90);
                        }
                    }
                }
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (allowRotation)
                {
                    if (limitRotation)
                    {
                        if (transform.rotation.eulerAngles.z >= -90)
                        {
                            transform.Rotate(0, 0, 90);
                        }
                        else
                        {
                            transform.Rotate(0, 0, -90);
                        }
                    }
                    else
                    {

                        transform.Rotate(0, 0, 90);
                    }

                    if (IsValidBorder2dPos())
                    {
                        FindObjectOfType<Border2d>().UpdateBorder2d(this);
                    }
                    else
                    {
                        if (limitRotation)
                        {
                            if (transform.rotation.eulerAngles.z <= 90)
                            {
                                transform.Rotate(0, 0, -90);
                            }
                            else
                            {
                                transform.Rotate(0, 0, 90);
                            }
                        }
                        else
                        {
                            transform.Rotate(0, 0, -90);
                        }
                    }
                }
            }
            //move down
            else if (Input.GetKeyDown(KeyCode.KeypadEnter) || Time.time - lastFall >= Fallspeed)
            {
                transform.position += new Vector3(0, -1, 0);

                if (IsValidBorder2dPos())
                {
                    FindObjectOfType<Border2d>().UpdateBorder2d(this);
                }
                else
                {
                    // Modify position
                    transform.position += new Vector3(0, 1, 0);

                    //clear filled horivzontal lines
                    Border2d.DeleteFullRows();

                    //disable script
                    enabled = false;

                    //spawn next group
                    FindObjectOfType<SpawnBlock>().SpawnNext();
                }
                lastFall = Time.time;
            }

        }
        bool IsValidBorder2dPos()
        {
            foreach (Transform block in transform)
            {

                Vector2 pos = FindObjectOfType<Border2d>().RoundVec2(block.position);

                //Not inside Border2d ?
                if (FindObjectOfType<Border2d>().InsideBorder2d(pos) == false)
                {
                    return false;
                }
                if (FindObjectOfType<Border2d>().GetTransformAtGridPosition(pos) != null && FindObjectOfType<Border2d>().GetTransformAtGridPosition(pos).parent != transform)
                {
                    return false;
                }
            }
            return true;
        }

        void Start()
        {
            //Default position not valid? Then it's game over
            //if (!IsValidBorder2dPos())
            //{
            //    Debug.Log("GAME OVER");
            //    Destroy(gameObject);
            //}
        }
    }
}

