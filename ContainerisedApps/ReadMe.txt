docker images //lists all images on the machine

docker ps //lists all running containers on the machine

docker run //runs an image in a container

docker stop <containerid> //stops the specified container


--------------------------------------
Build and run the Docker image
1/ Open a command prompt and navigate to your project folder.
2/ Use the following commands to build and run your Docker image:
$ docker build -t aspnetapp .
$ docker run -d -p 8080:80 --name myapp aspnetapp

View the web page running from a container

Go to localhost:8080 to access your app in a web browser.
(If you are using the Nano Windows Container and have not updated to the Windows Creator Update there is a bug affecting how Windows 10 talks to Containers via “NAT” (Network Address Translation). You must hit the IP of the container directly. You can get the IP address of your container with the following steps:
Run docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" myapp
Copy the container IP address and paste into your browser. (For example, 172.16.240.197))