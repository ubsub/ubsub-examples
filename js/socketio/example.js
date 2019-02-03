const socketio = require('socket.io-client');

const userId = 'HypW9sEVE';
const userKey = '463e501e5f66b72987d13770406b7b3f8e11f98f0add9ff1';
const topicId = 'rkxsfcsVN4';

const url = `https://socket.ubsub.io/socket?userId=${userId}&topicId=${topicId}&userKey=${userKey}`;
const io = socketio(url);
io.on('connect', socket => {
  console.log('Connected!');
  io.on('handshake-error', err => {
    console.log(err);
  });
  io.on('event', data => {
    // data: { topicId: 'rkxsfcsVN4', payload: {} }
    console.log(data);
  });
});
