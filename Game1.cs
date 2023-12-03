using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace FifteenPuzzle
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //member variables
        private Sprite _background;
        private Tile _puzzleImage;
        private ScoreWinLose _scoreWinLose;
        public Move movement = new Move();
        Song song;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //setting the resolution of game:
            _graphics.PreferredBackBufferWidth = 1280; //Width
            _graphics.PreferredBackBufferHeight = 720; //Height
            _graphics.ApplyChanges();



;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            var backgroundTexture = Content.Load<Texture2D>("sprites/gamebackground"); //loading the sprite in a variable
            var backgroundPosition = new Vector2(0, 0); //creating a vector position in a variable for the sprite background
            _background = new Sprite(backgroundTexture, backgroundPosition); //loading the sprite with the appropriate parameters


            var puzzleImage = Content.Load<Texture2D>("sprites/wastelandPuzzlePicture"); //loading the sprite for the puzzle
            var wholePuzzlePosition = new Vector2(0, 0); //creating a vector position in a variable for the sprite puzzle
            _puzzleImage = new Tile(puzzleImage, wholePuzzlePosition); //loading the sprite with the appropriate parameters

            var scoreFont = Content.Load<SpriteFont>("fonts/Score");
            var scorePosition = new Vector2(0, 0);
            _scoreWinLose = new ScoreWinLose(scoreFont, scorePosition);

            song = Content.Load<Song>("audio/backgroundMusic");
            MediaPlayer.Play(song);


        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            movement.Update(); //update method from the Move class that I created to move the tiles
            _scoreWinLose.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _background.Draw(_spriteBatch);

            //for loop to loop through the overloaded draw method to create 16 tiles:
            for (int j = 0; j <= 0;)
            {
                for (int i = 0; i <= 16; i++)
                {
                    if (i == 1)
                    {
                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileSixteenX, movement.posTileSixteenY, 636, 0); //tile16 for Move
                    }
                    else if (i == 2)
                    {
                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileFifteenX, movement.posTileFifteenY, 424, 0); //tile15 for Move   
                    }
                    else if (i == 3)
                    {
                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileFourteenX, movement.posTileFourteenY, 212, 0); //tile14 for Move
                    }
                    else if (i == 4)
                    {
                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileThirteenX, movement.posTileThirteenY, 0, 0); //tile13 for Move
                    }
                    else if (i == 5)
                    {
                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileTwelveX, movement.posTileTwelveY, 636, 120); //tile12 for Move
                    }
                    else if (i == 6)
                    {
                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileElevenX, movement.posTileElevenY, 424, 120); //tile11 for Move
                    }
                    else if (i == 7)
                    {
                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileTenX, movement.posTileTenY, 212, 120); //tile 10
                    }
                    else if (i == 8)
                    {
                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileNineX, movement.posTileNineY, 0, 120); //tile9 for Move
                    }
                    else if (i == 9)
                    {

                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileEightX, movement.posTileEightY, 636, 240); //tile8 for move
                    }
                    else if (i == 10)
                    {
                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileSevenX, movement.posTileSevenY, 424, 240); //tile7 for move
                        
                    }
                    else if (i == 11)
                    {
                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileSixX, movement.posTileSixY, 212, 240); //tile 6 for Move                      
                    }
                    else if (i == 12)
                    {
                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileFiveX, movement.posTileFiveY, 0, 240); //tile5 for Move
                    }
                    else if (i == 13)
                    {
                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileFourX, movement.posTileFourY, 636, 360); //tile4 for Move
                        
                    }
                    else if (i == 14)
                    {
                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileThreeX, movement.posTileThreeY, 424, 360); //tile3 for move
                        
                    }
                    else if (i == 15)
                    {
                        _puzzleImage.DrawTiles(_spriteBatch, movement.posTileTwoX, movement.posTileTwoY, 212, 360); //tile2 for move

                    }
                    else if (i == 16)
                    {
                        _puzzleImage.DrawBlackTile(_spriteBatch, movement.posTileOneX, movement.posTileOneY, 0, 360); //tile1 for move
                    }
                    else
                    {
                    }
                }
                break;
            }

            _scoreWinLose.Draw(_spriteBatch);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
