namespace Tuple
{
    public class MyTuple<T1, T2>
    {
        private T1 item1;
        private T2 item2;

        public MyTuple(T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }
        

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2}";
        }
    }
}
