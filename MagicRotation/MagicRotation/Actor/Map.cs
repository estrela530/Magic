using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using MagicRotation.Def;
using MagicRotation.Device;
using Action.Util;

namespace MagicRotation.Actor
{
    class Map
    {
        // フィールド
        //913
        private List<List<GameObject>> mapList;
        private GameDevice gameDevice;

        private Player player;
        // マップの並びデータ
        private int[,] mapData;

        #region 配列
        //// 切り取り位置保存用
        //private int[] cutX;
        //private int[] cutY;

        //// ブロックとする番号
        //private List<int> blockNumber;
        ////private List<int> deathNumber;
        ////private List<int> checkNumber;
        ////private List<int> nextNumber;
        #endregion
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Map(GameDevice gameDevice)
        {
            mapList = new List<List<GameObject>>();//マップの実体生成
            this.gameDevice = gameDevice;

            #region 配列
            //// マップの並びデータ生成
            //string path = "Content/csv/";
            //mapData = CsvLoad.Load(path + "stage案1-1.csv");

            //// カメラの範囲設定
            //Camera.SetMoveArea(
            //    new Vector2(0, 0),
            //    new Vector2(
            //        mapData.GetLength(1) * Size.BlockX - Screen.Width,
            //        mapData.GetLength(0) * Size.BlockY - Screen.Height));

            //// 切り取り位置の計算
            //InitCutXY();

            //// ブロック番号のリスト
            //blockNumber = new List<int>()
            //{ 1 };
            ////死亡ブロックリスト
            ////deathNumber = new List<int>()
            ////{ 8,9 };
            ////チェックポイントリスト
            ////checkNumber = new List<int>()
            ////{ 5 };
            ////シーン移行ポイント
            ////nextNumber = new List<int>()
            ////{
            ////    { 3 }
            ////};
            ///
            #endregion
        }

        private List<GameObject> AddBlock(int lineCnt, string[] line)
        {
            Dictionary<string, GameObject> objectDict = new Dictionary<string, GameObject>();
            //スペースは0
            objectDict.Add("0", new Space(Vector2.Zero, gameDevice));
            //ブロックは1
            objectDict.Add("1", new Block(Vector2.Zero, gameDevice));
            objectDict.Add("2", new Block(Vector2.Zero, gameDevice));
            objectDict.Add("3", new Block(Vector2.Zero, gameDevice));
            objectDict.Add("4", new Block(Vector2.Zero, gameDevice));
            objectDict.Add("5", new Block(Vector2.Zero, gameDevice));
            objectDict.Add("6", new Block(Vector2.Zero, gameDevice));
            //作業用リスト
            List<GameObject> workList = new List<GameObject>();

            int colCnt = 0;//列カウント用

            //渡された1行から1つずつ作業用リストに追加
            foreach (var s in line)
            {
                try
                {
                    //ディクショナリから元データ取り出し、クローン機能で複製
                    GameObject work = (GameObject)objectDict[s].Clone();
                    work.SetPosition(new Vector2(colCnt * work.GetWidth(),
                        lineCnt * work.GetHeight()));
                    workList.Add(work);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
                //列カウンタを増やす
                colCnt += 1;
            }
            return workList;
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer">レンダラー</param>
        public void Draw(Renderer renderer)
        {
            #region 配列
            //// カメラの配列位置を取得
            //Vector2 arrayPos = Camera.GetArrayPos();
            //// 縦一列描画
            //for (int y = (int)arrayPos.Y; y <= (int)arrayPos.Y + Size.MapY; y++)
            //{
            //    // 配列の範囲外なら処理せず飛ばす
            //    if (y < 0 || mapData.GetLength(0) <= y)
            //        continue;
            //    // 横一列描画
            //    DrawX(renderer, arrayPos, y);
            //}
            #endregion

            foreach (var list in mapList)
            {
                foreach (var obj in list)
                {
                    obj.Draw(renderer);
                }
            }

        }

        #region 配列
        /// <summary>
        /// 横一列描画
        /// </summary>
        /// <param name="renderer">レンダラー</param>
        /// <param name="arrayPos">配列位置</param>
        /// <param name="y">高さ</param>
        //private void DrawX(Renderer renderer, Vector2 arrayPos, int y)
        //{

        //    // 横一列描画
        //    for (int x = (int)arrayPos.X; x <= (int)arrayPos.X + Size.MapX; x++)
        //    {
        //        // 配列の範囲外なら処理せず飛ばす
        //        if (x < 0 || mapData.GetLength(1) <= x)
        //            continue;

        //        // マップデータの数値を見る
        //        int chipNum = mapData[y, x];
        //        // ブロック描画
        //        renderer.DrawTexture(
        //                "block.png",
        //                Camera.GetScreenPos(
        //                    new Vector2(Size.BlockX * x, Size.BlockY * y)),
        //                new Rectangle(
        //                    cutX[chipNum], cutY[chipNum],
        //                    Size.BlockX, Size.BlockY)
        //                );
        //    }
        //}

        ///// <summary>
        ///// 調べる位置がブロックかどうか
        ///// </summary>
        ///// <param name="position">調べる位置</param>
        ///// <returns>調べる位置がブロックであればtrue</returns>
        //public bool IsBlock(Vector2 position)
        //{
        //    // 座標をウィンドウ内に調整
        //    position = Vector2.Clamp(position,
        //        Camera.GetMin(),
        //        Camera.GetMax() + new Vector2(Screen.Width, Screen.Height));

        //    // ゲーム座標から配列位置を計算
        //    Point arrayPos = new Point(
        //        (int)position.X / 16, (int)position.Y / 16);

        //    //配列番号がサイズを超えていたら
        //    if (arrayPos.X < 0)
        //        arrayPos.X = 0;
        //    if (mapData.GetLength(1) <= arrayPos.X)
        //        arrayPos.X = mapData.GetLength(1) - 1;
        //    if (arrayPos.Y < 0)
        //        arrayPos.Y = 0;
        //    if (mapData.GetLength(0) <= arrayPos.Y)
        //        arrayPos.Y = mapData.GetLength(0) - 1;

        //    // 配列位置の番号を取り出す
        //    int mapNum = mapData[arrayPos.Y, arrayPos.X];

        //    // 番号がブロック番号リストに含まれていれば
        //    if (blockNumber.Contains(mapNum))
        //    {
        //        return true;
        //    }
        //    // そうでなければブロックでないと返す
        //    return false;
        //}

        //public bool IsDeathBlock(Vector2 position)
        //{
        //    // 座標をウィンドウ内に調整
        //    position = Vector2.Clamp(position,
        //        Camera.GetMin(),
        //        Camera.GetMax() + new Vector2(Screen.Width, Screen.Height));

        //    // ゲーム座標から配列位置を計算
        //    Point arrayPos = new Point(
        //        (int)position.X / 16, (int)position.Y / 16);

        //    // 配列位置の番号を取り出す
        //    int mapNum = mapData[arrayPos.Y, arrayPos.X];

        //    // 番号がブロック番号リストに含まれていれば
        //    //if (deathNumber.Contains(mapNum))
        //    //{
        //    //    return true;
        //    //}
        //    // そうでなければブロックでないと返す
        //    return false;
        //}

        //public bool IsCheckBlock(Vector2 position)
        //{
        //    // 座標をウィンドウ内に調整
        //    position = Vector2.Clamp(position,
        //        Camera.GetMin(),
        //        Camera.GetMax() + new Vector2(Screen.Width, Screen.Height));

        //    // ゲーム座標から配列位置を計算
        //    Point arrayPos = new Point(
        //        (int)position.X / 16, (int)position.Y / 16);

        //    // 配列位置の番号を取り出す
        //    int mapNum = mapData[arrayPos.Y, arrayPos.X];

        //    // 番号がブロック番号リストに含まれていれば
        //    //if (checkNumber.Contains(mapNum))
        //    //{
        //    //    return true;
        //    //}
        //    // そうでなければブロックでないと返す
        //    return false;
        //}


        //public bool IsNextBlock(Vector2 position)
        //{
        //    // 座標をウィンドウ内に調整
        //    position = Vector2.Clamp(position,
        //        Camera.GetMin(),
        //        Camera.GetMax() + new Vector2(Screen.Width, Screen.Height));

        //    // ゲーム座標から配列位置を計算
        //    Point arrayPos = new Point(
        //        (int)position.X / 16, (int)position.Y / 16);

        //    // 配列位置の番号を取り出す
        //    int mapNum = mapData[arrayPos.Y, arrayPos.X];

        //    // 番号がブロック番号リストに含まれていれば
        //    //if (nextNumber.Contains(mapNum))
        //    //{
        //    //    return true;
        //    //}
        //    // そうでなければブロックでないと返す
        //    return false;
        //}

        ///// <summary>
        ///// 切り取り位置の計算
        ///// </summary>
        //private void InitCutXY()
        //{
        //    // 配列生成
        //    cutX = new int[16];
        //    cutY = new int[16];
        //    // 切り取り位置の計算
        //    for (int i = 0; i < 16; i++)
        //    {
        //        cutX[i] = (i % 4) * Size.BlockX;
        //    }
        //    for (int i = 0; i < 16; i++)
        //    {
        //        cutY[i] = (i / 4) * Size.BlockY;
        //    }
        //}
        #endregion
        /// <summary>
        /// マップデータロード
        /// </summary>
        /// <param name="filename">ファイル名</param>
        public void Load(string filename, string path = "./")
        {
            #region 配列
            ////マップの並びデータ生成
            //string path = "Content/csv/";
            //mapData = CsvLoad.Load(path + filename);

            ////カメラの範囲設定
            //Camera.SetMoveArea(
            //    new Vector2(0, 0),
            //    new Vector2(
            //        mapData.GetLength(1) * Size.BlockX - Screen.Width,
            //        mapData.GetLength(0) * Size.BlockY - Screen.Height));
            #endregion
            CSVReader csvReader = new CSVReader();
            csvReader.Read(filename, path);

            var data = csvReader.GetData();//List<string[]>型で取得

            //1行ごとmapListに追加していく
            for (int lineCnt = 0; lineCnt < data.Count(); lineCnt++)
            {
                mapList.Add(AddBlock(lineCnt, data[lineCnt]));
            }
        }

        /// <summary>
        /// マップリストのクリア
        /// </summary>
        public void UnLoad()
        {
            mapList.Clear();
        }

        public void Updata(GameTime gameTime)
        {
            foreach (var list in mapList)
            {
                foreach (var obj in list)
                {
                    //objがSpaceクラスのオブジェクトなら次へ
                    if (obj is Space)
                    {
                        continue;
                    }

                    //更新
                    obj.Update(gameTime);
                }
            }
        }

        #region Hitメソッド
        public void Hit(GameObject gameObject)
        {
            Point work = gameObject.GetRectangle().Location;//左上の座標を取得
            //配列の何行何列目にいるかを計算
            int x = work.X / 32;
            int y = work.Y / 32;

            //移動に食い込んでる時の修正
            if (x < 1)
            {
                x = 1;
            }
            if (y < 1)
            {
                y = 1;
            }

            Range yRange = new Range(0, mapList.Count() - 1);//行の範囲
            Range xRange = new Range(0, mapList[0].Count() - 1);//列の範囲

            for (int row = y - 1; row <= (y + 1); row++)
            {
                for (int col = x - 1; col <= (x + 1); col++)
                {
                    //配列外なら何もしない
                    if (xRange.IsOutOfRange(col) || yRange.IsOutOfRange(row))
                    {
                        continue;
                    }

                    //その場所のオブジェクトを取得
                    GameObject obj = mapList[row][col];

                    //objがSpaceクラスなら次へ
                    if (obj is Space)
                    {
                        continue;
                    }

                    //衝突判定
                    if (obj.IsCollision(gameObject))
                    {
                        gameObject.Hit(obj);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 横幅を取得するメソッド
        /// </summary>
        /// <returns></returns>
        public int GetWidth()
        {
            int col = mapList[0].Count;

            int width = col * mapList[0][0].GetWidth();

            return width;
        }


        /// <summary>
        /// 縦幅を取得するメソッド
        /// </summary>
        /// <returns></returns>
        public int GetHeight()
        {
            //マップの縦データの個数
            int row = mapList.Count;
            //オブジェクト一つあたりの縦幅（サイズ）をかける
            int height = row * mapList[0][0].GetHeight();
            //マップの縦幅を返す
            return height;
        }
    }
}
