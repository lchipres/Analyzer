using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizer
{
    class Treeshold
    {
        Datax root;

        public void add(string s)
        {
            Datax what;
            for (int i = 0; i < s.Length; i++)
            {
                what = new Datax(s[i]);
                add(what);
            }
        }

        private void add(Datax d)
        {
            if (root == null)
            {
                root = d;
            }
            else
            {
                add(root, d);
            }
        }

        private void add(Datax place, Datax d)
        {
            if (place.Next == null)
            {
                d.Before = place;
                place.Next = d;
            }
            else
            {
                add(place.Next, d);
            }
        }

        public Boolean growTree()
        {
            if (root != null)
            {
                tree(root, '*', '/');
                // root equals to the next
                tree(root, '+', '-');
                Datax temp = root;

            }
            return false;
        }

        private Boolean tree(Datax place, char a, char b)
        {
            bool flag = false;
            if (place != null && place.Next != null)
            {
                if (place.Next.What == a || place.Next.What == b)
                {
                    flag = true;
                    place.Next.Left = place.Next.Before;
                    place.Next.Right = place.Next.Next;
                    if (place.Next.Next.Next != null)
                    {
                        place.Next.Next = place.Next.Next.Next;
                        place.Next.Next.Before = place.Next;
                    }
                    else
                    {
                        place.Next.Next= null;
                    }

                    if (place.Before != null)
                    {
                        place.Next.Before = place.Before;
                        place.Next.Before.Next = place.Next;
                    }
                    else
                    {
                        place.Next.Before = null;
                        root = root.Next;
                    }
                }
                tree(place.Next, a, b);
            }
            return flag;
        }

        public string preOrder()
        {
            if (root != null)
            {
                return preOrder(root);
            }
            return null;
        }

        private string preOrder(Datax root)
        {
            string str = "";
            if (root != null)
            {
                str += root.What + preOrder(root.Left) + preOrder(root.Right);
            }
            return str;
        }

        public string postOrder()
        {
            if (root != null)
            {
                return postOrder(root);
            }
            return null;
        }

        private string postOrder(Datax root)
        {
            string str = "";
            if (root != null)
            {
                str += postOrder(root.Left) + postOrder(root.Right) + root.What;
            }
            return str;
        }

        public int doPreOrder(string s)
        {
            Stack<int> lifo = new Stack<int>();
            for (int i = s.Length - 1; i > -1; i--)
            {
                if (s[i] == '*')
                {
                    lifo.Push((lifo.Pop() * lifo.Pop()));
                }
                else if (s[i] == '/')
                {
                    lifo.Push((lifo.Pop() / lifo.Pop()));
                }
                else if (s[i] == '+')
                {
                    lifo.Push((lifo.Pop() + lifo.Pop()));
                }
                else if (s[i] == '-')
                {
                    lifo.Push((lifo.Pop() - lifo.Pop()));
                }
                else
                {
                    lifo.Push((int)char.GetNumericValue(s[i]));
                }
            }

            return lifo.Pop();
        }

        public int doPostOrder(string s)
        {
            Stack<int> lifo = new Stack<int>();
            int a;
            int b;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '*')
                {
                    a = lifo.Pop();
                    b = lifo.Pop();
                    lifo.Push((b * a));
                }
                else if (s[i] == '/')
                {
                    a = lifo.Pop();
                    b = lifo.Pop();
                    lifo.Push((b / a));
                }
                else if (s[i] == '+')
                {
                    a = lifo.Pop();
                    b = lifo.Pop();
                    lifo.Push((b + a));
                }
                else if (s[i] == '-')
                {
                    a = lifo.Pop();
                    b = lifo.Pop();
                    lifo.Push((b - a));
                }
                else
                {
                    lifo.Push((int)char.GetNumericValue(s[i]));
                }
            }

            return lifo.Pop();
        }
    }
}
