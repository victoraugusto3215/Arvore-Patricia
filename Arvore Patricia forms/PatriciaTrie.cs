using System;
using System.Collections.Generic;
using System.Text;

namespace Arvore_Patricia_forms
{
    public class PatriciaTrie
    {
        public class Node
        {
            public string Key;
            public int BitIndex;
            public Node Left;
            public Node Right;

            public Node(string key, int bitIndex)
            {
                Key = key;
                BitIndex = bitIndex;
                Left = Right = this;
            }

            public bool IsLeaf => Left == this && Right == this;
        }

        public Node Root = null;

        public void Insert(string word)
        {
            string binary = ToBinary(word);
            if (Root == null)
            {
                Root = new Node(binary, -1);
                return;
            }

            Node parent = null;
            Node current = Root;

            while (!current.IsLeaf && current.BitIndex < FirstDifferentBit(current.Key, binary))
            {
                parent = current;
                current = GetBit(binary, current.BitIndex) == 0 ? current.Left : current.Right;
            }

            int diffBit = FirstDifferentBit(current.Key, binary);
            if (diffBit == -1) return;

            Node newLeaf = new Node(binary, -1);
            Node newInternal = new Node(binary, diffBit);

            if (GetBit(binary, diffBit) == 0)
            {
                newInternal.Left = newLeaf;
                newInternal.Right = current;
            }
            else
            {
                newInternal.Left = current;
                newInternal.Right = newLeaf;
            }

            if (parent == null)
            {
                Root = newInternal;
            }
            else if (GetBit(binary, parent.BitIndex) == 0)
            {
                parent.Left = newInternal;
            }
            else
            {
                parent.Right = newInternal;
            }
        }

        public Node SearchNode(string word)
        {
            string binary = ToBinary(word);
            Node current = Root;
            Node prev = null;

            while (!current.IsLeaf)
            {
                prev = current;
                int bit = GetBit(binary, current.BitIndex);
                current = bit == 0 ? current.Left : current.Right;

                // Segurança: se cair em um loop por erro de bitIndex incorreto
                if (prev == current) break;
            }

            if (current != null && current.Key == binary)
                return current;

            return null;
        }

        public bool Remove(string word)
        {
            string binary = ToBinary(word);
            if (Root == null) return false;

            Node grandParent = null;
            Node parent = null;
            Node current = Root;

            while (!current.IsLeaf)
            {
                grandParent = parent;
                parent = current;
                current = GetBit(binary, current.BitIndex) == 0 ? current.Left : current.Right;
            }

            if (current.Key != binary) return false;

            if (parent == null)
            {
                Root = null;
                return true;
            }

            Node sibling = (parent.Left == current) ? parent.Right : parent.Left;

            if (grandParent == null)
            {
                Root = sibling;
            }
            else
            {
                if (grandParent.Left == parent)
                    grandParent.Left = sibling;
                else
                    grandParent.Right = sibling;
            }

            return true;
        }

        private int GetBit(string binary, int index)
        {
            if (index < 0 || index >= binary.Length) return 0;
            return binary[index] == '1' ? 1 : 0;
        }

        private int FirstDifferentBit(string a, string b)
        {
            int max = Math.Max(a.Length, b.Length);
            for (int i = 0; i < max; i++)
            {
                char bitA = i < a.Length ? a[i] : '0';
                char bitB = i < b.Length ? b[i] : '0';
                if (bitA != bitB) return i;
            }
            return -1;
        }

        public string ToBinary(string word)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(word);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public string FromBinary(string binary)
        {
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < binary.Length; i += 8)
            {
                string byteString = binary.Substring(i, Math.Min(8, binary.Length - i));
                bytes.Add(Convert.ToByte(byteString, 2));
            }
            return Encoding.UTF8.GetString(bytes.ToArray());
        }
    }
}
