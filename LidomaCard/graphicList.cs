using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LidomaCard
{
   public class graphicList
    {
        List<shape> glist;
        public shape activeShape;
        public graphicList()
        {
            glist = new List<shape>();
        }
        public void selectAll()
        {
            foreach (shape s in glist)
            {
                s.active = true;
            }
        }
        public void unSelectAll()
        {
            foreach (shape s in glist)
            {
                s.active = false;
            }
        }
        public void add(shape s)
        {
            unSelectAll();
            s.active = true;
            glist.Add(s);
           
        }
        public void remove()
        {
            glist.RemoveAt(glist.Count - 1);
            activeShape = null;
        }
       public void draw(Graphics g)
       {
           //foreach (shape s in glist)
           //{
           //    s.draw(g);
           //}
       }
      


    }
}
