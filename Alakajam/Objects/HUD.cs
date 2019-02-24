using BS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alakajam.Objects
{
	class HUD : GameObject
	{
		SpriteFont font;

		Player player1; Player player2;

		public HUD(ContentManager content, Player player1, Player player2)
		{
			font = content.Load<SpriteFont> ("Fonts/5x7");
			this.player1 = player1;
			this.player2 = player2;
		}

		public Vector2 GetRow(PlayerNumber number, int row)
		{
			float x = (number == PlayerNumber.ONE ? 5 - 75 : 320 + 5);
			float y = 5 + row * 20;

			return new Vector2 (x, y);
		}

		public override void Update(GameTime gameTime)
		{
			base.Update (gameTime);
		}

		public override void Draw(SpriteBatch batch)
		{
			batch.DrawString (font, "     P1", GetRow(PlayerNumber.ONE, 0), Player.BLUE);
			batch.DrawString (font, "HEALTH: " + (int) player1.Health, GetRow(PlayerNumber.ONE, 1), Color.White);

			base.Draw (batch);
		}
	}
}
