const WebSocket = require('ws');

const userId = 'HypW9sEVE';
const userKey = '463e501e5f66b72987d13770406b7b3f8e11f98f0add9ff1';
const topicId = 'rkxsfcsVN4';

const url = `wss://socket.ubsub.io/stream?userId=${userId}&topicId=${topicId}&userKey=${userKey}`;

const ws = new WebSocket(url);
ws.on('open', () => {
  console.log('Connected');
});

ws.on('message', (payload) => {
  try {
    const data = JSON.parse(payload);
    console.dir(data);
  } catch (err) {
    console.error(err);
  }
});
