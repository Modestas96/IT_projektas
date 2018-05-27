def send():
    import requests
    import json

    channelID = "399455712603799565" # enable dev mode on discord, right-click on the channel, copy ID
    botToken = "Mzk5NDczNjQ4NjA1NTkzNjEx.DTNmeQ.wH7Uc-QR6219VYXC1iwlPPvZtWs"    # get from the bot page. must be a bot, not a discord app

    baseURL = "https://discordapp.com/api/channels/{}/messages".format(channelID)
    headers = { "Authorization":"Bot {}".format(botToken),
                "User-Agent":"myBotThing (http://some.url, v0.1)",
                "Content-Type":"application/json", }

    message = "hello world"

    POSTedJSON =  json.dumps ( {"content":message} )

    r = requests.post(baseURL, headers = headers, data = POSTedJSON)