using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class Sprite //this is a class created for the purpose of drawing static sprites
    {
        private Texture2D _texture; //texture set to private
        private Vector2 _position; //position of the asset

        //constructor where I pass the texture and position as parameters
        public Sprite(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
        }

        

        //draw method for drawing the sprite
        public virtual void Draw(SpriteBatch spriteBatch) //pasing the sprite batch to be able to use the spritebatch.draw method
        {
            spriteBatch.Draw(_texture, _position, Color.White);  //passing in the _texture var and _position var as well as setting the color so it is unaffected
        }

    }
}
