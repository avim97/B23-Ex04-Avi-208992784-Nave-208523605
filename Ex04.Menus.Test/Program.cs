namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            var interfacesMenu = InterfacesMenuCreator.GetMenu();
            var delegatesMenu = DelegatesMenuCreator.GetMenu();

            interfacesMenu.Enter();
            delegatesMenu.Enter();
        }
    }
}
