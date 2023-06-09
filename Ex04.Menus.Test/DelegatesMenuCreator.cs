﻿using System;
using Ex04.Menus.Delegates;
using Ex04.Menus.Test.Services;

namespace Ex04.Menus.Test
{
    public class DelegatesMenuCreator
    {
        private readonly DateShowerService r_DateShower;
        private readonly TimeShowerService r_TimeShower;
        private readonly VersionShowerService r_VersionShower;
        private readonly SpacesCounterService r_SpacesCounter;

        public DelegatesMenuCreator()
        {
            r_TimeShower = TimeShowerService.CreateInstance();
            r_DateShower = DateShowerService.CreateInstance();
            r_VersionShower = VersionShowerService.CreateInstance();
            r_SpacesCounter = SpacesCounterService.CreateInstance();
        }
        public MainMenu GetMenu()
        {
            const string k_MainMenuTitle = "Delegates Main Menu";
            const string k_ShowDateAndTimeSubMenuTitle = "Show Date/Time";
            const string k_VersionAndSpacesSubMenuTitle = "Version and Spaces";
            const string k_ShowDateActionItemTitle = "Show Date";
            const string k_ShowTimeActionItemTitle = "Show Time";
            const string k_ShowVersionActionItemTitle = "Show Version";
            const string k_CountSpacesActionItemTitle = "Count Spaces";

            MenuItem showDateActionItem = createMenuActionItem(k_ShowDateActionItemTitle, r_DateShower.MenuItem_BeenSelected);
            MenuItem showTimeActionItem = createMenuActionItem(k_ShowTimeActionItemTitle, r_TimeShower.MenuItem_BeenSelected);
            MenuItem showDateAndTimeSubMenu = createMenuItem(k_ShowDateAndTimeSubMenuTitle, showDateActionItem, showTimeActionItem);
            MenuItem showVersionActionItem = createMenuActionItem(k_ShowVersionActionItemTitle, r_VersionShower.MenuItem_BeenSelected);
            MenuItem countSpacesActionItem = createMenuActionItem(k_CountSpacesActionItemTitle, r_SpacesCounter.MenuItem_BeenSelected);
            MenuItem versionAndSpacesSubMenu = createMenuItem(k_VersionAndSpacesSubMenuTitle, showVersionActionItem, countSpacesActionItem);
            MainMenu mainMenu = createMainMenu(k_MainMenuTitle, showDateAndTimeSubMenu, versionAndSpacesSubMenu);

            return mainMenu;
        }
        private MainMenu createMainMenu(string i_Title, params MenuItem[] i_SubMenuItemsToAdd)
        {
            MainMenu mainMenu = new MainMenu()
            {
                Title = i_Title
            };

            mainMenu.AddSubItems(i_SubMenuItemsToAdd);

            return mainMenu;
        }
        private MenuItem createMenuItem(string i_Title, params MenuItem[] i_SubMenuItemsToAdd)
        {
            MenuItem menuItem = new MenuItem()
            {
                Title = i_Title
            };

            menuItem.AddSubItems(i_SubMenuItemsToAdd);

            return menuItem;
        }
        private MenuItem createMenuActionItem(string i_Title, Action i_ToAdd)
        {
            MenuItem menuItem = new MenuItem()
            {
                Title = i_Title
            };

            menuItem.SubscribeAsObserver(i_ToAdd);

            return menuItem;
        }
    }
}
