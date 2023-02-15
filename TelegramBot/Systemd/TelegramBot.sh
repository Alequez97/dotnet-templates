#!/bin/bash

sudo systemctl stop TelegramBotTemplate

git pull
rm -rf /srv/TelegramBotTemplate
mkdir /srv/TelegramBotTemplate
chown root /srv/TelegramBotTemplate
cd ..
dotnet publish -c Release -o /srv/TelegramBotTemplate

sudo cp TelegramBotTemplate.service /etc/systemd/system/TelegramBotTemplate.service
sudo systemctl daemon-reload
echo "run sudo systemctl start TelegramBotTemplate to start service"