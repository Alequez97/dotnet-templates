#!/bin/bash

sudo systemctl stop TelegramBot

git pull
rm -rf /srv/TelegramBot.TelegramBot
mkdir /srv/TelegramBot.TelegramBot
chown root /srv/TelegramBot.TelegramBot
cd ..
dotnet publish -c Release -o /srv/TelegramBot.TelegramBot

sudo cp TelegramBot.service /etc/systemd/system/TelegramBot.service
sudo systemctl daemon-reload
echo "run sudo systemctl start TelegramBot to start service"