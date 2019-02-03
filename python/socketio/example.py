#!/usr/bin/env python3
import socketio

userId = 'HypW9sEVE'
userKey = '463e501e5f66b72987d13770406b7b3f8e11f98f0add9ff1'
topicId = 'rkxsfcsVN4'
namespace = '/socket'

sio = socketio.Client()

@sio.on('connect', namespace=namespace)
def on_connect():
  print('Connected!')
  sio.emit('subscribe', {
    "userId": userId,
    "userKey": userKey,
    "topicId": topicId
  }, namespace=namespace)

@sio.on('event', namespace=namespace)
def on_data(data):
  print('GOT DATA:')
  print(data)

url = "https://socket.ubsub.io"
sio.connect(url, namespaces=[namespace])
