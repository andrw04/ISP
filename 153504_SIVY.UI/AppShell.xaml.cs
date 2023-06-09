﻿using _153504_SIVY.UI.Pages;

namespace _153504_SIVY.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SongDetails), typeof(SongDetails));
            Routing.RegisterRoute(nameof(AddNewGroupPage), typeof(AddNewGroupPage));
            Routing.RegisterRoute(nameof(AddNewObjectPage), typeof(AddNewObjectPage));
            Routing.RegisterRoute(nameof(EditObjectPage), typeof(EditObjectPage));
        }
    }
}