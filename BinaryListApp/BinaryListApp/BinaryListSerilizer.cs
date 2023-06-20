using System.IO;
using System.Threading.Tasks;
using SerializerTests.Nodes;
using SerializerTests.Interfaces;

namespace SerializerTests
{
    public class BinaryListSerializer : IListSerializer
    {
        public async Task Serialize(ListNode head, Stream s)
        {
            if (head == null)
            {
                await Task.CompletedTask;
                return;
            }

            using (var writer = new BinaryWriter(s, System.Text.Encoding.UTF8, true))
            {
                await SerializeNode(head, writer);
            }
        }

        public async Task<ListNode> Deserialize(Stream s)
        {
            if (s.Length == 0)
                return null;

            using (var reader = new BinaryReader(s, System.Text.Encoding.UTF8, true))
            {
                return await DeserializeNode(reader);
            }
        }

        public async Task<ListNode> DeepCopy(ListNode head)
        {
            if (head == null)
                return null;

            var newHead = new ListNode();
            newHead.Previous = await DeepCopy(head.Previous);
            newHead.Next = await DeepCopy(head.Next);
            newHead.Random = await DeepCopy(head.Random);

            return newHead;
        }

        private async Task SerializeNode(ListNode node, BinaryWriter writer)
        {
            if (node == null)
            {
                writer.Write(-1);
                return;
            }

            writer.Write(node.Data);

            await SerializeNode(node.Previous, writer);
            await SerializeNode(node.Next, writer);
            await SerializeNode(node.Random, writer);
        }

        private async Task<ListNode> DeserializeNode(BinaryReader reader)
        {
            int value = reader.ReadInt32();
            if (value == -1)
                return null;

            var node = new ListNode();

            node.Previous = await DeserializeNode(reader);
            node.Next = await DeserializeNode(reader);
            node.Random = await DeserializeNode(reader);

            return node;
        }
    }
}
