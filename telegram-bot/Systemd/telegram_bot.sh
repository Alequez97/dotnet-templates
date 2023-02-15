#!/bin/bash

sudo systemctl stop telegram_bot

git pull
rm -rf /srv/telegram_bot.TelegramBot
mkdir /srv/telegram_bot.TelegramBot
chown root /srv/telegram_bot.TelegramBot
cd ..
dotnet publish -c Release -o /srv/telegram_bot.TelegramBot

sudo cp telegram_bot.service /etc/systemd/system/telegram_bot.service
sudo systemctl daemon-reload
echo "run sudo systemctl start telegram_bot to start service"