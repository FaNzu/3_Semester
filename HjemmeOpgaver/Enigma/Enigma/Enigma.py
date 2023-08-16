import sys
import math

operation = 'ENCODE'
shift = 4
rotors = ['BDFHJLCPRTXVZNYEIWGAKMUSQO', 'AJDKSIRUXBLHWTMCQGZNPYFVOE', 'EKMFLGDQVZNTOWYHXUSPAIBRCJ']

message = 'AAA'
result = ''

def CaeserEncode(message, shift):
	alphabet = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'*3
	result = [alphabet[alphabet.index(letter)+shift+i] for i, letter in enumerate(message)]
	return result

def dorotor(message, rotor):
	#return ''.join(rotor[ord(c) - ord('A')] for c in message)
	temp = ''
	for letter in message:
		temp.join(rotor[ord(letter) - ord('A')])
	return temp


	#alphabet = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
	#for letter in message:
	#	result=[rotor[alphabet.index(letter)]]
	#	print(result)
	#return result

def encode(message, shift, operation):
	message = CaeserEncode(message, shift)
	for rotor in rotors:
		message = dorotor(message, rotor)
	return message
	
def decode():
	pass

if operation == 'ENCODE':
	result = encode(message, shift, operation)
else:
	result = decode(message, shift, operation)

print(''.join(result))
