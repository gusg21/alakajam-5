using BS.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alakajam.Input
{
    class PlayerController
    {
        public BreaddedInput fireButton;

        public PlayerController(BreaddedInput fireButton)
        {
            this.fireButton = fireButton;
        }
        public void Update(GameTime gameTime)
        {
            fireButton.Update(gameTime);
        }

    }
}
