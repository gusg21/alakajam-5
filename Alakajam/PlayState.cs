using Alakajam.Input;
using Alakajam.Objects;
using BS;
using BS.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        PlayerController player1Controller;
        PlayerController player2Controller;

		public PlayState(ContentManager content)
		{
			background = content.Load<Texture2D> ("Images/background2");

			camera = new BreaddedCamera (940, 480);
			camera.Zoom = 2F;
			camera.MoveTo (new Vector2 (160, 120));


			objects = new GameObjectGroup (this);

            player1Controller = new PlayerController(new BreaddedButton( new BreaddedMouseButton(BreaddedMouseButton.MouseButton.LEFT)));
            player2Controller = new PlayerController(new BreaddedKey(Keys.A));

			player1 = new Player (PlayerNumber.ONE, player1Controller, content, camera);
			objects.Add (player1);
			player2 = new Player (PlayerNumber.TWO, player2Controller, content, camera);
			objects.Add (player2);

			objects.Add (new HUD (content, player1, player2));
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
