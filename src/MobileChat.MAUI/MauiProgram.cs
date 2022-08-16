﻿using MobileChat.Client.Interfaces;
using MobileChat.Client.Services;
using MobileChat.MAUI.Interfaces;
using MobileChat.MAUI.Models;
using MobileChat.MAUI.Services;
using MudBlazor.Services;

namespace MobileChat.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            MauiAppBuilder builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddMudServices();

            //chat services
            builder.Services.AddScoped<ISaveFile, SaveFileService>();
            builder.Services.AddScoped<IChat, ChatService>();
            builder.Services.AddScoped<SessionStorage>();

            return builder.Build();
        }
    }
}