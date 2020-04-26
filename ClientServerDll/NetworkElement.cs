using System;

namespace ClientServerDll
{
    [Serializable]
    public class NetworkElement : IComparable
    {
        public int Part { get; set; }
        public byte[] Buffer { get; set; }

        public NetworkElement(int part, byte[] buffer)
        {
            Part = part;
            Buffer = buffer;
        }

        public int CompareTo(object obj)
        {
            NetworkElement element = obj as NetworkElement;
            if (element != null)
                return this.Part.CompareTo(element.Part);
            else
                throw new Exception("Error for CompareTo");
        }
    }
}