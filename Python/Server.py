import socket
from datetime import datetime
from time import sleep

port = 3333

s = socket.socket()
s.bind(('', port))

while True:
    print('listening')
    s.listen(5)
    c, addr = s.accept()
    print('receiving')
    print(c.recv(4096))
    while True:
        print('sending')
        now = datetime.now().strftime("%Y/%m/%d %H:%M:%S")
        try:
            c.send(now)
        except:
            break
        sleep(1)
    c.close()
s.close()