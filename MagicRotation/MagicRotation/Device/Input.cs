using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace MagicRotation.Device
{
    class Input
    {
        private static Vector2 velocity = Vector2.Zero;
        private static Vector2 padVelocity = Vector2.Zero;


        //追加
        // 現在のキーボードの状態
        private static KeyboardState currentKey;
        // 1フレーム前のキーボードの状態
        private static KeyboardState previousKey;


        //ゲームパッド
        private static List<PlayerIndex> playerIndex = new List<PlayerIndex>()
        {
            PlayerIndex.One,PlayerIndex.Two
        };
        private static Dictionary<PlayerIndex, GamePadState> currentGamePads =
            new Dictionary<PlayerIndex, GamePadState>()
            {
                {PlayerIndex.One,GamePad.GetState(PlayerIndex.One) }
            };
        private static Dictionary<PlayerIndex, GamePadState> previousGamePads =
            new Dictionary<PlayerIndex, GamePadState>()
            {
                {PlayerIndex.One,GamePad.GetState(PlayerIndex.One) }
            };
        // private Vector2 pos;

        public static void Update()
        {
            //ゲームパッド
            for (int i = 0; i < currentGamePads.Count; i++)
            {
                if (currentGamePads[playerIndex[i]].IsConnected == false)
                {
                    continue;
                }
                previousGamePads[playerIndex[i]] =
                    currentGamePads[playerIndex[i]];
                currentGamePads[playerIndex[i]] =
                    GamePad.GetState((PlayerIndex)i);
            }

            #region 汚い
            //previousState = currentState;
            //currentState = GamePad.GetState(PlayerIndex.One);
            //if (currentState.IsConnected)
            //{
            //    pos.X += currentState.ThumbSticks.Left.X * 1.0f;
            //    pos.Y += currentState.ThumbSticks.Left.Y * 1.0f;
            //}


            //if (gamePadState.IsConnected)
            //{
            //    string text = "";

            //    if (gamePadState.Buttons.A == ButtonState.Pressed)
            //    {
            //        text += "A押されたよ～";
            //    }


            //    float lX = gamePadState.ThumbSticks.Left.X;
            //    float lY = gamePadState.ThumbSticks.Left.Y;

            //    float tl = gamePadState.Triggers.Left;
            //    float tr = gamePadState.Triggers.Right;

            //    text = "LeftStick" + lX + "";
            //    text = "RightStick" + lY + "";

            //    text = "LeftTrigger" + tl + "";
            //    text = "RightTrigger" + tr + "";
            //}
            #endregion


            //更新
            UpdateVelocity();

            // キーボード
            previousKey = currentKey;
            currentKey = Keyboard.GetState();
        }



        //public static Vector2 Velocity()
        //{
        //    return velocity;
        //}

        private static void UpdateVelocity()
        {
            //毎ループ初期化
            velocity = Vector2.Zero;



            //正規化
            if (velocity.Length() != 0)
            {
                velocity.Normalize();
            }
        }

        public static bool IsButtonDown(PlayerIndex index, Buttons button)
        {
            if (currentGamePads[index].IsConnected == false)
            {
                return false;
            }
            return currentGamePads[index].IsButtonDown(button) &&
                !previousGamePads[index].IsButtonDown(button);
        }

        public static bool IsButtonPress(PlayerIndex index, Buttons button)
        {
            if (currentGamePads[index].IsConnected == false)
            {
                return false;
            }
            return currentGamePads[index].IsButtonDown(button);
        }

        public static bool IsButtonUp(PlayerIndex index, Buttons button)
        {
            if (currentGamePads[index].IsConnected == false)
            {
                return false;
            }
            return currentGamePads[index].IsButtonUp(button) && previousGamePads[index].IsButtonDown(button);
        }

        public static bool IsButtonRelease(PlayerIndex index, Buttons button)
        {
            if (currentGamePads[index].IsConnected == false)
            {
                return false;
            }
            return currentGamePads[index].IsButtonUp(button);
        }

        //public static bool GetStick(PlayerIndex index,GamePadThumbSticks gamePadThumbSticks)
        //{
        //    if (currentGamePads[index].IsConnected == false)
        //    {
        //        return false;
        //    }

        //    return true;
        //    //return currentGamePads[index].IsConnected(gamePadThumbSticks);
        //}

        public static Vector2 Velocity(PlayerIndex index)
        {
            if (currentGamePads[index].IsConnected == false)
            {
                return Vector2.Zero;
            }

            padVelocity = Vector2.Zero;

            //右
            if (currentGamePads[index].IsButtonDown(Buttons.DPadRight))
            {
                padVelocity.X += 1.0f;
            }
            //左
            if (currentGamePads[index].IsButtonDown(Buttons.DPadLeft))
            {
                padVelocity.X -= 1.0f;
            }
            //上
            if (currentGamePads[index].IsButtonDown(Buttons.DPadUp))
            {
                padVelocity.Y -= 1.0f;
            }
            //下
            if (currentGamePads[index].IsButtonDown(Buttons.DPadDown))
            {
                padVelocity.Y += 1.0f;
            }

            //左スティックの移動(方向や移動量)




            //正規化
            if (padVelocity.Length() != 0)
            {
                padVelocity.Normalize();
            }
            return padVelocity;
        }

        public static Vector2 GetLeftStickground(PlayerIndex index)
        {
            return new Vector2(currentGamePads[index].ThumbSticks.Left.X);//,-currentGamePads[index].ThumbSticks.Left.Y);
        }

        public static Vector2 GetLeftSticksky(PlayerIndex index)
        {
            return new Vector2(currentGamePads[index].ThumbSticks.Left.X, -currentGamePads[index].ThumbSticks.Left.Y);
        }





        /// <summary>
        /// キーが押された瞬間か？
        /// </summary>
        /// <param name="key">チェックしたいキー</param>
        /// <returns>現在キーが押されていて、1フレーム前に押されていなければtrue</returns>
        public static bool IsKeyDown(Keys key)
        {
            return currentKey.IsKeyDown(key) && !previousKey.IsKeyDown(key);
        }


        /// <summary>
        /// キーが押された瞬間か？
        /// </summary>
        /// <param name="key">チェックしたいキー</param>
        /// <returns>押された瞬間ならtrue</returns>
        public static bool GetKeyTrigger(Keys key)
        {
            return IsKeyDown(key);
        }



        /// <summary>
        /// キーが押されているか？
        /// </summary>
        /// <param name="key">調べたいキー</param>
        /// <returns>キーが押されていたらtrue</returns>
        public static bool GetKeyState(Keys key)
        {
            return currentKey.IsKeyDown(key);
        }

    }
}
