using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace PlayerNameTags
{
    public class FarmerPatches
    {
        public static void draw_Postfix(Farmer __instance, SpriteBatch b)
        {
            DrawPlayerNameTag(b, __instance);
        }

        private static void DrawPlayerNameTag(SpriteBatch b, Farmer farmer)
        {
            // Get size of text after rendered
            SpriteFont font = Game1.content.Load<SpriteFont>("Fonts\\SmallFont", LocalizedContentManager.CurrentLanguageCode);
            int nameWidth = (int)font.MeasureString(farmer.Name).X;
            int nameHeight = (int)font.MeasureString(farmer.Name).Y;

            // Get absolute position of farmer
            Vector2 farmerAbsolutePosition = farmer.getStandingPosition();

            // Convert to screen position
            Vector2 farmerScreenPosition = CoordinateConversion.absoluteToScreen(farmerAbsolutePosition);

            // Calculating draw screen position
            Vector2 drawPosition = new Vector2(
                farmerScreenPosition.X - nameWidth / 2,
                farmerScreenPosition.Y - Game1.tileSize * 2.3f
            );

            // Color
            Color textColor = Color.White;
            Color bgColor = Color.Black * 0.7f;

            // Get draw layer
            float drawLayer = farmer.getDrawLayer();

            // Draw background
            int paddingX = 12;
            int paddingY = 2;
            Rectangle bgRect = new Rectangle((int)drawPosition.X - paddingX / 2, (int)drawPosition.Y - paddingY / 2, nameWidth + paddingX, nameHeight + paddingY);
            b.Draw(Game1.staminaRect, bgRect, null, bgColor, 0, Vector2.Zero, SpriteEffects.None, drawLayer);

            // Draw text to screen
            b.DrawString(font, farmer.Name, drawPosition, textColor, 0, Vector2.Zero, 1, SpriteEffects.None, drawLayer + 0.0001f);
        }
    }
}
