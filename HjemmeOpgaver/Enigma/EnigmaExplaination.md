# Enigma introduction
During my freetime ive found interest in encryption stuff, and a classic one is the enigma problem.
I am taking version which is introduced on [Codinggame](https://www.codingame.com/training/easy/encryptiondecryption-of-enigma-machine "Encryption/Decryption of Enigma Machine"). It is quite simplier than the real thing, but still a good challenge to crack. I suggest you go giving it a try before looking at my explation and solution. 

## The real engima
TBD
# Explanation

## The goal of the game
Our machine will be a basic version of the real thing.

The first step of the encryption is a **caesar shift** of the *message*. Meaning that a simple message of *AAA* the oiutput will be *EFG*

*A + 4 = E*

*A + 4 + 1 = F*

*A + 4 +1 +1 = G*

After the caeser shift, the next step will be to use some rotors delivered to the user. A rotor is a randomized alphabet, which will be used to encrypt the message even further. 

A total of 3 rotors will be used, an example of this could be `BDFHJLCPRTXVZNYEIWGAKMUSQO`. This will be used like a secondary alphabet which we will compare to. 

 Now map *EFG* to first ROTOR such as:
`ABCDEFGHIJKLMNOPQRSTUVWXYZ`
`BDFHJLCPRTXVZNYEIWGAKMUSQO`

So *EFG* becomes ***JLC***, as the letters directly under *EFG*. This is a bit trickerier to program than the caeser. But this was just the first of 3 rotors. 

If the *second ROTOR* is `AJDKSIRUXBLHWTMCQGZNPYFVOE`, we apply the substitution step again thus:

`ABCDEFGHIJKLMNOPQRSTUVWXYZ`
`AJDKSIRUXBLHWTMCQGZNPYFVOE`

So *JLC* becomes ***BHD***

`ABCDEFGHIJKLMNOPQRSTUVWXYZ`
`EKMFLGDQVZNTOWYHXUSPAIBRCJ`

*BHD* becomes ***KQF*** the final answer to *AAA* when it come through the whole encryption

### Caeser Cipher
This is a classic encryption technic, we have to shift the *letter* a certain distance in the alphabet. In the example above, we have to shift it 4 places. And end up *E*, and in this encryption theres a spin on it. We also have to increment the shift with 1 for each *letter* shiftet. So the same *letter* will never be the same.

### Rotor Cipher
This is an encryption technic used masterfully in the enigma machine. And the author of this challange has a rather simple and elegant implemtation of it. 

The basics are that we have a normal alphabet and a rotor. We take our *Caeser* encrypted *message* and find the index of the each letter of the message. We then find the same index of out rotor and the letter in that placement is our Rotor encrypted message.

```
	EFG
ABCDEFGHIJKLMNOPQRSTUVWXYZ
	|||
	vvv
BDFHJLCPRTXVZNYEIWGAKMUSQO
	JLC
```
*Do note that this will be perfomed 3 times total with different rotors.*

## My solution to the problem
Ill be making both a *python* and *C#* solution for this project. As those are both langauges i know. Both will have ups and downs for this. In this **explanation** ill be using *python* as an example. But will include a *C#* section where ill go through any changes needed to be done. 

The input we are reciving is compromised 6 lines. 
- The very first line declares if we are decoding or encoding the message. So the only 2 possible states are ```ENCODE``` or ```DECODE```. 
- The second line is an *integer* that describes how much we have to shift the alpabet in the *Caeser* cipher
- The next 3 lines, are the rotors we are provided. A rotor is defined as an alphabet that has randomized the postion of the letters. As an example these are the 3 rotors used in the introduction.
```
BDFHJLCPRTXVZNYEIWGAKMUSQO
AJDKSIRUXBLHWTMCQGZNPYFVOE
EKMFLGDQVZNTOWYHXUSPAIBRCJ
```
- and the last input we are recieving are the message itself. This could be anything, as long its in the string type. And all letters in the message is in uppercase. Both of these restrictions are from the constraints given to us in the game description. 

### Python code 
The first thing we are going to do, is seperate the *ENCODING* and *DECODING* section of the code. As the things we have to do is in different timelines. 
```
if operation == "ENCODE":
	message = caeser_cipher(message, shift, operation)
	for rotor in rotors:
		message = do_rotor(message, rotor, operation)
else:
	pass
```
Now that we have seperated the 2 sections, we can do the caeser cipher. As that is the first part of the *encoding* the message. As explaned in an earlier section this will shift the letters in the message. 
**CAESER CIPHER**
```
def caeser_cipher(message, shift, operation):
	if operation == 'ENCODE':
		for i, letter in enumerate(message):
			result = [alphabet[(alphabet.index(letter)+shift+i)%26]]
	else:
		for i, letter in enumerate(message):
			result = [alphabet[(alphabet.index(letter)-shift-i)%26]]
	return ''.join(result)
```
Alot of things are happening in this function at a glance. But ill do my best to break it down.

Our inputs are the *message* itself, lets use **'AAA'** as an example. The amount it has to be shifted and lastly the operation we'll be perfoming. 
Because the very next thing we check in a if statement, is which of the operations we'll perfome. *For now lets stick with Encoding*

In my solution to this problem, i have a temporary list for my resuts. This is done as, all the letters will be outputed indivially. And so we'll collect them in a list and return them in a collected string. 

If we digest the *Encoding* line down to its basics, we are perfoming a for loop, for which we do the shift. In this for loop, we are the function *Enumerate*. To both recieve the index and the letter itself from the placement in the *message*. This is very useful, but as ill show in my c# code. It can be done manually.
 
Lets take a closer look at ```[alphabet[(alphabet.index(letter+shift+i)%26]``` and understand what is happening here. Lets understand the index part first, as we'll have to find the index of out letter. We'll search for it with the index function of the string type. Our string is called alphabet, is just a uppercase alphabet. If we use the **AAA** example as before. The very first letter will be **A**, and its index are 1 in the english alphabet.

If we change the code ```[alphabet[(1+shift+i)%26]```, the next thing we can look at is the shift. Ill be using the same example as before, which was integer 4. And lastly we have the extra shift, we had to do for each letter. As we havent done a shift yet it is still 0.

```[alphabet[(1+4+0)%26]``` is our new function. The last bit ```%26``` is a math operation called *modulo*. It returns the remainder, after 2 numbers are divided. As the english alphabet is 26 letters long, we'll use that. What this means in practice, is if we have a number that has an index thats over the length of the alphabet. It'll decrease the number back to be within the range of the alphabet. *Example: 27%26=1*

We finally have our new letter for our encryption. As such we'll have to do this for all letters in the message itself. 

**ROTOR CIPHER**
```
def do_rotor(message, rotor, operation):
	result = ''
	if operation == 'ENCODE':
		for letter in message:
			result += rotor[alphabet.index(letter)]
	else:
		for letter in message:
			result += alphabet[rotor.index(letter)]
	return result
```
Our *rotor* function is really similar to the *Caeser* function. Intead of recieving a number, we are recieving the rotor. Which was the randomized alphabet. Next up we create an empty string, within this scope we can use for store the *encoded* message.
After that we check if we are supposed to *decode* or *encode*. As before, i'll be showing the *encoding* example for now. 

```
for letter in message:
			result += rotor[alphabet.index(letter)]
```
for each letter in our message, we'll exchange the letter. We will agian be using the index function to find the number index of our letter. And replace it with the *rotor* letter with the same index. And add it to the string, on the last place on the string. 

***DECODING CHANGES***
As the decoding part is the oppesite of what, we have just been doing. We'll do the *caeser cipher* and *rotor cipher* in the reversed order. Another consideration is that the rotors, has to be applied in the reversed other too. As such we calls the list ```.reversed()``` function. It simply reverses the order (a,b,c) -> (c,b,a). 

In our *Caeser cipher*, we have to remove the shift we added before. As such we have to minus instead of adding the *shift* and *indexnumber*
```	
This:
(alphabet.index(letter)+shift+i)%26
Becomes:
(alphabet.index(letter)-shift-i)%26
```

in the *rotor function* we have to go from the rotor index to the alphabet index. 
```
This:
result += rotor[alphabet.index(letter)]
Becomes:
result += alphabet[rotor.index(letter)]  
```

## C# code
TBD