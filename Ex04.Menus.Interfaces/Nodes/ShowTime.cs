namespace Ex04.Menus.Interfaces.Nodes
{
    public class ShowTime : IClickListener
    {
        public void Click(){
            string time = System.DateTime.Now.ToString("HH:mm:ss");
            System.Console.WriteLine($"{time}\n");
        }
    }
}