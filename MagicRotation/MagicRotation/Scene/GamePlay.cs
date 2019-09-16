using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MagicRotation.Actor;
using MagicRotation.Device;
using MagicRotation.Scene;
using MagicRotation.Util;

namespace MagicRotation.Scene
{
    class GamePlay : IScene
    {
        // マップ
        private Map map;
        private GameObjectManager gameObjectManager;
        private GameDevice gameDevice;
        private Renderer renderer;
        private bool IsEndFlag;

        public GamePlay()
        {
            gameDevice = GameDevice.Instance();
            gameObjectManager = new GameObjectManager();
        }

        public void Initialize()
        {
            gameObjectManager.Initialize();
            // マップ生成
            map = new Map(GameDevice.Instance());
            map.Load("map.csv");

            gameObjectManager.Add(map);

            //csvデータからゲームオブジェクトを登録する
            //GameObjectCSVParser parser = new GameObjectCSVParser(gameObjectManager);
            //var dataList = parser.Parse("stage案1-1.csv", "./csv/");
            //foreach (var data in dataList)
            //{
            //    gameObjectManager.Add(data);
            //}
        }
        

        public void Draw(Renderer renderer)
        {
            // Begin
            renderer.Begin();

            // マップ描画処理
            //renderer.DrawTexture("backColor", Vector2.Zero);
            map.Draw(renderer);
            gameObjectManager.Draw(renderer);

            // End
            renderer.End();
        }

        public Map GetMap()
        {
            return map;
        }

        public void Update(GameTime gameTime)
        {
            gameObjectManager.Update(gameTime);

            map.Updata(gameTime);

            //Draw(renderer);
        }

        public void Shutdown()
        {
            
        }

        public bool IsEnd()
        {
            return IsEndFlag;
        }

        public SceneName Next()
        {
            return SceneName.GamePlay;
        }
    }
}
