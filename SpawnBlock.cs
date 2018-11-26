using UnityEngine;
using System.Collections;


namespace Tetris
{
    public class SpawnBlock : MonoBehaviour
    {


        public void SpawnNext()
        {
            GameObject nextBlock = (GameObject)Instantiate(Resources.Load(GetRandomBlock(), typeof(GameObject)), new Vector2(5.0f, 20.0f), Quaternion.identity);

        }

        string GetRandomBlock()
        {
            int randomTetromino = Random.Range(1, 26);

            string randomTetrominoName = "blocks/Group Z";
            switch (randomTetromino)
            {
                case 1:
                    randomTetrominoName = "blocks/Group A";
                    break;

                case 2:
                    randomTetrominoName = "blocks/Group B";
                    break;
                case 3:
                    randomTetrominoName = "blocks/Group C";
                    break;
                case 4:
                    randomTetrominoName = "blocks/Group D";
                    break;
                case 5:
                    randomTetrominoName = "blocks/Group E";
                    break;
                case 6:
                    randomTetrominoName = "blocks/Group F";
                    break;
                case 7:
                    randomTetrominoName = "blocks/Group G";
                    break;
                case 8:
                    randomTetrominoName = "blocks/Group H";
                    break;
                case 9:
                    randomTetrominoName = "blocks/Group I";
                    break;
                case 10:
                    randomTetrominoName = "blocks/Group J";
                    break;
                case 11:
                    randomTetrominoName = "blocks/Group K";
                    break;
                case 12:
                    randomTetrominoName = "blocks/Group L";
                    break;
                case 13:
                    randomTetrominoName = "blocks/Group M";
                    break;
                case 14:
                    randomTetrominoName = "blocks/Group N";
                    break;
                case 15:
                    randomTetrominoName = "blocks/Group O";
                    break;
                case 16:
                    randomTetrominoName = "blocks/Group P";
                    break;
                case 17:
                    randomTetrominoName = "blocks/Group Q";
                    break;
                case 18:
                    randomTetrominoName = "blocks/Group R";
                    break;
                case 19:
                    randomTetrominoName = "blocks/Group S";
                    break;
                case 20:
                    randomTetrominoName = "blocks/Group T";
                    break;
                case 21:
                    randomTetrominoName = "blocks/Group U";
                    break;
                case 22:
                    randomTetrominoName = "blocks/Group V";
                    break;
                case 23:
                    randomTetrominoName = "blocks/Group W";
                    break;
                case 24:
                    randomTetrominoName = "blocks/Group X";
                    break;
                case 25:
                    randomTetrominoName = "blocks/Group Y";
                    break;
            }
            return randomTetrominoName;
        }

        void Start()
        {
            SpawnNext();
        }
    }

}