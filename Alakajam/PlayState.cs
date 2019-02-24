using BS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alakajam
{
	class PlayState : GameState
	{
		Texture2D background;
		BreaddedCamera camera;
		GameObjectGroup objects;

		Player player1; Player player2;

		public PlayState(ContentManager content)
		{
			background = content.Load<Texture2D> ("Images/background");

			camera = new BreaddedCamera (640, 480);
			camera.Zoom = 2F;
			camera.MoveTo (new Vector2 (160, 120));

			objects = new GameObjectGroup ();

			player1 = new Player (PlayerNumber.ONE, content);
			objects.Add (player1);
			player2 = new Player (PlayerNumber.TWO, content);
			objects.Add (player2);
		}

		public override void Update(GameTime gameTime)
		{
			Parent.TransformMatrix = camera.Transform;

			objects.Update (gameTime);

			base.Update (gameTime);
		}

		public override void Draw(SpriteBatch batch)
		{
			batch.Draw (background, Vector2.Zero, Color.White);

			objects.Draw (batch);

			base.Draw (batch);
		}
	}
}
