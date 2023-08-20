from sys import stderr

n = int(input())
q = int(input())
MIME = {}
    
for i in range(n):
    key, value = input().split()
    MIME[key.lower()]=value
    print(MIME, file=stderr, flush=True)
for fn in range(q):
    name=input().lower().split('.')
    ext = name[-1] if len(name) != 1 else None
    print(MIME[ext] if ext in MIME else 'UNKNOWN')