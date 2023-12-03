using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace FifteenPuzzle
{
     
    public class Move
    {
        //this is the speed for the X and Y axis
        protected int speedY = 240 / 2;
        protected int speedX = 213;
        

        // this is where I set the positins of the tiles so I can easily manipulate them for movement:
        /// <summary>
        /// this is where I am writing the positions for tile, in this case, X and Y togheter

        public int posTileOneY = 360; //360  //position X and Y for the black tile (tile1), this is the moveable tile
        public int posTileOneX = 213; //0

        public int posTileTwoX = 0; //213  //position X and Y (tile2)
        public int posTileTwoY = 360; //360

        public int posTileThreeX = 426; //position X and Y (tile3)
        public int posTileThreeY = 360;

        public int posTileFourX = 639; // position X and Y (tile 4)
        public int posTileFourY = 360;

        public int posTileFiveX = 0; //postion X and Y (tile 5)
        public int posTileFiveY = 240;

        public int posTileSixX = 213; //position X and Y (tile 6)
        public int posTileSixY = 240;

        public int posTileSevenX = 426; //position X and Y (tile 7)
        public int posTileSevenY = 240;

        public int posTileEightX = 639; //position X and Y (tile 8)
        public int posTileEightY = 240;

        public int posTileNineX = 0; // position X and Y (tile 9)
        public int posTileNineY = 120;

        public int posTileTenX = 213; //position X and Y  (tile 10)
        public int posTileTenY = 120; 

        public int posTileElevenX = 426; //position X and Y  (tile 11)
        public int posTileElevenY = 120;

        public int posTileTwelveX = 639; //position X and Y  (tile 12)
        public int posTileTwelveY = 120;

        public int posTileThirteenX = 0; //position X and Y (tile 13)
        public int posTileThirteenY = 0;

        public int posTileFourteenX = 213; //position X and Y (tile 14)
        public int posTileFourteenY = 0;

        public int posTileFifteenX = 426; //position X and Y (tile 15)
        public int posTileFifteenY = 0;

        public int posTileSixteenX = 639; //position X and Y (tile 16)
        public int posTileSixteenY = 0;

        public void Shuffle()
        {
            posTileTwoX = 426;
            posTileThreeX = 213;
        }

        /// </summary>

        protected KeyboardState currentKey;
        protected KeyboardState previousKey;



        public virtual void  Update()
        {
            previousKey = currentKey;
            currentKey = Keyboard.GetState(); //getting keyboard keys

            // setting player movement so that it can't go off screen and it only goes once per key press, also using else if to stop player from going diagonally:
            if (currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneY > 0)
            {
                posTileOneY -= speedY;
                
            } else if (currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneY < 360)
            {
                posTileOneY += speedY;
            } else if (currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneX > 0)
            {
                posTileOneX -= speedX;
            } else if (currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneX < 639)
            {
                posTileOneX += speedX;
            }



            #region Collision
            //tile 2 Collision
            if (posTileOneX == posTileTwoX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileTwoY) //collision right
            {
                if (IsTileOneTouchingRight(posTileTwoX) &&
                posTileOneX >= 0)
                {

                    posTileTwoX -= 213;
                }
            }

            if (posTileOneX == posTileTwoX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileTwoY) //collision left
            {
                if (IsTileOneTouchingLeft(posTileTwoX) &&
                posTileOneX >= 0)
                {
                    posTileTwoX += 213;

                }
            }

            if (posTileOneY == posTileTwoY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileTwoX) //collision up
            {
                if (IsTileOneTouchingUp(posTileTwoY) &&
                posTileOneY <= 360)
                {
                    posTileTwoY += 120;

                }

            }

            if (posTileOneY == posTileTwoY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileTwoX) //collision bottom
            {
                if (IsTileOneTouchingBottom(posTileTwoY) &&
                posTileOneY <= 360)
                {
                    posTileTwoY -= 120;

                }

            }


            //collision tile 3
            if (posTileOneX == posTileThreeX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileThreeY) //colision right
            {
                if (IsTileOneTouchingRight(posTileThreeX) &&
                posTileOneX >= 0)
                {
                    posTileThreeX -= 213;

                }
            }

            if (posTileOneX == posTileThreeX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileThreeY) //collision left
            {
                if (IsTileOneTouchingLeft(posTileThreeX) &&
                posTileOneX >= 0)
                {
                    posTileThreeX += 213;

                }
            }

            if (posTileOneY == posTileThreeY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileThreeX) //collision up
            {
                if (IsTileOneTouchingUp(posTileThreeY) &&
                posTileOneY <= 360)
                {
                    posTileThreeY += 120;

                }

            }

            if (posTileOneY == posTileThreeY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileThreeX) //collision up
            {
                if (IsTileOneTouchingBottom(posTileThreeY) &&
                posTileOneY <= 360)
                {
                    posTileThreeY -= 120;

                }

            }


            //collion tile 4
            if (posTileOneX == posTileFourX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileFourY)
            {
                if (IsTileOneTouchingLeft(posTileFourX) &&
                posTileOneX >= 0)
                {
                    posTileFourX -= 213;

                }
            }

            if (posTileOneX == posTileFourX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileFourY)
            {
                if (IsTileOneTouchingLeft(posTileFourX) &&
                posTileOneX >= 0)
                {
                    posTileFourX += 213;

                }

            }

            if (posTileOneY == posTileFourY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileFourX) //collision up
            {
                if (IsTileOneTouchingUp(posTileFourY) &&
                posTileOneY <= 360)
                {
                    posTileFourY += 120;

                }

            }

            if (posTileOneY == posTileFourY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileFourX) //collion bottom
            {
                if (IsTileOneTouchingBottom(posTileFourY) &&
                posTileOneY <= 360)
                {
                    posTileFourY -= 120;

                }

            }


            //tile 5 Collision
            if (posTileOneY == posTileFiveY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileFiveX) //collision up
            {
                if (IsTileOneTouchingUp(posTileFiveY) &&
                posTileOneY <= 360)
                {
                    posTileFiveY += 120;

                }

            }

            if (posTileOneY == posTileFiveY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileFiveX) //collion bottom
            {
                if (IsTileOneTouchingBottom(posTileFiveY) &&
                posTileOneY <= 360)
                {
                    posTileFiveY -= 120;

                }

            }

            if (posTileOneX == posTileFiveX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileFiveY) //collision right
            {
                if (IsTileOneTouchingRight(posTileFiveX) &&
                posTileOneX >= 0)
                {

                    posTileFiveX -= 213;
                }
            }

            if (posTileOneX == posTileFiveX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileFiveY) //collision left
            {
                if (IsTileOneTouchingLeft(posTileFiveX) &&
                posTileOneX >= 0)
                {

                    posTileFiveX += 213;
                }
            }

            //collision tile 6
            if (posTileOneY == posTileSixY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileSixX) //collision up
            {
                if (IsTileOneTouchingUp(posTileSixY) &&
                posTileOneY <= 360)
                {
                    posTileSixY += 120;

                }

            }

            if (posTileOneY == posTileSixY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileSixX) //collion bottom
            {
                if (IsTileOneTouchingBottom(posTileSixY) &&
                posTileOneY <= 360)
                {
                    posTileSixY -= 120;

                }

            }

            if (posTileOneX == posTileSixX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileSixY) //collision right
            {
                if (IsTileOneTouchingRight(posTileSixX) &&
                posTileOneX >= 0)
                {

                    posTileSixX -= 213;
                }
            }

            if (posTileOneX == posTileSixX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileSixY) //collision left
            {
                if (IsTileOneTouchingLeft(posTileSixX) &&
                posTileOneX >= 0)
                {

                    posTileSixX += 213;
                }
            }


            //collision Tile 7
            if (posTileOneY == posTileSevenY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileSevenX) //collision up
            {
                if (IsTileOneTouchingUp(posTileSevenY) &&
                posTileOneY <= 360)
                {
                    posTileSevenY += 120;

                }

            }

            if (posTileOneY == posTileSevenY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileSevenX) //collion bottom
            {
                if (IsTileOneTouchingBottom(posTileSevenY) &&
                posTileOneY <= 360)
                {
                    posTileSevenY -= 120;

                }

            }

            if (posTileOneX == posTileSevenX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileSevenY) //collision right
            {
                if (IsTileOneTouchingRight(posTileSevenX) &&
                posTileOneX >= 0)
                {

                    posTileSevenX -= 213;
                }
            }

            if (posTileOneX == posTileSevenX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileSevenY) //collision left
            {
                if (IsTileOneTouchingLeft(posTileSevenX) &&
                posTileOneX >= 0)
                {

                    posTileSevenX += 213;
                }
            }


            //Collision Tile 8
            if (posTileOneY == posTileEightY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileEightX) //collision up
            {
                if (IsTileOneTouchingUp(posTileEightY) &&
                posTileOneY <= 360)
                {
                    posTileEightY += 120;

                }

            }

            if (posTileOneY == posTileEightY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileEightX) //collion bottom
            {
                if (IsTileOneTouchingBottom(posTileEightY) &&
                posTileOneY <= 360)
                {
                    posTileEightY -= 120;

                }

            }

            if (posTileOneX == posTileEightX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileEightY) //collision right
            {
                if (IsTileOneTouchingRight(posTileEightX) &&
                posTileOneX >= 0)
                {

                    posTileEightX -= 213;
                }
            }

            if (posTileOneX == posTileEightX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileEightY) //collision left
            {
                if (IsTileOneTouchingLeft(posTileEightX) &&
                posTileOneX >= 0)
                {

                    posTileEightX += 213;
                }
            }

            //Collision Tile 9
            if (posTileOneY == posTileNineY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileNineX) //collision up
            {
                if (IsTileOneTouchingUp(posTileNineY) &&
                posTileOneY <= 360)
                {
                    posTileNineY += 120;

                }

            }

            if (posTileOneY == posTileNineY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileNineX) //collion bottom
            {
                if (IsTileOneTouchingBottom(posTileNineY) &&
                posTileOneY <= 360)
                {
                    posTileNineY -= 120;

                }

            }

            if (posTileOneX == posTileNineX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileNineY) //collision right
            {
                if (IsTileOneTouchingRight(posTileNineX) &&
                posTileOneX >= 0)
                {

                    posTileNineX -= 213;
                }
            }

            if (posTileOneX == posTileNineX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileNineY) //collision left
            {
                if (IsTileOneTouchingLeft(posTileNineX) &&
                posTileOneX >= 0)
                {

                    posTileNineX += 213;
                }
            }


            //Collision Tile 10
            if (posTileOneY == posTileTenY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileTenX) //collision up
            {
                if (IsTileOneTouchingUp(posTileTenY) &&
                posTileOneY <= 360)
                {
                    posTileTenY += 120;

                }

            }

            if (posTileOneY == posTileTenY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileTenX) //collion bottom
            {
                if (IsTileOneTouchingBottom(posTileTenY) &&
                posTileOneY <= 360)
                {
                    posTileTenY -= 120;

                }

            }

            if (posTileOneX == posTileTenX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileTenY) //collision right
            {
                if (IsTileOneTouchingRight(posTileTenX) &&
                posTileOneX >= 0)
                {

                    posTileTenX -= 213;
                }
            }

            if (posTileOneX == posTileTenX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileTenY) //collision left
            {
                if (IsTileOneTouchingLeft(posTileTenX) &&
                posTileOneX >= 0)
                {

                    posTileTenX += 213;
                }
            }


            //Collision Tile 11
            if (posTileOneY == posTileElevenY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileElevenX) //collision up
            {
                if (IsTileOneTouchingUp(posTileElevenY) &&
                posTileOneY <= 360)
                {
                    posTileElevenY += 120;

                }

            }

            if (posTileOneY == posTileElevenY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileElevenX) //collion bottom
            {
                if (IsTileOneTouchingBottom(posTileElevenY) &&
                posTileOneY <= 360)
                {
                    posTileElevenY -= 120;

                }

            }

            if (posTileOneX == posTileElevenX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileElevenY) //collision right
            {
                if (IsTileOneTouchingRight(posTileElevenX) &&
                posTileOneX >= 0)
                {

                    posTileElevenX -= 213;
                }
            }

            if (posTileOneX == posTileElevenX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileElevenY) //collision left
            {
                if (IsTileOneTouchingLeft(posTileElevenX) &&
                posTileOneX >= 0)
                {

                    posTileElevenX += 213;
                }
            }


            //Collision tile twelve
            if (posTileOneY == posTileTwelveY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileTwelveX) //collision up
            {
                if (IsTileOneTouchingUp(posTileTwelveY) &&
                posTileOneY <= 360)
                {
                    posTileTwelveY += 120;

                }

            }

            if (posTileOneY == posTileTwelveY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileTwelveX) //collion bottom
            {
                if (IsTileOneTouchingBottom(posTileTwelveY) &&
                posTileOneY <= 360)
                {
                    posTileTwelveY -= 120;

                }

            }

            if (posTileOneX == posTileTwelveX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileTwelveY) //collision right
            {
                if (IsTileOneTouchingRight(posTileTwelveX) &&
                posTileOneX >= 0)
                {

                    posTileTwelveX -= 213;
                }
            }

            if (posTileOneX == posTileTwelveX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileTwelveY) //collision left
            {
                if (IsTileOneTouchingLeft(posTileTwelveX) &&
                posTileOneX >= 0)
                {

                    posTileTwelveX += 213;
                }
            }

            //Collision tile 13
            if (posTileOneY == posTileThirteenY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileThirteenX) //collision up
            {
                if (IsTileOneTouchingUp(posTileThirteenY) &&
                posTileOneY <= 360)
                {
                    posTileThirteenY += 120;

                }

            }

            if (posTileOneY == posTileThirteenY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileThirteenX) //collion bottom
            {
                if (IsTileOneTouchingBottom(posTileThirteenY) &&
                posTileOneY <= 360)
                {
                    posTileThirteenY -= 120;

                }

            }

            if (posTileOneX == posTileThirteenX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileThirteenY) //collision right
            {
                if (IsTileOneTouchingRight(posTileThirteenX) &&
                posTileOneX >= 0)
                {

                    posTileThirteenX -= 213;
                }
            }

            if (posTileOneX == posTileThirteenX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileThirteenY) //collision left
            {
                if (IsTileOneTouchingLeft(posTileThirteenX) &&
                posTileOneX >= 0)
                {

                    posTileThirteenX += 213;
                }
            }
            // Collison tile 14
            if (posTileOneY == posTileFourteenY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileFourteenX) //collision up
            {
                if (IsTileOneTouchingUp(posTileFourteenY) &&
                posTileOneY <= 360)
                {
                    posTileFourteenY += 120;

                }

            }

            if (posTileOneY == posTileFourteenY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileFourteenX) //collion bottom
            {
                if (IsTileOneTouchingBottom(posTileFourteenY) &&
                posTileOneY <= 360)
                {
                    posTileFourteenY -= 120;

                }

            }

            if (posTileOneX == posTileFourteenX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileFourteenY) //collision right
            {
                if (IsTileOneTouchingRight(posTileFourteenX) &&
                posTileOneX >= 0)
                {

                    posTileFourteenX -= 213;
                }
            }

            if (posTileOneX == posTileFourteenX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileFourteenY) //collision left
            {
                if (IsTileOneTouchingLeft(posTileFourteenX) &&
                posTileOneX >= 0)
                {

                    posTileFourteenX += 213;
                }
            }

            //Collision 15
            if (posTileOneY == posTileFifteenY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileFifteenX) //collision up
            {
                if (IsTileOneTouchingUp(posTileFifteenY) &&
                posTileOneY <= 360)
                {
                    posTileFifteenY += 120;

                }

            }

            if (posTileOneY == posTileFifteenY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileFifteenX) //collion bottom
            {
                if (IsTileOneTouchingBottom(posTileFifteenY) &&
                posTileOneY <= 360)
                {
                    posTileFifteenY -= 120;

                }

            }

            if (posTileOneX == posTileFifteenX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileFifteenY) //collision right
            {
                if (IsTileOneTouchingRight(posTileFifteenX) &&
                posTileOneX >= 0)
                {

                    posTileFifteenX -= 213;
                }
            }

            if (posTileOneX == posTileFifteenX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileFifteenY) //collision left
            {
                if (IsTileOneTouchingLeft(posTileFifteenX) &&
                posTileOneX >= 0)
                {

                    posTileFifteenX += 213;
                }
            }

            // Collision 16
            if (posTileOneY == posTileSixteenY && currentKey.IsKeyDown(Keys.Up) && previousKey.IsKeyUp(Keys.Up) && posTileOneX == posTileSixteenX) //collision up
            {
                if (IsTileOneTouchingUp(posTileSixteenY) &&
                posTileOneY <= 360)
                {
                    posTileSixteenY += 120;

                }

            }

            if (posTileOneY == posTileSixteenY && currentKey.IsKeyDown(Keys.Down) && previousKey.IsKeyUp(Keys.Down) && posTileOneX == posTileSixteenX) //collion bottom
            {
                if (IsTileOneTouchingBottom(posTileSixteenY) &&
                posTileOneY <= 360)
                {
                    posTileSixteenY -= 120;

                }

            }

            if (posTileOneX == posTileSixteenX && currentKey.IsKeyDown(Keys.Right) && previousKey.IsKeyUp(Keys.Right) && posTileOneY == posTileSixteenY) //collision right
            {
                if (IsTileOneTouchingRight(posTileSixteenX) &&
                posTileOneX >= 0)
                {

                    posTileSixteenX -= 213;
                }
            }

            if (posTileOneX == posTileSixteenX && currentKey.IsKeyDown(Keys.Left) && previousKey.IsKeyUp(Keys.Left) && posTileOneY == posTileSixteenY) //collision left
            {
                if (IsTileOneTouchingLeft(posTileSixteenX) &&
                posTileOneX >= 0)
                {

                    posTileSixteenX += 213;
                }
            }
            //Ends Collision for tiles



        }
        public bool IsTileOneTouchingRight(int posTileXRight) //checking for tile one if it collides with other tiles on the right
        {
            return this.posTileOneX >= posTileXRight;
        }

        public bool IsTileOneTouchingLeft(int posTileXLeft) //checking for tile one if it collides with other tiles on the left
        {
            return this.posTileOneX <= posTileXLeft;
        }

        public bool IsTileOneTouchingUp(int posTileYUp) //checking for tile one if it collides with other tiles up
        {
            return this.posTileOneY >= posTileYUp;
        }

        public bool IsTileOneTouchingBottom(int posTileYBottom) //checking for tile one if it collides with other tiles on the bottom
        {
            return this.posTileOneY <= posTileYBottom;
        }

        #endregion



    }
}
