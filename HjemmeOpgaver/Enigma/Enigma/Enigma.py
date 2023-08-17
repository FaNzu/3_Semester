#operation = 'ENCODE'
operation = 'DECODE'
shift = 4
rotors = ['BDFHJLCPRTXVZNYEIWGAKMUSQO', 'AJDKSIRUXBLHWTMCQGZNPYFVOE', 'EKMFLGDQVZNTOWYHXUSPAIBRCJ']
message = 'KQF'
result = ''
alphabet = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'*3

def caeser_encode(message, shift):
	global alphabet
	result = [alphabet[alphabet.index(letter)+shift+i] for i, letter in enumerate(message)]
	print(result)
	return result

def caeser_decode(messagecoded, shift):
	global alphabet
	result = [alphabet[alphabet.index(letter)-shift-i] for i, letter in enumerate(message)]
	return result



def rotor_func(c: str, rotor: str):
	return rotor[alphabet.index(c)]

def do_rotor(message, rotor):
	res = ''
	for letter in message:
		res += rotor_func(letter, rotor)
	return res

#[abc[cipher.index(c)] for c in 'KLMXYZ']
#['A', 'B', 'C', 'N', 'O', 'P']

def alpabet_func(c:str, rotor:str):
	return alphabet[rotor.index(c)]

def de_do_rotor(coded_message, rotor):
	res='' 
	for letter in coded_message:
		res += alpabet_func(letter, rotor)
		print(letter, res)
	return res

def encode(message, shift):
	message = caeser_encode(message, shift)
	for rotor in rotors:
		message = do_rotor(message, rotor)
	return message
	
def decode(message, shift):
	rotors.reverse()
	print(rotors)
	for rotor in range(len(rotors)-1):
		message = de_do_rotor(message, rotor)
	message = caeser_decode(message, shift)
	return message

def solution():

	if operation == 'ENCODE':
		result = encode(message, shift)
	else:
		result = decode(message, shift)
	print(''.join(result))

solution()