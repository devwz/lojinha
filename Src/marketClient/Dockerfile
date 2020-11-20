FROM node:14.1.0-alpine as build
WORKDIR /usr/src/app
COPY ["package*.json", "./"]
RUN npm i
COPY . .
RUN npm run build

FROM nginx:1.18.0-alpine
COPY ["nginx.conf", "/etc/nginx/conf.d/default.conf"]
COPY --from=build /usr/src/app/dist/marketClient /usr/share/nginx/html