# Enigma introduction
During my freetime ive found interest in encryption stuff, and a classic one is the enigma problem.
I am taking version which is introduced on [Codinggame](https://www.codingame.com/training/easy/encryptiondecryption-of-enigma-machine "Encryption/Decryption of Enigma Machine"). It is quite simplier than the real thing, but still a good challenge to crack. I suggest you go giving it a try before looking at my explation and solution. 

## The real engima
TBD
# Explanation

## the goal of the game
Our machine will be a basic version of the real thing.

The first step of the encryption is a caesar shift of the *message*. Meaning that a simple message of *AAA* the oiutput will be *EFG*

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

## My solution to the problem
Ill be making both a *python* and *C#* solution for this project. As those are both langauges i know. Both will have ups and downs for this. In this **explanation** ill be using *python* as an example. But will include a *C#* section where ill go through any changes needed to be done. 

First issue to overcome is the *Caeser Cipher* as that is the beginning of encryption. 
