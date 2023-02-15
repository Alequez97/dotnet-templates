#!/bin/bash

sudo systemctl stop telegram_bot

git pull
rm -rf /srv/VirtualCards.TelegramBot
mkdir /srv/VirtualCards.TelegramBot
chown root /srv/VirtualCards.TelegramBot
cd ..
dotnet publish -c Release -o /srv/VirtualCards.TelegramBot

sudo cp telegram_bot.service /etc/systemd/system/telegram_bot.service
sudo systemctl daemon-reload
echo "run sudo systemctl start telegram_bot to start service"