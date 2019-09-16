using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicRotation.Device;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace MagicRotation.Scene
{
    class GameTitle : IScene
    {
        //フィールド
        // 終了しているかどうか
        private bool isEndFlag;
        // サウンド
        private Sound sound;

        // レンダラー
        private Renderer renderer;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameTitle()
        {
            isEndFlag = false;
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();

            //レンダラー生成
            renderer = gameDevice.GetRenderer();
        }
        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            renderer.DrawTexture("3417_3", Vector2.Zero);
            renderer.End();
        }

        public void Initialize()
        {
            isEndFlag = false;
        }

        /// <summary>
        /// シーンが終了かどうか
        /// </summary>
        /// <returns>シーン終了ならtrue</returns>
        public bool IsEnd()
        {
            return isEndFlag;
        }

        public SceneName Next()
        {
            return SceneName.GamePlay;
        }

        public void Shutdown()
        {

        }

        public void Update(GameTime gameTime)
        {
            //Console.WriteLine(isEndFlag);

            if (Input.GetKeyTrigger(Keys.Space))
            {
                isEndFlag = true;
            }

            
            //if (/*Input.ButtonDown(PlayerIndex.One, Buttons.Y) ||*/
            //    Input.GetKeyTrigger(Keys.Space))
            //{
            //    isEndFlag = true;
            //}


        }
    }
}
