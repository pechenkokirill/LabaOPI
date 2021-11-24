﻿using System.Windows;

namespace LabaOPI.Services
{
    public static class ApplicationExtention
    {
        public static bool IsDesignTime(this Application app)
        {
            return Application.Current is not App;
        }
    }
}
