#!/bin/bash

systemctl stop TelegramBotTemplate

git pull
rm -rf /srv/TelegramBotTemplate
mkdir /srv/TelegramBotTemplate
chown root /srv/TelegramBotTemplate
cd ..
dotnet publish -c Release -o /srv/TelegramBotTemplate
cd ./Systemd
cp TelegramBotTemplate.service /etc/systemd/system/TelegramBotTemplate.service
systemctl daemon-reload
echo "run sudo systemctl start TelegramBotTemplate to start service"