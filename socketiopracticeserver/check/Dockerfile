FROM node:12

WORKDIR /usr/src/app

COPY package*.json ./

RUN npm install

RUN npm install -g pm2

RUN npm install socket.io

COPY . .

EXPOSE 3001

CMD ["pm2-runtime", "start", "./bin/www"]