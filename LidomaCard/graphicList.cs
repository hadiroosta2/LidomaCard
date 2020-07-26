using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LidomaCard
{
    class graphicList
    {
        List<shape> glist;
        public shape activeShape;
        public graphicList()
        {
            glist = new List<shape>();
        }
        public void add(shape s)
        {
            glist.Add(s);
            activeShape = s;
        }
        public void remove()
        {
            glist.RemoveAt(glist.Count - 1);
            activeShape = null;
        }
        public void draw(Graphics g)
        {
            foreach (shape s in glist)
            {
                s.draw(g);
            }
        }
    }
}
