namespace SIT
{
    internal class ListRand
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;

        public void Serialize(FileStream s)
        {
            List<ListNode> listNodes = new List<ListNode>();
            var tempNode = new ListNode();
            tempNode = Head;

            do
            {
                listNodes.Add(tempNode);
                tempNode = tempNode.Next;
            } while (tempNode != null);

            using StreamWriter streamWriter = new StreamWriter(s);
            foreach (var listNode in listNodes)
                streamWriter.WriteLine(listNode.Data + ";" + listNodes.IndexOf(listNode.Rand));
        }

        public void Deserialize(FileStream s)
        {
            var listNodes = new List<ListNode>();
            var tempNode = new ListNode();
            Head = tempNode;
            string line;
            
            try
            {
                using (var streamReader = new StreamReader(s))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Equals("")) continue;
                        tempNode.Data = line;
                        var next = new ListNode();
                        tempNode.Next = next;
                        listNodes.Add(tempNode);
                        next.Prev = tempNode;
                        tempNode = next;
                    }
                }
                
                Tail = tempNode.Prev;
                Tail.Next = null;
                
                foreach (var listNode in listNodes)
                {
                    listNode.Rand = listNodes[int.Parse(listNode.Data.Split(';')[1])];
                    listNode.Data = listNode.Data.Split(';')[0];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ОЙ, подробности:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
