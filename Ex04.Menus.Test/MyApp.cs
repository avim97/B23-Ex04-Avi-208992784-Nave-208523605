using Ex04.Menus.Interfaces;
using Ex04.Menus.Interfaces.Nodes;

namespace Ex04.Menus.Test
{
    public class MyApp
    {
        public void Start()
        {
            initInterfacesAndRun();
        }

        private void initInterfacesAndRun()
        {
            MenuItem mainMenu = new MenuItem("Interfaces Main Menu", true);

            MenuItem showDateAndTimeSubMenu = new MenuItem("Show Date/Time", false);
            showDateAndTimeSubMenu.ParentMenuItem = mainMenu;
            MenuItem versionAndSpacesSubMenu = new MenuItem("Version and Spaces", false);
            versionAndSpacesSubMenu.ParentMenuItem = mainMenu;

            IClickListener countSpacesListener = new CountSpaces();
            IClickListener showVersionListener = new ShowVersion();
            IClickListener showTimeListener = new ShowTime();
            IClickListener showDateListener = new ShowDate();

            MenuItem countSpaces = new MenuItem("Count Spaces", false);
            countSpaces.ClickListener = countSpacesListener;
            countSpaces.ParentMenuItem = versionAndSpacesSubMenu;

            MenuItem showVersion = new MenuItem("Show Version", false);
            showVersion.ClickListener = showVersionListener;
            showVersion.ParentMenuItem = versionAndSpacesSubMenu;

            MenuItem showTime = new MenuItem("Show Time", false);
            showTime.ClickListener = showTimeListener;
            showTime.ParentMenuItem = showDateAndTimeSubMenu;

            MenuItem showDate = new MenuItem("Show Date", false);
            showDate.ClickListener = showDateListener;
            showDate.ParentMenuItem = showDateAndTimeSubMenu;

            mainMenu.AddMenuItem(showDateAndTimeSubMenu);
            mainMenu.AddMenuItem(versionAndSpacesSubMenu);

            showDateAndTimeSubMenu.AddMenuItem(showDate);
            showDateAndTimeSubMenu.AddMenuItem(showTime);

            versionAndSpacesSubMenu.AddMenuItem(showVersion);
            versionAndSpacesSubMenu.AddMenuItem(countSpaces);


            mainMenu.Click();
        }
    }
}