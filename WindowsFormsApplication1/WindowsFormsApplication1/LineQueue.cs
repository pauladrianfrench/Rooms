namespace Rooms
{
    using System;
    using System.Collections.Generic;

    class MyLineQueue
    {
        private List<ILine> lines;

        public MyLineQueue()
        {
            lines = new List<ILine>();
        }
        public bool Remove(ILine l)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].IsCongruentTo(l))
                {
                    lines.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool Remove(int count)
        {
            int ix = lines.Count - count;
            lines.RemoveRange(ix, count);

            return true;
        }
        public int Find(ILine l)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].IsCongruentTo(l))
                {
                    return i;
                }
            }
            return -1;
        }
        public void Enqueue(ILine l, List<Shape> shapes)
        {
            int findCount = 0;
            foreach (Shape s in shapes)
            {
                if (s.Contains(l))
                    findCount++;
            }

            if (findCount < 2 && Find(l) < 0)
                lines.Add(l);
        }
        public ILine Dequeue()
        {

            if (lines.Count == 0)
            {
                throw new Exception("Queue is empty!");
            }
            else
            {
                ILine ret = lines[0];
                lines.RemoveAt(0);
                return ret;
            }
        }
        public int Count
        {
            get { return lines.Count; }
        }
    }
}
