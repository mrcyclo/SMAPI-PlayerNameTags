using Microsoft.Xna.Framework;
using StardewValley;

namespace PlayerNameTags
{
    /**
     * tile position
     * top-left corner of the map
     * measured in tiles; used when placing things on the map (e.g., location.Objects uses tile positions).
     * 
     * absolute position
     * top-left corner of the map
     * measured in pixels; used when more granular measurements are needed (e.g., NPC movement).
     * 
     * screen position
     * top-left corner of the visible screen
     * measured in pixels; used when drawing to the screen.
     */

    public class CoordinateConversion
    {
        public static Vector2 absoluteToScreen(Vector2 position)
        {
            return new Vector2(
                position.X - Game1.viewport.X,
                position.Y - Game1.viewport.Y
            );
        }

        public static Vector2 absoluteToTile(Vector2 position)
        {
            return new Vector2(
                position.X / Game1.tileSize,
                position.Y / Game1.tileSize
            );
        }

        public static Vector2 screenToAbsolute(Vector2 position)
        {
            return new Vector2(
                position.X + Game1.viewport.X,
                position.Y + Game1.viewport.Y
            );
        }

        public static Vector2 screenToTile(Vector2 position)
        {
            return new Vector2(
                (position.X + Game1.viewport.X) / Game1.tileSize,
                (position.Y + Game1.viewport.Y) / Game1.tileSize
            );
        }

        public static Vector2 tileToAbsolute(Vector2 position)
        {
            return new Vector2(
                position.X * Game1.tileSize,
                position.Y * Game1.tileSize
            );
        }

        public static Vector2 tileToScreen(Vector2 position)
        {
            return new Vector2(
                (position.X * Game1.tileSize) - Game1.viewport.X,
                (position.Y * Game1.tileSize) - Game1.viewport.Y
            );
        }
    }
}
