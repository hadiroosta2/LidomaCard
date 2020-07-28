using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace LidomaCard
{
    [Serializable]
   public class graphicList
    {
        List<drawBase> list;
        drawBase activeChild;
        
        public graphicList()
        {
            list = new List<drawBase>();
            activeChild = new labelObject();
           
        }
       
        public void add(drawBase o)
        {
            UnSelectAll();
            list.Add(o);
            activeChild = o;
           
        }
        public void addSelection(Point p)
        {
            for (int i = list.Count - 1; i >= 0; --i)
            {
                if (list[i].HitTest(p) == 0 || list[i].HitTest(p) == -1)
                {
                    list[i].Select = true;
                }

            }
        }
        public int wichSelect(Point p)
        {
            UnSelectAll();
            for(int i=list.Count-1 ;i>=0;--i)
            {
                if (list[i].HitTest(p) == 0 || list[i].HitTest(p) ==-1)
                {
                    list[i].Select = true;

                    return i;
                }
                
            }
            return -1;
        }

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public drawBase this[int index]
        {
            get
            {
                if (index < 0 | index>=list.Count)
                {
                    return null;
                }
                return list[index];
            }
        }

        public IEnumerable<drawBase> selection
        {
            get
            {
                foreach (drawBase o in list)
                {
                    if (o.Select)
                        yield return o;
                }
            }
        }

        public int activeIndex()
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Select)
                {
                  
                    return i;

                }
            }
            return -1;
        }

        public void MoveNext()
        {
            int i = activeIndex();
            if (i >= 0 && i + 1 < list.Count)
            {
                UnSelectAll();
                list[i + 1].Select = true;
                activeChild = list[i + 1];
            }
            else
            {
                UnSelectAll();
                list[0].Select = true;
                activeChild = list[0];
            }
            
        }
        public void sellectAll()
        {
            foreach (drawBase o in list)
            {
                o.Select = true;
            }
            
        }
        public int SelectionCount
        {
            get
            {
                int n = 0;

                foreach (drawBase o in selection)
                {
                    n++;
                }

                return n;
            }
        }
        public void  DeletSelection()
        {
            int n = list.Count;
            for(int i=n-1;i>=0;--i)
            {
                if(((drawBase)list[i]).Select)
                list.RemoveAt(i);
              
            }
               
        }

        public void UnSelectAll()
        {
            foreach (drawBase o in selection)
            {
                o.Select = false;
            }
        }
        public void DeleteLastAddedObject()
        {
            if (list.Count > 0)
            {
                list.RemoveAt(0);
            }
        }
        public void print(DrawArea drawArea,Graphics g,int j,bool border)
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            foreach (drawBase o in list)
            {
               
                o.print( drawArea,g, j,border);

            }
        }
        public virtual void draw(DrawArea drawArea, Graphics g,float zoom)
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            foreach (drawBase o in list)
            {
               
                o.Draw(drawArea, g,zoom);
              
            }
        }

        public bool clear()
        {
            bool result = (list.Count >= 1);
            list.Clear();
            activeChild = null;
            return result;

        }

        public void moveToBack(drawBase o)
        {

            list.Insert(0, o);
        }

       

    }
}
