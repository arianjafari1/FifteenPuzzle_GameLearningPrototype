using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FifteenPuzzle
{
    public class Tile : Sprite //this is a class to slit the image into Tiles for the puzzle
    {
        private Texture2D _textureTile; //texture set to private
        private Vector2 _positionTile; //position of the asset

        //constructor
        public Tile(Texture2D texture, Vector2 position) : base(texture, position)
        {
            _textureTile = texture;
            _positionTile = position;
        }

        //getters for the vectors and texture
        public Texture2D getTexture()
        {
            return this._textureTile;
        }
        public Vector2 getPosition()
        {
            return this._positionTile;
        }

        //setters
        public void setTexture(Texture2D newTexture)
        {
            this._textureTile = newTexture;
        }
        public void setPosition(Vector2 newPosition)
        {
            this._positionTile = newPosition;
        }



        const byte tileWidth = 212; // 854 pixels of the total images divide by 4 and -1.5 to make it a whole and leave some space
        const sbyte tileHeight = 118; //480 pixels divided by 4 - 2 to leave some space

        //(where to split X, where to split Y, how much it cuts from original X, same for Y):
        //Rectangle sourceRect = new Rectangle(0, 0, 302, 302);
        //Rectangle sourceRect2 = new Rectangle(0, 0, 302, 302);


            
        public void DrawTiles(SpriteBatch _spriteBatch, int vectorX, int vectorY, int splitX = 0, int splitY = 0, int cutX = tileWidth, int cutY = tileHeight) //draw method
        {
            //overloading draw method with sourceRect to split image into multiple tiles
            _spriteBatch.Draw(getTexture(), new Vector2(vectorX, vectorY), new Rectangle(splitX, splitY, cutX, cutY), Color.White);

        }

        public void DrawBlackTile(SpriteBatch _spriteBatch, int vectorX, int vectorY, int splitX = 0, int splitY = 0, int cutX = tileWidth, int cutY = tileHeight) //draw method
        {
            //overloading draw method with sourceRect to split image into multiple tiles
            _spriteBatch.Draw(getTexture(), new Vector2(vectorX, vectorY), new Rectangle(splitX, splitY, cutX, cutY), Color.Black);

        }

    }
}
