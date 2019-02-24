using BS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alakajam
{
	class Player : MotionGameObject
	{
		PlayerNumber number;
		Texture2D tex;
		Texture2D fishingRod;
		SpriteEffects rodFlip;
		Vector2 rodOffset;

		public Player(PlayerNumber number, ContentManager content) : base()
		{
			this.number = number;

			if (number == PlayerNumber.ONE)
			{
				position = new Vector2 (1, 31);
			}
			else if (number == PlayerNumber.TWO)
			{
				position = new Vector2 (291, 31);
			}

			tex = content.Load<Texture2D> ("Images/player-" + (number == PlayerNumber.ONE ? "blue" : "green"));
			fishingRod = content.Load<Texture2D> ("Images/fishing-rod");
			rodFlip = (number == PlayerNumber.ONE ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
			rodOffset = (number == PlayerNumber.ONE ? new Vector2(23, 11) : new Vector2 (-2, 11));
		}

		public override void Draw(SpriteBatch batch)
		{
			batch.Draw (tex, position, Color.White);
			batch.Draw (fishingRod, position + rodOffset, null, Color.White, 0f, Vector2.Zero, Vector2.One, rodFlip, 0f);

			base.Draw (batch);
		}
	}

	enum PlayerNumber
	{
		ONE, TWO
	}
}
