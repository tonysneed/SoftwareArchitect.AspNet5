Dockerizing an ASP.NET 5 App

This sample demonstrates how to deploy an ASP.NET 5 web app
to a Docker container on a Linux virtual machine.

NOTE: You will first need to create a virtual machine
with Linux Ubuntu 14.04 using virtualization software
such as Parallels, VMWare, Virtual PC, etc.

These instructions can also be found here:
https://github.com/tonysneed/Deploy-AspNet5-Docker

1. After creating a new Linux VM, install Docker
   - Install Docker from its own package source
     > Open a Terminal and execute the following commands, one at a time:
   
  sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 36A1D7869245C8950F966E92D8576A8BA88D21E9
  sudo sh -c "echo deb https://get.docker.com/ubuntu docker main > /etc/apt/sources.list.d/docker.list"
  sudo apt-get update
  sudo apt-get install lxc-docker

   - Verify Docker installation 

  docker --version

2. Eliminate need to prefix docker commands with sudo for root privilges
   
  sudo groupadd docker
  sudo gpasswd -a parallels docker
  sudo service docker restart
  

   - Verify docker root privileges
   
  docker run --help

   - Say hello to Docker:
   
  docker run hello-world

3. Open the Dockerfile present in the web app folder.
   - Note the following content:

	FROM microsoft/aspnet:1.0.0-beta7

	COPY . /app

	WORKDIR /app

	RUN ["dnu", "restore"]

	EXPOSE 5004

	ENTRYPOINT ["dnx", "kestrel"]

4. Copy WebApp folder to the Home directory on the Linux VM

5. From the app directory, build the docker image

	docker build -t webapp .

6. Verify the docker image

	docker images

7. Run the container

	docker run -t -d -p 80:5004 webapp

   - You should get back the container id
   - This will map port 80 on the VM to 5004 on the container

   - Verify that the container is running

	docker ps

8. Open a browser on the Linux VM

	http:localhost

   - You should see the welcome page 
    