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
		}

		public override void Draw(SpriteBatch batch)
		{
			batch.Draw (tex, position, Color.White);

			base.Draw (batch);
		}
	}

	enum PlayerNumber
	{
		ONE, TWO
	}
}
