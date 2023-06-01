using Ex04.Menus.Interfaces;
using Ex04.Menus.Test.Services;

namespace Ex04.Menus.Test
{
    public static class InterfacesMenuCreator
    {
        public static MainMenu GetMenu()
        {
            MainMenu mainMenu = new MainMenu("Interfaces Main Menu");

            MenuItem showDateAndTimeSubMenu = new MenuItem(mainMenu, "Display Date/Time");
            MenuItem versionAndSpacesSubMenu = new MenuItem(mainMenu, "Version and Spaces");

            var countSpacesService = new SpacesCounterService();
            var showVersionService = new VersionShowerService();
            var showTimeService = new TimeShowerService();
            var showDateService = new DateShowerService();

            MenuItem countSpaces = new MenuItem(versionAndSpacesSubMenu, "Count Spaces");
            countSpaces.SubscribeAsObserver(countSpacesService);

            MenuItem showVersion = new MenuItem(versionAndSpacesSubMenu, "Display Version");
            showVersion.SubscribeAsObserver(showVersionService);

            MenuItem showTime = new MenuItem(showDateAndTimeSubMenu, "Display Time");
            showTime.SubscribeAsObserver(showTimeService);

            MenuItem showDate = new MenuItem(showDateAndTimeSubMenu, "Display Date");
            showDate.SubscribeAsObserver(showDateService);

            showDateAndTimeSubMenu.AddSubItem(showDate);
            showDateAndTimeSubMenu.AddSubItem(showTime);

            versionAndSpacesSubMenu.AddSubItem(showVersion);
            versionAndSpacesSubMenu.AddSubItem(countSpaces);

            mainMenu.AddSubItem(showDateAndTimeSubMenu);
            mainMenu.AddSubItem(versionAndSpacesSubMenu);

            return mainMenu;
        }
    }
}
