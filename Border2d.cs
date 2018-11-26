using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Tetris
{
    public class Border2d : MonoBehaviour
    {

        public static int width = 20;
        public static int height = 30;
        public static Transform[,] grid = new Transform[width, height];

        public void UpdateBorder2d(Block2d block)
        {

            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    if (grid[x, y] != null)
                    {
                        if (grid[x,y].parent == block.transform)
                        {
                            grid[x, y] = null;
                        }
                    }
                }
            }
            //Add new children to grid
            foreach (Transform tetromino in block.transform)
            {
                Vector2 pos = RoundVec2(tetromino.position);
                if(pos.y < height)
                {
                    grid[(int)pos.x, (int)pos.y] = tetromino;
                }
            }

        }

        bool IsinsideBorder2d(Vector2 pos)
        {

            return ((int)pos.x >= 0 && (int)pos.x < width && (int)pos.y >= 0);
        }
            public Transform GetTransformAtGridPosition (Vector2 pos)
        {
            if(pos.y > height - 1)
            {
                return null;
            }
            return grid[(int)pos.x, (int)pos.y];
        }
        public Vector2 RoundVec2(Vector2 v)
        {
            return new Vector2(Mathf.Round(v.x),
                               Mathf.Round(v.y));
        }
        public bool InsideBorder2d(Vector2 pos)
        {
            return ((int)pos.x >= 0 &&
                    (int)pos.x < width &&
                    (int)pos.y >= 0);
        }


        public static void DeleteRow(int y)
        {
            for (int x = 0; x < width; ++x)
            {

                Destroy(grid[x, y].gameObject);
                grid[x, y] = null;

            }
        }

        public static void DecreaseRow(int y)
        {
            for (int x = 0; x < width; ++x)
            {

                if (grid[x, y] != null)
                {
                    // Move one towards bottom
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;

                    // Update Block position
                    grid[x, y - 1].position += new Vector3(0, -1, 0);
                }
            }
        }


        public static bool IsRowFull(int y)
        {
            for (int x = 0; x < width; ++x)
                if (grid[x, y] == null)
                {
                    return false;
                }

            return true;
        }
        public static void DecreaseRowsAbove(int y)
        {
            for (int i = y; i < width; ++i)
                DecreaseRow(i);
        }

        public static void DeleteFullRows()
        {
            for (int y = 0; y < height; ++y)
            {
                if (IsRowFull(y))
                {
                    DeleteRow(y);
                    DecreaseRowsAbove(y + 1);
                    --y;
                }
            }
        }
    }
}
  