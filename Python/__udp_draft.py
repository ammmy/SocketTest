import socket

client = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
client.sendto(b"12345",("127.0.0.1",3333))

data, addr = client.recvfrom(4096)
print(data)

message = "from Python"
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
sock.sendto(message, ("127.0.0.1", 3333))
