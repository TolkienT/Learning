1.docker拉取镜像
docker pull mongo:latest

2.运行容器
docker run -itd --name mongodb -p 27017:27017 mongo --auth
-p 27017:27017 ：映射容器服务的 27017 端口到宿主机的 27017 端口。外部可以直接通过 宿主机 ip:27017 访问到 mongo 的服务。
--auth：需要密码才能访问容器服务。

3.创建用户
docker exec -it mongodb mongosh admin
db.createUser({ user: "username", pwd: "xxxxxx", roles: [{ role: "rolename", db: "admin" }] })
db.auth('username', 'XXXXXX');