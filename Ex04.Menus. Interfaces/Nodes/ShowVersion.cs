namespace Ex04.Menus.Interfaces.Nodes
{
    public class ShowVersion : IClickListener
    {
        public void Click()
        {
            string version = "Version: 23.2.4.9805";
            System.Console.WriteLine($"{version}\n");
        }
    }
}