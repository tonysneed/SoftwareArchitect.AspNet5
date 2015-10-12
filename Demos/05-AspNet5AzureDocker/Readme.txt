Deploy ASP.NET 5 Apps
to a Linux Virtual Machine with Docker on Azure

1. Create a Linux Virtual Machine with Docker using Visual Studio 2015 Tools for Docker
  - If not a subscriber sign up for a free Azure trial:  `https://portal.azure.com`
  - Install Visual Studio 2015 Tools for Docker
    + This requires Visual Studio 2015
  - Create a new Web project and select an empty ASP.NET 5 template
    + Right-click on the generated project and select **Publish** from the context menu
    + Under Profile, select Docker Containers, then click the New button
    + Enter a unique DNS name, as well as an admin user name and password.
    + Enter a password (or upload an SSH key)
    + Note the full DNS name, for example: `linux-docker.cloudapp.net`
    + Wait for Azure to provision the virtual machine by visiting the Azure portal.

2. Configure the docker command line interface
  - Get basic information from the remote VM, supplying correct host name and port number

    docker --tls -H tcp://linux-docker.cloudapp.net:2376 info

  - Set the docker_host environment variable:

    set docker_host=tcp://linux-docker.cloudapp.net:2376

  - Requesting docker info again: `docker --tls info`
    
3. Execute docker commands to run the console app on the remote VM
  - Run the console app residing on Docker Hub

    docker --tls run -t tonysneed/aspnet5-consoleapp

  - This will print "Hello World" to the console

4. Execute docker commands to run the console app on the remote VM
  - Run the web app residing on Docker Hub, mapping port 80 on the VM to port 5004 on the container

    docker --tls run -t -d -p 80:5004 tonysneed/aspnet5-webapp

  - Show the logs, substituting the number returned by the run command

    docker --tls logs f2de092f14b67590ae4dc08cd3a453a28271de0a8f27e6d80ec356cbc5151d43

  - Show the running containers

    docker --tls ps

  - Open a browser and go to: `http://linux-docker.cloudapp.net`

