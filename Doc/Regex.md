# Regex

KWO正则表达式有5种执行方式

|执行模式|执行方式|注意事项|
|join|发送```join```数据包到每个websocket连接|玩家名字即为相应文本|
|left|发送```left``数据包到每个websocket连接|玩家名字即为相应文本|
|chat|发送```left``数据包到每个websocket连接|格式为“玩家名字\|玩家发言文本”|
