using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LidomaCard
{
  public class shape
    {
        public string text;
        public int left;
        public int top;
        public float width;
        public float height;
        public bool active;
        public shape()
        {
            text = "";
            left = 0;
            top = 0;
            width = 100;
            height = 30;
            active = false;
        }
        public virtual void draw(Graphics g)
        {
           
        }
    }
}
