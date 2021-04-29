﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace App05.Models
{
   public class Animation
    {
        public int CurrentFrame { get; set; }

        public int FrameCount { get; private set; }

        public int FrameHeight { get { return Texture.Height; } }

        public int FrameWidth { get { return Texture.Width / FrameCount; } }
        
        public float FrameSpeed { get; set; }

        public bool IsLooping { get; set; }

        public Texture2D Texture { get; private set; }

        public Animation (Texture2D texture, int frameCount, float frameSpeed)
        {
            Texture = texture;

            FrameCount = frameCount;

            IsLooping = true;

            FrameSpeed = frameSpeed;
        }


    }
}
