namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            var interfaceMenuCreator = new InterfacesMenuCreator();
            var delegatesMenuCreator = new DelegatesMenuCreator();
            var interfacesMenuDemo = interfaceMenuCreator.GetMenu();
            var delegatesMenuDemo = delegatesMenuCreator.GetMenu();

            interfacesMenuDemo.Enter();
            delegatesMenuDemo.Enter();
        }
    }
}
