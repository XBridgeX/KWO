# PACK

KWO用于Websocket传输的json格式

# 🔒 安全

考虑到服务器的安全问题，KWO默认发送加密过的数据包

当然您也可以关闭加密

## 加密格式

 - 取密码大写MD5作为基密码
 - 前16位作为AES_Key
 - 后16位作为AES_IV
 - 使用AES/CBC/PCKS7Padding(PCKS5Padding理论上通用)

```json
{
    "type":"encrypt",
    "params":{
        "mode":"aes_cbc_pck7padding",
        "raw":"加密过的数据包"
    }
}
```

# 🔀 下面是KWO发出的数据包

## 玩家加入服务器

``` json
{
    "type":"pack",
    "cause":"join",
    "params":{
        "sender":"lition",
    }
}
```

## 玩家离开服务器


``` json
{
    "type":"pack",
    "cause":"left",
    "params":{
        "sender":"lition",
    }
}
```

## 玩家聊天


``` json
{
    "type":"pack",
    "cause":"chat",
    "params":{
        "sender":"lition",
        "text":"哼哼 啊啊啊啊啊"
    }
}
```

## 执行命令返回


``` json
{
    "type":"pack",
    "cause":"runcmdfeedback",
    "params":{
        "result":"执行命令返回",
        "id":"执行时传入的id"
    }
}
```

## 服务器开启

``` json
{
    "type":"pack",
    "cause":"start",
    "params":{}
}
```

## 服务器关闭


``` json
{
    "type":"pack",
    "cause":"stop",
    "params":{}
}
```

## 直接发送文本


``` json
{
    "type":"pack",
    "cause":"plantext",
    "params":{
        "text":"哼哼 啊啊啊啊啊啊",
    }
}
```

## 数据包解析失败

``` json
{
    "type":"pack",
    "cause":"decodefailed",
    "params":{
        "msg":"描述文本",
    }
}
```

# 🔀 下面是KWO可接收的数据包


## 向服务器发送文本消息

``` json
{
    "type":"pack",
    "action":"sendtext",
    "params":{
        "text":"要向服务器中发送的文本",
        "id":"此项无用"
    }
}
```

## 执行命令

``` json
{
    "type":"pack",
    "action":"runcmdrequest",
    "params":{
        "cmd":"要向服务器中执行的命令",
        "id":"返回执行结果时需要附带执行id"
    }
}
```

# 💬 websocket操作

您需要实现一个websocket客户端，并到KWO

