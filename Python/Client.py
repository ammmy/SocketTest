import socket

s = socket.socket()
host = "127.0.0.1"
port = 3333

s.connect((host, port))
s.send("from Python\n")
while True:
    print host, s.recv(4096)
    s.send("from Python\n")