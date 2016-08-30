using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ophiuchiEscaper
{
    public class Tile
    {

        #region Fields
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        public int TileNumber;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the Tilemap
        /// </summary>
        /// <param name="texture">Texture for the sprite</param>
        /// <param name="rows">Number of rows in the image</param>
        /// <param name="columns">Number of columns</param>
        public Tile(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            totalFrames = Rows * Columns;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Updates the image to display the next frame
        /// </summary>
        public void Update()
        {
            //currentFrame++;
            //if(currentFrame == totalFrames)
            //{
            //    currentFrame = 0;
            //}
        }

        /// <summary>
        /// Draws the texture given the location
        /// </summary>
        /// <param name="spriteBatch">Spritebatch</param>
        /// <param name="location">Location to draw sprite</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 location, int tilenumber)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)tilenumber / (float)Columns);
            int column = tilenumber % Columns;

            //Rectangle containing texture we want to draw
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            //Rectangle containing where we want texture to be drawn
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width/2, height/2);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        #endregion
    }
}
