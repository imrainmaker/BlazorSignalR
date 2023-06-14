namespace BlazorDemo.Client.Pages.Demo.Demo1
{
    public partial class Demo1
    {
        public int MyValue { get; set; }

        public void AddValue()
        {
            MyValue +=1;
        }

        public void AddValue(int value)
        {
            MyValue += value;
        }
    }
}
