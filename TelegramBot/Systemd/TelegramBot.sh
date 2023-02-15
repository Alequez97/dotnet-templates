#!/bin/bash

sudo systemctl stop TelegramBot

git pull
rm -rf /srv/TelegramBot
mkdir /srv/TelegramBot
chown root /srv/TelegramBot
cd ..
dotnet publish -c Release -o /srv/TelegramBot

sudo cp TelegramBot.service /etc/systemd/system/TelegramBot.service
sudo systemctl daemon-reload
echo "run sudo systemctl start TelegramBot to start service"