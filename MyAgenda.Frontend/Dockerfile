# Build stage
FROM node:24 AS build
WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .
RUN npm run build

# Production stage
FROM nginx:stable-alpine
COPY --from=build /app/dist /usr/share/nginx/html

# Config nginx
COPY default.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
