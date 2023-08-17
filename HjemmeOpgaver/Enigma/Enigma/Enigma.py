import sys;		import string
operation = 'ENCODE'
shift = 9
rotors = ['BDFHJLCPRTXVZNYEIWGAKMUSQO','AJDKSIRUXBLHWTMCQGZNPYFVOE','EKMFLGDQVZNTOWYHXUSPAIBRCJ']
message='PQSACVVTOISXFXCIAMQEM'
alphabet = string.ascii_uppercase

"""operation = input()
shift = int(input())
rotors=[]
for i in range(3):    rotors.append(input())
message=input()
print(shift, message, file=sys.stderr, flush=True)"""
#input collection from coding game system. if you are going to use it locally, ignore or delete this part.

def caeser_cipher(message, shift, operation):
	if operation == 'ENCODE':
		result = [alphabet[(alphabet.index(letter)+shift+i)%26] for i, letter in enumerate(message)]
	else:
		result = [alphabet[(alphabet.index(letter)-shift-i)%26] for i, letter in enumerate(message)]
	return ''.join(result)

def do_rotor(message, rotor, operation):
	res = ''
	if operation == 'ENCODE':
		for letter in message:
			res += rotor[alphabet.index(letter)]
	else:
		for letter in message:
			res += alphabet[rotor.index(letter)]
	return res

if operation == "ENCODE":
	message = caeser_cipher(message, shift, operation)
	for rotor in rotors:
		message = do_rotor(message, rotor, operation)
else:
	rotors.reverse()
	for rotor in rotors:
		message = do_rotor(message, rotor, operation)
	message = caeser_cipher(message, shift, operation)
print(message)