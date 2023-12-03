using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FifteenPuzzle
{
    public class ScoreWinLose : Move
    {
        private SpriteFont _font;
        sbyte score = 100; //where the score starts at , also use only even numbers to avoid issues
        const int seconds = 30; // 600 seconds is 10 minutes
        public int timer = 60 * seconds;
        private Vector2 _position; //position of the font
        const int timerConstant = 60 * seconds;
        bool isGameWon = false;


        public ScoreWinLose(SpriteFont font, Vector2 position)
        {
            _font = font;
            _position = position;
        }

        public override void Update()
        {

            if (isGameWon == true) // keep counting down as long as timer doesn't equal 0 and game isn't won
            {
               
            } else if (timer != 0 && isGameWon == false)
            {
                timer--;
            }

            if (timer == timerConstant - timerConstant * 20 / 100) // if 20 percent of timer is gone then score goes to 80
            {
                score = 80;
            }

            if (timer == timerConstant - timerConstant * 40 / 100) // if 40 percent of timer is gone then score goes to 50
            {
                score = 50;
            }
            if (timer == timerConstant - timerConstant * 80 / 100) // if 80 percent of timer is gone then score goes to 30
            {
                score = 30;
            }
            if (timer == timerConstant - timerConstant * 90 / 100) // if 90 percent of timer is gone then score goes to 10
            {
                score = 10;
            }
            if (timer == 0) // if timer is 0, then score is 0
            {
                score = 0;
            }
            if (areTilesAlligned())
            {
                isGameWon = true;
            } else if (!areTilesAlligned())
            {
                isGameWon = false;
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //use the drawstring method to draw text
            spriteBatch.DrawString(_font, "Score: " + score, _position = new Vector2(920, 10), Color.Black);
            spriteBatch.DrawString(_font, "Time remaining: " + timer, _position = new Vector2(920, 50), Color.Black);
            spriteBatch.DrawString(_font, "milliseconds", _position = new Vector2(1100, 80), Color.Black);
            spriteBatch.DrawString(_font, "(start at: 10 minutes)", _position = new Vector2(920, 120), Color.Black);

            if (score == 0)
            {
                spriteBatch.DrawString(_font, "You have Lost", _position = new Vector2(920, 180), Color.Red);
            } else if (isGameWon == true)
            {
                spriteBatch.DrawString(_font, "You have Won", _position = new Vector2(920, 180), Color.Green);
            }

            
        }
        public bool areTilesAlligned()
        {
            return this.posTileOneY == 360 && posTileOneX == 0 && posTileTwoX == 213 && posTileTwoY == 360 && posTileThreeX == 426 && posTileThreeY == 360 && posTileFourX == 639 &&
        posTileFourY == 360 && posTileFiveX == 0 && posTileFiveY == 240 && posTileSixX == 213 && posTileSixY == 240 && posTileSevenX == 426 && posTileSevenY == 240 &&
        posTileEightX == 639 && posTileEightY == 240 && posTileNineX == 0 && posTileNineY == 120 && posTileTenX == 213 && posTileTenY == 120 && posTileElevenX == 426 &&
        posTileElevenY == 120 && posTileTwelveX == 639 && posTileTwelveY == 120 && posTileThirteenX == 0 && posTileThirteenY == 0 && posTileFourteenX == 213 &&
        posTileFourteenY == 0 && posTileFifteenX == 426 && posTileFifteenY == 0 && posTileSixteenX == 639 && posTileSixteenY == 0;
        }


    }
}
