using SIT;

const string Path = "test.dat";

var rand = new Random();

var nodesCount = 10;

ListNode headNode = new ListNode();
ListNode tailNode = new ListNode();
ListNode tempNode = new ListNode();

headNode.Data = rand.Next(0, 100).ToString();

tailNode = headNode;

for (var i = 1; i < nodesCount; i++)
    tailNode = AddNode(tailNode);

tempNode = headNode;

for (var i = 0; i < nodesCount; i++)
{
    tempNode.Rand = RandomNode(headNode, nodesCount);
    tempNode = tempNode.Next;
}

var firstNode = new ListRand();
firstNode.Head = headNode;
firstNode.Tail = tailNode;
firstNode.Count = nodesCount;

var fs = new FileStream(Path, FileMode.OpenOrCreate);
firstNode.Serialize(fs);

var second = new ListRand();
try
{
    fs = new FileStream(Path, FileMode.Open);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
second.Deserialize(fs);

if (second.Tail.Data == firstNode.Tail.Data) Console.WriteLine("Успешно");

ListNode AddNode(ListNode listNode)
{
    var random = new Random();
    var result = new ListNode
    {
        Prev = listNode,
        Next = null,
        Data = random.Next(0, 100).ToString()
    };
    listNode.Next = result;
    return result;
}

ListNode RandomNode(ListNode? head, int nodesCount)
{
    var random = new Random();
    var result = head;
    for (var i = 0; i < random.Next(0, nodesCount); i++)
    {
        result = result?.Next;
    }
    return result;
}