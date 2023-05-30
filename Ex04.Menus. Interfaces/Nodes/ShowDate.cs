namespace Ex04.Menus.Interfaces.Nodes
{
    public class ShowDate : IClickListener
    {
        public void Click()
        {
            string date = System.DateTime.Now.ToString("dd/MM/yyyy");
            System.Console.WriteLine($"{date}\n");
        }
    }
}