namespace BlazorDemo.Client.Pages.Demo.Demo5
{
    public partial class Demo5
    {
        public Student MyStudent { get; set; }

        public Demo5()
        {
            MyStudent = new Student();
        }

        public void OnSubmit()
        {
            Console.WriteLine(MyStudent.Firstname + " " + MyStudent.YearResult);
        }
    }
}
